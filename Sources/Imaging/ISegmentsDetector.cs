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

    /// <summary>
    /// Segment detector's interface.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>The interface specifies set of methods, which should be implemented by different
    /// segment detection algorithms.</para>
    /// <para>Note: This interface should not be implemented by segmentation filters.</para>
    /// </remarks>
    /// 
    public interface ISegmentsDetector
    {
        /// <summary>
        /// Process image looking for segments.
        /// </summary>
        /// 
        /// <param name="image">Source image to process.</param>
        /// 
        /// <returns>Returns array of found segments.</returns>
        /// 
        Segment[] ProcessImage(Bitmap image);

        /// <summary>
        /// Process image looking for segments.
        /// </summary>
        /// 
        /// <param name="imageData">Source image data to process.</param>
        /// 
        /// <returns>Returns array of found segments.</returns>
        /// 
        Segment[] ProcessImage(BitmapData imageData);

        /// <summary>
        /// Process image looking for segments.
        /// </summary>
        /// 
        /// <param name="image">Unmanaged source image to process.</param>
        /// 
        /// <returns>Returns array of found segments.</returns>
        /// 
        Segment[] ProcessImage(UnmanagedImage image);

        /// <summary>
        /// Process image looking for segments.
        /// </summary>
        /// 
        /// <param name="image">Source image to process.</param>
        /// <param name="rect">Image rectangle for processing by detector.</param>
        /// 
        /// <returns>Returns array of found segments.</returns>
        /// 
        Segment[] ProcessImage(Bitmap image, Rectangle rect);

        /// <summary>
        /// Process image looking for segments.
        /// </summary>
        /// 
        /// <param name="imageData">Source image data to process.</param>
        /// <param name="rect">Image rectangle for processing by detector.</param>
        /// 
        /// <returns>Returns array of found segments.</returns>
        /// 
        Segment[] ProcessImage(BitmapData imageData, Rectangle rect);

        /// <summary>
        /// Process image looking for segments.
        /// </summary>
        /// 
        /// <param name="image">Unmanaged source image to process.</param>
        /// <param name="rect">Image rectangle for processing by detector.</param>
        /// 
        /// <returns>Returns array of found segments.</returns>
        /// 
        Segment[] ProcessImage(UnmanagedImage image, Rectangle rect);
    }
}
