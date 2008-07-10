// AForge Image Formats Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2005-2008
// andrew.kirillov@gmail.com
//

namespace AForge.Imaging.Formats
{
    using System;
    using System.IO;
    using System.Drawing;

    /// <summary>
    /// Image decoder interface, which specifies set of methods, which should be
    /// implemented by image decoders for different file formats.
    /// </summary>
    /// 
    /// <remarks><para>The interface specifies set of methods, which are sutable not
    /// only for simple one-frame image formats. The interface also defines methods
    /// to work with image formats designed to store multiple frames and image formats
    /// which provide different type of image description (like aquasion paramters, etc).
    /// </para></remarks>
    /// 
    public interface IImageDecoder
    {
        /// <summary>
        /// Decode first frame of image from the specified stream.
        /// </summary>
        /// 
        /// <param name="stream">Source stream, which contains encoded image.</param>
        /// 
        /// <returns>Returns decoded image frame.</returns>
        /// 
        /// <remarks>
        /// <para>For one-frame image formats the method is supposed to decode single
        /// available frame. For multi-frame image formats the first frame should be
        /// decode.</para>
        /// 
        /// <para>Implementations of this method may throw
        /// <see cref="System.ArgumentException"/> exception to report about incorrectly
        /// formatted image or <see cref="NotSupportedException"/> exception to report if
        /// certain formats are not supported.</para>
        /// </remarks>
        /// 
        Bitmap DecodeSingleFrame( Stream stream );

        // TODO: define methods for multi-frame images and for image formats,
        // which may have image description inside.
    }
}
