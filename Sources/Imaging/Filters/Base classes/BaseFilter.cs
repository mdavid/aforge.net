// AForge Image Processing Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2005-2008
// andrew.kirillov@gmail.com
//

namespace AForge.Imaging.Filters
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public abstract class BaseFilter : IFilter
    {
        public Bitmap Apply( Bitmap image )
        {
            return null;
        }

        public Bitmap Apply( BitmapData imageData )
        {
            return null;
        }

        public UnmanagedImage Apply( UnmanagedImage image )
        {
            return null;
        }

        public void Apply( UnmanagedImage sourceImage, UnmanagedImage destinationImage )
        {
        }

        protected abstract unsafe void ProcessFilter( UnmanagedImage sourceData, UnmanagedImage destinationData );
    }
}
