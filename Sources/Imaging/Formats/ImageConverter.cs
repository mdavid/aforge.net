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
    /// <para>Supported formats:</para>
    /// <list type="enumeration">BMP</list>
    /// <list type="enumeration">EMF</list>
    /// <list type="enumeration">GIF</list>
    /// <list type="enumeration">JPG</list>
    /// <list type="enumeration">PNG</list>
    /// <list type="enumeration">TIFF</list>
    /// <list type="enumeration">WMF</list>
    /// </remarks>
    public static class ImageConverter
    {
        /// <summary>
        /// Converts to.
        /// </summary>
        /// <param name="newFormat">The new image format.</param>
        /// <param name="imageFile">The image file to convert.</param>
        /// <param name="overwrite">if set to <c>true</c> [overwrite].</param>
        /// <returns>True if the converting process was successful, otherwise false.</returns>
        public static bool ConvertTo(IImageDecoder newFormat, string imageFile, bool overwrite)
        {
            return Core(imageFile, imageFile, newFormat, overwrite, 0, 0, 100);
        }

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
            try
            {
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
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Transforms an image with the passed variables adn saves it.
        /// </summary>
        /// <param name="originalFile">The original file.</param>
        /// <param name="newFile">The new file.</param>
        /// <param name="newFormat">The new format.</param>
        /// <param name="overwrite">If <c>true</c> the
        /// original file will be overwritten or deleted.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="jpgQuality">The JPG quality.</param>
        /// <returns></returns>
        private static bool Core
            (String originalFile, 
             String newFile, 
             IImageDecoder newFormat,
             bool overwrite,
             int width, 
             int height, 
             byte jpgQuality
             )
        {
            Bitmap pic = ImageDecoder.DecodeFromFile(originalFile);
            if (width == 0 /*|| height == 0*/)
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
            bool result;

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
            //MemoryReducer.ReduceMemoryUsage();

            newFormat.Open(ms);
            
            //Create destination directory, if it doesn't exist already
            int index = newFile.LastIndexOf('\\');
            if (index != -1 && !Directory.Exists(newFile.Substring(0, index)))
                Directory.CreateDirectory(newFile.Substring(0, index));

            //Check, if same destination file name, but no overwriting allowed
            if (newFile == originalFile.ToLower() && !overwrite)
                newFile = newFile.Insert(newFile.LastIndexOf('.'), "_1");

            result = newFormat.Save(null, ref newFile);

            //Check, if different destination file names,
            //..but overwriting needed --> then delete original file
            if (newFile != originalFile.ToLower() && overwrite)
                File.Delete(originalFile);

            newFormat.Close(); 
                                  
            return result;
        }
        #endregion Private helper functions
    }
}
