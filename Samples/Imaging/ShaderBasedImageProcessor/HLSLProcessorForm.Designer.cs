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
            this.hLSLLaplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.LaplaceTrackBar = new System.Windows.Forms.TrackBar();
            this.LaplaceStrengthLabel = new System.Windows.Forms.Label();
            this.LaplaceLabel = new System.Windows.Forms.Label();
            this.chessboardNumberLabel = new System.Windows.Forms.Label();
            this.chessboardLabel = new System.Windows.Forms.Label();
            this.chessBoardTrackBar = new System.Windows.Forms.TrackBar();
            this.hLSLGrayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrayscaleLabel = new System.Windows.Forms.Label();
            this.GrayscaleRedTrackBar = new System.Windows.Forms.TrackBar();
            this.GrayscaleRedValue = new System.Windows.Forms.Label();
            this.GrayscaleRed = new System.Windows.Forms.Label();
            this.GrayscaleGreen = new System.Windows.Forms.Label();
            this.GrayscaleGreenValue = new System.Windows.Forms.Label();
            this.GrayscaleGreenTrackBar = new System.Windows.Forms.TrackBar();
            this.GrayscaleBlue = new System.Windows.Forms.Label();
            this.GrayscaleBlueValue = new System.Windows.Forms.Label();
            this.GrayscaleBlueTrackBar = new System.Windows.Forms.TrackBar();
            this.menuStrip.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LaplaceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chessBoardTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleRedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleGreenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleBlueTrackBar)).BeginInit();
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
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // hLSLFilterToolStripMenuItem1
            // 
            this.hLSLFilterToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noFilterToolStripMenuItem,
            this.hLSLInvertToolStripMenuItem,
            this.hLSLChessboardToolStripMenuItem,
            this.hLSLLaplaceToolStripMenuItem,
            this.hLSLGrayscaleToolStripMenuItem});
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
            // hLSLLaplaceToolStripMenuItem
            // 
            this.hLSLLaplaceToolStripMenuItem.Name = "hLSLLaplaceToolStripMenuItem";
            this.hLSLLaplaceToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.hLSLLaplaceToolStripMenuItem.Text = "HLSLLaplace";
            this.hLSLLaplaceToolStripMenuItem.Click += new System.EventHandler(this.hLSLLaplaceToolStripMenuItem_Click);
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Controls.Add(this.GrayscaleBlue);
            this.optionsGroupBox.Controls.Add(this.GrayscaleBlueValue);
            this.optionsGroupBox.Controls.Add(this.GrayscaleBlueTrackBar);
            this.optionsGroupBox.Controls.Add(this.GrayscaleGreen);
            this.optionsGroupBox.Controls.Add(this.GrayscaleGreenValue);
            this.optionsGroupBox.Controls.Add(this.GrayscaleGreenTrackBar);
            this.optionsGroupBox.Controls.Add(this.GrayscaleRed);
            this.optionsGroupBox.Controls.Add(this.GrayscaleRedValue);
            this.optionsGroupBox.Controls.Add(this.GrayscaleRedTrackBar);
            this.optionsGroupBox.Controls.Add(this.GrayscaleLabel);
            this.optionsGroupBox.Controls.Add(this.LaplaceTrackBar);
            this.optionsGroupBox.Controls.Add(this.LaplaceStrengthLabel);
            this.optionsGroupBox.Controls.Add(this.LaplaceLabel);
            this.optionsGroupBox.Controls.Add(this.chessboardNumberLabel);
            this.optionsGroupBox.Controls.Add(this.chessboardLabel);
            this.optionsGroupBox.Controls.Add(this.chessBoardTrackBar);
            this.optionsGroupBox.Location = new System.Drawing.Point(832, 27);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(200, 355);
            this.optionsGroupBox.TabIndex = 2;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Options";
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
            // LaplaceStrengthLabel
            // 
            this.LaplaceStrengthLabel.AutoSize = true;
            this.LaplaceStrengthLabel.Location = new System.Drawing.Point(108, 74);
            this.LaplaceStrengthLabel.Name = "LaplaceStrengthLabel";
            this.LaplaceStrengthLabel.Size = new System.Drawing.Size(13, 13);
            this.LaplaceStrengthLabel.TabIndex = 4;
            this.LaplaceStrengthLabel.Text = "3";
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
            // chessboardNumberLabel
            // 
            this.chessboardNumberLabel.AutoSize = true;
            this.chessboardNumberLabel.Location = new System.Drawing.Point(77, 20);
            this.chessboardNumberLabel.Name = "chessboardNumberLabel";
            this.chessboardNumberLabel.Size = new System.Drawing.Size(13, 13);
            this.chessboardNumberLabel.TabIndex = 2;
            this.chessboardNumberLabel.Text = "8";
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
            // hLSLGrayscaleToolStripMenuItem
            // 
            this.hLSLGrayscaleToolStripMenuItem.Name = "hLSLGrayscaleToolStripMenuItem";
            this.hLSLGrayscaleToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.hLSLGrayscaleToolStripMenuItem.Text = "HLSLGrayscale";
            this.hLSLGrayscaleToolStripMenuItem.Click += new System.EventHandler(this.hLSLGrayscaleToolStripMenuItem_Click);
            // 
            // GrayscaleLabel
            // 
            this.GrayscaleLabel.AutoSize = true;
            this.GrayscaleLabel.Location = new System.Drawing.Point(10, 139);
            this.GrayscaleLabel.Name = "GrayscaleLabel";
            this.GrayscaleLabel.Size = new System.Drawing.Size(54, 13);
            this.GrayscaleLabel.TabIndex = 5;
            this.GrayscaleLabel.Text = "Grayscale";
            // 
            // GrayscaleRedTrackBar
            // 
            this.GrayscaleRedTrackBar.Location = new System.Drawing.Point(31, 160);
            this.GrayscaleRedTrackBar.Maximum = 800;
            this.GrayscaleRedTrackBar.Minimum = 1;
            this.GrayscaleRedTrackBar.Name = "GrayscaleRedTrackBar";
            this.GrayscaleRedTrackBar.Size = new System.Drawing.Size(118, 45);
            this.GrayscaleRedTrackBar.TabIndex = 6;
            this.GrayscaleRedTrackBar.TickFrequency = 100;
            this.GrayscaleRedTrackBar.Value = 213;
            this.GrayscaleRedTrackBar.ValueChanged += new System.EventHandler(this.GrayscaleRedTrackBar_ValueChanged);
            // 
            // GrayscaleRedValue
            // 
            this.GrayscaleRedValue.AutoSize = true;
            this.GrayscaleRedValue.Location = new System.Drawing.Point(155, 160);
            this.GrayscaleRedValue.Name = "GrayscaleRedValue";
            this.GrayscaleRedValue.Size = new System.Drawing.Size(34, 13);
            this.GrayscaleRedValue.TabIndex = 7;
            this.GrayscaleRedValue.Text = "0.213";
            // 
            // GrayscaleRed
            // 
            this.GrayscaleRed.AutoSize = true;
            this.GrayscaleRed.Location = new System.Drawing.Point(10, 160);
            this.GrayscaleRed.Name = "GrayscaleRed";
            this.GrayscaleRed.Size = new System.Drawing.Size(15, 13);
            this.GrayscaleRed.TabIndex = 8;
            this.GrayscaleRed.Text = "R";
            // 
            // GrayscaleGreen
            // 
            this.GrayscaleGreen.AutoSize = true;
            this.GrayscaleGreen.Location = new System.Drawing.Point(10, 211);
            this.GrayscaleGreen.Name = "GrayscaleGreen";
            this.GrayscaleGreen.Size = new System.Drawing.Size(15, 13);
            this.GrayscaleGreen.TabIndex = 11;
            this.GrayscaleGreen.Text = "G";
            // 
            // GrayscaleGreenValue
            // 
            this.GrayscaleGreenValue.AutoSize = true;
            this.GrayscaleGreenValue.Location = new System.Drawing.Point(155, 211);
            this.GrayscaleGreenValue.Name = "GrayscaleGreenValue";
            this.GrayscaleGreenValue.Size = new System.Drawing.Size(34, 13);
            this.GrayscaleGreenValue.TabIndex = 10;
            this.GrayscaleGreenValue.Text = "0.715";
            // 
            // GrayscaleGreenTrackBar
            // 
            this.GrayscaleGreenTrackBar.Location = new System.Drawing.Point(31, 211);
            this.GrayscaleGreenTrackBar.Maximum = 800;
            this.GrayscaleGreenTrackBar.Minimum = 1;
            this.GrayscaleGreenTrackBar.Name = "GrayscaleGreenTrackBar";
            this.GrayscaleGreenTrackBar.Size = new System.Drawing.Size(118, 45);
            this.GrayscaleGreenTrackBar.TabIndex = 9;
            this.GrayscaleGreenTrackBar.TickFrequency = 100;
            this.GrayscaleGreenTrackBar.Value = 715;
            this.GrayscaleGreenTrackBar.ValueChanged += new System.EventHandler(this.GrayscaleGreenTrackBar_ValueChanged);
            // 
            // GrayscaleBlue
            // 
            this.GrayscaleBlue.AutoSize = true;
            this.GrayscaleBlue.Location = new System.Drawing.Point(10, 262);
            this.GrayscaleBlue.Name = "GrayscaleBlue";
            this.GrayscaleBlue.Size = new System.Drawing.Size(14, 13);
            this.GrayscaleBlue.TabIndex = 14;
            this.GrayscaleBlue.Text = "B";
            // 
            // GrayscaleBlueValue
            // 
            this.GrayscaleBlueValue.AutoSize = true;
            this.GrayscaleBlueValue.Location = new System.Drawing.Point(155, 262);
            this.GrayscaleBlueValue.Name = "GrayscaleBlueValue";
            this.GrayscaleBlueValue.Size = new System.Drawing.Size(34, 13);
            this.GrayscaleBlueValue.TabIndex = 13;
            this.GrayscaleBlueValue.Text = "0.072";
            // 
            // GrayscaleBlueTrackBar
            // 
            this.GrayscaleBlueTrackBar.Location = new System.Drawing.Point(31, 262);
            this.GrayscaleBlueTrackBar.Maximum = 800;
            this.GrayscaleBlueTrackBar.Minimum = 1;
            this.GrayscaleBlueTrackBar.Name = "GrayscaleBlueTrackBar";
            this.GrayscaleBlueTrackBar.Size = new System.Drawing.Size(118, 45);
            this.GrayscaleBlueTrackBar.TabIndex = 12;
            this.GrayscaleBlueTrackBar.TickFrequency = 100;
            this.GrayscaleBlueTrackBar.Value = 72;
            this.GrayscaleBlueTrackBar.ValueChanged += new System.EventHandler(this.GrayscaleBlueTrackBar_ValueChanged);
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
            ((System.ComponentModel.ISupportInitialize)(this.LaplaceTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chessBoardTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleRedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleGreenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleBlueTrackBar)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem hLSLGrayscaleToolStripMenuItem;
        private System.Windows.Forms.Label GrayscaleRedValue;
        private System.Windows.Forms.TrackBar GrayscaleRedTrackBar;
        private System.Windows.Forms.Label GrayscaleLabel;
        private System.Windows.Forms.Label GrayscaleGreen;
        private System.Windows.Forms.Label GrayscaleGreenValue;
        private System.Windows.Forms.TrackBar GrayscaleGreenTrackBar;
        private System.Windows.Forms.Label GrayscaleRed;
        private System.Windows.Forms.Label GrayscaleBlue;
        private System.Windows.Forms.Label GrayscaleBlueValue;
        private System.Windows.Forms.TrackBar GrayscaleBlueTrackBar;

    }
}

