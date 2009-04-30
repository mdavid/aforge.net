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
    /// Information about JPG image's frame.
    /// </summary>
    public sealed class JPGImageInfo : ImageInfo
    {
        // JPG quality, has to be a value between 0-100
        private byte quality;
        /// <summary>
        /// JPG quality value of the image.
        /// </summary>
        /// 
        /// <remarks><para>Value has to be between 1 and 100.</para></remarks>
        /// 
        [Category("JPG Info")]
        public byte Quality
        {
            get { return quality; }
            set { quality = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JPGImageInfo"/> class.
        /// </summary>
        /// 
        public JPGImageInfo() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JPGImageInfo"/> class.
        /// </summary>
        /// 
        /// <param name="width">Image's width.</param>
        /// <param name="height">Image's height.</param>
        /// <param name="bitsPerPixel">Number of bits per image's pixel.</param>
        /// <param name="frameIndex">Frame's index.</param>
        /// <param name="totalFrames">Total frames in the image.</param>
        /// 
        public JPGImageInfo(int width, int height, int bitsPerPixel, int frameIndex, int totalFrames) :
            base(width, height, bitsPerPixel, frameIndex, totalFrames) { }

        /// <summary>
        /// Creates a new object that is a copy of the current instance. 
        /// </summary>
        /// 
        /// <returns>A new object that is a copy of this instance.</returns>
        /// 
        public override object Clone()
        {
            JPGImageInfo clone = new JPGImageInfo(width, height, bitsPerPixel, frameIndex, totalFrames);

            clone.quality = quality;

            return clone;
        }
    }

    /// <summary>
    /// JPG image format encoder.
    /// </summary>
    public class JPGCodec : IImageEncoder
    {
        // stream with JPG encoded data
        private Stream stream = null;
        // bitmap with JPG encoded data
        private Bitmap bitmap = null;
        //The quality value of the jpeg codec
        private byte quality;
        private List<string> extensions = new List<string>(2);
        JPGImageInfo imageInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="JPGCodec"/> class.
        /// </summary>
        /// <param name="quality">The quality of the jpeg codec.</param>
        public JPGCodec(byte quality)
        {
            this.quality = quality;
        }

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
        /// Initializes the jpeg encoder.
        /// </summary>
        /// <param name="stream">The image stream, which should be encoded with the jpeg encoder.</param>
        public void Initialize(Stream stream)
        {
            this.stream = stream;
            bitmap = (Bitmap)Bitmap.FromStream(stream);
            imageInfo = new JPGImageInfo(bitmap.Width, bitmap.Height, 24, 0, 1);
            imageInfo.Quality = quality;
            extensions.Add("jpg");
            extensions.Add("jpeg");
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
            throw new NotSupportedException("Not necessary for dotNet default jpeg encoder.");
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
        /// Saves as a jpeg image.
        /// </summary>
        /// <param name="path">Path to which the image would be saved.</param>
        /// <returns>
        /// True, if the saving process was successful, otherwise false.
        /// </returns>
        public void Save(string path)
        {
            if (imageInfo.Quality < 0 || imageInfo.Quality > 100)
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

            SaveJpeg(path, Bitmap.FromStream(stream), imageInfo.Quality);          
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

        /// <summary>
        /// Saves an image as a jpeg image, with the passed quality.
        /// </summary>
        /// <param name="path">Path to which the image would be saved.</param>
        /// <param name="img">The image</param>
        /// <param name="quality">An integer from 0 to 100, with 100 being the
        /// highest quality</param>
        private static void SaveJpeg(string path, Image img, int quality)
        {
            // Encoder parameter for image quality
            EncoderParameter qualityParam =
                new EncoderParameter(Encoder.Quality, quality);
            // Jpeg image codec
            ImageCodecInfo jpegCodec = ImageCodecInfo.GetImageEncoders()[1];

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }
    }
}
