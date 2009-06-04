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
    /// Detects segments in an image, which contains pixel with similar color. 
    /// </summary>
    /// <remarks>
    /// <para>The <see>SimplePosterization</see> process should be used before doing segment detection.</para>
    /// 
    /// <para>The class processes 8, 24 and 32 bpp images.</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    /// SimpleColorSegmentsDetector detector = new SimpleColorSegmentsDetector( );
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
    /// <seealso cref="Filters.SimplePosterization"/>
    /// 
    public class SimpleColorSegmentsDetector : ISegmentsDetector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleColorSegmentsDetector"/> class.
        /// </summary>
        public SimpleColorSegmentsDetector() { }

        /// <summary>
        /// Process image looking for segments.
        /// </summary>
        /// <param name="image">Source image to process.</param>
        /// <returns>Returns array of found segments.</returns>
        public Segment[] ProcessImage(Bitmap image)
        {
            return ProcessImage(image, new Rectangle(0, 0, image.Width, image.Height));
        }

        /// <summary>
        /// Process image looking for segments.
        /// </summary>
        /// <param name="image">Source image to process.</param>
        /// <param name="rect">Image rectangle for processing by the detector.</param>
        /// <returns>Returns array of found segments.</returns>
        /// <exception cref="UnsupportedImageFormatException">The source image has incorrect pixel format.</exception>
        public Segment[] ProcessImage(Bitmap image, Rectangle rect)
        {
            // check image format
            if (
                (image.PixelFormat != PixelFormat.Format8bppIndexed) &&
                (image.PixelFormat != PixelFormat.Format24bppRgb) &&
                (image.PixelFormat != PixelFormat.Format32bppRgb) &&
                (image.PixelFormat != PixelFormat.Format32bppArgb)
                )
            {
                throw new UnsupportedImageFormatException("Unsupported pixel format of the source image.");
            }

            // lock source image
            BitmapData imageData = image.LockBits(
                rect, ImageLockMode.ReadOnly, image.PixelFormat);

            Segment[] segments;

            try
            {
                // process the image
                segments = ProcessImage(new UnmanagedImage(imageData), new Rectangle(0, 0, imageData.Width, imageData.Height));
            }
            finally
            {
                // unlock image
                image.UnlockBits(imageData);
            }

            return segments;
        }

        /// <summary>
        /// Process image looking for segments.
        /// </summary>
        /// <param name="imageData">Source image data to process.</param>
        /// <returns>Returns array of found segments.</returns>
        public Segment[] ProcessImage(BitmapData imageData)
        {
            return ProcessImage(new UnmanagedImage(imageData), new Rectangle(0, 0, imageData.Width, imageData.Height));
        }

        /// <summary>
        /// Process image looking for segments.
        /// </summary>
        /// <param name="imageData">Source image data to process.</param>
        /// <param name="rect">Image rectangle for processing by the detector.</param>
        /// <returns>Returns array of found segments.</returns>
        public Segment[] ProcessImage(BitmapData imageData, Rectangle rect)
        {
            return ProcessImage(new UnmanagedImage(imageData), rect);
        }

        /// <summary>
        /// Process image looking for segments.
        /// </summary>
        /// <param name="image">Unmanaged source image to process.</param>
        /// <returns>Returns array of found segments.</returns>
        public Segment[] ProcessImage(UnmanagedImage image)
        {
            return ProcessImage(image, new Rectangle(0, 0, image.Width, image.Height));
        }

        /// <summary>
        /// Process image looking for segments.
        /// </summary>
        /// <param name="image">Unmanged source image to process.</param>
        /// <param name="rect">Image rectangle for processing by the detector.</param>
        /// <returns>Returns array of found segments.</returns>
        public unsafe Segment[] ProcessImage(UnmanagedImage image, Rectangle rect)
        {
            //all regions with their color and list of corresponding pixel
            Dictionary<Color, List<Point>> dict = new Dictionary<Color, List<Point>>();

            // get pixel size
            int pixelSize = System.Drawing.Image.GetPixelFormatSize(image.PixelFormat) / 8;

            int startX = rect.Left;
            int startY = rect.Top;
            int stopX = startX + rect.Width;
            int stopY = startY + rect.Height;
            int offset = image.Stride - rect.Width * pixelSize;

            // do the job
            byte* ptr = (byte*)image.ImageData.ToPointer();

            // allign pointer to the first pixel to process
            ptr += (startY * image.Stride + startX * pixelSize);
            // check image format
            if (image.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                // for each line
                for (int y = startY; y < stopY; y++)
                {
                    // for each pixel in line
                    for (int x = startX; x < stopX; x++, ptr++)
                    {
                        // get regions
                        Color col = Color.FromArgb(*ptr, *ptr, *ptr);
                        FillDictionary(ref dict, col, x, y);
                    }
                    ptr += offset;
                }
            }
            else
            {
                // for each line
                for (int y = startY; y < stopY; y++)
                {
                    // for each pixel in line
                    for (int x = startX; x < stopX; x++, ptr += pixelSize)
                    {
                        // get regions
                        Color col = Color.FromArgb(ptr[RGB.R], ptr[RGB.G], ptr[RGB.B]);
                        FillDictionary(ref dict, col, x, y);
                    }
                    ptr += offset;
                }
            }

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
            dict.Clear();

            return segments;
        }

        private static void FillDictionary(ref Dictionary<Color, List<Point>> dict, Color col, int x, int y)
        {
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
    }
}
