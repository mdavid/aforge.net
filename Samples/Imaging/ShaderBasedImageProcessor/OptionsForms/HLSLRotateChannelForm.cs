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

    public partial class HLSLRotateChannelsForm : Form
    {
        HLSLRotateChannels filter;

        public HLSLRotateChannelsForm(HLSLProcessor processor)
        {
            InitializeComponent();
            this.filter = new HLSLRotateChannels();
            processor.Filter = this.filter;
        }

        private void RGBRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                filter.Order = RGBOrder.RGB;
        }

        private void RBGRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                filter.Order = RGBOrder.RBG;
        }

        private void BRGRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                filter.Order = RGBOrder.BRG;
        }

        private void BGRRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                filter.Order = RGBOrder.BGR;
        }

        private void GBRRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                filter.Order = RGBOrder.GBR;
        }

        private void GRBRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                filter.Order = RGBOrder.GRB;
        }
    }
}
