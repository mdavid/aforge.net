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

    public partial class HLSLThresholdRGBForm : Form
    {
        HLSLThresholdRGB filter;

        public HLSLThresholdRGBForm(HLSLProcessor processor)
        {
            InitializeComponent();
            this.filter = new HLSLThresholdRGB();
            processor.Filter = this.filter;
        }

        private void RedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            filter.R = (byte)RedTrackBar.Value;
            RedValue.Text = filter.R.ToString();
        }

        private void GreenTrackBar_ValueChanged(object sender, EventArgs e)
        {
            filter.G = (byte)GreenTrackBar.Value;
            GreenValue.Text = filter.G.ToString();
        }

        private void BlueTrackBar_ValueChanged(object sender, EventArgs e)
        {
            filter.B = (byte)BlueTrackBar.Value;
            BlueValue.Text = filter.B.ToString();
        }

        private void OnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                filter.Binarization = true;
        }

        private void OffRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                filter.Binarization = false;
        }
    }
}
