// AForge Image Processing Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2005-2008
// andrew.kirillov@gmail.com
//

namespace AForge.Imaging
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    /// <summary>
    /// Some internal tools of the Imaging library.
    /// </summary>
    internal class Tools
    {
        // private constructor to avoid instances of the class
        private Tools( ) { }

        /// <summary>
        /// Get number of bytes required for each pixel in the specified format.
        /// </summary>
        /// 
        /// <param name="pixelFormat">Pixel format to get number of bytes for.</param>
        /// 
        /// <returns>Returns required bytes per pixel.</returns>
        /// 
        public static int GetBytesPerPixel( PixelFormat pixelFormat )
        {
            int pixelSize = 0;

            switch ( pixelFormat )
            {
                case PixelFormat.Format8bppIndexed: // 8 bpp grayscale
                    pixelSize = 1;
                    break;
                case PixelFormat.Format16bppGrayScale:
                    pixelSize = 2;
                    break;
                case PixelFormat.Format24bppRgb:
                    pixelSize = 3;
                    break;
                case PixelFormat.Format32bppArgb:
                    pixelSize = 4;
                    break;
                case PixelFormat.Format48bppRgb:
                    pixelSize = 6;
                    break;
                case PixelFormat.Format64bppArgb:
                    pixelSize = 8;
                    break;
            }

            return pixelSize;
        }
    }
}
