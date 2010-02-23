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
    /// Discrete laplace operator.
    /// </summary>
    /// <remarks>Discrete laplace operator is often used in image processing e.g. in 
    /// edge detection and motion estimation applications. The discrete laplacian is 
    /// defined as the sum of the second derivatives and calculated as sum of 
    /// diffrences over the nearest neighbours of the central pixel.</remarks>
    public class HLSLLaplace : HLSLBaseFilter
    {
        /// <summary>
        /// Gets or sets the multiplication factor for stronger lines in edge image.
        /// </summary>
        /// <value>Multiplication factor.</value>
        /// <remarks>Default value: 3.0</remarks>
        public float Factor { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLLaplace"/> class.
        /// </summary>
        public HLSLLaplace()
        {
            Factor = 3.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLLaplace"/> class.
        /// </summary>
        /// <param name="factor">Multiplication factor for stronger lines in edge image.</param>
        public HLSLLaplace(float factor)
        {
            Factor = factor;
        }

        /// <summary>
        /// Sets the HLSL based invert filter.
        /// </summary>        
        public override void RenderEffect(GraphicsDevice graphics, TextureInformation info)
        {
            Effect effect = GetEffect(graphics, "HLSLLaplace");

            effect.Parameters["factor"].SetValue(Factor);
            effect.Parameters["width"].SetValue(info.Width);
            effect.Parameters["height"].SetValue(info.Height);

            effect.Begin();
            effect.CurrentTechnique.Passes[0].Begin();
            effect.CurrentTechnique.Passes[0].End();
            effect.End();
        }
    }
}
