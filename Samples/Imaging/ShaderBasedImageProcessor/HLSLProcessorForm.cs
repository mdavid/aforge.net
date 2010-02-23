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
    using System;
    using AForge.Imaging.ShaderBased;
    using System.Drawing.Imaging;
    using System.Drawing;
    using AForge.Imaging.ShaderBased.HLSLFilter;

    public partial class HLSLProcessorForm : Form
    {
        public HLSLProcessor processor;        
        public HLSLProcessorForm()
        {            
            InitializeComponent();
            DisableOptions();

            System.Resources.ResourceManager resource =
                new System.Resources.ResourceManager("ShaderBasedImageProcessor.Properties.Resources",
                System.Reflection.Assembly.GetExecutingAssembly());
            Bitmap bitmap = new Bitmap((Bitmap)resource.GetObject("dom_erfurt"));

            processor = new HLSLProcessor();
            processor.Begin(bitmap, panel);
        }

        private void DisableOptions()
        {
            chessBoardTrackBar.Value = 8;
            chessBoardTrackBar.Enabled = false;
            chessboardNumberLabel.Enabled = false;
            chessboardLabel.Enabled = false;

            LaplaceTrackBar.Value = 3;
            LaplaceLabel.Enabled = false;
            LaplaceStrengthLabel.Enabled = false;
            LaplaceTrackBar.Enabled = false;
        }

        private void HLSLProcessorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            processor.End();
        }

        private void saveAsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {            
            saveFileDialog.Filter = "PNG (*.png)|*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = processor.RenderToBitmap();
                bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region toolstrip menu events
        private void noFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableOptions();
            processor.Filter = new HLSLOriginal();
        }

        private void hLSLInvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableOptions();
            processor.Filter = new HLSLInvert();
        }

        private void hLSLChessboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableOptions();
            chessBoardTrackBar.Enabled = true;
            chessboardNumberLabel.Enabled = true;
            chessboardLabel.Enabled = true;
            processor.Filter = new HLSLChessboard();
        }

        private void hLSLLaplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableOptions();
            LaplaceLabel.Enabled = true;
            LaplaceStrengthLabel.Enabled = true;
            LaplaceTrackBar.Enabled = true;
            processor.Filter = new HLSLLaplace();
        }

        #endregion toolstrip menu events

        #region trackbar events
        private void LaplaceTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (processor.Filter is HLSLLaplace)
            {
                HLSLLaplace laplaceFilter;
                laplaceFilter = (HLSLLaplace)processor.Filter;
                laplaceFilter.Factor = LaplaceTrackBar.Value;
                LaplaceStrengthLabel.Text = LaplaceTrackBar.Value.ToString();
            }
        }

        private void chessBoardTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (processor.Filter is HLSLChessboard)
            {
                HLSLChessboard chessFilter;
                chessFilter = (HLSLChessboard)processor.Filter;
                chessFilter.SquaresPerSide = chessBoardTrackBar.Value;
                chessboardNumberLabel.Text = chessBoardTrackBar.Value.ToString();
            }
        }
        #endregion trackbar events
    }
}
