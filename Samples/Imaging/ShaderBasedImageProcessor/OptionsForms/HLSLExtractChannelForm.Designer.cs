namespace ShaderBasedImageProcessor
{
    partial class HLSLExtractChannelForm
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
            this.HLSLExtractChannelGroupBox = new System.Windows.Forms.GroupBox();
            this.BlueRadioButton = new System.Windows.Forms.RadioButton();
            this.GreenRadioButton = new System.Windows.Forms.RadioButton();
            this.RedRadioButton = new System.Windows.Forms.RadioButton();
            this.Label = new System.Windows.Forms.Label();
            this.Options.SuspendLayout();
            this.HLSLExtractChannelGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Options
            // 
            this.Options.Controls.Add(this.HLSLExtractChannelGroupBox);
            this.Options.Controls.Add(this.Label);
            this.Options.Location = new System.Drawing.Point(12, 12);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(250, 500);
            this.Options.TabIndex = 3;
            this.Options.TabStop = false;
            this.Options.Text = "Options";
            // 
            // HLSLExtractChannelGroupBox
            // 
            this.HLSLExtractChannelGroupBox.Controls.Add(this.BlueRadioButton);
            this.HLSLExtractChannelGroupBox.Controls.Add(this.GreenRadioButton);
            this.HLSLExtractChannelGroupBox.Controls.Add(this.RedRadioButton);
            this.HLSLExtractChannelGroupBox.Location = new System.Drawing.Point(6, 32);
            this.HLSLExtractChannelGroupBox.Name = "HLSLExtractChannelGroupBox";
            this.HLSLExtractChannelGroupBox.Size = new System.Drawing.Size(238, 97);
            this.HLSLExtractChannelGroupBox.TabIndex = 11;
            this.HLSLExtractChannelGroupBox.TabStop = false;
            this.HLSLExtractChannelGroupBox.Text = "Channel";
            // 
            // BlueRadioButton
            // 
            this.BlueRadioButton.AutoSize = true;
            this.BlueRadioButton.Checked = true;
            this.BlueRadioButton.Location = new System.Drawing.Point(7, 67);
            this.BlueRadioButton.Name = "BlueRadioButton";
            this.BlueRadioButton.Size = new System.Drawing.Size(46, 17);
            this.BlueRadioButton.TabIndex = 3;
            this.BlueRadioButton.TabStop = true;
            this.BlueRadioButton.Text = "Blue";
            this.BlueRadioButton.UseVisualStyleBackColor = true;
            this.BlueRadioButton.CheckedChanged += new System.EventHandler(this.BlueRadioButton_CheckedChanged);
            // 
            // GreenRadioButton
            // 
            this.GreenRadioButton.AutoSize = true;
            this.GreenRadioButton.Location = new System.Drawing.Point(7, 44);
            this.GreenRadioButton.Name = "GreenRadioButton";
            this.GreenRadioButton.Size = new System.Drawing.Size(54, 17);
            this.GreenRadioButton.TabIndex = 2;
            this.GreenRadioButton.Text = "Green";
            this.GreenRadioButton.UseVisualStyleBackColor = true;
            this.GreenRadioButton.CheckedChanged += new System.EventHandler(this.GreenRadioButton_CheckedChanged);
            // 
            // RedRadioButton
            // 
            this.RedRadioButton.AutoSize = true;
            this.RedRadioButton.Location = new System.Drawing.Point(7, 20);
            this.RedRadioButton.Name = "RedRadioButton";
            this.RedRadioButton.Size = new System.Drawing.Size(45, 17);
            this.RedRadioButton.TabIndex = 1;
            this.RedRadioButton.Text = "Red";
            this.RedRadioButton.UseVisualStyleBackColor = true;
            this.RedRadioButton.CheckedChanged += new System.EventHandler(this.RedRadioButton_CheckedChanged);
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(6, 16);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(104, 13);
            this.Label.TabIndex = 4;
            this.Label.Text = "ExtractChannel Filter";
            // 
            // HLSLExtractChannelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 522);
            this.Controls.Add(this.Options);
            this.Name = "HLSLExtractChannelForm";
            this.Text = "HLSLExtractChannelForm";
            this.Options.ResumeLayout(false);
            this.Options.PerformLayout();
            this.HLSLExtractChannelGroupBox.ResumeLayout(false);
            this.HLSLExtractChannelGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox Options;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.GroupBox HLSLExtractChannelGroupBox;
        private System.Windows.Forms.RadioButton GreenRadioButton;
        private System.Windows.Forms.RadioButton RedRadioButton;
        private System.Windows.Forms.RadioButton BlueRadioButton;
    }
}