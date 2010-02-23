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
    /// Inverts an image. 
    /// </summary>
    public class HLSLInvert : HLSLBaseFilter
    {
        /// <summary>
        /// Sets the HLSL based invert filter.
        /// </summary>        
        public override void RenderEffect(GraphicsDevice graphics, TextureInformation info)            
        {
            Effect effect = GetEffect(graphics, "HLSLInvert");

            effect.Begin();
            effect.CurrentTechnique.Passes[0].Begin();
            effect.CurrentTechnique.Passes[0].End();
            effect.End();
        }
    }
}
