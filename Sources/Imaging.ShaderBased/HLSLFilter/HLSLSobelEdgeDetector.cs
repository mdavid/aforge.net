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
    /// Sobel edge detector.
    /// </summary>
    /// <remarks><para>The filter searches for objects' edges by applying Sobel operator.</para>
    /// 
    /// <para>Each pixel of the result image is calculated as approximated absolute gradient
    /// magnitude for corresponding pixel of the source image:
    /// <code lang="none">
    /// |G| = |Gx| + |Gy] ,
    /// </code>
    /// where Gx and Gy are calculate utilizing Sobel convolution kernels:
    /// <code lang="none">
    ///    Gx         Gy
    /// -1 0 +1    +1 +2 +1
    /// -2 0 +2     0  0  0
    /// -1 0 +1    -1 -2 -1
    /// </code>
    /// Using the above kernel the approximated magnitude for pixel <b>x</b> is calculate using
    /// the next equation:
    /// <code lang="none">
    /// P1 P2 P3
    /// P8  x P4
    /// P7 P6 P5
    /// 
    /// |G| = |P1 + 2P2 + P3 - P7 - 2P6 - P5| +
    ///       |P3 + 2P4 + P5 - P1 - 2P8 - P7|
    /// </code>
    /// </para>
    ///	
    /// <para>Sample usage:</para>
    /// <code>
    ///  // 1. Offline rendering
    ///  // create HLSLProcessor, used as rendering framework
    ///  HLSLProcessor processor = new HLSLProcessor();
    ///  // starts HLSLProcessor
    ///  processor.Begin( image );
    ///  // create HLSLSobelEdgeDetector filter
    ///  HLSLSobelEdgeDetector filter = new HLSLSobelEdgeDetector( true );
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
    ///  // create HLSLSobelEdgeDetector filter
    ///  HLSLSobelEdgeDetector filter2 = new HLSLSobelEdgeDetector( false );
    ///  processor2.Filter = filter2;  
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
    /// <img src="img/shaderbased/sample1.jpg" width="480" height="361" />
    /// <para><b>Result image:</b></para>
    /// <img src="img/shaderbased/HLSLSobelEdgeDetector.jpg" width="480" height="361" />
    /// </remarks>
    public sealed class HLSLSobelEdgeDetector : HLSLBaseFilter
    {
        /// <summary>
        /// Indicating whether edge image is colored of grayscaled. Default: false
        /// </summary>
        /// <value>
        /// 	<c>true</c> if edge image will be colored, otherwise edge image is grayscaled.
        /// </value>
        public bool IsColored { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLSobelEdgeDetector"/> class.
        /// </summary>
        /// <param name="isColored">if set to <c>true</c> edge image will be colored, 
        /// otherwise edge image is grayscaled.</param>
        public HLSLSobelEdgeDetector(bool isColored)
            : base("HLSLSobelEdgeDetector")
        {
            IsColored = isColored;
        }

        /// <summary>
        /// Sets the HLSL based SobelEdgeDetector filter.
        /// </summary>        
        internal override void RenderEffect(TextureInformation info)            
        {
            effect.Parameters["isColored"].SetValue(IsColored);
            effect.Parameters["width"].SetValue(info.Width);
            effect.Parameters["height"].SetValue(info.Height);
            effect.Begin();
            effect.CurrentTechnique.Passes[0].Begin();
            effect.CurrentTechnique.Passes[0].End();
            effect.End();
        }
    }
}
