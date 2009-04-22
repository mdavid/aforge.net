// AForge Image Formats Library
// AForge.NET framework
//
// Copyright © Frank Nagl, 2008
// admin@franknagl.de
// www.franknagl.de
//
namespace AForge.Imaging.Formats
{
    using System;
    using System.IO;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.ComponentModel;
    using System.Collections.Generic;

    /// <summary>
    /// Information about PNG image's frame.
    /// </summary>
    public sealed class PNGImageInfo : ImageInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PNGImageInfo"/> class.
        /// </summary>
        /// 
        public PNGImageInfo() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PNGImageInfo"/> class.
        /// </summary>
        /// 
        /// <param name="width">Image's width.</param>
        /// <param name="height">Image's height.</param>
        /// <param name="bitsPerPixel">Number of bits per image's pixel.</param>
        /// <param name="frameIndex">Frame's index.</param>
        /// <param name="totalFrames">Total frames in the image.</param>
        /// 
        public PNGImageInfo(int width, int height, int bitsPerPixel, int frameIndex, int totalFrames) :
            base(width, height, bitsPerPixel, frameIndex, totalFrames) { }

        /// <summary>
        /// Creates a new object that is a copy of the current instance. 
        /// </summary>
        /// 
        /// <returns>A new object that is a copy of this instance.</returns>
        /// 
        public override object Clone()
        {
            PNGImageInfo clone = new PNGImageInfo(width, height, bitsPerPixel, frameIndex, totalFrames);
            return clone;
        }
    }

    /// <summary>
    /// PNG image format encoder.
    /// </summary>
    public class PNGCodec : IImageEncoder
    {
        // stream with PNG encoded data
        private Stream stream = null;
        // bitmap with PNG encoded data
        private Bitmap bitmap = null;
        private List<string> extensions = new List<string>(2);
        PNGImageInfo imageInfo;

        #region IImageEncoder Member
        List<string> IImageEncoder.Extensions
        {
            get { return extensions; }
            //set { extensions = value; }
        }

        /// <summary>
        /// Gets the image info.
        /// </summary>
        /// <value>The image info.</value>
        public ImageInfo ImageInfo
        {
            get { return imageInfo; }
        }

        /// <summary>
        /// Initializes the PNG encoder.
        /// </summary>
        /// <param name="stream">The image stream, which should be encoded with the PNG encoder.</param>
        public void Initialize(Stream stream)
        {
            this.stream = stream;
            bitmap = (Bitmap)Bitmap.FromStream(stream);
            imageInfo = new PNGImageInfo(bitmap.Width, bitmap.Height, 24, 0, 1);
            extensions.Add("png");
        }

        /// <summary>
        /// Encodes the image steam.
        /// </summary>
        /// <remarks>This method throws
        /// <see cref="System.NotSupportedException"/> exception, because the encoder is a
        /// default dotnet encoder. No custom encoding necessary.
        /// </remarks>
        public void Encode()
        {
            throw new NotSupportedException("Not necessary for dotNet default PNG encoder.");
        }

        /// <summary>
        /// Gets the image of the image stream.
        /// </summary>
        /// <returns>The image of the image stream.</returns>
        public Bitmap[] ToBitmaps()
        {
            Bitmap[] bitmaps = new Bitmap[1];
            bitmaps[0] = (Bitmap)Bitmap.FromStream(stream);
            return bitmaps;
        }

        /// <summary>
        /// Saves as a PNG image.
        /// </summary>
        /// <param name="path">Path to which the image would be saved.</param>
        /// <returns>
        /// True, if the saving process was successful, otherwise false.
        /// </returns>
        public void Save(string path)
        {
            bitmap.Save(path, ImageFormat.Png);
        }

        /// <summary>
        /// Close decoding of previously opened stream.
        /// </summary>
        /// <remarks>
        /// Implementations of this method don't close stream itself, but just close
        /// decoding cleaning all associated data with it.
        /// </remarks>
        public void Close()
        {
            stream = null;
            bitmap = null;
            imageInfo = null;
        }

        #endregion Implementations of IImageEncoder
    }
}
