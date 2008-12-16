// AForge Image Processing Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2005-2008
// andrew.kirillov@aforgenet.com
//

namespace AForge.Imaging.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;

    /// <summary>
    /// Homogenity edge detector.
    /// </summary>
    /// 
    /// <remarks><para>The filter finds objects' edges by calculating maximum difference
    /// of processing pixel with neighboring pixels in 8 direction.</para>
    /// 
    /// <para>Suppose 3x3 square element of the source image (x - is currently processed
    /// pixel):
    /// <code lang="none">
    /// 1 2 3
    /// 8 x 4
    /// 7 6 5
    /// </code>
    /// The corresponding pixel of the result image equals to:
    /// <code lang="none">
    /// max( |x-1|, |x-2|, |x-3|, |x-4|, |x-5|, |x-6|, |x-7|, |x-8| )
    /// </code>
    /// </para>
    /// 
    /// <para>The filter accepts 8 bpp grayscale images for processing.</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    /// // create filter
    /// HomogenityEdgeDetector filter = new HomogenityEdgeDetector( );
    /// // apply the filter
    /// filter.ApplyInPlace( image );
    /// </code>
    /// 
    /// <para><b>Initial image:</b></para>
    /// <img src="img/imaging/sample2.jpg" width="320" height="240" />
    /// <para><b>Result image:</b></para>
    /// <img src="img/imaging/homogenity_edges.png" width="320" height="240" />
    /// </remarks>
    /// 
    /// <seealso cref="DifferenceEdgeDetector"/>
    /// 
    public class HomogenityEdgeDetector : BaseUsingCopyPartialFilter
    {
        // private format translation dictionary
        private Dictionary<PixelFormat, PixelFormat> formatTransalations = new Dictionary<PixelFormat, PixelFormat>( );

        /// <summary>
        /// Format translations dictionary.
        /// </summary>
        public override Dictionary<PixelFormat, PixelFormat> FormatTransalations
        {
            get { return formatTransalations; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomogenityEdgeDetector"/> class.
        /// </summary>
        /// 
        public HomogenityEdgeDetector( )
        {
            // initialize format translation dictionary
            formatTransalations[PixelFormat.Format8bppIndexed] = PixelFormat.Format8bppIndexed;
        }

        /// <summary>
        /// Process the filter on the specified image.
        /// </summary>
        /// 
        /// <param name="source">Source image data.</param>
        /// <param name="destination">Destination image data.</param>
        /// <param name="rect">Image rectangle for processing by the filter.</param>
        /// 
        protected override unsafe void ProcessFilter( UnmanagedImage source, UnmanagedImage destination, Rectangle rect )
        {
            // processing start and stop X,Y positions
            int startX  = rect.Left + 1;
            int startY  = rect.Top + 1;
            int stopX   = startX + rect.Width - 2;
            int stopY   = startY + rect.Height - 2;

            int dstStride = destination.Stride;
            int srcStride = source.Stride;

            int dstOffset = dstStride - rect.Width + 2;
            int srcOffset = srcStride - rect.Width + 2;

            int d, max, v;

            // data pointers
            byte* src = (byte*) source.ImageData.ToPointer( );
            byte* dst = (byte*) destination.ImageData.ToPointer( );

            // allign pointers
            src += srcStride * startY + startX;
            dst += dstStride * startY + startX;

            // for each line
            for ( int y = startY; y < stopY; y++ )
            {
                // for each pixel
                for ( int x = startX; x < stopX; x++, src++, dst++ )
                {
                    max = 0;
                    v = *src;

                    // top-left
                    d = v - src[-srcStride - 1];
                    if ( d < 0 )
                        d = -d;
                    if ( d > max )
                        max = d;
                    // top
                    d = v - src[-srcStride];
                    if ( d < 0 )
                        d = -d;
                    if ( d > max )
                        max = d;
                    // top-right
                    d = v - src[-srcStride + 1];
                    if ( d < 0 )
                        d = -d;
                    if ( d > max )
                        max = d;
                    // left
                    d = v - src[-1];
                    if ( d < 0 )
                        d = -d;
                    if ( d > max )
                        max = d;
                    // right
                    d = v - src[1];
                    if ( d < 0 )
                        d = -d;
                    if ( d > max )
                        max = d;
                    // bottom-left
                    d = v - src[srcStride - 1];
                    if ( d < 0 )
                        d = -d;
                    if ( d > max )
                        max = d;
                    // bottom
                    d = v - src[srcStride];
                    if ( d < 0 )
                        d = -d;
                    if ( d > max )
                        max = d;
                    // bottom-right
                    d = v - src[srcStride + 1];
                    if ( d < 0 )
                        d = -d;
                    if ( d > max )
                        max = d;

                    *dst = (byte) max;
                }
                src += srcOffset;
                dst += dstOffset;
            }
        }
    }
}
