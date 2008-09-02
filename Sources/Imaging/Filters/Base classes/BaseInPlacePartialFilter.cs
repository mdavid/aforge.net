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

    public abstract class BaseInPlacePartialFilter : IFilter, IInPlaceFilter, IInPlacePartialFilter
    {
        protected abstract List<PixelFormat> SupportedFormats { get; }

        public Bitmap Apply( Bitmap image )
        {
            // lock source bitmap data
            BitmapData srcData = image.LockBits(
                new Rectangle( 0, 0, image.Width, image.Height ),
                ImageLockMode.ReadOnly, image.PixelFormat );

            Bitmap dstImage = null;

            try
            {
                // apply the filter
                dstImage = Apply( srcData );
            }
            finally
            {
                // unlock source image
                image.UnlockBits( srcData );
            }

            return dstImage;
        }

        public Bitmap Apply( BitmapData imageData )
        {
            // destination image format
            PixelFormat dstPixelFormat = imageData.PixelFormat;

            // check pixel format of the source image
            CheckSourceFormat( dstPixelFormat );

            // get image dimension
            int width  = imageData.Width;
            int height = imageData.Height;

            // create new image of required format
            Bitmap dstImage = ( dstPixelFormat == PixelFormat.Format8bppIndexed ) ?
                AForge.Imaging.Image.CreateGrayscaleImage( width, height ) :
                new Bitmap( width, height, dstPixelFormat );

            // lock destination bitmap data
            BitmapData dstData = dstImage.LockBits(
                new Rectangle( 0, 0, width, height ),
                ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed );

            // copy image
            AForge.SystemTools.CopyUnmanagedMemory( dstData.Scan0, imageData.Scan0, imageData.Stride * height );

            // process the filter
            ProcessFilter( new UnmanagedImage( dstData ), new Rectangle( 0, 0, width, height ) );

            // unlock destination images
            dstImage.UnlockBits( dstData );

            return dstImage;
        }

        public UnmanagedImage Apply( UnmanagedImage image )
        {
            return null;
        }

        public void Apply( UnmanagedImage sourceImage, UnmanagedImage destinationImage )
        {
        }

        public void ApplyInPlace( Bitmap image )
        {
            // apply the filter
            ApplyInPlace( image, new Rectangle( 0, 0, image.Width, image.Height ) );
        }

        public void ApplyInPlace( BitmapData imageData )
        {
            // apply the filter
            ApplyInPlace( imageData, new Rectangle( 0, 0, imageData.Width, imageData.Height ) );
        }

        public void ApplyInPlace( UnmanagedImage image )
        {
        }

        public void ApplyInPlace( Bitmap image, Rectangle rect )
        {
            // lock source bitmap data
            BitmapData data = image.LockBits(
                new Rectangle( 0, 0, image.Width, image.Height ),
                ImageLockMode.ReadWrite, image.PixelFormat );

            try
            {
                // apply the filter
                ApplyInPlace( data, rect );
            }
            finally
            {
                // unlock image
                image.UnlockBits( data );
            }
        }

        public void ApplyInPlace( BitmapData imageData, Rectangle rect )
        {
            // check pixel format of the source image
            CheckSourceFormat( imageData.PixelFormat );

            // validate rectangle
            rect.Intersect( new Rectangle( 0, 0, imageData.Width, imageData.Height ) );

            // process the filter if rectangle is not empty
            if ( ( rect.Width | rect.Height ) != 0 )
                ProcessFilter( new UnmanagedImage( imageData ), rect );
        }

        public void ApplyInPlace( UnmanagedImage image, Rectangle rect )
        {
        }

        protected abstract unsafe void ProcessFilter( UnmanagedImage image, Rectangle rect );

        // Check pixel format of the source image
        private void CheckSourceFormat( PixelFormat pixelFormat )
        {
            if ( !SupportedFormats.Contains( pixelFormat ) )
                throw new ArgumentException( "Source pixel format is not supported by the filter." );
        }
    }
}
