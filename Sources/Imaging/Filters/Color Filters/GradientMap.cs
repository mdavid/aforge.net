//
// Copyright © André Fiedler, 2013
//

using AForge.Imaging;
using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

/// <summary>
/// GradientMap filter - map a color gradient to the images colors
/// </summary>
/// 
/// <para>Sample usage:</para>
/// <code>
/// // create filter
/// GradientMap filter = new GradientMap( );
/// // set the gradient
/// filter.GradientStart = Color.FromArgb(255, 255, 255, 255);
/// filter.GradientEnd   = Color.FromArgb(200, 43, 26, 1);
/// // apply the filter
/// filter.ApplyInPlace( image );
/// </code>
///
namespace AForge.Imaging.Filters
{
    class GradientMap : BaseInPlacePartialFilter
    {
        public Color GradientStart = Color.FromArgb(255, 255, 255, 255);
        public Color GradientEnd   = Color.FromArgb(255, 0, 0, 0);

        // private format translation dictionary
        private Dictionary<PixelFormat, PixelFormat> formatTranslations = new Dictionary<PixelFormat, PixelFormat>( );

        /// <summary>
        /// Format translations dictionary.
        /// </summary>
        public override Dictionary<PixelFormat, PixelFormat> FormatTranslations
        {
            get { return formatTranslations; }
        }

        /// <summary>   
        /// Initializes a new instance of the <see cref="GradientMap"/> class.
        /// </summary>
        public GradientMap()
        {
            formatTranslations[PixelFormat.Format24bppRgb]  = PixelFormat.Format24bppRgb;
            formatTranslations[PixelFormat.Format32bppRgb]  = PixelFormat.Format32bppRgb;
            formatTranslations[PixelFormat.Format32bppArgb] = PixelFormat.Format32bppArgb;
        }

        /// <summary>
        /// Process the filter on the specified image.
        /// </summary>
        /// 
        /// <param name="image">Source image data.</param>
        /// <param name="rect">Image rectangle for processing by the filter.</param>
        ///
        protected override unsafe void ProcessFilter( UnmanagedImage image, Rectangle rect )
        {
            int pixelSize = ( image.PixelFormat == PixelFormat.Format24bppRgb ) ? 3 : 4;

            int startX  = rect.Left;
            int startY  = rect.Top;
            int stopX   = startX + rect.Width;
            int stopY   = startY + rect.Height;
            int offset  = image.Stride - rect.Width * pixelSize;
            Double luma;
            Double fade;

            // do the job
            byte* ptr = (byte*) image.ImageData.ToPointer( );

            // allign pointer to the first pixel to process
            ptr += ( startY * image.Stride + startX * pixelSize );

            // for each line  
            for ( int y = startY; y < stopY; y++ )
            {
                // for each pixel
                for ( int x = startX; x < stopX; x++, ptr += pixelSize )
                {
                    luma = (0.2126 * ptr[RGB.R] + 0.7152 * ptr[RGB.G] + 0.0722 * ptr[RGB.B]) / 255;
                    fade = (luma * GradientStart.A + (1 - luma) * GradientEnd.A) / 255;

                    ptr[RGB.R] = (byte) Convert.ToInt32(fade * (luma * GradientStart.R + (1 - luma) * GradientEnd.R) + (1 - fade) * ptr[RGB.R]);
                    ptr[RGB.G] = (byte) Convert.ToInt32(fade * (luma * GradientStart.G + (1 - luma) * GradientEnd.G) + (1 - fade) * ptr[RGB.G]);
                    ptr[RGB.B] = (byte) Convert.ToInt32(fade * (luma * GradientStart.B + (1 - luma) * GradientEnd.B) + (1 - fade) * ptr[RGB.B]);
                }
                ptr += offset;
            }
        }
    }
}
