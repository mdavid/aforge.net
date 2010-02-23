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
            this.hLSLFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hLSLFilterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hLSLInvertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hLSLChessboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.chessBoardTrackBar = new System.Windows.Forms.TrackBar();
            this.chessboardLabel = new System.Windows.Forms.Label();
            this.chessboardNumberLabel = new System.Windows.Forms.Label();
            this.hLSLLaplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LaplaceLabel = new System.Windows.Forms.Label();
            this.LaplaceStrengthLabel = new System.Windows.Forms.Label();
            this.LaplaceTrackBar = new System.Windows.Forms.TrackBar();
            this.menuStrip.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chessBoardTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaplaceTrackBar)).BeginInit();
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
            this.hLSLFilterToolStripMenuItem,
            this.hLSLFilterToolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1044, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // hLSLFilterToolStripMenuItem
            // 
            this.hLSLFilterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.hLSLFilterToolStripMenuItem.Name = "hLSLFilterToolStripMenuItem";
            this.hLSLFilterToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.hLSLFilterToolStripMenuItem.Text = "File";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // hLSLFilterToolStripMenuItem1
            // 
            this.hLSLFilterToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noFilterToolStripMenuItem,
            this.hLSLInvertToolStripMenuItem,
            this.hLSLChessboardToolStripMenuItem,
            this.hLSLLaplaceToolStripMenuItem});
            this.hLSLFilterToolStripMenuItem1.Name = "hLSLFilterToolStripMenuItem1";
            this.hLSLFilterToolStripMenuItem1.Size = new System.Drawing.Size(75, 20);
            this.hLSLFilterToolStripMenuItem1.Text = "HLSL Filter";
            // 
            // noFilterToolStripMenuItem
            // 
            this.noFilterToolStripMenuItem.Name = "noFilterToolStripMenuItem";
            this.noFilterToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.noFilterToolStripMenuItem.Text = "No Filter";
            this.noFilterToolStripMenuItem.Click += new System.EventHandler(this.noFilterToolStripMenuItem_Click);
            // 
            // hLSLInvertToolStripMenuItem
            // 
            this.hLSLInvertToolStripMenuItem.Name = "hLSLInvertToolStripMenuItem";
            this.hLSLInvertToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.hLSLInvertToolStripMenuItem.Text = "HLSLInvert";
            this.hLSLInvertToolStripMenuItem.Click += new System.EventHandler(this.hLSLInvertToolStripMenuItem_Click);
            // 
            // hLSLChessboardToolStripMenuItem
            // 
            this.hLSLChessboardToolStripMenuItem.Name = "hLSLChessboardToolStripMenuItem";
            this.hLSLChessboardToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.hLSLChessboardToolStripMenuItem.Text = "HLSLChessboard :-)";
            this.hLSLChessboardToolStripMenuItem.Click += new System.EventHandler(this.hLSLChessboardToolStripMenuItem_Click);
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Controls.Add(this.LaplaceTrackBar);
            this.optionsGroupBox.Controls.Add(this.LaplaceStrengthLabel);
            this.optionsGroupBox.Controls.Add(this.LaplaceLabel);
            this.optionsGroupBox.Controls.Add(this.chessboardNumberLabel);
            this.optionsGroupBox.Controls.Add(this.chessboardLabel);
            this.optionsGroupBox.Controls.Add(this.chessBoardTrackBar);
            this.optionsGroupBox.Location = new System.Drawing.Point(832, 27);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(200, 245);
            this.optionsGroupBox.TabIndex = 2;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Options";
            // 
            // chessBoardTrackBar
            // 
            this.chessBoardTrackBar.Location = new System.Drawing.Point(6, 36);
            this.chessBoardTrackBar.Maximum = 80;
            this.chessBoardTrackBar.Minimum = 2;
            this.chessBoardTrackBar.Name = "chessBoardTrackBar";
            this.chessBoardTrackBar.Size = new System.Drawing.Size(177, 45);
            this.chessBoardTrackBar.TabIndex = 0;
            this.chessBoardTrackBar.Value = 8;
            this.chessBoardTrackBar.ValueChanged += new System.EventHandler(this.chessBoardTrackBar_ValueChanged);
            // 
            // chessboardLabel
            // 
            this.chessboardLabel.AutoSize = true;
            this.chessboardLabel.Location = new System.Drawing.Point(7, 20);
            this.chessboardLabel.Name = "chessboardLabel";
            this.chessboardLabel.Size = new System.Drawing.Size(66, 13);
            this.chessboardLabel.TabIndex = 1;
            this.chessboardLabel.Text = "Chessboard:";
            // 
            // chessboardNumberLabel
            // 
            this.chessboardNumberLabel.AutoSize = true;
            this.chessboardNumberLabel.Location = new System.Drawing.Point(77, 20);
            this.chessboardNumberLabel.Name = "chessboardNumberLabel";
            this.chessboardNumberLabel.Size = new System.Drawing.Size(13, 13);
            this.chessboardNumberLabel.TabIndex = 2;
            this.chessboardNumberLabel.Text = "8";
            // 
            // hLSLLaplaceToolStripMenuItem
            // 
            this.hLSLLaplaceToolStripMenuItem.Name = "hLSLLaplaceToolStripMenuItem";
            this.hLSLLaplaceToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.hLSLLaplaceToolStripMenuItem.Text = "HLSLLaplace";
            this.hLSLLaplaceToolStripMenuItem.Click += new System.EventHandler(this.hLSLLaplaceToolStripMenuItem_Click);
            // 
            // LaplaceLabel
            // 
            this.LaplaceLabel.AutoSize = true;
            this.LaplaceLabel.Location = new System.Drawing.Point(10, 74);
            this.LaplaceLabel.Name = "LaplaceLabel";
            this.LaplaceLabel.Size = new System.Drawing.Size(91, 13);
            this.LaplaceLabel.TabIndex = 3;
            this.LaplaceLabel.Text = "Laplace Strength:";
            // 
            // LaplaceStrengthLabel
            // 
            this.LaplaceStrengthLabel.AutoSize = true;
            this.LaplaceStrengthLabel.Location = new System.Drawing.Point(108, 74);
            this.LaplaceStrengthLabel.Name = "LaplaceStrengthLabel";
            this.LaplaceStrengthLabel.Size = new System.Drawing.Size(13, 13);
            this.LaplaceStrengthLabel.TabIndex = 4;
            this.LaplaceStrengthLabel.Text = "3";
            // 
            // LaplaceTrackBar
            // 
            this.LaplaceTrackBar.Location = new System.Drawing.Point(10, 91);
            this.LaplaceTrackBar.Maximum = 30;
            this.LaplaceTrackBar.Minimum = 1;
            this.LaplaceTrackBar.Name = "LaplaceTrackBar";
            this.LaplaceTrackBar.Size = new System.Drawing.Size(173, 45);
            this.LaplaceTrackBar.TabIndex = 0;
            this.LaplaceTrackBar.Value = 3;
            this.LaplaceTrackBar.ValueChanged += new System.EventHandler(this.LaplaceTrackBar_ValueChanged);
            // 
            // HLSLProcessorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 591);
            this.Controls.Add(this.optionsGroupBox);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "HLSLProcessorForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HLSLProcessorForm_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chessBoardTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaplaceTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem hLSLFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hLSLFilterToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem noFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hLSLInvertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hLSLChessboardToolStripMenuItem;
        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.TrackBar chessBoardTrackBar;
        private System.Windows.Forms.Label chessboardNumberLabel;
        private System.Windows.Forms.Label chessboardLabel;
        private System.Windows.Forms.ToolStripMenuItem hLSLLaplaceToolStripMenuItem;
        private System.Windows.Forms.Label LaplaceLabel;
        private System.Windows.Forms.Label LaplaceStrengthLabel;
        private System.Windows.Forms.TrackBar LaplaceTrackBar;

    }
}

