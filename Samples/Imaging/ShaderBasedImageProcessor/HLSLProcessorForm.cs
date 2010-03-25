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

    public partial class HLSLProcessorForm : Form
    {
        public HLSLProcessor processor;
        GroupBox Options;

        public HLSLProcessorForm()
        {            
            InitializeComponent();

            System.Resources.ResourceManager resource =
                new System.Resources.ResourceManager("ShaderBasedImageProcessor.Properties.Resources",
                System.Reflection.Assembly.GetExecutingAssembly());
            Bitmap bitmap = new Bitmap((Bitmap)resource.GetObject("dom_erfurt"));

            processor = new HLSLProcessor();
            processor.Begin(bitmap, panel);
            NoFilterToolStripMenuItem_Click(null, null); //processor.Filter = new HLSLOriginal();            
        }

        private void InitOptions(GroupBox groupBox)
        {
            Controls.Remove(Options);
            Options = groupBox;
            Options.Location = new System.Drawing.Point(832, 27);
            //Options.Visible = true;
            Controls.Add(Options);
        }

        private void HLSLProcessorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            processor.End();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {            
            saveFileDialog.Filter = "PNG (*.png)|*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = processor.RenderToBitmap();
                bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Filter ToolStrip MenuItem Events
        private void NoFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitOptions(new HLSLOriginalForm(processor).Options);
        }

        private void ChessboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitOptions(new HLSLChessboardForm(processor).Options);
        }

        private void ExtractChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitOptions(new HLSLExtractChannelForm(processor).Options);
        }

        private void InvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitOptions(new HLSLInvertForm(processor).Options);
        }

        private void GrayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitOptions(new HLSLGrayscaleForm(processor).Options);
        }

        private void LaplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitOptions(new HLSLLaplaceForm(processor).Options);
        }

        private void hLSLRotateChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitOptions(new HLSLRotateChannelsForm(processor).Options);
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitOptions(new HLSLSepiaForm(processor).Options);
        }

        private void ThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitOptions(new HLSLThresholdForm(processor).Options);
        }

        private void ThresholdRGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitOptions(new HLSLThresholdRGBForm(processor).Options);
        }
        #endregion Filter ToolStrip MenuItem Events        
    }
}
