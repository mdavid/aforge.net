// AForge Image Formats Library
// AForge.NET framework
//
// Copyright © Frank Nagl, 2008
// admin@franknagl.de
// www.franknagl.de
//
namespace AForge.Imaging.Formats
{
    using System.Drawing;
    using System.IO;

    /// <summary>
    /// Image encoder interface, which specifies set of methods, which should be
    /// implemented by image encoders for different file formats.
    /// </summary>
    /// 
    /// <remarks><para>The interface specifies set of methods, which are sutable not
    /// only for simple one-frame image formats. The interface also defines methods
    /// to work with image formats designed to store multiple frames and image formats
    /// which provide different type of image description.
    /// </para></remarks>
    /// 
    /// <remarks><para>
    /// The counterpart is the <seealso cref="IImageDecoder"/> interface.
    /// </para></remarks>
    /// 
    public interface IImageEncoder
    {
        /// <summary>
        /// Gets the possible file extensions of the encoder.
        /// </summary>
        /// <remarks>
        /// <para>Should be set in the <see cref="Initialize"/> method.</para>
        /// </remarks>
        /// <value>The file extensions.</value>
        System.Collections.Generic.List<string> Extensions{ get; }

        /// <summary>
        /// Initializes the specified encoder.
        /// </summary>
        /// <param name="stream">The image stream, which should be encoded with the encoder.</param>
        void Initialize(Stream stream);

        /// <summary>
        /// Encodes the image steam.
        /// </summary>
        /// 
        /// <remarks>Implementations of this method may throw
        /// <see cref="System.NotSupportedException"/> exception in the case if the encoder is a
        /// default dotnet encoder (JPG, BMP, PNG, etc.).
        /// </remarks>
        void Encode();

        /// <summary>
        /// Saves the stream as an image with the implemented Image encoder.
        /// </summary>
        /// <param name="path">Path to which the image would be saved.</param>
        void Save(string path);

        /// <summary>
        /// Gets all images of the image stream as an array of bitmaps.
        /// </summary>
        /// <returns>All images of the image stream.</returns>
        Bitmap[] ToBitmaps();

        /// <summary>
        /// Close decoding of previously opened stream.
        /// </summary>
        /// 
        /// <remarks><para>Implementations of this method don't close stream itself, but just close
        /// decoding cleaning all associated data with it.</para></remarks>
        /// 
        void Close();
    }
}
