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

    /// <summary>
    /// In-place partial filter interface.
    /// </summary>
    /// 
    /// <remarks><para>The interface defines the set of methods, which should be
    /// implemented by filters, which are capable to do image processing
    /// directly on the source image. Not all image processing filters
    /// can be applied directly to the source image - only filters, which do not
    /// change image's dimension and pixel format, can be applied directly to the
    /// source image.</para>
    /// 
    /// <para>The interface also supports partial image filtering, allowing to specify
    /// image rectangle, which should be filtered.</para>
    /// </remarks>
    /// 
    public interface IInPlacePartialFilter
    {
        /// <summary>
        /// Apply filter to an image or its part.
        /// </summary>
        /// 
        /// <param name="image">Image to apply filter to.</param>
        /// <param name="rect">Image's rectangle for processing by filter.</param>
        /// 
        /// <remarks>The method applies filter directly to the provided image data.</remarks>
        /// 
        void ApplyInPlace( Bitmap image, Rectangle rect );

        /// <summary>
        /// Apply filter to an image or its part.
        /// </summary>
        /// 
        /// <param name="imageData">Image to apply filter to.</param>
        /// <param name="rect">Image's rectangle for processing by filter.</param>
        /// 
        /// <remarks>The method applies filter directly to the provided image data.</remarks>
        /// 
        void ApplyInPlace( BitmapData imageData, Rectangle rect );

        /// <summary>
        /// Apply filter to an image in unmanaged memory.
        /// </summary>
        /// 
        /// <param name="imageData">Pointer to an image in unmanaged memory.</param>
        /// <param name="width">Image's width.</param>
        /// <param name="height">Image's height.</param>
        /// <param name="stride">Image's stride (line size).</param>
        /// <param name="format">Image's pixel format.</param>
        /// <param name="rect">Image's rectangle for processing by filter.</param>
        /// 
        /// <remarks>The method applies filter directly to the provided image data.</remarks>
        /// 
        void ApplyInPlace( IntPtr imageData, int width, int height, int stride, PixelFormat format,
            Rectangle rect );
    }
}
