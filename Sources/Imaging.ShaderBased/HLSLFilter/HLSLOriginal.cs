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
    public class HLSLOriginal : HLSLBaseFilter
    {
        /// <summary>
        /// Sets the HLSL based invert filter.
        /// </summary>        
        public override void RenderEffect(GraphicsDevice graphics, TextureInformation info)
        {
            Effect effect = GetEffect(graphics, "HLSLOriginal");

            effect.Begin();
            effect.CurrentTechnique.Passes[0].Begin();
            effect.CurrentTechnique.Passes[0].End();
            effect.End();
        }
    }
}
