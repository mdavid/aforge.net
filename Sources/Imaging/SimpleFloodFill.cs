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
    /// Flood fills the segments of a colored image.
    /// </summary>
    /// 
    /// <remarks><para>The class implements the flood fill process of a colored image.
    /// Flood filling is an algorithm which fills a particular bounded area with color.</para>
    /// 
    /// <para>The flood fill process should be used after 
    /// using <see cref="Posterization"/> algorithm.</para>
    /// 
    /// <para>The class processes only color 24 bpp images.</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    /// // create SimpleFloodFill's instance
    /// SimpleFloodFill flood = new SimpleFloodFill( );
    /// // flood fill image
    /// flood.ProcessImage( image );
    /// </code>
    /// 
    /// <para><b>Initial image:</b></para>
    /// <img src="img/imaging/posterization.png" width="480" height="361" />
    /// <para><b>Result image:</b></para>
    /// <img src="img/imaging/simplefloodfill.png" width="480" height="361" />
    /// </remarks>
    /// 
    /// <seealso cref="Posterization"/>
    /// 
    public class SimpleFloodFill
    {
        private const int ColNumber = 32;
        // Color table for coloring regions
        private static Color[] colorTable = new Color[ColNumber]
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

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleFloodFill"/> class.
        /// </summary>
        public SimpleFloodFill() { }

        /// <summary>
        /// Do the flood filling process.
        /// </summary>
        /// <param name="image">Source image to flood fill.</param>
        /// <exception cref="UnsupportedImageFormatException">Source image can be color (24 bpp) image only.</exception>
        /// 
        public void ProcessImage(Bitmap image)
        {
            // check image format
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                throw new UnsupportedImageFormatException("Source image can be color (24 bpp) image only.");
            }

            int w = image.Width;
            int h = image.Height;
            Rectangle rect = new Rectangle(0, 0, w, h);
            //All Colors with their id for the colorTable
            Dictionary<Color, int> colors = new Dictionary<Color, int>();

            // lock source bitmap data
            BitmapData imageData = image.LockBits(
                rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int offset = imageData.Stride - w * 3;
            int colorId = 0;         

            // floodfill image
            unsafe
            {
                byte* src = (byte*)imageData.Scan0.ToPointer();

                // for each line
                for (int y = 0; y < h - 1; y++)
                {
                    // for each pixel in line
                    for (int x = 0; x < w; x++, src += 3)
                    {
                        Color col = Color.FromArgb(src[RGB.R], src[RGB.G], src[RGB.B]);
                        int tempId;

                        if (colors.ContainsKey(col))
                        {
                            colors.TryGetValue(col, out tempId);
                        }
                        else
                        {
                            colorId++;
                            if (colorId == ColNumber)
                                colorId = 0;
                            tempId = colorId;
                            colors.Add(col, tempId);
                        }

                        
                        src[RGB.R] = colorTable[tempId].R;
                        src[RGB.G] = colorTable[tempId].G;
                        src[RGB.B] = colorTable[tempId].B;
                    }
                    src += offset;
                }
            }

            // unlock destination image
            image.UnlockBits(imageData);
        }
    }
}
