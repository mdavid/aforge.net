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
    using System;

    public partial class HLSLGrayscaleForm : Form
    {
        HLSLGrayscale filter;

        public HLSLGrayscaleForm(HLSLProcessor processor)
        {
            InitializeComponent();
            this.filter = new HLSLGrayscale(HLSLGrayscale.CommonAlgorithms.BT709);
            processor.Filter = this.filter;
        }

        private void GrayscaleRedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            filter.Red = GrayscaleRedTrackBar.Value / 1000.0f;
            GrayscaleRedValue.Text = filter.Red.ToString();
        }

        private void GrayscaleGreenTrackBar_ValueChanged(object sender, EventArgs e)
        {
            filter.Green = GrayscaleGreenTrackBar.Value / 1000.0f;
            GrayscaleGreenValue.Text = filter.Green.ToString();
        }

        private void GrayscaleBlueTrackBar_ValueChanged(object sender, EventArgs e)
        {
            filter.Blue = GrayscaleBlueTrackBar.Value / 1000.0f;
            GrayscaleBlueValue.Text = filter.Blue.ToString();
        }
    }
}
