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

            GrayscaleRedTrackBar.Value = 213;
            GrayscaleGreenTrackBar.Value = 715;
            GrayscaleBlueTrackBar.Value = 72;
            GrayscaleBlue.Enabled = false;
            GrayscaleBlueTrackBar.Enabled = false;
            GrayscaleBlueValue.Enabled = false;
            GrayscaleGreen.Enabled = false;
            GrayscaleGreenTrackBar.Enabled = false;
            GrayscaleGreenValue.Enabled = false;
            GrayscaleRed.Enabled = false;
            GrayscaleRedTrackBar.Enabled = false;
            GrayscaleRedValue.Enabled = false;
            GrayscaleLabel.Enabled = false;

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
            processor.Filter = new HLSLLaplace(3.0f);
        }

        private void hLSLGrayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableOptions();
            GrayscaleBlue.Enabled = true;
            GrayscaleBlueTrackBar.Enabled = true;
            GrayscaleBlueValue.Enabled = true;
            GrayscaleGreen.Enabled = true;
            GrayscaleGreenTrackBar.Enabled = true;
            GrayscaleGreenValue.Enabled = true;
            GrayscaleRed.Enabled = true;
            GrayscaleRedTrackBar.Enabled = true;
            GrayscaleRedValue.Enabled = true;
            GrayscaleLabel.Enabled = true;
            processor.Filter = new HLSLGrayscale(0.213f, 0.715f, 0.072f);
        }
        #endregion toolstrip menu events

        #region trackbar events
        private void LaplaceTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (processor.Filter is HLSLLaplace)
            {
                HLSLLaplace filter;
                filter = (HLSLLaplace)processor.Filter;
                filter.Factor = LaplaceTrackBar.Value;
                LaplaceStrengthLabel.Text = LaplaceTrackBar.Value.ToString();
            }
        }

        private void chessBoardTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (processor.Filter is HLSLChessboard)
            {
                HLSLChessboard filter;
                filter = (HLSLChessboard)processor.Filter;
                filter.SquaresPerSide = chessBoardTrackBar.Value;
                chessboardNumberLabel.Text = chessBoardTrackBar.Value.ToString();
            }
        }        
        
        private void GrayscaleRedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (processor.Filter is HLSLGrayscale)
            {
                HLSLGrayscale filter;
                filter = (HLSLGrayscale)processor.Filter;
                filter.Red = GrayscaleRedTrackBar.Value / 1000.0f;
                GrayscaleRedValue.Text = filter.Red.ToString();
            }
        }        

        private void GrayscaleGreenTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (processor.Filter is HLSLGrayscale)
            {
                HLSLGrayscale filter;
                filter = (HLSLGrayscale)processor.Filter;
                filter.Green = GrayscaleGreenTrackBar.Value / 1000.0f;
                GrayscaleGreenValue.Text = filter.Green.ToString();
            }
        }

        private void GrayscaleBlueTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (processor.Filter is HLSLGrayscale)
            {
                HLSLGrayscale filter;
                filter = (HLSLGrayscale)processor.Filter;
                filter.Blue = GrayscaleBlueTrackBar.Value / 1000.0f;
                GrayscaleBlueValue.Text = filter.Blue.ToString();
            }
        }
        #endregion trackbar events
    }
}
