// AForge Shader-Based Image Processing Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Frank Nagl, 2009-2010
// admin@franknagl.de
//
namespace AForge.Imaging.ShaderBased.HLSLFilter
{
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Shows original image without any filtering.
    /// </summary>
    public sealed class HLSLOriginal : HLSLBaseFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLOriginal"/> class.
        /// </summary>
        public HLSLOriginal() : base("HLSLOriginal") { }
        /// <summary>
        /// Sets the HLSL based invert filter.
        /// </summary>        
        internal override void RenderEffect(TextureInformation info)
        {
            effect.Begin();
            effect.CurrentTechnique.Passes[0].Begin();
            effect.CurrentTechnique.Passes[0].End();
            effect.End();
        }
    }
}
