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

    /// <summary>
    /// Contains methods to process 32-bit ARGB images.
    /// </summary>
    public static class ARGB
    {
        /// <summary>Color channel <c>blue</c></summary>
        public const short B = 0;
        /// <summary>Color channel <c>green</c></summary>
        public const short G = 1;
        /// <summary>Color channel <c>red</c></summary>
        public const short R = 2;
        /// <summary>Transparence channel <c>alpha</c></summary>
        public const short A = 3;

        /// <summary>
        /// Calculates the x and y coordinate of the pixel from the 
        /// index of the one-dimensional byte array, which represents the image.
        /// </summary>
        /// <param name="index">The index of the one-dimensional byte array.</param>
        /// <param name="stride">The stride of the image.</param>
        /// <param name="channel">The color channel.</param>
        /// <returns></returns>
        public static System.Drawing.Point GetPoint(int index, int stride, int channel)
        {
            int y = (index - channel) / stride;
            int x = index - channel - y * stride;
            return new System.Drawing.Point(x, y);
        }

        /// <summary>
        /// Calculates the index of a pixel from its x and y coordinates.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="stride">The stride of the image.</param>
        /// <param name="channel">The color channel.</param>
        /// <returns></returns>
        public static int GetIndex(int x, int y, int stride, int channel)
        {
            int index = y * stride + x + channel;
            return index;
        }

        /// <summary>
        /// Creates a grayscale image as  a 32 bit-ARGB bitmap.
        /// </summary>
        /// <param name="value">The value of the RGB channels.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        public static Bitmap GrayColorBitmap(byte value, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Rectangle rectangle = new Rectangle(0, 0, width, height);
            // lock source image
            BitmapData imageData = bitmap.LockBits(rectangle,
                                                 ImageLockMode.ReadWrite,
                                                 bitmap.PixelFormat);

            //Bitmap width * 4 (for ARGB per pixel)
            int stride = imageData.Stride;
            // Get the address of the first line.  
            IntPtr scan0 = imageData.Scan0;

            //int offset = stride - w;//No offset in ARGB images
            int arraySize = stride * imageData.Height;
            // Declare an array to hold the bytes of the bitmap
            byte[] values = new byte[arraySize];

            // Copy the values into the array.
            System.Runtime.InteropServices.Marshal.Copy(scan0, values, 0, arraySize);

            for (int i = 0; i < arraySize; i += 4)
            {
                values[i + ARGB.A] = 255;
                values[i + ARGB.R] = value;
                values[i + ARGB.G] = value;
                values[i + ARGB.B] = value;
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(values, 0, scan0, arraySize);

            // unlock image
            bitmap.UnlockBits(imageData);

            return bitmap;
        }
    }
}
