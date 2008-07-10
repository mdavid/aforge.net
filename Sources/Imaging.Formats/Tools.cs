// AForge Image Formats Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2005-2008
// andrew.kirillov@gmail.com
//

namespace AForge.Imaging.Formats
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    /// <summary>
    /// Set of tools used internally in AForge.Imaging.Formats library.
    /// </summary>
    internal class Tools
    {
        /// <summary>
        /// Create and initialize new grayscale image.
        /// </summary>
        /// 
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height.</param>
        /// 
        /// <returns>Returns new created grayscale image.</returns>
        /// 
        /// <remarks><para>AForge.Imaging.Image.CreateGrayscaleImage() function
        /// could be used instead, which does the some. But it was not used to get
        /// rid of dependency on AForge.Imaing library.</para></remarks>
        /// 
        public static Bitmap CreateGrayscaleImage( int width, int height )
        {
            // create new image
            Bitmap image = new Bitmap( width, height, PixelFormat.Format8bppIndexed );
            // get palette
            ColorPalette cp = image.Palette;
            // init palette with grayscale color
            for ( int i = 0; i < 256; i++ )
            {
                cp.Entries[i] = Color.FromArgb( i, i, i );
            }
            // set palette back
            image.Palette = cp;
            // return new image
            return image;
        }
    }
}
