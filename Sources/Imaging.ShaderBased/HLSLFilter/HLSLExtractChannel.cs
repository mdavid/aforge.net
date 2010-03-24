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
    using System;

    /// <summary>
    /// Extract RGB channel from image.
    /// </summary>
    /// 
    /// <remarks><para>Extracts specified channel of color image and returns
    /// it as grayscale image.</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    ///  // 1. Offline rendering
    ///  // create HLSLProcessor, used as rendering framework
    ///  HLSLProcessor processor = new HLSLProcessor();
    ///  // starts HLSLProcessor
    ///  processor.Begin( image );
    ///  // create HLSLExtractChannel filter
    ///  HLSLExtractChannel filter = new HLSLExtractChannel( );
    ///  processor.Filter = filter;
    ///  // optional: configure filter
    ///  filter.Channel = RGB.R;
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
    ///  // create HLSLExtractChannel filter
    ///  HLSLExtractChannel filter2 = new HLSLExtractChannel( );
    ///  processor2.Filter = filter2;  
    ///  // optional: configure filter
    ///  filter2.Channel = RGB.R;
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
    /// <img src="img/shaderbased/HLSLExtractChannel.jpg" width="480" height="361" />
    /// </remarks>
    public sealed class HLSLExtractChannel : HLSLBaseFilter
    {
        private short channel;
        
        /// <summary>RGB channel to replace.</summary>
        /// <remarks><para>Default value is set to <see cref="AForge.Imaging.ShaderBased.RGB.B"/>.</para></remarks>
        /// <exception cref="ArgumentException">Invalid channel is specified.</exception>
        public short Channel
        {
            get { return channel; }
            set 
            {
                if (value != RGB.R && value != RGB.G && value != RGB.B)
                    throw new ArgumentException("Invalid channel is specified.");

                if (effect == null)
                    throw new ArgumentException("Channel" + InitMsg);

                channel = value;
                effect.Parameters["channel"].SetValue(channel);
            }
        }      
        
        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLReplaceChannel"/> class.
        /// </summary>
        public HLSLExtractChannel()
            : base("HLSLExtractChannel") { }

        /// <summary>
        /// Sets the HLSL based SobelEdgeDetector filter.
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
