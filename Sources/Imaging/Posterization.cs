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
    /// Posterizates a colored image.
    /// </summary>
    /// 
    /// <remarks><para>The class implements the posterization of a colored image.
    /// Posterization is a process in photograph development which converts normal 
    /// photographs into an image consisting of distinct, but flat, areas of different 
    /// tones or colors.</para>
    /// 
    /// <para>The posterization process should be used before 
    /// using <see cref="SimpleFloodFill"/> or <see cref="SimpleRegionColorSegmentation"/> algorithms.</para>
    /// 
    /// <para>The class processes only color 24 bpp images.</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    /// // create Posterization's instance
    /// Posterization poster = new Posterization( );
    /// //set threshold
    /// poster.Threshold = 50;
    /// // posterizate image
    /// poster.ProcessImage( image );
    /// </code>
    /// 
    /// <para><b>Initial image:</b></para>
    /// <img src="img/imaging/sample1.jpg" width="480" height="361" />
    /// <para><b>Result image:</b></para>
    /// <img src="img/imaging/posterization.png" width="480" height="361" />
    /// </remarks>
    /// 
    /// <seealso cref="SimpleFloodFill"/>
    /// <seealso cref="SimpleRegionColorSegmentation"/>
    /// 
    public class Posterization
    {
        byte threshold = 90;
        /// <summary>
        /// Gets or sets the threshold for the posterization process.
        /// </summary>
        /// <remarks>Default value: 90</remarks>
        /// <value>The threshold value for the posterization process.</value>
        public byte Threshold
        {
            get { return threshold; }
            set { threshold = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Posterization"/> class.
        /// </summary>
        public Posterization() { }

        /// <summary>
        /// Posterizate image.
        /// </summary>
        /// <param name="image">Source image to posterizate.</param>
        /// <exception cref="UnsupportedImageFormatException">Source image can be color (24 bpp) image only.</exception>
        /// 
        public void ProcessImage(Bitmap image)
        {
            // check image format
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
                throw new UnsupportedImageFormatException("Source image can be color (24 bpp) image only.");
            
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
                for (int y = 0; y < h; y++)
                {
                    // for each pixel in line
                    for (int x = 0; x < w; x++, src += 3)
                    {
                        src[RGB.R] = (byte)((src[RGB.R] / threshold) * threshold);
                        src[RGB.G] = (byte)((src[RGB.G] / threshold) * threshold);
                        src[RGB.B] = (byte)((src[RGB.B] / threshold) * threshold);
                    }
                    src += offset;
                }
            }
            // unlock destination image
            image.UnlockBits(imageData);
        }
    }
}
