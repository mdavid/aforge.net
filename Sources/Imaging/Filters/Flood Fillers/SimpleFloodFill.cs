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
namespace AForge.Imaging.Filters
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
    /// using <see cref="AForge.Imaging.Filters.SimplePosterization"/> algorithm.</para>
    /// 
    /// <para>The class processes only color 24 or 32 bpp images.</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    /// // create SimpleFloodFill's instance
    /// SimpleFloodFill flood = new SimpleFloodFill( );
    /// Rectangle rect = new Rectangle( 0, 0, 240, 360 );
    /// // flood fill image
    /// flood.ApplyInPlace( image, rect );
    /// </code>
    /// 
    /// <para><b>Initial image:</b></para>
    /// <img src="img/imaging/posterization.png" width="480" height="361" />
    /// <para><b>Result image:</b></para>
    /// <img src="img/imaging/simplefloodfill.png" width="480" height="361" />
    /// </remarks>
    /// 
    /// <seealso cref="AForge.Imaging.Filters.SimplePosterization"/>
    /// 
    public class SimpleFloodFill : BaseInPlacePartialFilter
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

        // private format translation dictionary
        private Dictionary<PixelFormat, PixelFormat> formatTransalations = new Dictionary<PixelFormat, PixelFormat>();

        /// <summary>
        /// Format translations dictionary.
        /// </summary>
        public override Dictionary<PixelFormat, PixelFormat> FormatTransalations
        {
            get { return formatTransalations; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleFloodFill"/> class.
        /// </summary>
        public SimpleFloodFill() 
        {
            // initialize format translation dictionary
            formatTransalations[PixelFormat.Format24bppRgb] = PixelFormat.Format24bppRgb;
            formatTransalations[PixelFormat.Format32bppRgb] = PixelFormat.Format32bppRgb;
            formatTransalations[PixelFormat.Format32bppArgb] = PixelFormat.Format32bppArgb;        
        }

        /// <summary>
        /// Process the filter on the specified image.
        /// </summary>
        /// <param name="image">Source image to flood fill.</param>
        /// <param name="rect">Image rectangle for processing by the filter.</param>
        ///
        protected override unsafe void ProcessFilter(UnmanagedImage image, Rectangle rect)
        {
            //All Colors with their id for the colorTable
            Dictionary<Color, int> colors = new Dictionary<Color, int>();
            int colorId = 0;

            // get pixel size
            int pixelSize = Image.GetPixelFormatSize(image.PixelFormat) / 8;

            int startX = rect.Left;
            int startY = rect.Top;
            int stopX = startX + rect.Width;
            int stopY = startY + rect.Height;
            int offset = image.Stride - rect.Width * pixelSize;

            // do the job, floodfill image
            byte* ptr = (byte*)image.ImageData.ToPointer();

            // allign pointer to the first pixel to process
            ptr += (startY * image.Stride + startX * pixelSize);

            // for each line
            for (int y = startY; y < stopY; y++)
            {
                // for each pixel in line
                for (int x = startX; x < stopX; x++, ptr += pixelSize)
                {
                    Color col = Color.FromArgb(ptr[RGB.R], ptr[RGB.G], ptr[RGB.B]);
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


                    ptr[RGB.R] = colorTable[tempId].R;
                    ptr[RGB.G] = colorTable[tempId].G;
                    ptr[RGB.B] = colorTable[tempId].B;
                }
                ptr += offset;
            }
        }
    }
}
