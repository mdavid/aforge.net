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
    /// Chessboard image.
    /// </summary>
    /// <remarks>
    /// <para>No image filtering. Just creating a chessboard texture or image :-).</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    ///  // 1. Offline rendering
    ///  // create HLSLProcessor, used as rendering framework
    ///  HLSLProcessor processor = new HLSLProcessor();
    ///  // starts HLSLProcessor
    ///  processor.Begin( image );
    ///  // create HLSLChessboard filter
    ///  HLSLChessboard filter = new HLSLChessboard( );
    ///  // optional: configure filter
    ///  filter.SquaresPerSide = 10.0f;
    ///  processor.Filter = filter;
    ///  // apply the filter  
    ///  Bitmap resultImage = processor.RenderToBitmap( );
    ///  Texture2D resultTexture = processor.RenderToTexture( );
    ///  processor.End( );
    ///  
    ///  // 2. Online rendering
    ///  // create any windows control for rendering in
    ///  Form myForm = new Form( );
    ///  // create HLSLProcessor, used as rendering framework
    ///  HLSLProcessor processor2 = new HLSLProcessor( );
    ///  // starts HLSLProcessor
    ///  processor2.Begin( image, myForm );
    ///  // create HLSLChessboard filter
    ///  HLSLChessboard filter2 = new HLSLChessboard( );
    ///  // optional: configure filter
    ///  filter2.SquaresPerSide = 10.0f;
    ///  processor2.Filter = filter;
    ///  // apply the filter
    ///  myForm.Show( );
    ///  while ( myForm.Created )
    ///  {
    ///      processor2.Render( );
    ///      Application.DoEvents( );
    ///  }
    ///  processor2.End( );
    /// </code>
    /// 
    /// <para><b>Initial image:</b></para>
    /// <img src="img/imaging/sample1.jpg" width="480" height="361" />
    /// <para><b>Result image:</b></para>
    /// <img src="img/imaging/HLSLChessboard.jpg" width="480" height="361" />
    /// </remarks>
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
