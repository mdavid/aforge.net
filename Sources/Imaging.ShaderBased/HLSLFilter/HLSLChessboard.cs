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
    public class HLSLChessboard : HLSLBaseFilter
    {
        /// <summary>
        /// Gets or sets the number of squares per side of the chessboard.
        /// </summary>
        /// <value>The squares per side.</value>
        /// <remarks>Default value: 8.0</remarks>
        public float SquaresPerSide { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLChessboard"/> class.
        /// </summary>
        public HLSLChessboard()
        {
            SquaresPerSide = 8.0f;
        }

        /// <summary>
        /// Sets the HLSL based invert filter.
        /// </summary>        
        public override void RenderEffect(GraphicsDevice graphics, TextureInformation info)
        {
            Effect effect = GetEffect(graphics, "HLSLChessboard");

            effect.Parameters["number"].SetValue(SquaresPerSide);

            effect.Begin();
            effect.CurrentTechnique.Passes[0].Begin();
            effect.CurrentTechnique.Passes[0].End();
            effect.End();
        }
    }
}
