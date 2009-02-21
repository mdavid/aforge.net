// AForge Image Processing Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2005-2009
// andrew.kirillov@gmail.com
//
// Copyright © Frank Nagl, 2009
// admin@franknagl.de
//
namespace AForge.Imaging
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the properties and attributes of a pixel.
    /// </summary>
    public class Pixel
    {
        /// <summary>Gets or sets the color of this pixel.</summary>
        public Color Color {get; set;}
        /// <summary>Gets or sets the index of the image byte array of this pixel.</summary>
        public int Index { get; set; }
        /// <summary>Gets or sets the id of the region, the pixel belongs to.</summary>
        public int RegionId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pixel"/> class.
        /// </summary>
        /// <param name="index">The index of the image byte array of this pixel.</param>
        /// <param name="regionId">The id of the region, the pixel belongs to.</param>
        /// <param name="color">The color of this pixel.</param>
        public Pixel(int index, int regionId, Color color)
        {
            this.Index = index;
            this.RegionId = regionId;
            this.Color = color;
        }
    }

    /// <summary>
    /// Describes a connected region in an image.
    /// </summary>
    public class Region
    {
        /// <summary>Gets or sets the id of the region.</summary>
        public int Id { get; set; }
        ///// <summary>Gets or sets the color of this region.</summary>
        //public Color Color { get; set; }
        /// <summary>
        /// A dirctionary list of all pixels of tthe region. 
        /// The index of a pixel is its key for the dictionary.
        /// </summary>
        public Dictionary<int, Pixel> Pixels = new Dictionary<int, Pixel>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Segment"/> class.
        /// </summary>
        /// <param name="id">The id of the region.</param>
        public Region(int id)
        {
            this.Id = id;
        }
    }

    /// <summary>
    /// Segments a colored image.
    /// </summary>
    /// <remarks><para>The filter performs a region based segmentation in colored image. 
    /// It extracts the colored regions with all corresponding pixels.
    /// Its segment bitmap colors each separate segment using different color.</para>
    /// <para>Sample usage:</para>
    /// <code>
    /// Bitmap myBitmap = new (...);
    /// int threshold = 5;
    /// // create filter
    /// RegionbasedColorSegmentation seg = new RegionbasedColorSegmentation(myBitmap, threshold);
    /// // apply the filter
    /// seg.ExtractSegments();
    /// // create the segment bitmap
    /// seg.CreateSegmentBitmap();
    /// // save the segment bitmap
    /// seg.SegmentBitmap.Save(...);
    /// </code>
    /// <para><b>Initial image:</b></para>
    /// <img src="sampleSeg.jpg" width="320" height="240" />
    /// <para><b>Segment image:</b></para>
    /// <img src="RegionbasedColorSegmentation.jpg" width="320" height="240" />
    /// </remarks>
    public class RegionbasedColorSegmentation
    {
        // Color table for coloring regions
        private static Color[] colorTable = new Color[32]
		{
			Color.Red,		Color.Green,	Color.Blue,			Color.Yellow,
			Color.Violet,	Color.Brown,	Color.Olive,		Color.Cyan,

			Color.Magenta,	Color.Gold,		Color.Indigo,		Color.Ivory,
			Color.HotPink,	Color.DarkRed,	Color.DarkGreen,	Color.DarkBlue,

			Color.DarkSeaGreen,	Color.Gray,	Color.DarkKhaki,	Color.DarkGray,
			Color.LimeGreen, Color.Tomato,	Color.SteelBlue,	Color.SkyBlue,

			Color.Silver,	Color.Salmon,	Color.SaddleBrown,	Color.RosyBrown,
            Color.PowderBlue, Color.Plum,	Color.PapayaWhip,	Color.Orange
		};

        Bitmap origBitmap;
        Rectangle origRect;
        int width;
        int height;
        byte threshold;
        private Dictionary<int, Pixel> AllPixels;

        /// <summary>Gets or sets the segmented bitmap.</summary>
        public Bitmap SegmentBitmap { get; set; }
        /// <summary>Gets or sets the colored segments.</summary>
        public Dictionary<int, Region> Regions { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionbasedColorSegmentation"/> class.
        /// </summary>
        /// <param name="origBitmap">The original bitmap.</param>
        /// <param name="threshold">The threshold for the segmentation.</param>
        public RegionbasedColorSegmentation(Bitmap origBitmap, byte threshold)
        {
            this.origBitmap = origBitmap;
            this.threshold = threshold;
            Init();
        }

        private void Init()
        {
            width = origBitmap.Width;
            height = origBitmap.Height;

            origRect = new Rectangle(0, 0, width, height);

            // check image format
            if (origBitmap.PixelFormat != PixelFormat.Format32bppArgb)
            {
                if (origBitmap.PixelFormat == PixelFormat.Format24bppRgb ||
                    origBitmap.PixelFormat == PixelFormat.Format32bppRgb)
                    origBitmap = AForge.Imaging.Image.Clone(origBitmap, PixelFormat.Format32bppArgb);
                else
                    throw new ArgumentException("Source image can be 32 bpp or 24 bpp color image only");
            }

            Regions = new Dictionary<int, Region>();
            AllPixels = new Dictionary<int, Pixel>();
            // create new image
            SegmentBitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
        }

        /// <summary>
        /// Extracts the color segments of the original bitmap as pixel-connected regions.
        /// </summary>
        public void ExtractSegments()
        {
            // lock source bitmap data
            BitmapData imageData = origBitmap.LockBits(
                origRect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            // image sizes
            int stride = imageData.Stride;
            int pixelSize = 4;//ARGB
            int offset = stride - width * pixelSize;

            // process image
            unsafe
            {
                byte* src = (byte*)imageData.Scan0.ToPointer();
                int pos = 0;               
                Pixel p;
                Region s1;
                Region s2;

                src += stride + pixelSize;//start pointer position -> 2.line, 2.pixel 
                pos = stride + pixelSize;//start pixel position -> 2.line, 2.pixel 
                // for each line
                for (int y = 1; y < height - 1; y++)
                {
                    // for each pixel in line
                    for (int x = 1; x < width - 1; x++, src += pixelSize, pos += pixelSize)
                    {
                        //neighbour pixel positions
                        int leftup = pos - stride - pixelSize;
                        int up = pos - stride;
                        int rightup = pos - stride + pixelSize;
                        int left = pos - pixelSize;
                        int right = pos + pixelSize;
                        int leftdown = pos + stride - pixelSize;
                        int down = pos + stride;
                        int rightdown = pos + stride + pixelSize;
                        //neighbour pointer positions
                        int lu = - stride - pixelSize;
                        int u = - stride;
                        int ru = - stride + pixelSize;
                        int l = - pixelSize;
                        int r = + pixelSize;
                        int ld = + stride - pixelSize;
                        int d = + stride;
                        int rd = + stride + pixelSize;
                        //neighbours with similar color == friends; 
                        //key = pixel position of neighbour
                        //value = TRUE,if a neighbour is already a member of a region
                        Dictionary<int, bool> friends = new Dictionary<int, bool>(8);
                        
                        #region CHECK ALL 8 NEIGHBOURS OF A PIXEL
                        //leftup
                        if (Math.Abs(src[ARGB.R] - src[lu + ARGB.R]) < threshold &&
                            Math.Abs(src[ARGB.G] - src[lu + ARGB.G]) < threshold &&
                            Math.Abs(src[ARGB.B] - src[lu + ARGB.B]) < threshold)
                        {
                            if (AllPixels.TryGetValue(leftup, out p))
                                friends.Add(leftup, true);
                            else
                                friends.Add(leftup, false);
                        }

                        //up
                        if (Math.Abs(src[ARGB.R] - src[u + ARGB.R]) < threshold &&
                            Math.Abs(src[ARGB.G] - src[u + ARGB.G]) < threshold &&
                            Math.Abs(src[ARGB.B] - src[u + ARGB.B]) < threshold)
                        {
                            if (AllPixels.TryGetValue(up, out p))
                                friends.Add(up, true);
                            else
                                friends.Add(up, false);
                        }

                        //rightup
                        if (Math.Abs(src[ARGB.R] - src[ru + ARGB.R]) < threshold &&
                            Math.Abs(src[ARGB.G] - src[ru + ARGB.G]) < threshold &&
                            Math.Abs(src[ARGB.B] - src[ru + ARGB.B]) < threshold)
                        {
                            if (AllPixels.TryGetValue(rightup, out p))
                                friends.Add(rightup, true);
                            else
                                friends.Add(rightup, false);
                        }

                        //left
                        if (Math.Abs(src[ARGB.R] - src[l + ARGB.R]) < threshold &&
                            Math.Abs(src[ARGB.G] - src[l + ARGB.G]) < threshold &&
                            Math.Abs(src[ARGB.B] - src[l + ARGB.B]) < threshold)
                        {
                            if (AllPixels.TryGetValue(left, out p))
                                friends.Add(left, true);
                            else
                                friends.Add(left, false);
                        }

                        //right
                        if (Math.Abs(src[ARGB.R] - src[r + ARGB.R]) < threshold &&
                            Math.Abs(src[ARGB.G] - src[r + ARGB.G]) < threshold &&
                            Math.Abs(src[ARGB.B] - src[r + ARGB.B]) < threshold)
                        {
                            if (AllPixels.TryGetValue(right, out p))
                                friends.Add(right, true);
                            else
                                friends.Add(right, false);
                        }

                        //leftdown
                        if (Math.Abs(src[ARGB.R] - src[ld + ARGB.R]) < threshold &&
                            Math.Abs(src[ARGB.G] - src[ld + ARGB.G]) < threshold &&
                            Math.Abs(src[ARGB.B] - src[ld + ARGB.B]) < threshold)
                        {
                            if (AllPixels.TryGetValue(leftdown, out p))
                                friends.Add(leftdown, true);
                            else
                                friends.Add(leftdown, false);
                        }

                        //down
                        if (Math.Abs(src[ARGB.R] - src[d + ARGB.R]) < threshold &&
                            Math.Abs(src[ARGB.G] - src[d + ARGB.G]) < threshold &&
                            Math.Abs(src[ARGB.B] - src[d + ARGB.B]) < threshold)
                        {
                            if (AllPixels.TryGetValue(down, out p))
                                friends.Add(down, true);
                            else
                                friends.Add(down, false);
                        }

                        //rightdown
                        if (Math.Abs(src[ARGB.R] - src[rd + ARGB.R]) < threshold &&
                            Math.Abs(src[ARGB.G] - src[rd + ARGB.G]) < threshold &&
                            Math.Abs(src[ARGB.B] - src[rd + ARGB.B]) < threshold)
                        {
                            if (AllPixels.TryGetValue(rightdown, out p))
                                friends.Add(rightdown, true);
                            else
                                friends.Add(rightdown, false);
                        }
                        #endregion CHECK ALL 8 NEIGHBOURS OF A PIXEL

                        int tempPos = 0;
                        //Check, if a neighbour is already member of a region
                        if (friends.ContainsValue(true))
                        {
                            // first loop looks for the first neighbour with a region
                            foreach (KeyValuePair<int, bool> friend in friends)
                            {
                                if (friend.Value)
                                {
                                    tempPos = friend.Key;
                                    break;
                                }                          
                            }

                            //Get first neighbour and its region
                            AllPixels.TryGetValue(tempPos, out p);
                            Regions.TryGetValue(p.RegionId, out s1);
                            //Remove first neighbour from friends
                            friends.Remove(tempPos);

                            //Add the original pixel to friends
                            if (AllPixels.TryGetValue(pos, out p))
                                friends.Add(pos, true);
                            else
                                friends.Add(pos, false);

                            // second loop summarize the regions from the pixel and its neighbours
                            foreach (KeyValuePair<int, bool> friend2 in friends)
                            {
                                if (friend2.Value)
                                {
                                    AllPixels.TryGetValue(friend2.Key, out p);
                                    if (p.RegionId != s1.Id)
                                    {
                                        Regions.TryGetValue(p.RegionId, out s2);
                                        //for (int i = 0; i < s2.Pixels.Count; i++)
                                        foreach (KeyValuePair<int, Pixel> px2 in s2.Pixels)
                                        {
                                            AllPixels.Remove(px2.Key);
                                            Pixel tempPx = new Pixel(px2.Value.Index, s1.Id, px2.Value.Color);
                                            AllPixels.Add(tempPx.Index, tempPx);
                                            s1.Pixels.Add(tempPx.Index, tempPx);

                                        }
                                        Regions.Remove(s2.Id);
                                    }
                                }
                                else
                                {
                                    Pixel newPx = new Pixel(friend2.Key, s1.Id, Color.FromArgb(src[friend2.Key - pos + ARGB.A], src[friend2.Key - pos + ARGB.R], src[friend2.Key - pos + ARGB.G], src[friend2.Key - pos + ARGB.B]));
                                    AllPixels.Add(newPx.Index, newPx);
                                    s1.Pixels.Add(newPx.Index, newPx);
                                }
                            }

                            Regions.Remove(s1.Id);
                            Regions.Add(s1.Id, s1);

                        }
                        else // no neighbour is already member of a region
                        {
                            p = new Pixel(pos, pos, Color.FromArgb(src[ARGB.A], src[ARGB.R], src[ARGB.G], src[ARGB.B]));
                            AllPixels.Add(pos, p);

                            s1 = new Region(pos);
                            s1.Pixels.Add(pos, p);

                            foreach (KeyValuePair<int, bool> px in friends)
                            {
                                p = new Pixel(px.Key, pos, Color.FromArgb(src[px.Key - pos + ARGB.A], src[px.Key - pos + ARGB.R], src[px.Key - pos + ARGB.G], src[px.Key - pos + ARGB.B]));
                                AllPixels.Add(px.Key, p);

                                s1.Pixels.Add(px.Key/*pos*/, p);
                            }

                            Regions.Add(pos, s1);
                        }

                    }
                    pos += 2 * pixelSize;
                    src += 2 * pixelSize;
                }
            }
            // unlock destination image
            origBitmap.UnlockBits(imageData);       
        }


        /// <summary>
        /// Creates the segment bitmap. Every region is colored with a separate color from the <see cref="colorTable"/>.
        /// Note: The segment color in the segment bitmap is not the original color of the segment.
        /// </summary>
        public void CreateSegmentBitmap()
        {
            int colNumber = 0;
            // lock destination bitmap data
            BitmapData dstData = SegmentBitmap.LockBits(
                origRect, ImageLockMode.WriteOnly, SegmentBitmap.PixelFormat);

            // image sizes
            int stride = dstData.Stride;
            int pixelSize = 4;//ARGB
            int offset = stride - width * pixelSize;

            // copy image
            unsafe
            {                
                byte* dst = (byte*)dstData.Scan0.ToPointer();

                foreach (KeyValuePair<int, Region>iter in Regions)
                {
                    //colNumber = (colNumber == 32) ? 0 : colNumber;
                    if (colNumber == 32)
                        colNumber = 0;

                    //Segment seg = Segments.GetEnumerator
                    foreach (KeyValuePair<int, Pixel> px in iter.Value.Pixels)
                    {
                        dst[px.Key] = colorTable[colNumber].B;
                        dst[px.Key + 1] = colorTable[colNumber].G;
                        dst[px.Key + 2] = colorTable[colNumber].R;
                        dst[px.Key + 3] = colorTable[colNumber].A;
                    }
                    colNumber++;
                }
            }
            // unlock destination image
            SegmentBitmap.UnlockBits(dstData);
        }
    }
}
