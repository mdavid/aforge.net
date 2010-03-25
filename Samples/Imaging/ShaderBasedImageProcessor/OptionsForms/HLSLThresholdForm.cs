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

    public partial class HLSLThresholdForm : Form
    {
        HLSLThreshold filter;

        public HLSLThresholdForm(HLSLProcessor processor)
        {
            InitializeComponent();
            this.filter = new HLSLThreshold();
            processor.Filter = this.filter;
        }

        private void ThresholdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            filter.Threshold = (byte)ThresholdTrackBar.Value;
            RedValue.Text = filter.Threshold.ToString();
        }
    }
}
