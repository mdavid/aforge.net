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

    public partial class HLSLLaplaceForm : Form
    {
        HLSLLaplace filter;

        public HLSLLaplaceForm(HLSLProcessor processor)
        {
            InitializeComponent();
            this.filter = new HLSLLaplace(HLSLLaplace.Versions.Normal);
            processor.Filter = this.filter;
        }

        private void LaplaceTrackBar_ValueChanged(object sender, EventArgs e)
        {
            filter.Factor = LaplaceTrackBar.Value;
            LaplaceStrengthLabel.Text = LaplaceTrackBar.Value.ToString();
        }

        private void NormalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                filter.Version = HLSLLaplace.Versions.Normal;
        }

        private void WithDiagonalsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                filter.Version = HLSLLaplace.Versions.WithDiagonals;
        }
    }
}
