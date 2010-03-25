namespace ShaderBasedImageProcessor
{
    partial class HLSLThresholdRGBForm
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
            this.BlueLabel = new System.Windows.Forms.Label();
            this.BlueValue = new System.Windows.Forms.Label();
            this.BlueTrackBar = new System.Windows.Forms.TrackBar();
            this.GreenLabel = new System.Windows.Forms.Label();
            this.GreenValue = new System.Windows.Forms.Label();
            this.GreenTrackBar = new System.Windows.Forms.TrackBar();
            this.RedLabel = new System.Windows.Forms.Label();
            this.RedValue = new System.Windows.Forms.Label();
            this.RedTrackBar = new System.Windows.Forms.TrackBar();
            this.Label = new System.Windows.Forms.Label();
            this.BinarizationGroupBox = new System.Windows.Forms.GroupBox();
            this.OffRadioButton = new System.Windows.Forms.RadioButton();
            this.OnRadioButton = new System.Windows.Forms.RadioButton();
            this.Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTrackBar)).BeginInit();
            this.BinarizationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Options
            // 
            this.Options.Controls.Add(this.BinarizationGroupBox);
            this.Options.Controls.Add(this.BlueLabel);
            this.Options.Controls.Add(this.BlueValue);
            this.Options.Controls.Add(this.BlueTrackBar);
            this.Options.Controls.Add(this.GreenLabel);
            this.Options.Controls.Add(this.GreenValue);
            this.Options.Controls.Add(this.GreenTrackBar);
            this.Options.Controls.Add(this.RedLabel);
            this.Options.Controls.Add(this.RedValue);
            this.Options.Controls.Add(this.RedTrackBar);
            this.Options.Controls.Add(this.Label);
            this.Options.Location = new System.Drawing.Point(12, 12);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(250, 500);
            this.Options.TabIndex = 3;
            this.Options.TabStop = false;
            this.Options.Text = "Options";
            // 
            // BlueLabel
            // 
            this.BlueLabel.AutoSize = true;
            this.BlueLabel.Location = new System.Drawing.Point(6, 139);
            this.BlueLabel.Name = "BlueLabel";
            this.BlueLabel.Size = new System.Drawing.Size(14, 13);
            this.BlueLabel.TabIndex = 10;
            this.BlueLabel.Text = "B";
            // 
            // BlueValue
            // 
            this.BlueValue.AutoSize = true;
            this.BlueValue.Location = new System.Drawing.Point(208, 139);
            this.BlueValue.Name = "BlueValue";
            this.BlueValue.Size = new System.Drawing.Size(25, 13);
            this.BlueValue.TabIndex = 7;
            this.BlueValue.Text = "100";
            // 
            // BlueTrackBar
            // 
            this.BlueTrackBar.Location = new System.Drawing.Point(27, 139);
            this.BlueTrackBar.Maximum = 255;
            this.BlueTrackBar.Minimum = 1;
            this.BlueTrackBar.Name = "BlueTrackBar";
            this.BlueTrackBar.Size = new System.Drawing.Size(175, 45);
            this.BlueTrackBar.TabIndex = 2;
            this.BlueTrackBar.TickFrequency = 10;
            this.BlueTrackBar.Value = 100;
            this.BlueTrackBar.ValueChanged += new System.EventHandler(this.BlueTrackBar_ValueChanged);
            // 
            // GreenLabel
            // 
            this.GreenLabel.AutoSize = true;
            this.GreenLabel.Location = new System.Drawing.Point(6, 88);
            this.GreenLabel.Name = "GreenLabel";
            this.GreenLabel.Size = new System.Drawing.Size(15, 13);
            this.GreenLabel.TabIndex = 9;
            this.GreenLabel.Text = "G";
            // 
            // GreenValue
            // 
            this.GreenValue.AutoSize = true;
            this.GreenValue.Location = new System.Drawing.Point(208, 88);
            this.GreenValue.Name = "GreenValue";
            this.GreenValue.Size = new System.Drawing.Size(25, 13);
            this.GreenValue.TabIndex = 6;
            this.GreenValue.Text = "100";
            // 
            // GreenTrackBar
            // 
            this.GreenTrackBar.Location = new System.Drawing.Point(27, 88);
            this.GreenTrackBar.Maximum = 255;
            this.GreenTrackBar.Minimum = 1;
            this.GreenTrackBar.Name = "GreenTrackBar";
            this.GreenTrackBar.Size = new System.Drawing.Size(175, 45);
            this.GreenTrackBar.TabIndex = 1;
            this.GreenTrackBar.TickFrequency = 10;
            this.GreenTrackBar.Value = 100;
            this.GreenTrackBar.ValueChanged += new System.EventHandler(this.GreenTrackBar_ValueChanged);
            // 
            // RedLabel
            // 
            this.RedLabel.AutoSize = true;
            this.RedLabel.Location = new System.Drawing.Point(6, 37);
            this.RedLabel.Name = "RedLabel";
            this.RedLabel.Size = new System.Drawing.Size(15, 13);
            this.RedLabel.TabIndex = 8;
            this.RedLabel.Text = "R";
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
            // RedTrackBar
            // 
            this.RedTrackBar.Location = new System.Drawing.Point(27, 37);
            this.RedTrackBar.Maximum = 255;
            this.RedTrackBar.Minimum = 1;
            this.RedTrackBar.Name = "RedTrackBar";
            this.RedTrackBar.Size = new System.Drawing.Size(175, 45);
            this.RedTrackBar.TabIndex = 0;
            this.RedTrackBar.TickFrequency = 10;
            this.RedTrackBar.Value = 100;
            this.RedTrackBar.ValueChanged += new System.EventHandler(this.RedTrackBar_ValueChanged);
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(6, 16);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(105, 13);
            this.Label.TabIndex = 4;
            this.Label.Text = "RGB Threshold Filter";
            // 
            // BinarizationGroupBox
            // 
            this.BinarizationGroupBox.Controls.Add(this.OffRadioButton);
            this.BinarizationGroupBox.Controls.Add(this.OnRadioButton);
            this.BinarizationGroupBox.Location = new System.Drawing.Point(6, 190);
            this.BinarizationGroupBox.Name = "BinarizationGroupBox";
            this.BinarizationGroupBox.Size = new System.Drawing.Size(238, 80);
            this.BinarizationGroupBox.TabIndex = 11;
            this.BinarizationGroupBox.TabStop = false;
            this.BinarizationGroupBox.Text = "Binarization";
            // 
            // OffRadioButton
            // 
            this.OffRadioButton.AutoSize = true;
            this.OffRadioButton.Checked = true;
            this.OffRadioButton.Location = new System.Drawing.Point(7, 44);
            this.OffRadioButton.Name = "OffRadioButton";
            this.OffRadioButton.Size = new System.Drawing.Size(39, 17);
            this.OffRadioButton.TabIndex = 2;
            this.OffRadioButton.TabStop = true;
            this.OffRadioButton.Text = "Off";
            this.OffRadioButton.UseVisualStyleBackColor = true;
            this.OffRadioButton.CheckedChanged += new System.EventHandler(this.OffRadioButton_CheckedChanged);
            // 
            // OnRadioButton
            // 
            this.OnRadioButton.AutoSize = true;
            this.OnRadioButton.Location = new System.Drawing.Point(7, 20);
            this.OnRadioButton.Name = "OnRadioButton";
            this.OnRadioButton.Size = new System.Drawing.Size(39, 17);
            this.OnRadioButton.TabIndex = 1;
            this.OnRadioButton.Text = "On";
            this.OnRadioButton.UseVisualStyleBackColor = true;
            this.OnRadioButton.CheckedChanged += new System.EventHandler(this.OnRadioButton_CheckedChanged);
            // 
            // HLSLThresholdRGBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 522);
            this.Controls.Add(this.Options);
            this.Name = "HLSLThresholdRGBForm";
            this.Text = "HLSLThresholdRGBForm";
            this.Options.ResumeLayout(false);
            this.Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTrackBar)).EndInit();
            this.BinarizationGroupBox.ResumeLayout(false);
            this.BinarizationGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox Options;
        private System.Windows.Forms.Label BlueLabel;
        private System.Windows.Forms.Label BlueValue;
        private System.Windows.Forms.TrackBar BlueTrackBar;
        private System.Windows.Forms.Label GreenLabel;
        private System.Windows.Forms.Label GreenValue;
        private System.Windows.Forms.TrackBar GreenTrackBar;
        private System.Windows.Forms.Label RedLabel;
        private System.Windows.Forms.Label RedValue;
        private System.Windows.Forms.TrackBar RedTrackBar;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.GroupBox BinarizationGroupBox;
        private System.Windows.Forms.RadioButton OffRadioButton;
        private System.Windows.Forms.RadioButton OnRadioButton;
    }
}