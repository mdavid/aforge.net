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
    /// Grayscale image.
    /// </summary>
    /// <remarks><para>The filter Grayscales colored and Grayscale images.</para>
    /// <para>Sample usage:</para>
    /// <code>
    ///  // 1. Offline rendering
    ///  // create HLSLProcessor, used as rendering framework
    ///  HLSLProcessor processor = new HLSLProcessor();
    ///  // starts HLSLProcessor
    ///  processor.Begin( image );
    ///  // create HLSLGrayscale filter
    ///  HLSLGrayscale filter = new HLSLGrayscale( HLSLGrayscale.CommonAlgorithms.BT709 );
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
    ///  // create HLSLGrayscale filter
    ///  HLSLGrayscale filter2 = new HLSLGrayscale( 0.5f, 0.419f, 0.081f );
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
    /// <img src="img/imaging/sample1.jpg" width="480" height="361" />
    /// <para><b>Result image (RMY):</b></para>
    /// <img src="img/imaging/HLSLGrayscale.jpg" width="480" height="361" />
    /// </remarks>
    public sealed class HLSLGrayscale : HLSLBaseFilter
    {
        /// <summary>
        /// Set of predefined common grayscaling algorithms, 
        /// which have aldready initialized grayscaling coefficients.
        /// </summary>
        public enum CommonAlgorithms
        {
            /// <summary>Grayscale image using BT709 algorithm.</summary>
            BT709,
            /// <summary>Grayscale image using R-Y algorithm. </summary>
            RMY,
            /// <summary>Grayscale image using Y algorithm.</summary>
            Y
        }

        /// <summary>Portion of red channel's value to use during 
        /// conversion from RGB to grayscale. </summary>
        public float Red { get; set; }
        /// <summary>Portion of green channel's value to use during 
        /// conversion from RGB to grayscale. </summary>
        public float Green { get; set; }
        /// <summary>Portion of blue channel's value to use during 
        /// conversion from RGB to grayscale. </summary>
        public float Blue { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLGrayscale"/> class.
        /// </summary>
        /// <param name="algorithm">Predefined common grayscaling algorithm.</param>
        public HLSLGrayscale(CommonAlgorithms algorithm)
            : base("HLSLGrayscale")
        {
            switch (algorithm)
            {
                case CommonAlgorithms.BT709:
                    Red = 0.2125f;
                    Green = 0.7154f;
                    Blue = 0.0721f;
                    break;
                case CommonAlgorithms.RMY:
                    Red = 0.5f;
                    Green = 0.419f;
                    Blue = 0.081f;
                    break;
                case CommonAlgorithms.Y:
                    Red = 0.299f;
                    Green = 0.587f;
                    Blue = 0.114f;
                    break;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLGrayscale"/> class.
        /// </summary>
        /// <param name="red">Red coefficient.</param>
        /// <param name="green">Green coefficient.</param>
        /// <param name="blue">Blue coefficient.</param>
        public HLSLGrayscale(float red, float green, float blue) 
            : base("HLSLGrayscale")
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        /// <summary>
        /// Sets the HLSL based Grayscale filter.
        /// </summary>        
        internal override void RenderEffect(TextureInformation info)            
        {
            effect.Parameters["red"].SetValue(Red);
            effect.Parameters["green"].SetValue(Green);
            effect.Parameters["blue"].SetValue(Blue);
            effect.Begin();
            effect.CurrentTechnique.Passes[0].Begin();
            effect.CurrentTechnique.Passes[0].End();
            effect.End();
        }
    }
}
