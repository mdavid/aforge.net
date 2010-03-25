namespace ShaderBasedImageProcessor
{
    partial class HLSLThresholdForm
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
            this.RedValue = new System.Windows.Forms.Label();
            this.ThresholdTrackBar = new System.Windows.Forms.TrackBar();
            this.Label = new System.Windows.Forms.Label();
            this.Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Options
            // 
            this.Options.Controls.Add(this.RedValue);
            this.Options.Controls.Add(this.ThresholdTrackBar);
            this.Options.Controls.Add(this.Label);
            this.Options.Location = new System.Drawing.Point(12, 12);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(250, 500);
            this.Options.TabIndex = 3;
            this.Options.TabStop = false;
            this.Options.Text = "Options";
            // 
            // RedValue
            // 
            this.RedValue.AutoSize = true;
            this.RedValue.Location = new System.Drawing.Point(208, 37);
            this.RedValue.Name = "RedValue";
            this.RedValue.Size = new System.Drawing.Size(25, 13);
            this.RedValue.TabIndex = 5;
            this.RedValue.Text = "100";
            // 
            // ThresholdTrackBar
            // 
            this.ThresholdTrackBar.Location = new System.Drawing.Point(9, 37);
            this.ThresholdTrackBar.Maximum = 255;
            this.ThresholdTrackBar.Minimum = 1;
            this.ThresholdTrackBar.Name = "ThresholdTrackBar";
            this.ThresholdTrackBar.Size = new System.Drawing.Size(193, 45);
            this.ThresholdTrackBar.TabIndex = 0;
            this.ThresholdTrackBar.TickFrequency = 10;
            this.ThresholdTrackBar.Value = 100;
            this.ThresholdTrackBar.ValueChanged += new System.EventHandler(this.ThresholdTrackBar_ValueChanged);
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(6, 16);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(79, 13);
            this.Label.TabIndex = 4;
            this.Label.Text = "Threshold Filter";
            // 
            // HLSLThresholdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 522);
            this.Controls.Add(this.Options);
            this.Name = "HLSLThresholdForm";
            this.Text = "HLSLThresholdForm";
            this.Options.ResumeLayout(false);
            this.Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox Options;
        private System.Windows.Forms.Label RedValue;
        private System.Windows.Forms.TrackBar ThresholdTrackBar;
        private System.Windows.Forms.Label Label;
    }
}