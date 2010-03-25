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

    public partial class HLSLChessboardForm : Form
    {
        HLSLChessboard filter;

        public HLSLChessboardForm(HLSLProcessor processor)
        {
            InitializeComponent();
            this.filter = new HLSLChessboard();
            processor.Filter = this.filter;
        }

        private void chessBoardTrackBar_ValueChanged(object sender, EventArgs e)
        {
            filter.SquaresPerSide = chessBoardTrackBar.Value;
            chessboardNumberLabel.Text = chessBoardTrackBar.Value.ToString();
        }
    }
}
