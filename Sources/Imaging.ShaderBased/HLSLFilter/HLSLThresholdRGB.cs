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
    /// Threshold filter for every rgb channel with or without binarization.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// The filter does rgb-threshold filtering using specified threshold values for every channel. 
    /// Every channel with intensity equal or lower than its threshold value is converted to black 
    /// channel (value 0). All other channels are converted to white channels (value 255), 
    /// when binarization is set. Otherwise the channels don't change.
    /// </para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    ///  // 1. Offline rendering
    ///  // create HLSLProcessor, used as rendering framework
    ///  HLSLProcessor processor = new HLSLProcessor();
    ///  // starts HLSLProcessor
    ///  processor.Begin( image );
    ///  // create HLSLThresholdRGB filter
    ///  HLSLThresholdRGB filter = new HLSLThresholdRGB( );
    ///  processor.Filter = filter;
    ///  // optional: configure filter
    ///  filter.R = 220;
    ///  filter.G = 80;
    ///  filter.B = 60;
    ///  filter.Binarization = true;
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
    ///  // create HLSLThresholdRGB filter
    ///  HLSLThresholdRGB filter2 = new HLSLThresholdRGB( );
    ///  processor2.Filter = filter2; 
    ///  // optional: configure filter
    ///  filter2.R = 220;
    ///  filter2.G = 80;
    ///  filter2.B = 60;
    ///  filter2.Binarization = false;
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
    /// <para><b>Result image (with binarization):</b></para>
    /// <img src="img/shaderbased/HLSLThresholdRGBBinarization.jpg" width="480" height="361" />
    /// <para><b>Result image (without binarization):</b></para>
    /// <img src="img/shaderbased/HLSLThresholdRGB.jpg" width="480" height="361" />
    /// </remarks>
    public sealed class HLSLThresholdRGB : HLSLBaseFilter
    {
        bool binarization;
        private byte r;
        private byte g;
        private byte b;

        /// <summary>If true filter does channel binairzation.</summary>
        /// <remarks><para>Default value is set to false.</para></remarks>
        public bool Binarization
        {
            get { return binarization; }
            set
            {
                if (effect == null)
                    throw new ArgumentException("Binarization" + InitMsg);

                binarization = value;
                effect.Parameters["binarization"].SetValue(binarization);
            }
        }

        /// <summary>Threshold value for channel red.</summary>
        /// <remarks><para>Default value is set to 100.</para></remarks>
        public byte R
        {
            get { return r; }
            set
            {
                if (effect == null)
                    throw new ArgumentException("Threshold for channel red" + InitMsg);

                r = value;
                effect.Parameters["r"].SetValue(r);
            }
        }

        /// <summary>Threshold value for channel green.</summary>
        /// <remarks><para>Default value is set to 100.</para></remarks>
        public byte G
        {
            get { return g; }
            set
            {
                if (effect == null)
                    throw new ArgumentException("Threshold for channel green" + InitMsg);

                g = value;
                effect.Parameters["g"].SetValue(g);
            }
        }

        /// <summary>Threshold value for channel blue.</summary>
        /// <remarks><para>Default value is set to 100.</para></remarks>
        public byte B
        {
            get { return b; }
            set
            {
                if (effect == null)
                    throw new ArgumentException("Threshold for channel blue" + InitMsg);

                b = value;
                effect.Parameters["b"].SetValue(b);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLThreshold"/> class.
        /// </summary>
        public HLSLThresholdRGB()
            : base("HLSLThresholdRGB") { }

        /// <summary>
        /// Initializes threshold values.
        /// </summary>
        protected override void PostInit()
        {
            R = 100;
            G = 100;
            B = 100;
        }

        /// <summary>
        /// Renders the HLSLThresholdRGB effect.
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
