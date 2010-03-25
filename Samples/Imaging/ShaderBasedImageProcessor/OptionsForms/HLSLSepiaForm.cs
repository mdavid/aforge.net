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

    public partial class HLSLSepiaForm : Form
    {
        HLSLSepia filter;

        public HLSLSepiaForm(HLSLProcessor processor)
        {
            InitializeComponent();
            this.filter = new HLSLSepia();
            processor.Filter = this.filter;
        }

        private void QTrackBar_ValueChanged(object sender, EventArgs e)
        {
            filter.Q = QTrackBar.Value / 1000.0f;
            QValue.Text = filter.Q.ToString();
        }

        private void ITrackBar_ValueChanged(object sender, EventArgs e)
        {
            filter.I = ITrackBar.Value / 1000.0f;
            IValue.Text = filter.I.ToString();
        }
    }
}
