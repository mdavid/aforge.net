// AForge Shader-Based Image Processing Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Frank Nagl, 2009-2010
// admin@franknagl.de
//
namespace AForge.Imaging.ShaderBased
{
    using System.Resources;
    using System.Reflection;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;
    using System;

    /// <summary>
    /// Base class for HLSL based image processing filter.
    /// </summary>
    /// <remarks>
    /// Provides a method to init and configure a shader for a specified
    /// image processing filter.
    /// </remarks>
    public abstract class HLSLBaseFilter
    {
        /// <summary>Reference to XNA graphics device. Note: Only using it in PostInit().</summary>
        private GraphicsDevice graphics;
        /// <summary>The specified shader effect.</summary>
        protected Effect effect;
        /// <summary>The HLSL effect file, located in project's resources file.</summary>
        protected string effectFile;
        /// <summary>Message for ArgumentException, thrown by defining a 
        /// property before setting <see cref="HLSLProcessor.Filter"/>.</summary>
        protected const string InitMsg = " can be defined primaly after setting property HLSLProcessor.Filter.";

        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLBaseFilter"/> class.
        /// </summary>
        /// <param name="effectFile">The HLSL effect file, located in project's resources file.</param>
        protected HLSLBaseFilter(string effectFile) 
        {
            this.effectFile = effectFile;
        }

        /// <summary>
        /// Inits the specified effect.
        /// </summary>
        /// <param name="graphics">The XNA graphics device.</param>
        /// <returns></returns>
        internal void Init(GraphicsDevice graphics)
        {
            this.graphics = graphics;
            // Load the effect from Resources.resx file.
            ResourceManager resource =
                new ResourceManager("AForge.Imaging.ShaderBased.Properties.Resources",
                Assembly.GetExecutingAssembly());
            string s = resource.GetString(effectFile);
            CompiledEffect compiledeffect = Effect.CompileEffectFromSource(s,
                                                                          null,
                                                                          null,
                                                                          CompilerOptions.None,
                                                                          TargetPlatform.Windows);
            effect = new Effect(   graphics,
                                   compiledeffect.GetEffectCode(),
                                   CompilerOptions.None,
                                   null);
            PostInit();
        }

        /// <summary>
        /// Provides inidvidual filter initialization after graphics device 
        /// and effect initialization.
        /// </summary>
        protected virtual void PostInit() { }

        /// <summary>
        /// Renders the specified effect.
        /// </summary>
        /// <param name="info">The texture information of the texture, which will be processed.</param>
        internal abstract void RenderEffect(TextureInformation info);

        /// <summary>
        /// Creates a 2D texture from bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap used for the texture.</param>
        /// <returns>The created texture.</returns>
        public Texture2D CreateTexture(System.Drawing.Bitmap bitmap)
        {
            if (graphics == null)
                throw new ArgumentException("Textures" + InitMsg);
            Texture2D texture;
            ImageConverter.BitmapToTexture(bitmap, graphics, out texture);
            return texture;
        }

        /// <summary>
        /// Creates a 2D texture from image file.
        /// </summary>
        /// <param name="filename">Image file used for the texture.</param>
        /// <returns>The created texture.</returns>
        public Texture2D CreateTexture(string filename)
        {
            if (graphics == null)
                throw new ArgumentException("Textures" + InitMsg);
            return Texture2D.FromFile(graphics, filename);
        }
    }
}
