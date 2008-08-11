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
    /// Image processing filter interface.
    /// </summary>
    /// 
    /// <remarks>The interface defines the set of methods, which should be
    /// provided by all image processing filters. Methods of this interface
    /// keep the source image unchanged and returt the result of image processing
    /// filter as new image.</remarks>
    /// 
    public interface IFilter
    {
        /// <summary>
        /// Apply filter to an image.
        /// </summary>
        /// 
        /// <param name="image">Source image to apply filter to.</param>
        /// 
        /// <returns>Returns filter's result obtained by applying the filter to
        /// the source image.</returns>
        /// 
        /// <remarks>The method keeps the source image unchanged and returns the
        /// the result of image processing filter as new image.</remarks> 
        ///
        Bitmap Apply( Bitmap image );

        /// <summary>
        /// Apply filter to an image.
        /// </summary>
        /// 
        /// <param name="imageData">Source image to apply filter to.</param>
        /// 
        /// <returns>Returns filter's result obtained by applying the filter to
        /// the source image.</returns>
        /// 
        /// <remarks>The filter accepts bitmap data as input and returns the result
        /// of image processing filter as new image. The source image data are kept
        /// unchanged.</remarks>
        /// 
        Bitmap Apply( BitmapData imageData );

        /// <summary>
        /// Apply filter to an image.
        /// </summary>
        /// 
        /// <param name="imageData">Pointer to source image in unmanaged memory.</param>
        /// <param name="width">Image's width.</param>
        /// <param name="height">Image's height.</param>
        /// <param name="stride">Image's stride (line size).</param>
        /// <param name="format">Image's pixel format.</param>
        /// <param name="destData">Pointer to destination buffer in unmanaged memory, which receives
        /// resulting image.</param>
        /// <param name="destSize">Size of destination buffer.</param>
        /// <param name="destWidth">Receives width of the resulting image put into destination buffer.</param>
        /// <param name="destHeight">Receives height of the resulting image put into destination buffer.</param>
        /// <param name="destStride">Receives stride of the resulting image put into destination buffer.</param>
        /// 
        /// <remarks>The filter accepts bitmap data as input and returns the result
        /// of image processing filter as new image. The source image data are kept
        /// unchanged.</remarks>
        /// 
        void Apply( IntPtr imageData, int width, int height, int stride, PixelFormat format,
            IntPtr destData, int destSize, out int destWidth, out int destHeight, out int destStride );
    }
}
