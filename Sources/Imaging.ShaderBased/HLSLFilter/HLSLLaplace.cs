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
    /// Discrete laplace operator.
    /// </summary>
    /// <remarks>
    /// <para>Discrete laplace operator is often used in image processing e.g. in 
    /// edge detection and motion estimation applications. The discrete laplacian is 
    /// defined as the sum of the second derivatives and calculated as sum of 
    /// differences over the nearest neighbours of the central pixel.
    /// </para>
    /// <para>Therefore two versions of kernels exists:</para>
    /// <code lang="none">
    ///    V1         V2
    /// 0  1  0     1  1  1
    /// 1 -4  1     1 -8  1
    /// 0  1  0     1  1  1
    /// </code>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    ///  // 1. Offline rendering
    ///  // create HLSLProcessor, used as rendering framework
    ///  HLSLProcessor processor = new HLSLProcessor();
    ///  // starts HLSLProcessor
    ///  processor.Begin( image );
    ///  // create HLSLLaplace filter
    ///  HLSLLaplace filter = new HLSLLaplace( HLSLLaplace.Versions.WithDiagonals );
    ///  // optional: configure filter
    ///  filter.Factor = 3.0f;
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
    ///  // create HLSLLaplace filter
    ///  HLSLLaplace filter2 = new HLSLLaplace( HLSLLaplace.Versions.WithDiagonals, 1.0f );
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
    /// <img src="img/imaging/HLSLLaplace.jpg" width="480" height="361" />
    /// </remarks>
    public sealed class HLSLLaplace : HLSLBaseFilter
    {
        /// <summary>Two different versions of Laplace filter.</summary>
        public enum Versions
        {
            /// <summary>Normal kernel without diagonal neighbours.</summary>
            Normal,
            /// <summary>Kernel including diagonal neighbours.</summary>
            WithDiagonals
        }

        /// <summary>The version of Laplace filter.</summary>
        public Versions Version { get; set; }

        /// <summary>
        /// Multiplication factor for stronger lines in edge image.
        /// </summary>
        /// <remarks>Default value: 1.0</remarks>
        public float Factor { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLLaplace"/> class.
        /// </summary>
        /// <param name="version">The version of Laplace filter.</param>
        public HLSLLaplace(Versions version)
            : base("HLSLLaplace")
        {
            Factor = 1.0f;
            Version = version;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HLSLLaplace"/> class.
        /// </summary>
        /// <param name="version">The version of Laplace filter.</param>
        /// <param name="factor">Multiplication factor for stronger lines in edge image.</param>
        public HLSLLaplace(Versions version, float factor)
            : base("HLSLLaplace")
        {
            Factor = factor;
            Version = version;
        }

        /// <summary>
        /// Sets the HLSL based invert filter.
        /// </summary>        
        internal override void RenderEffect(TextureInformation info)
        {
            effect.Parameters["version"].SetValue((int)Version);
            effect.Parameters["factor"].SetValue(Factor);
            effect.Parameters["width"].SetValue(info.Width);
            effect.Parameters["height"].SetValue(info.Height);
            effect.Begin();
            effect.CurrentTechnique.Passes[0].Begin();
            effect.CurrentTechnique.Passes[0].End();
            effect.End();
        }
    }
}
