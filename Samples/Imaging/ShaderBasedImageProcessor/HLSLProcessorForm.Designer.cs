namespace ShaderBasedImageProcessor
{
    partial class HLSLProcessorForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NoFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ChessboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtractChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InvertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LaplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThresholdRGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hLSLRotateChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel.Location = new System.Drawing.Point(12, 27);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(365, 245);
            this.panel.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.FilterToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1094, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveAsToolStripMenuItem,
            this.QuitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SaveAsToolStripMenuItem.Text = "Save As";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // QuitToolStripMenuItem
            // 
            this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
            this.QuitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.QuitToolStripMenuItem.Text = "Quit";
            this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // FilterToolStripMenuItem
            // 
            this.FilterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NoFilterToolStripMenuItem,
            this.toolStripSeparator1,
            this.ChessboardToolStripMenuItem,
            this.ExtractChannelToolStripMenuItem,
            this.GrayscaleToolStripMenuItem,
            this.InvertToolStripMenuItem,
            this.LaplaceToolStripMenuItem,
            this.sepiaToolStripMenuItem,
            this.ThresholdToolStripMenuItem,
            this.ThresholdRGBToolStripMenuItem,
            this.hLSLRotateChannelToolStripMenuItem});
            this.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem";
            this.FilterToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.FilterToolStripMenuItem.Text = "HLSL Image Filter";
            // 
            // NoFilterToolStripMenuItem
            // 
            this.NoFilterToolStripMenuItem.Name = "NoFilterToolStripMenuItem";
            this.NoFilterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.NoFilterToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.NoFilterToolStripMenuItem.Text = "No Filter";
            this.NoFilterToolStripMenuItem.Click += new System.EventHandler(this.NoFilterToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // ChessboardToolStripMenuItem
            // 
            this.ChessboardToolStripMenuItem.Name = "ChessboardToolStripMenuItem";
            this.ChessboardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.ChessboardToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ChessboardToolStripMenuItem.Text = "Chessboard :-)";
            this.ChessboardToolStripMenuItem.Click += new System.EventHandler(this.ChessboardToolStripMenuItem_Click);
            // 
            // ExtractChannelToolStripMenuItem
            // 
            this.ExtractChannelToolStripMenuItem.Name = "ExtractChannelToolStripMenuItem";
            this.ExtractChannelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.ExtractChannelToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ExtractChannelToolStripMenuItem.Text = "Extract Channel";
            this.ExtractChannelToolStripMenuItem.Click += new System.EventHandler(this.ExtractChannelToolStripMenuItem_Click);
            // 
            // GrayscaleToolStripMenuItem
            // 
            this.GrayscaleToolStripMenuItem.Name = "GrayscaleToolStripMenuItem";
            this.GrayscaleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.GrayscaleToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.GrayscaleToolStripMenuItem.Text = "Grayscale";
            this.GrayscaleToolStripMenuItem.Click += new System.EventHandler(this.GrayscaleToolStripMenuItem_Click);
            // 
            // InvertToolStripMenuItem
            // 
            this.InvertToolStripMenuItem.Name = "InvertToolStripMenuItem";
            this.InvertToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.InvertToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.InvertToolStripMenuItem.Text = "Invert";
            this.InvertToolStripMenuItem.Click += new System.EventHandler(this.InvertToolStripMenuItem_Click);
            // 
            // LaplaceToolStripMenuItem
            // 
            this.LaplaceToolStripMenuItem.Name = "LaplaceToolStripMenuItem";
            this.LaplaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.LaplaceToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.LaplaceToolStripMenuItem.Text = "Laplace";
            this.LaplaceToolStripMenuItem.Click += new System.EventHandler(this.LaplaceToolStripMenuItem_Click);
            // 
            // sepiaToolStripMenuItem
            // 
            this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            this.sepiaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.sepiaToolStripMenuItem.Text = "Sepia";
            this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.sepiaToolStripMenuItem_Click);
            // 
            // ThresholdToolStripMenuItem
            // 
            this.ThresholdToolStripMenuItem.Name = "ThresholdToolStripMenuItem";
            this.ThresholdToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.ThresholdToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ThresholdToolStripMenuItem.Text = "Threshold";
            this.ThresholdToolStripMenuItem.Click += new System.EventHandler(this.ThresholdToolStripMenuItem_Click);
            // 
            // ThresholdRGBToolStripMenuItem
            // 
            this.ThresholdRGBToolStripMenuItem.Name = "ThresholdRGBToolStripMenuItem";
            this.ThresholdRGBToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.T)));
            this.ThresholdRGBToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ThresholdRGBToolStripMenuItem.Text = "Threshold RGB";
            this.ThresholdRGBToolStripMenuItem.Click += new System.EventHandler(this.ThresholdRGBToolStripMenuItem_Click);
            // 
            // hLSLRotateChannelToolStripMenuItem
            // 
            this.hLSLRotateChannelToolStripMenuItem.Name = "hLSLRotateChannelToolStripMenuItem";
            this.hLSLRotateChannelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.hLSLRotateChannelToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.hLSLRotateChannelToolStripMenuItem.Text = "HLSLRotateChannel";
            this.hLSLRotateChannelToolStripMenuItem.Click += new System.EventHandler(this.hLSLRotateChannelToolStripMenuItem_Click);
            // 
            // HLSLProcessorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 591);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "HLSLProcessorForm";
            this.Text = "Aforge.NET HLSL Based Image Processor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HLSLProcessorForm_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NoFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InvertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChessboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LaplaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GrayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThresholdRGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExtractChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hLSLRotateChannelToolStripMenuItem;

    }
}

