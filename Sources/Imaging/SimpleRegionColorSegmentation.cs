// AForge Image Processing Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Andrew Kirillov, 2005-2009
// andrew.kirillov@aforgenet.com
//
// Copyright © Frank Nagl, 2008-2009
// admin@franknagl.de
//
namespace AForge.Imaging
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Segments a colored image into regions, which contains pixel with similar color.
    /// </summary>
    /// <remarks>Combines the SimpleColorSegmentation and the SimpleFloodfill classes, 
    /// additional collecting regions</remarks>
    public class SimpleRegionColorSegmentation
    {
        private struct RGB
        {
            /// <summary>Color channel <c>blue</c></summary>
            public const short B = 0;
            /// <summary>Color channel <c>green</c></summary>
            public const short G = 1;
            /// <summary>Color channel <c>red</c></summary>
            public const short R = 2;
        }

        private const byte ColNumber = 32;
        // Color table for coloring regions
        private static Color[] colorTable = new Color[32]
        {
            Color.Red,		Color.Green,	Color.Blue,			Color.Yellow,
            Color.Violet,	Color.Brown,	Color.Olive,		Color.Cyan,

            Color.Aquamarine,	Color.Gold,		Color.Indigo,		Color.Ivory,
            Color.Azure,	Color.DarkRed,	Color.DarkGreen,	Color.DarkBlue,

            Color.DarkSeaGreen,	Color.Gray,	Color.DarkKhaki,	Color.DarkGray,
            Color.LimeGreen, Color.Tomato,	Color.SteelBlue,	Color.SkyBlue,

            Color.Silver,	Color.Salmon,	Color.SaddleBrown,	Color.RosyBrown,
            Color.PowderBlue, Color.Plum,	Color.PapayaWhip,	Color.Orange
        };

        byte threshold = 90;
        /// <summary>
        /// Gets or sets the threshold for the segmentation. Default value: 90.
        /// </summary>
        /// <value>The threshold value.</value>
        public byte Threshold
        {
            get { return threshold; }
            set { threshold = value; }
        }

        /// <summary>All regions with their color and list of corresponding pixel.</summary>
        public Dictionary<Color, List<Pixel>> Regions = new Dictionary<Color, List<Pixel>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleRegionColorSegmentation"/> class.
        /// </summary>
        public SimpleRegionColorSegmentation() { }

        /// <summary>
        /// Extracts the color segments of the original bitmap as pixel-connected regions.
        /// </summary>
        /// <param name="image">The image to process.</param>
        /// <param name="floodfill">if set to <c>true</c> the color regions will be floodfilled.</param>
        public void ProcessImage(Bitmap image, bool floodfill)
        {
            // check image format
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
                throw new ArgumentException("Source image can be color (24 bpp) image only");

            int w = image.Width;
            int h = image.Height;
            Rectangle rect = new Rectangle(0, 0, w, h);

            // lock source bitmap data
            BitmapData imageData = image.LockBits(
                rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            byte colorId = 0; 

            // process image
            unsafe
            {
                byte* src = (byte*)imageData.Scan0.ToPointer();
                // for each line
                for (int y = 0; y < h - 1; y++)
                {
                    // for each pixel in line
                    for (int x = 0; x < w; x++, src += 3)
                    {
                        src[RGB.R] = (byte)((src[RGB.R] / threshold) * threshold);
                        src[RGB.G] = (byte)((src[RGB.G] / threshold) * threshold);
                        src[RGB.B] = (byte)((src[RGB.B] / threshold) * threshold);

                        //Get regions and floodfill them
                        Color col = Color.FromArgb(src[RGB.R], src[RGB.G], src[RGB.B]);
                        List<Pixel> list;
                        int tempId;

                        if (Regions.ContainsKey(col))
                        {
                            Regions.TryGetValue(col, out list);
                            Regions.Remove(col);
                            tempId = list[0].ColorId;
                        }
                        else
                        {
                            colorId++;
                            if (colorId == ColNumber)
                                colorId = 0;
                            list = new List<Pixel>();
                            tempId = colorId;
                        }

                        list.Add(new Pixel(x, y, tempId));
                        Regions.Add(col, list);
                        if (floodfill)
                        {
                            src[RGB.R] = colorTable[tempId].R;
                            src[RGB.G] = colorTable[tempId].G;
                            src[RGB.B] = colorTable[tempId].B;
                        }
                    }
                }
            }
            // unlock destination image
            image.UnlockBits(imageData);
        }
    }

    /// <summary>
    /// Represents a pixel with its coordinates and its color id in 
    /// the <paramref name="SimpleRegionColorSegmentation.ColorTable"/>.
    /// </summary>
    public struct Pixel
    {
        /// <summary>The x-coordinate of the pixel.</summary>
        public int X;
        /// <summary>The y-coordinate of the pixel.</summary>
        public int Y;
        /// <summary>The color id for the <paramref name="SimpleRegionColorSegmentation.ColorTable"/>, 
        /// when floodfilling the image.</summary>
        public int ColorId;

        /// <summary>
        /// Initializes a new instance of the <see cref="Pixel"/> class.
        /// </summary>
        /// <param name="x">The x-vector.</param>
        /// <param name="y">The y-vector.</param>
        /// <param name="colorId">The color id for the <paramref name="SimpleRegionColorSegmentation.ColorTable"/>, 
        /// when floodfilling the image</param>
        public Pixel(int x, int y, int colorId)
        {
            this.X = x;
            this.Y = y;
            this.ColorId = colorId;
        }
    }
}
