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
    /// Replace RGB channel of color image.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>Replaces specified RGB channel of color image with
    /// specified grayscale image.</para>
    /// 
    /// <para>The filter is quite useful in conjunction with <see cref="HLSLExtractChannel"/> filter
    /// (however may be used alone in some cases). Using the <see cref="HLSLExtractChannel"/> filter
    /// it is possible to extract one of RGB channel, perform some image processing with it and then
    /// put it back into the original color image.</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    /// // create HLSLProcessor, used as rendering framework
    /// HLSLProcessor processor = new HLSLProcessor();
    /// // starts HLSLProcessor
    /// processor.Begin(image);
    /// // create HLSLExtractChannel filter
    /// HLSLExtractChannel extractChannel = new HLSLExtractChannel();
    /// processor.Filter = extractChannel;
    /// // optional: configure filter
    /// extractChannel.Channel = RGB.R;
    /// // get result texture
    /// Texture2D texture = processor.RenderToTexture();
    /// processor.ChangeTexture(texture);
    /// // create HLSLThreshold filter
    /// HLSLThreshold threshold = new HLSLThreshold();
    /// processor.Filter = threshold;
    /// // optional: configure filter
    /// threshold.Threshold = 230;
    /// texture = processor.RenderToTexture();
    /// // reset source texture to original image
    /// processor.ResetTexture();
    /// // create HLSLReplaceChannel filter
    /// HLSLReplaceChannel replaceChannel = new HLSLReplaceChannel();
    /// processor.Filter = replaceChannel;
    /// // optional: configure filter
    /// replaceChannel.Channel = RGB.R;
    /// replaceChannel.ChannelTexture = texture;
    /// // apply the filter
    /// Bitmap resultImage = processor.RenderToBitmap();
    /// Texture2D resultTexture = processor.RenderToTexture( );
    /// processor.End();
    /// </code>
    /// 
    /// <para><b>Initial image:</b></para>
    /// <img src="img/shaderbased/sample1.jpg" width="480" height="361" />
    /// <para><b>Result image:</b></para>
    /// <img src="img/shaderbased/HLSLReplaceChannel.jpg" width="480" height="361" />
    /// </remarks>
    public sealed class HLSLReplaceChannel : HLSLBaseFilter
    {
        private short channel;
        private Texture2D channelTexture;
        /// <summary>
        /// Grayscale texture to use for channel replacement.
        /// </summary>
        /// 
        /// <remarks>
        /// <para><note>Channel texture should be grayscale image.</note></para>
        /// </remarks>      
        public Texture2D ChannelTexture
        {
            get { return channelTexture; }
            set 
            {
                channelTexture = value;                
                effect.Parameters["channelImage"].SetValue(value);                
            }
        }
        
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
        public HLSLReplaceChannel()
            : base("HLSLReplaceChannel") { }

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
