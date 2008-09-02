// AForge Image Processing Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2005-2008
// andrew.kirillov@gmail.com
//

namespace AForge.Imaging.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;

    /// <summary>
    /// Threshold binarization.
    /// </summary>
    /// 
    /// <remarks><para>The filter does image binarization using specified threshold value. All pixels
    /// with intensities equal or higher than threshold value are converted to white pixels. All other
    /// pixels with intensities below threshold value are converted to black pixels.</para>
    /// <para>Sample usage:</para>
    /// <code>
    /// // create filter
    /// Threshold filter = new Threshold( 100 );
    /// // apply the filter
    /// filter.ApplyInPlace( image );
    /// </code>
    /// <para><b>Initial image:</b></para>
    /// <img src="grayscale.jpg" width="480" height="361" />
    /// <para><b>Result image:</b></para>
    /// <img src="threshold.jpg" width="480" height="361" />
    /// </remarks>
    /// 
    public class Threshold : BaseInPlacePartialFilter
    {
        /// <summary>
        /// Threshold value.
        /// </summary>
        protected byte threshold = 128;

        private List<PixelFormat> supportedFormats = new List<PixelFormat>( );

        protected override List<PixelFormat> SupportedFormats
        {
            get
            {
                return supportedFormats;
            }
        }

        /// <summary>
        /// Threshold value.
        /// </summary>
        /// 
        /// <remarks>Default value is 128.</remarks>
        /// 
        public byte ThresholdValue
        {
            get { return threshold; }
            set { threshold = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Threshold"/> class.
        /// </summary>
        /// 
        public Threshold( )
        {
            supportedFormats.Add( PixelFormat.Format8bppIndexed );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Threshold"/> class.
        /// </summary>
        /// 
        /// <param name="threshold">Threshold value.</param>
        /// 
        public Threshold( byte threshold )
            : this( )
        {
            this.threshold = threshold;
        }

        /// <summary>
        /// Process the filter on the specified image.
        /// </summary>
        /// 
        /// <param name="image">Image data.</param>
        /// <param name="rect">Image rectangle for processing by the filter.</param>
        /// 
        protected override unsafe void ProcessFilter( UnmanagedImage image, Rectangle rect )
        {
            int startX  = rect.Left;
            int startY  = rect.Top;
            int stopX   = startX + rect.Width;
            int stopY   = startY + rect.Height;
            int offset  = image.Stride - rect.Width;

            // do the job
            byte* ptr = (byte*) image.ImageData.ToPointer( );

            // allign pointer to the first pixel to process
            ptr += ( startY * image.Stride + startX );

            // for each line	
            for ( int y = startY; y < stopY; y++ )
            {
                // for each pixel
                for ( int x = startX; x < stopX; x++, ptr++ )
                {
                    *ptr = (byte) ( ( *ptr >= threshold ) ? 255 : 0 );
                }
                ptr += offset;
            }
        }
    }
}
