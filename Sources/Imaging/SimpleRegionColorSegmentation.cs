// AForge Image Processing Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Andrew Kirillov, 2005-2009
// andrew.kirillov@aforgenet.com
//
// Copyright © Frank Nagl, 2008-2009
// admin@franknagl.de
// www.franknagl.de
//
namespace AForge.Imaging
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Segments and extracts a colored image into regions, which contains pixel with similar color. 
    /// </summary>
    /// <remarks>
    /// <para>The <see>Posterization</see> process should be used before doing segmentation.</para>
    /// 
    /// <para>The class processes only color 24 bpp images.</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    /// SimpleRegionColorSegmentation segmentation = new SimpleRegionColorSegmentation( );
    /// Segment[] segments = segmentation.ProcessImage( image );
    /// // process segments
    /// foreach (Segment seg in segments)
    /// {
    ///     Color col = seg.Color;
    ///     Point[] pixelList = seg.Pixel;
    ///     // process all pixel of segment
    ///     foreach (Point px in pixelList)
    ///     {
    ///         // ...
    ///     }
    /// }
    /// </code>
    /// </remarks>
    /// 
    /// <seealso cref="Posterization"/>
    /// 
    public class SimpleRegionColorSegmentation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleRegionColorSegmentation"/> class.
        /// </summary>
        public SimpleRegionColorSegmentation() { }

        /// <summary>
        /// Segments the image.
        /// </summary>
        /// <param name="image">Source image to process.</param>
        /// <returns>Returns array of found segments.</returns>
        /// <exception cref="UnsupportedImageFormatException">Source image can be color (24 bpp) image only.</exception>
        public Segment[] ProcessImage(Bitmap image)
        {
            // check image format
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
                throw new ArgumentException("Source image can be color (24 bpp) image only.");

            //all regions with their color and list of corresponding pixel
            Dictionary<Color, List<Point>> dict = new Dictionary<Color, List<Point>>();

            int w = image.Width;
            int h = image.Height;
            Rectangle rect = new Rectangle(0, 0, w, h);

            // lock source bitmap data
            BitmapData imageData = image.LockBits(
                rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int offset = imageData.Stride - w * 3;

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
                        // get regions
                        Color col = Color.FromArgb(src[RGB.R], src[RGB.G], src[RGB.B]);
                        List<Point> list;

                        if (dict.ContainsKey(col))
                        {
                            dict.TryGetValue(col, out list);
                            dict.Remove(col);
                        }
                        else
                        {
                            list = new List<Point>();
                        }

                        list.Add(new Point(x, y));
                        dict.Add(col, list);
                    }
                    src += offset;
                }
            }
            // unlock destination image
            image.UnlockBits(imageData);

            // copy dictionary to array
            Segment[] segments = new Segment[dict.Count];
            int index = 0;
            foreach (KeyValuePair<Color, List<Point>> seg in dict)
            {
                Point[] pxList = new Point[seg.Value.Count];
                seg.Value.CopyTo(pxList);
                segments[index] = new Segment(seg.Key, pxList);                
                index++;
            }

            return segments;
        }
    }

    /// <summary>
    /// Contains color and array of all pixel of segment.
    /// </summary>
    public struct Segment
    {
        /// <summary>Color of segment.</summary>
        public Color Color;
        /// <summary>Array with coordinates of all pixel of segment.</summary>
        public Point[] Pixel;

        /// <summary>
        /// Initializes a new instance of the <see cref="Segment"/> struct.
        /// </summary>
        /// <param name="color">The color of segment.</param>
        /// <param name="pixel">All pixel of segment.</param>
        public Segment(Color color, Point[] pixel)
        {
            this.Color = color;
            this.Pixel = pixel;
        }
    }
}
