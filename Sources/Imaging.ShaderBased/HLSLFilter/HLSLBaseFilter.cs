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

    /// <summary>
    /// Base class for HLSL based image processing filter.
    /// </summary>
    /// <remarks>
    /// Provides a method to init and configure a shader for a specified
    /// image processing filter.
    /// </remarks>
    public abstract class HLSLBaseFilter
    {
        /// <summary>
        /// Gets the specified effect.
        /// </summary>
        /// <param name="graphics">The XNA graphics device.</param>
        /// <param name="effectFile">The effect file, located in project's resources file.</param>
        /// <returns></returns>
        protected Effect GetEffect(GraphicsDevice graphics, string effectFile)
        {
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
            Effect effect = new Effect(graphics,
                                       compiledeffect.GetEffectCode(),
                                       CompilerOptions.None,
                                       null);

            return effect;
        }

        /// <summary>
        /// Renders the specified effect.
        /// </summary>
        /// <param name="graphics">The XNA graphics device.</param>
        /// <param name="info">The texture information of the texture, which will be processed.</param>
        public abstract void RenderEffect(GraphicsDevice graphics, TextureInformation info);
    }
}
