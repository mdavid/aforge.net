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
    /// Rotate RGB channels from image.
    /// </summary>
    /// 
    /// <remarks><para>The filter rotates RGB channels by specified channel order.</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    ///  // 1. Offline rendering
    ///  // create HLSLProcessor, used as rendering framework
    ///  HLSLProcessor processor = new HLSLProcessor();
    ///  // starts HLSLProcessor
    ///  processor.Begin( image );
    ///  // create HLSLRotateChannels filter
    ///  HLSLRotateChannels filter = new HLSLRotateChannels( );
    ///  processor.Filter = filter;
    ///  // optional: configure filter
    ///  filter.Order = RGBOrder.GBR;
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
    ///  // create HLSLRotateChannels filter
    ///  HLSLRotateChannels filter2 = new HLSLRotateChannels( );
    ///  processor2.Filter = filter2;  
    ///  // optional: configure filter
    ///  filter.Order = RGBOrder.GBR;
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
    /// <img src="img/shaderbased/HLSLRotateChannels.jpg" width="480" height="361" />
    /// </remarks>
    public sealed class HLSLRotateChannels : HLSLBaseFilter
    {
        private RGBOrder order;
        
        /// <summary>The rotation order of RGB channels.</summary>
        /// <remarks><para>Default value is set to <see cref="AForge.Imaging.ShaderBased.RGBOrder.GBR"/>.</para></remarks>
        public RGBOrder Order
        {
            get { return order; }
            set 
            {
                if (effect == null)
                    throw new ArgumentException("RGB Order" + InitMsg);

                order = value;
                effect.Parameters["order"].SetValue((int)order);
            }
        }      
        
        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLReplaceChannel"/> class.
        /// </summary>
        public HLSLRotateChannels()
            : base("HLSLRotateChannels") { }

        /// <summary>
        /// Sets the <see cref="Order"/> value to 
        /// <see cref="AForge.Imaging.ShaderBased.RGBOrder.GBR"/>.
        /// </summary>
        protected override void PostInit()
        {
            Order = RGBOrder.GBR;
        }

        /// <summary>
        /// Renders the HLSL based RotateChannels filter.
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
