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

    public partial class HLSLExtractChannelForm : Form
    {
        HLSLExtractChannel filter;

        public HLSLExtractChannelForm(HLSLProcessor processor)
        {
            InitializeComponent();
            this.filter = new HLSLExtractChannel();
            processor.Filter = this.filter;
        }

        private void RedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                filter.Channel = RGB.R;
        }

        private void GreenRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                filter.Channel = RGB.G;
        }

        private void BlueRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                filter.Channel = RGB.B;
        }
    }
}
