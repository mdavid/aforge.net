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
    /// Sepia filter - old brown photo.
    /// </summary>
    /// <remarks><para>The filter makes an image look like an old brown photo. The main
    /// idea of the algorithm:
    /// <list type="bullet">
    /// <item>transform to YIQ color space;</item>
    /// <item>modify it;</item>
    /// <item>transform back to RGB.</item>
    /// </list></para>
    /// 
    /// <para>
    /// <b>1) RGB -> YIQ</b>:
    /// <code lang="none">
    ///	Y = 0.299 * R + 0.587 * G + 0.114 * B
    ///	I = 0.596 * R - 0.274 * G - 0.322 * B
    ///	Q = 0.212 * R - 0.523 * G + 0.311 * B
    ///	</code>
    ///	</para>
    ///	
    /// <para>
    /// <b>2) update</b>:
    /// <code lang="none">
    ///	I = 51
    ///	Q = 0
    ///	</code>
    ///	</para>
    ///	
    /// <para>
    ///	<b>3) YIQ -> RGB</b>:
    /// <code lang="none">
    ///	R = 1.0 * Y + 0.956 * I + 0.621 * Q
    ///	G = 1.0 * Y - 0.272 * I - 0.647 * Q
    ///	B = 1.0 * Y - 1.105 * I + 1.702 * Q
    ///	</code>
    ///	</para>
    ///	
    /// <para>Sample usage:</para>
    /// <code>
    ///  // 1. Offline rendering
    ///  // create HLSLProcessor, used as rendering framework
    ///  HLSLProcessor processor = new HLSLProcessor();
    ///  // starts HLSLProcessor
    ///  processor.Begin( image );
    ///  // create HLSLSepia filter
    ///  HLSLSepia filter = new HLSLSepia( );
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
    ///  // create HLSLSepia filter
    ///  HLSLSepia filter2 = new HLSLSepia( );
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
    /// <img src="img/shaderbased/HLSLSepia.jpg" width="480" height="361" />
    /// </remarks>
    public sealed class HLSLSepia : HLSLBaseFilter
    {
        /// <summary>Q coefficient of YIQ color space. Default: 0.0</summary>     
        public float Q { get; set; }
        /// <summary>I coefficient of YIQ color space. Default: 0.2</summary>
        public float I { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLSepia"/> class.
        /// </summary>
        public HLSLSepia()
            : base("HLSLSepia")
        {
            Q = 0.0f;
            I = 0.2f; // = 51 / 255.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLSepia"/> class.
        /// </summary>
        /// <param name="q">The updated Q coefficient of YIQ color space.</param>
        /// <param name="i">The updated I coefficient of YIQ color space.</param>
        public HLSLSepia(float q, float i)
            : base("HLSLSepia")
        {
            Q = q;
            I = i;
        }

        /// <summary>
        /// Renders the HLSL based Sepia filter.
        /// </summary>        
        /// <param name="info">The texture information of the texture, which will be processed.</param>
        internal override void RenderEffect(TextureInformation info)            
        {
            effect.Parameters["Q"].SetValue(Q);
            effect.Parameters["I"].SetValue(I);
            effect.Begin();
            effect.CurrentTechnique.Passes[0].Begin();
            effect.CurrentTechnique.Passes[0].End();
            effect.End();
        }
    }
}
