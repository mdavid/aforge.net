// AForge Shader-Based Image Processing Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Frank Nagl, 2009-2010
// admin@franknagl.de
//
namespace AForge.Imaging.ShaderBased
{
    using System;
    using System.Drawing;
    using Microsoft.Xna.Framework.Graphics;
    using System.IO;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;

    /// <summary>Represents the channel indices of ARGB structure.</summary>
    public struct ARGB
    {
        /// <summary>Color channel <c>blue</c></summary>
        public const short B = 0;
        /// <summary>Color channel <c>green</c></summary>
        public const short G = 1;
        /// <summary>Color channel <c>red</c></summary>
        public const short R = 2;
        /// <summary>Transparence channel <c>alpha</c></summary>
        public const short A = 3;
    }

    /// <summary>Represents the channel indices of RGB structure.</summary>
    public struct RGB
    {
        /// <summary>Color channel <c>blue</c></summary>
        public const short B = 0;
        /// <summary>Color channel <c>green</c></summary>
        public const short G = 1;
        /// <summary>Color channel <c>red</c></summary>
        public const short R = 2;
    }

    /// <summary>
    /// Helper class for different Image converts. See function details for more information.
    /// </summary>
    public static class ImageConverter
    {
        /// <summary>
        /// Converts Texture2D to 32 bit Bitmap.
        /// </summary>
        /// <param name="texture">The texture Object, which will be converted.</param>
        /// <param name="alpha">The alpha value, e.g. 255.</param>
        /// <returns>Result Bitmap.</returns>
        public static Bitmap TextureToARGB(Texture2D texture, byte? alpha)
        {
            var textureData = new byte[4 * texture.Width * texture.Height];
            texture.GetData(textureData);

            var bitmap = new Bitmap
            (
                texture.Width, texture.Height,
                PixelFormat.Format32bppArgb
            );

            var bmpData = bitmap.LockBits
            (
                new Rectangle(0, 0, texture.Width, texture.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb
            );

            // Get the address of the first line. 
            var safePtr = bmpData.Scan0;
            Marshal.Copy(textureData, 0, safePtr, textureData.Length);

            //Bitmap width * 4 (for ARGB per pixel)
            int stride = bmpData.Stride;
            int arraySize = stride * bmpData.Height;
            // Declare an array to hold the bytes of the bitmap
            var values = new byte[arraySize];

            // Copy the values into the array.
            Marshal.Copy(safePtr, values, 0, arraySize);
            
            //Sets the alpha channel to passed alpha, otherwise it would always be 0.
            if (alpha != null)
                for (int i = 0; i < arraySize; i += 4)
                {
                    values[i + ARGB.A] = alpha.Value;
                }

            // Copy the ARGB values back to the bitmap data
            Marshal.Copy(values, 0, safePtr, arraySize);

            // unlock image
            bitmap.UnlockBits(bmpData);
            return bitmap;
        }

        /// <summary>
        /// Converts Texture2D to 24 bit Bitmap.
        /// </summary>
        /// <param name="texture">The texture Object, which will be converted.</param>
        /// <returns>Result Bitmap.</returns>
        public static Bitmap TextureToRGB(Texture2D texture)
        {
            byte[] texData = new byte[4 * texture.Width * texture.Height];
            texture.GetData<byte>(texData);
            // offset in rgb images //wrong: int offset = 4 - (3 * texture.Width) % 4;
            int offset = (3 * texture.Width) % 4;
            if (offset != 0) 
                offset = 4 - offset;
            byte[] texDataRGB = new byte[(3 * texture.Width + offset) * texture.Height];
            int nTex = 0; //position in texture array
            int nRgb = 0; //position in rgb array

            // for each line
            for (int y = 0; y < texture.Height; y++)
            {
                // for each pixel
                for (int x = 0; x < (4 * texture.Width); x++)
                {
                    // ignore alpha channel
                    if ((nTex+1) % 4 == 0)
                    {
                        nTex++;
                        continue;
                    }
                    texDataRGB[nRgb] = texData[nTex];
                    nRgb++;
                    nTex++;
                }
                nRgb += offset;
            }

            Bitmap bitmap = new Bitmap(texture.Width, texture.Height, PixelFormat.Format24bppRgb);

            BitmapData bmpData = bitmap.LockBits(
                           new System.Drawing.Rectangle(0, 0, texture.Width, texture.Height),
                           ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            // Get the address of the first line. 
            IntPtr safePtr = bmpData.Scan0;
            Marshal.Copy(texDataRGB, 0, safePtr, texDataRGB.Length);

            // unlock image
            bitmap.UnlockBits(bmpData);
            return bitmap;
        }

        /// <summary>
        /// Converts Bitmap to Texture2D.
        /// </summary>
        /// <param name="bitmap">The bitmap object, which will be converted.</param>
        /// <param name="graphicsDevice">The XNA graphics device.</param>
        /// <param name="texture">The result texture.</param>
        public static void BitmapToTexture( Bitmap bitmap,
                                            GraphicsDevice graphicsDevice,
                                            out Texture2D texture)
        {
            using (MemoryStream s = new MemoryStream())
            {
                bitmap.Save(s, ImageFormat.Bmp);
                s.Seek(0, SeekOrigin.Begin);
                texture = Texture2D.FromFile(graphicsDevice, s);

                s.Seek(0, SeekOrigin.Begin);
            }
        }

        /// <summary>
        /// Converts Bitmap to Texture2D.
        /// </summary>
        /// <param name="bitmap">The bitmap object, which will be converted.</param>
        /// <param name="graphicsDevice">The XNA graphics device.</param>
        /// <param name="texture">The result texture.</param>
        /// <param name="info">The texture information of the result texture.</param>
        public static void BitmapToTexture( Bitmap bitmap, 
                                            GraphicsDevice graphicsDevice,
                                            out Texture2D texture,
                                            out TextureInformation info)
        {
            using (MemoryStream s = new MemoryStream())
            {
                bitmap.Save(s, ImageFormat.Bmp);
                s.Seek(0, SeekOrigin.Begin);
                texture = Texture2D.FromFile(graphicsDevice, s);
                
                s.Seek(0, SeekOrigin.Begin);
                info = Texture2D.GetTextureInformation(s);
            }
        }
    }
}
