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
    /// Threshold binarization.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// The filter does image binarization using specified threshold value. All pixels (or 
    /// one channel of them) with intensities higher than threshold value are converted to white 
    /// pixels. All other pixels with intensities equal or below threshold value are converted to black pixels.
    /// </para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    ///  // 1. Offline rendering
    ///  // create HLSLProcessor, used as rendering framework
    ///  HLSLProcessor processor = new HLSLProcessor();
    ///  // starts HLSLProcessor
    ///  processor.Begin( image );
    ///  // create HLSLThreshold filter
    ///  HLSLThreshold filter = new HLSLThreshold( );
    ///  processor.Filter = filter;
    ///  // optional: configure filter
    ///  filter.Threshold = 170;
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
    ///  // create HLSLThreshold filter
    ///  HLSLThreshold filter2 = new HLSLThreshold( );
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
    /// <para><b>Result image (Threshold = 170):</b></para>
    /// <img src="img/shaderbased/HLSLThreshold.jpg" width="480" height="361" />
    /// </remarks>
    public sealed class HLSLThreshold : HLSLBaseFilter
    {
        private byte threshold;

        /// <summary>Threshold value.</summary>
        /// <remarks><para>Default value is set to 100.</para></remarks>
        public byte Threshold
        {
            get { return threshold; }
            set 
            {
                if (effect == null)
                    throw new ArgumentException("Threshold" + InitMsg);

                threshold = value;
                effect.Parameters["threshold"].SetValue(threshold);
            }
        }      
        
        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLThreshold"/> class.
        /// </summary>
        public HLSLThreshold()
            : base("HLSLThreshold") { }

        /// <summary>
        /// Initializes threshold value.
        /// </summary>
        protected override void PostInit()
        {
            Threshold = 100;
        }

        /// <summary>
        /// Renders the HLSLThreshold effect.
        /// </summary>
        /// <param name="info">The texture information of the texture, which will be processed.</param>
        internal override void RenderEffect(TextureInformation info)            
        {            
            effect.Begin();
            effect.CurrentTechnique.Passes[0].Begin();
            effect.CurrentTechnique.Passes[0].End();
            effect.End();
        }
    }
}
