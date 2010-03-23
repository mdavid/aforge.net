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
    /// Replace RGB channel of color imgae.
    /// </summary>
    /// 
    /// <remarks><para>Replaces specified RGB channel of color image with
    /// specified grayscale image.</para></remarks>
    public sealed class HLSLReplaceChannel : HLSLBaseFilter
    {
        private short channel;
        private Texture2D channelTexture;
        /// <summary>
        /// Grayscale texture to use for channel replacement.
        /// </summary>
        /// 
        /// <remarks>
        /// <para><note>Channel texture should be 8 bpp or 16 bpp grayscale image.</note></para>
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
