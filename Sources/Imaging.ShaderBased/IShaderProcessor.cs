// AForge Shader-Based Image Processing Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Frank Nagl, 2009-2010
// admin@franknagl.de
//
namespace AForge.Imaging.ShaderBased
{
    using System.Drawing;
    using System.Windows.Forms;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Shader based <c>I</c>mage <c>P</c>rocessing framework interface.
    /// </summary>
    /// <remarks>
    /// The interface defines the set of methods, which should be provided
    /// by all shader based image processing frameworks. Methods of this interface
    /// keep the source image unchanged and return the result of image processing
    /// filter as new image or render the result online to a windows control.
    /// </remarks>
    public interface IShaderProcessor
    {
        /// <summary>
        /// Starts the shader based image processor.
        /// </summary>
        /// <remarks>Inits all necessary devices and 
        /// informations for shader based image processing.</remarks>
        /// <param name="bitmap">Source image to process.</param>
        void Begin(Bitmap bitmap);
        /// <summary>
        /// Starts the shader based image processor.
        /// </summary>
        /// <remarks>Inits all necessary devices and 
        /// informations for shader based image processing.</remarks>
        /// <param name="file">Source image's filename.</param>
        void Begin(string file);
        /// <summary>
        /// Starts the shader based image processor.
        /// </summary>
        /// <remarks>Inits all necessary devices and 
        /// informations for shader based image processing.</remarks>
        /// <param name="bitmap">Source image to process.</param>
        /// <param name="control">Windows control using for online rendering process.</param>
        void Begin(Bitmap bitmap, Control control);
        /// <summary>
        /// Starts the shader based image processor.
        /// </summary>
        /// <remarks>Inits all necessary devices and 
        /// informations for shader based image processing.</remarks>
        /// <param name="file">Source image's filename.</param>
        /// <param name="control">Windows control using for online rendering process.</param>
        void Begin(string file, Control control);
        /// <summary>
        /// Stops render process. Disposes the used windows control and the used devices.
        /// </summary>
        void End();
        /// <summary>
        /// Renders online the image processing results into a windows control.
        /// </summary>
        void Render();
        /// <summary>
        /// Renders offline the image processing routines and stores the
        /// result image into a texture.
        /// </summary>
        /// <returns>Result texture.</returns>
        Texture2D RenderToTexture();
        /// <summary>
        /// Renders offline the image processing routines and stores the
        /// result image into a bitmap.
        /// </summary>
        /// <returns>Result image.</returns>
        Bitmap RenderToBitmap();
    }
}
