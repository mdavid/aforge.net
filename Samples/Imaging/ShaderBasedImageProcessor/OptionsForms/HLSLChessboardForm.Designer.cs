namespace ShaderBasedImageProcessor
{
    partial class HLSLChessboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Options = new System.Windows.Forms.GroupBox();
            this.chessboardNumberLabel = new System.Windows.Forms.Label();
            this.chessboardLabel = new System.Windows.Forms.Label();
            this.chessBoardTrackBar = new System.Windows.Forms.TrackBar();
            this.Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chessBoardTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Options
            // 
            this.Options.Controls.Add(this.chessboardNumberLabel);
            this.Options.Controls.Add(this.chessboardLabel);
            this.Options.Controls.Add(this.chessBoardTrackBar);
            this.Options.Location = new System.Drawing.Point(12, 12);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(250, 500);
            this.Options.TabIndex = 1;
            this.Options.TabStop = false;
            this.Options.Text = "Options";
            // 
            // chessboardNumberLabel
            // 
            this.chessboardNumberLabel.AutoSize = true;
            this.chessboardNumberLabel.Location = new System.Drawing.Point(106, 20);
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
            this.chessboardLabel.Size = new System.Drawing.Size(93, 13);
            this.chessboardLabel.TabIndex = 2;
            this.chessboardLabel.Text = "Chessboard fields:";
            // 
            // chessBoardTrackBar
            // 
            this.chessBoardTrackBar.Location = new System.Drawing.Point(6, 36);
            this.chessBoardTrackBar.Maximum = 80;
            this.chessBoardTrackBar.Minimum = 2;
            this.chessBoardTrackBar.Name = "chessBoardTrackBar";
            this.chessBoardTrackBar.Size = new System.Drawing.Size(238, 45);
            this.chessBoardTrackBar.TabIndex = 0;
            this.chessBoardTrackBar.Value = 8;
            this.chessBoardTrackBar.ValueChanged += new System.EventHandler(this.chessBoardTrackBar_ValueChanged);
            // 
            // HLSLChessboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 522);
            this.Controls.Add(this.Options);
            this.Name = "HLSLChessboardForm";
            this.Text = "HLSLChessboardForm";
            this.Options.ResumeLayout(false);
            this.Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chessBoardTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label chessboardNumberLabel;
        private System.Windows.Forms.Label chessboardLabel;
        private System.Windows.Forms.TrackBar chessBoardTrackBar;
        public System.Windows.Forms.GroupBox Options;
    }
}