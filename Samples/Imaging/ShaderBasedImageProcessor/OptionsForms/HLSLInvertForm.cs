// AForge Shader-Based Image Processing Library demo
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Frank Nagl, 2009-2010
// admin@franknagl.de
//
namespace ShaderBasedImageProcessor
{
    using System.Windows.Forms;
    using AForge.Imaging.ShaderBased.HLSLFilter;
    using AForge.Imaging.ShaderBased;

    public partial class HLSLInvertForm : Form
    {
        HLSLInvert filter;

        public HLSLInvertForm(HLSLProcessor processor)
        {
            InitializeComponent();
            this.filter = new HLSLInvert();
            processor.Filter = this.filter;
        }
    }
}
