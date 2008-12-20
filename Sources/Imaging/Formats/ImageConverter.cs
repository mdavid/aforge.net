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
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    /// <summary>
    /// Provides several static functions to convert one or multiple image file(s) in a 
    /// special image format.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Supported formats are all default dotnet codecs (BMP, EMF, GIF, JPG, PNG, TIFF, WMF)
    /// and all custom codecs, which implements the <seealso cref="IImageEncoder"/> interface.
    /// </para>
    /// </remarks>
    public static class ImageConverter
    {
        #region Converting one image
        /// <summary>
        /// Converts an image to the passed <seealso cref="IImageDecoder"/> format.
        /// </summary>
        /// <param name="newFormat">The new image format.</param>
        /// <param name="imageFile">The image file to convert.</param>
        /// <param name="overwrite"><c>True</c> if overwrites/deletes orginal file, otherwise <c>false</c>.</param>
        public static void ConvertTo(IImageEncoder newFormat, string imageFile, bool overwrite)
        {
            Convert(imageFile, imageFile, newFormat, overwrite, 0, 0);
        }

        /// <summary>
        /// Converts an image to the passed <seealso cref="IImageDecoder"/> format.
        /// </summary>
        /// <param name="newFormat">The new image format.</param>
        /// <param name="imageFile">The image file to convert.</param>
        /// <param name="overwrite"><c>True</c> if overwrites/deletes orginal file, otherwise <c>false</c>.</param>
        /// <param name="biggerSideLength">Length of the bigger side of the image.</param>
        public static void ConvertTo(IImageEncoder newFormat, string imageFile, 
            bool overwrite, int biggerSideLength)
        {
            float w, h;
            CalcBiggerSideLength(imageFile, biggerSideLength, out w, out h);
            Convert(imageFile, imageFile, newFormat, overwrite, (int)w, (int)h);            
        }

        /// <summary>
        /// Converts an image to the passed <seealso cref="IImageDecoder"/> format.
        /// </summary>
        /// <param name="newFormat">The new image format.</param>
        /// <param name="imageFile">The image file to convert.</param>
        /// <param name="overwrite"><c>True</c> if overwrites/deletes orginal file, otherwise <c>false</c>.</param>
        /// <param name="width">The desired width of the image.</param>
        /// <param name="height">The desired height of the image.</param>
        public static void ConvertTo(IImageEncoder newFormat, string imageFile,
            bool overwrite, int width, int height)
        {
            Convert(imageFile, imageFile, newFormat, overwrite, width, height);
        }

        /// <summary>
        /// Converts an image to the passed <seealso cref="IImageDecoder"/> format.
        /// </summary>
        /// <param name="newFormat">The new image format.</param>
        /// <param name="originalFile">The original file.</param>
        /// <param name="newFile">The new file.</param>
        public static void ConvertTo(IImageEncoder newFormat, string originalFile, string newFile)
        {
            Convert(originalFile, newFile, newFormat, false, 0, 0);
        }

        /// <summary>
        /// Converts an image to the passed <seealso cref="IImageDecoder"/> format.
        /// </summary>
        /// <param name="newFormat">The new image format.</param>
        /// <param name="originalFile">The original file.</param>
        /// <param name="newFile">The new file.</param>
        /// <param name="overwrite"><c>True</c> if overwrites/deletes orginal file, otherwise <c>false</c>.</param>
        /// <param name="biggerSideLength">Length of the bigger side of the image.</param>
        public static void ConvertTo(IImageEncoder newFormat, string originalFile, string newFile,
            bool overwrite, int biggerSideLength)
        {
            float w, h;
            CalcBiggerSideLength(originalFile, biggerSideLength, out w, out h);
            Convert(originalFile, newFile, newFormat, overwrite, (int)w, (int)h);
        }

        /// <summary>
        /// Converts an image to the passed <seealso cref="IImageDecoder"/> format.
        /// </summary>
        /// <param name="newFormat">The new image format.</param>
        /// <param name="originalFile">The original file.</param>
        /// <param name="newFile">The new file.</param>
        /// <param name="overwrite"><c>True</c> if overwrites/deletes orginal file, otherwise <c>false</c>.</param>
        /// <param name="width">The desired width of the image.</param>
        /// <param name="height">The desired height of the image.</param>
        public static void ConvertTo(IImageEncoder newFormat, string originalFile, string newFile,
            bool overwrite, int width, int height)
        {
            Convert(originalFile, newFile, newFormat, overwrite, width, height);
        }
        #endregion Converting one image

        #region List of images
        /// <summary>
        /// Converts an image to the passed <seealso cref="IImageDecoder"/> format.
        /// </summary>
        /// <param name="newFormat">The new image format.</param>
        /// <param name="imageFiles">The image files to convert.</param>
        /// <param name="overwrite"><c>True</c> if overwrites/deletes orginal file, otherwise <c>false</c>.</param>
        public static void ConvertAll(IImageEncoder newFormat, string[] imageFiles, bool overwrite)
        {
            foreach (string image in imageFiles)
                Convert(image, image, newFormat, overwrite, 0, 0);
        }

        /// <summary>
        /// Converts an image to the passed <seealso cref="IImageDecoder"/> format.
        /// </summary>
        /// <param name="newFormat">The new image format.</param>
        /// <param name="imageFiles">The image files to convert.</param>
        /// <param name="overwrite"><c>True</c> if overwrites/deletes orginal file, otherwise <c>false</c>.</param>
        /// <param name="biggerSideLength">Length of the bigger side of the image.</param>
        public static void ConvertAll(IImageEncoder newFormat, string[] imageFiles,
            bool overwrite, int biggerSideLength)
        {
            float w, h;
            foreach (string image in imageFiles)
            {
                CalcBiggerSideLength(image, biggerSideLength, out w, out h);
                Convert(image, image, newFormat, overwrite, (int)w, (int)h);
            }
        }

        /// <summary>
        /// Converts an image to the passed <seealso cref="IImageDecoder"/> format.
        /// </summary>
        /// <param name="newFormat">The new image format.</param>
        /// <param name="imageFiles">The image files to convert.</param>
        /// <param name="overwrite"><c>True</c> if overwrites/deletes orginal file, otherwise <c>false</c>.</param>
        /// <param name="width">The desired width of the image.</param>
        /// <param name="height">The desired height of the image.</param>
        public static void ConvertAll(IImageEncoder newFormat, string[] imageFiles,
            bool overwrite, int width, int height)
        {
            foreach (string image in imageFiles)
                Convert(image, image, newFormat, overwrite, width, height);
        }

        /// <summary>
        /// Converts an image to the passed <seealso cref="IImageDecoder"/> format.
        /// </summary>
        /// <param name="newFormat">The new image format.</param>
        /// <param name="originalFiles">The original files.</param>
        /// <param name="newFiles">The new files.</param>
        public static void ConvertAll(IImageEncoder newFormat, string[] originalFiles, 
            string[] newFiles)
        {
            if (originalFiles.Length != newFiles.Length)
                throw new ArgumentOutOfRangeException
                    ("newFiles must have same length like originalFiles.");

            for (int i = 0; i < originalFiles.Length; i++)
                Convert(originalFiles[i], newFiles[i], newFormat, false, 0, 0);
        }

        /// <summary>
        /// Converts an image to the passed <seealso cref="IImageDecoder"/> format.
        /// </summary>
        /// <param name="newFormat">The new image format.</param>
        /// <param name="originalFiles">The original files.</param>
        /// <param name="newFiles">The new files.</param>
        /// <param name="biggerSideLength">Length of the bigger side of the image.</param>
        public static void ConvertAll(IImageEncoder newFormat, string[] originalFiles, 
            string[] newFiles, int biggerSideLength)
        {
            if (originalFiles.Length != newFiles.Length)
                throw new ArgumentOutOfRangeException
                    ("newFiles must have same length like originalFiles.");

            float w, h;
            for (int i = 0; i < originalFiles.Length; i++)
            {
                CalcBiggerSideLength(originalFiles[i], biggerSideLength, out w, out h);
                Convert(originalFiles[i], newFiles[i], newFormat, false, (int)w, (int)h);
            }
        }

        /// <summary>
        /// Converts an image to the passed <seealso cref="IImageDecoder"/> format.
        /// </summary>
        /// <param name="newFormat">The new image format.</param>
        /// <param name="originalFiles">The original files.</param>
        /// <param name="newFiles">The new files.</param>
        /// <param name="width">The desired width of the image.</param>
        /// <param name="height">The desired height of the image.</param>
        public static void ConvertAll(IImageEncoder newFormat, string[] originalFiles, 
            string[] newFiles, int width, int height)
        {
            if (originalFiles.Length != newFiles.Length)
                throw new ArgumentOutOfRangeException
                    ("newFiles must have same length like originalFiles.");
            
            for (int i = 0; i < originalFiles.Length; i++)
                Convert(originalFiles[i], newFiles[i], newFormat, false, width, height);
        }
        #endregion List of images

        #region Private helper functions
        /// <summary>
        /// Calcs the length of the bigger side.
        /// </summary>
        /// <param name="imageFile">The image file.</param>
        /// <param name="biggerSideLength">Length of the bigger side of the image.</param>
        /// <param name="w">The width.</param>
        /// <param name="h">The height.</param>
        private static void CalcBiggerSideLength(string imageFile, 
                                                 int biggerSideLength,
                                                 out float w,
                                                 out float h)
        {
            w = h = 0;

            Bitmap pic = new Bitmap(imageFile);
            w = (float)pic.Width;
            h = (float)pic.Height;
            float ratio = w / h;
            if (w > h)
            {
                w = biggerSideLength;
                h = w / ratio;
            }
            else
            {
                h = biggerSideLength;
                w = h * ratio;
            }
            pic.Dispose();
        }

        /// <summary>
        /// Transforms an image with the passed variables and saves it.
        /// </summary>
        /// <param name="originalFile">The original file.</param>
        /// <param name="newFile">The new file.</param>
        /// <param name="newFormat">The new encoding format.</param>
        /// <param name="overwrite">If <c>true</c> the
        /// original file will be overwritten or deleted.</param>
        /// <param name="width">The width of the converted image.</param>
        /// <param name="height">The height of the converted image.</param>
        private static void Convert
            (String originalFile, 
             String newFile, 
             IImageEncoder newFormat,
             bool overwrite,
             int width, 
             int height
             )
        {
            Bitmap pic = ImageDecoder.DecodeFromFile(originalFile);
            if (width == 0 || height == 0)
            {
                width = pic.Width;
                height = pic.Height;
            }
            float ratio = (float)width / (float)height;
            float h = (float)pic.Height;
            float w = (float)pic.Width;
            float xStart = 0f;
            float yStart = 0f;
            float wCorrect = w;
            float hCorrect = h;

            if (w / h > ratio)
            {
                wCorrect = h * ratio;
                xStart = (w - wCorrect) / 2.0f;
            }
            else if (w / h <= ratio)
            {
                hCorrect = w / ratio;
                yStart = (h - hCorrect) / 2.0f;
            }

            RectangleF rec = new RectangleF(xStart, yStart, wCorrect, hCorrect);
            Bitmap croppedPic = pic.Clone(rec, pic.PixelFormat);
            pic.Dispose();
            croppedPic = new Bitmap(croppedPic, width, height);
            
            MemoryStream ms = new MemoryStream();
            croppedPic.Save(ms, ImageFormat.Bmp);
            croppedPic.Dispose();

            newFormat.Initialize(ms);
            
            //Create destination directory, if it doesn't exist already            
            newFile = newFile.Replace('\\', '/');
            int index = newFile.LastIndexOf('/');
            if (index != -1 && !Directory.Exists(newFile.Substring(0, index)))
                Directory.CreateDirectory(newFile.Substring(0, index));

            #region Check for right extension
            string oldExt = newFile.Substring(newFile.LastIndexOf('.') + 1);
            bool correctExt = true;            
            foreach (string ext in newFormat.Extensions)
                if (ext.ToLower() == oldExt.ToLower())
                {
                    correctExt = false;
                    break;
                }

            if (correctExt)
                newFile = newFile.Replace(oldExt, newFormat.Extensions[0]);

            #endregion Check for right extension

            //Check, if same destination file name, but no overwriting allowed
            if (newFile.ToLower() == originalFile.ToLower() && !overwrite)
                newFile = newFile.Insert(newFile.LastIndexOf('.'), "_1");

            newFormat.Save(newFile);

            //Check, if different destination file names,
            //..but overwriting needed --> then delete original file
            if (newFile.ToLower() != originalFile.ToLower() && overwrite)
                File.Delete(originalFile);

            newFormat.Close(); 
        }
        #endregion Private helper functions
    }
}
