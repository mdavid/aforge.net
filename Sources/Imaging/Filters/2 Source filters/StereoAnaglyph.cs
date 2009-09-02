// AForge Image Processing Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Andrew Kirillov, 2005-2009
// andrew.kirillov@aforgenet.com

namespace AForge.Imaging.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class StereoAnaglyph : BaseInPlaceFilter2
    {
        public enum Type
        {
            TrueAnaglyph,
            GrayAnaglyph,
            ColorAnaglyph,
            HalfColorAnaglyph,
            OptimizedAnaglyph
        }

        private Type anaglyphType = Type.ColorAnaglyph;


        public Type AnaglyphType
        {
            get { return anaglyphType; }
            set { anaglyphType = value; }
        }


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
        /// Initializes a new instance of the <see cref="StereoAnaglyph"/> class.
        /// </summary>
        public StereoAnaglyph( )
        {
            formatTransalations[PixelFormat.Format24bppRgb] = PixelFormat.Format24bppRgb;
        }

        /// <summary>
        /// Process the filter on the specified image.
        /// </summary>
        /// 
        /// <param name="image">Source image data.</param>
        /// <param name="overlay">Overlay image data.</param>
        ///
        protected override unsafe void ProcessFilter( UnmanagedImage image, UnmanagedImage overlay )
        {
            // get image dimension
            int width  = image.Width;
            int height = image.Height;

            // initialize other variables
            int offset    = image.Stride - width * 3;
            int ovrOffset = overlay.Stride - width * 3;

            // do the job
            byte * ptr = (byte*) image.ImageData.ToPointer( );
            byte * ovr = (byte*) overlay.ImageData.ToPointer( );

            switch ( anaglyphType )
            {
                case Type.TrueAnaglyph:
                    // for each line
                    for ( int y = 0; y < height; y++ )
                    {
                        // for each pixel
                        for ( int x = 0; x < width; x++, ptr += 3, ovr += 3 )
                        {
                            ptr[RGB.R] = (byte) ( ptr[RGB.R] * 0.299 + ptr[RGB.G] * 0.587 + ptr[RGB.B] * 0.114 );
                            ptr[RGB.G] = 0;
                            ptr[RGB.B] = (byte) ( ovr[RGB.R] * 0.299 + ovr[RGB.G] * 0.587 + ovr[RGB.B] * 0.114 );
                        }
                        ptr += offset;
                        ovr += ovrOffset;
                    }
                    break;

                case Type.GrayAnaglyph:
                    // for each line
                    for ( int y = 0; y < height; y++ )
                    {
                        // for each pixel
                        for ( int x = 0; x < width; x++, ptr += 3, ovr += 3 )
                        {
                            ptr[RGB.R] = (byte) ( ptr[RGB.R] * 0.299 + ptr[RGB.G] * 0.587 + ptr[RGB.B] * 0.114 );
                            ptr[RGB.G] = (byte) ( ovr[RGB.R] * 0.299 + ovr[RGB.G] * 0.587 + ovr[RGB.B] * 0.114 );
                            ptr[RGB.B] = ptr[RGB.G];
                        }
                        ptr += offset;
                        ovr += ovrOffset;
                    }
                    break;
                
                case Type.ColorAnaglyph:
                    // for each line
                    for ( int y = 0; y < height; y++ )
                    {
                        // for each pixel
                        for ( int x = 0; x < width; x++, ptr += 3, ovr += 3 )
                        {
                            // keep Red as it is and take only Green and Blue from the second image
                            ptr[RGB.G] = ovr[RGB.G];
                            ptr[RGB.B] = ovr[RGB.B];
                        }
                        ptr += offset;
                        ovr += ovrOffset;
                    }
                    break;

                case Type.HalfColorAnaglyph:
                    // for each line
                    for ( int y = 0; y < height; y++ )
                    {
                        // for each pixel
                        for ( int x = 0; x < width; x++, ptr += 3, ovr += 3 )
                        {
                            ptr[RGB.R] = (byte) ( ptr[RGB.R] * 0.299 + ptr[RGB.G] * 0.587 + ptr[RGB.B] * 0.114 );
                            ptr[RGB.G] = ovr[RGB.G];
                            ptr[RGB.B] = ovr[RGB.B];
                        }
                        ptr += offset;
                        ovr += ovrOffset;
                    }
                    break;

                case Type.OptimizedAnaglyph:
                    // for each line
                    for ( int y = 0; y < height; y++ )
                    {
                        // for each pixel
                        for ( int x = 0; x < width; x++, ptr += 3, ovr += 3 )
                        {
                            ptr[RGB.R] = (byte) ( ptr[RGB.G] * 0.7 + ptr[RGB.B] * 0.3 );
                            ptr[RGB.G] = ovr[RGB.G];
                            ptr[RGB.B] = ovr[RGB.B];
                        }
                        ptr += offset;
                        ovr += ovrOffset;
                    }
                    break;
            }
        }
    }
}
