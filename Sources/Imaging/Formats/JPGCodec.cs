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
    /// JPG image format decoder.
    /// </summary>
    public class JPGCodec : IImageDecoder
    {
        // stream with JPG encoded data
        private Stream stream = null;
        // information about images retrieved from header
        private JPGImageInfo imageInfo = null;
        // stream position pointing to beginning of data - right after header
        private long dataPosition = 0;
        private byte quality;

        /// <summary>
        /// Initializes a new instance of the <see cref="JPGCodec"/> class.
        /// </summary>
        /// <param name="quality">The quality of the jpeg codec.</param>
        public JPGCodec(byte quality)
        {
            this.quality = quality;
        }

        /// <summary>
        /// Decode first frame of JPG image.
        /// </summary>
        /// 
        /// <param name="stream">Source stream, which contains encoded image.</param>
        /// 
        /// <returns>Returns decoded image frame.</returns>
        /// 
        /// <exception cref="FormatException">Not a JPG image format.</exception>
        /// <exception cref="NotSupportedException">Format of the JPG image is not supported.</exception>
        /// <exception cref="ArgumentException">The stream contains invalid (broken) JPG image.</exception>
        /// 
        public Bitmap DecodeSingleFrame(Stream stream)
        {
            return new Bitmap(stream);
        }

        /// <summary>
        /// Open specified stream.
        /// </summary>
        /// 
        /// <param name="stream">Stream to open.</param>
        /// 
        /// <returns>Returns number of images found in the specified stream.</returns>
        /// 
        /// <exception cref="FormatException">Not a JPG image format.</exception>
        /// <exception cref="NotSupportedException">Format of the JPG image is not supported.</exception>
        /// <exception cref="ArgumentException">The stream contains invalid (broken) JPG image.</exception>
        ///
        public int Open(Stream stream)
        {
            // close previous decoding
            Close();

            this.imageInfo = ReadHeader(stream);
            this.imageInfo.Quality = quality;
            this.stream = stream;
            this.dataPosition = stream.Seek(0, SeekOrigin.Current);

            return imageInfo.TotalFrames;
        }

        /// <summary>
        /// Decode specified frame.
        /// </summary>
        /// 
        /// <param name="frameIndex">Image frame to decode.</param>
        /// <param name="imageInfo">Receives information about decoded frame.</param>
        /// 
        /// <returns>Returns decoded frame.</returns>
        /// 
        /// <exception cref="NullReferenceException">No image stream was opened previously.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Stream does not contain frame with specified index.</exception>
        /// <exception cref="ArgumentException">The stream contains invalid (broken) JPG image.</exception>
        /// 
        public Bitmap DecodeFrame(int frameIndex, out ImageInfo imageInfo)
        {
            // check requested frame index
            if (frameIndex != 0)
            {
                throw new ArgumentOutOfRangeException("Currently opened stream does not contain frame with specified index.");
            }

            // seek to the required frame
            stream.Seek(dataPosition, SeekOrigin.Begin);

            //// read required frame
            Bitmap image = new Bitmap(stream);

            // provide also frame information
            imageInfo = (JPGImageInfo)this.imageInfo.Clone();

            return image;
        }

        /// <summary>
        /// Saves an image as a jpeg image.
        /// </summary>
        /// <param name="bitmap">The original bitmap.</param>
        /// <param name="path">Path to which the image would be saved.</param>
        /// <returns>True, if the saving process was successful, otherwise false.</returns>
        public bool Save(Bitmap bitmap, ref string path)
        {
            return Save(bitmap, ref path, "jpg");
        }

        /// <summary>
        /// Saves an image as a jpeg image.
        /// </summary>
        /// <param name="bitmap">The original bitmap.</param>
        /// <param name="path">Path to which the image would be saved.</param>
        /// <param name="extension">The extension of the jpeg format.</param>
        /// <returns>
        /// True, if the saving process was successful, otherwise false.
        /// </returns>
        public bool Save(Bitmap bitmap, ref string path, string extension)
        {
            if (imageInfo.Quality < 0 || imageInfo.Quality > 100)
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

            path = path.Substring(0, path.LastIndexOf('.') + 1) + extension;
            try
            { SaveJpeg(path, Bitmap.FromStream(stream), imageInfo.Quality); }
            catch (Exception)
            { return false; }

            return true;
        }

        /// <summary>
        /// Close decoding of previously opened stream.
        /// </summary>
        /// 
        /// <remarks><para>The method does not close stream itself, but just closes
        /// decoding cleaning all associated data with it.</para></remarks>
        /// 
        public void Close()
        {
            stream = null;
            imageInfo = null;
        }

        // Read and process JPG header. After the header is read stream pointer will
        // point to data.
        private JPGImageInfo ReadHeader(Stream stream)
        {
            Bitmap image = new Bitmap(stream);

            // prepare image information
            JPGImageInfo imageInfo = new JPGImageInfo(image.Width, image.Height, 24, 0, 1);
            image.Dispose();

            return imageInfo;
        }

        /// <summary>
        /// Saves an image as a jpeg image, with the passed quality.
        /// </summary>
        /// <param name="path">Path to which the image would be saved.</param>
        /// <param name="img">The image</param>
        /// <param name="quality">An integer from 0 to 100, with 100 being the
        /// highest quality</param>
        private static void SaveJpeg(string path, Image img, int quality)
        {
            if (quality < 0 || quality > 100)
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");


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
