namespace ShaderBasedImageProcessor
{
    partial class HLSLGrayscaleForm
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
            this.GrayscaleBlue = new System.Windows.Forms.Label();
            this.GrayscaleBlueValue = new System.Windows.Forms.Label();
            this.GrayscaleBlueTrackBar = new System.Windows.Forms.TrackBar();
            this.GrayscaleGreen = new System.Windows.Forms.Label();
            this.GrayscaleGreenValue = new System.Windows.Forms.Label();
            this.GrayscaleGreenTrackBar = new System.Windows.Forms.TrackBar();
            this.GrayscaleRed = new System.Windows.Forms.Label();
            this.GrayscaleRedValue = new System.Windows.Forms.Label();
            this.GrayscaleRedTrackBar = new System.Windows.Forms.TrackBar();
            this.GrayscaleLabel = new System.Windows.Forms.Label();
            this.Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleBlueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleGreenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleRedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Options
            // 
            this.Options.Controls.Add(this.GrayscaleBlue);
            this.Options.Controls.Add(this.GrayscaleBlueValue);
            this.Options.Controls.Add(this.GrayscaleBlueTrackBar);
            this.Options.Controls.Add(this.GrayscaleGreen);
            this.Options.Controls.Add(this.GrayscaleGreenValue);
            this.Options.Controls.Add(this.GrayscaleGreenTrackBar);
            this.Options.Controls.Add(this.GrayscaleRed);
            this.Options.Controls.Add(this.GrayscaleRedValue);
            this.Options.Controls.Add(this.GrayscaleRedTrackBar);
            this.Options.Controls.Add(this.GrayscaleLabel);
            this.Options.Location = new System.Drawing.Point(12, 12);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(250, 500);
            this.Options.TabIndex = 3;
            this.Options.TabStop = false;
            this.Options.Text = "Options";
            // 
            // GrayscaleBlue
            // 
            this.GrayscaleBlue.AutoSize = true;
            this.GrayscaleBlue.Location = new System.Drawing.Point(6, 139);
            this.GrayscaleBlue.Name = "GrayscaleBlue";
            this.GrayscaleBlue.Size = new System.Drawing.Size(14, 13);
            this.GrayscaleBlue.TabIndex = 10;
            this.GrayscaleBlue.Text = "B";
            // 
            // GrayscaleBlueValue
            // 
            this.GrayscaleBlueValue.AutoSize = true;
            this.GrayscaleBlueValue.Location = new System.Drawing.Point(208, 139);
            this.GrayscaleBlueValue.Name = "GrayscaleBlueValue";
            this.GrayscaleBlueValue.Size = new System.Drawing.Size(34, 13);
            this.GrayscaleBlueValue.TabIndex = 7;
            this.GrayscaleBlueValue.Text = "0.072";
            // 
            // GrayscaleBlueTrackBar
            // 
            this.GrayscaleBlueTrackBar.Location = new System.Drawing.Point(27, 139);
            this.GrayscaleBlueTrackBar.Maximum = 800;
            this.GrayscaleBlueTrackBar.Minimum = 1;
            this.GrayscaleBlueTrackBar.Name = "GrayscaleBlueTrackBar";
            this.GrayscaleBlueTrackBar.Size = new System.Drawing.Size(175, 45);
            this.GrayscaleBlueTrackBar.TabIndex = 2;
            this.GrayscaleBlueTrackBar.TickFrequency = 100;
            this.GrayscaleBlueTrackBar.Value = 72;
            this.GrayscaleBlueTrackBar.ValueChanged += new System.EventHandler(this.GrayscaleBlueTrackBar_ValueChanged);
            // 
            // GrayscaleGreen
            // 
            this.GrayscaleGreen.AutoSize = true;
            this.GrayscaleGreen.Location = new System.Drawing.Point(6, 88);
            this.GrayscaleGreen.Name = "GrayscaleGreen";
            this.GrayscaleGreen.Size = new System.Drawing.Size(15, 13);
            this.GrayscaleGreen.TabIndex = 9;
            this.GrayscaleGreen.Text = "G";
            // 
            // GrayscaleGreenValue
            // 
            this.GrayscaleGreenValue.AutoSize = true;
            this.GrayscaleGreenValue.Location = new System.Drawing.Point(208, 88);
            this.GrayscaleGreenValue.Name = "GrayscaleGreenValue";
            this.GrayscaleGreenValue.Size = new System.Drawing.Size(34, 13);
            this.GrayscaleGreenValue.TabIndex = 6;
            this.GrayscaleGreenValue.Text = "0.715";
            // 
            // GrayscaleGreenTrackBar
            // 
            this.GrayscaleGreenTrackBar.Location = new System.Drawing.Point(27, 88);
            this.GrayscaleGreenTrackBar.Maximum = 800;
            this.GrayscaleGreenTrackBar.Minimum = 1;
            this.GrayscaleGreenTrackBar.Name = "GrayscaleGreenTrackBar";
            this.GrayscaleGreenTrackBar.Size = new System.Drawing.Size(175, 45);
            this.GrayscaleGreenTrackBar.TabIndex = 1;
            this.GrayscaleGreenTrackBar.TickFrequency = 100;
            this.GrayscaleGreenTrackBar.Value = 715;
            this.GrayscaleGreenTrackBar.ValueChanged += new System.EventHandler(this.GrayscaleGreenTrackBar_ValueChanged);
            // 
            // GrayscaleRed
            // 
            this.GrayscaleRed.AutoSize = true;
            this.GrayscaleRed.Location = new System.Drawing.Point(6, 37);
            this.GrayscaleRed.Name = "GrayscaleRed";
            this.GrayscaleRed.Size = new System.Drawing.Size(15, 13);
            this.GrayscaleRed.TabIndex = 8;
            this.GrayscaleRed.Text = "R";
            // 
            // GrayscaleRedValue
            // 
            this.GrayscaleRedValue.AutoSize = true;
            this.GrayscaleRedValue.Location = new System.Drawing.Point(208, 37);
            this.GrayscaleRedValue.Name = "GrayscaleRedValue";
            this.GrayscaleRedValue.Size = new System.Drawing.Size(34, 13);
            this.GrayscaleRedValue.TabIndex = 5;
            this.GrayscaleRedValue.Text = "0.213";
            // 
            // GrayscaleRedTrackBar
            // 
            this.GrayscaleRedTrackBar.Location = new System.Drawing.Point(27, 37);
            this.GrayscaleRedTrackBar.Maximum = 800;
            this.GrayscaleRedTrackBar.Minimum = 1;
            this.GrayscaleRedTrackBar.Name = "GrayscaleRedTrackBar";
            this.GrayscaleRedTrackBar.Size = new System.Drawing.Size(175, 45);
            this.GrayscaleRedTrackBar.TabIndex = 0;
            this.GrayscaleRedTrackBar.TickFrequency = 100;
            this.GrayscaleRedTrackBar.Value = 213;
            this.GrayscaleRedTrackBar.ValueChanged += new System.EventHandler(this.GrayscaleRedTrackBar_ValueChanged);
            // 
            // GrayscaleLabel
            // 
            this.GrayscaleLabel.AutoSize = true;
            this.GrayscaleLabel.Location = new System.Drawing.Point(6, 16);
            this.GrayscaleLabel.Name = "GrayscaleLabel";
            this.GrayscaleLabel.Size = new System.Drawing.Size(79, 13);
            this.GrayscaleLabel.TabIndex = 4;
            this.GrayscaleLabel.Text = "Grayscale Filter";
            // 
            // HLSLGrayscaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 522);
            this.Controls.Add(this.Options);
            this.Name = "HLSLGrayscaleForm";
            this.Text = "HLSLGrayscaleForm";
            this.Options.ResumeLayout(false);
            this.Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleBlueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleGreenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleRedTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox Options;
        private System.Windows.Forms.Label GrayscaleBlue;
        private System.Windows.Forms.Label GrayscaleBlueValue;
        private System.Windows.Forms.TrackBar GrayscaleBlueTrackBar;
        private System.Windows.Forms.Label GrayscaleGreen;
        private System.Windows.Forms.Label GrayscaleGreenValue;
        private System.Windows.Forms.TrackBar GrayscaleGreenTrackBar;
        private System.Windows.Forms.Label GrayscaleRed;
        private System.Windows.Forms.Label GrayscaleRedValue;
        private System.Windows.Forms.TrackBar GrayscaleRedTrackBar;
        private System.Windows.Forms.Label GrayscaleLabel;
    }
}