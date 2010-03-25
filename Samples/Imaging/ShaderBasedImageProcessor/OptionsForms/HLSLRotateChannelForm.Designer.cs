namespace ShaderBasedImageProcessor
{
    partial class HLSLRotateChannelsForm
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
            this.FilterLabel = new System.Windows.Forms.Label();
            this.RGBRadioButton = new System.Windows.Forms.RadioButton();
            this.RBGRadioButton = new System.Windows.Forms.RadioButton();
            this.BRGRadioButton = new System.Windows.Forms.RadioButton();
            this.BGRRadioButton = new System.Windows.Forms.RadioButton();
            this.GBRRadioButton = new System.Windows.Forms.RadioButton();
            this.GRBRadioButton = new System.Windows.Forms.RadioButton();
            this.Options.SuspendLayout();
            this.SuspendLayout();
            // 
            // Options
            // 
            this.Options.Controls.Add(this.GRBRadioButton);
            this.Options.Controls.Add(this.GBRRadioButton);
            this.Options.Controls.Add(this.BGRRadioButton);
            this.Options.Controls.Add(this.BRGRadioButton);
            this.Options.Controls.Add(this.RBGRadioButton);
            this.Options.Controls.Add(this.RGBRadioButton);
            this.Options.Controls.Add(this.FilterLabel);
            this.Options.Location = new System.Drawing.Point(12, 12);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(250, 500);
            this.Options.TabIndex = 3;
            this.Options.TabStop = false;
            this.Options.Text = "Options";
            // 
            // FilterLabel
            // 
            this.FilterLabel.AutoSize = true;
            this.FilterLabel.Location = new System.Drawing.Point(6, 16);
            this.FilterLabel.Name = "FilterLabel";
            this.FilterLabel.Size = new System.Drawing.Size(111, 13);
            this.FilterLabel.TabIndex = 4;
            this.FilterLabel.Text = "Rotate Channels Filter";
            // 
            // RGBRadioButton
            // 
            this.RGBRadioButton.AutoSize = true;
            this.RGBRadioButton.Location = new System.Drawing.Point(9, 32);
            this.RGBRadioButton.Name = "RGBRadioButton";
            this.RGBRadioButton.Size = new System.Drawing.Size(100, 17);
            this.RGBRadioButton.TabIndex = 5;
            this.RGBRadioButton.TabStop = true;
            this.RGBRadioButton.Text = "RGB (Standard)";
            this.RGBRadioButton.UseVisualStyleBackColor = true;
            this.RGBRadioButton.CheckedChanged += new System.EventHandler(this.RGBRadioButton_CheckedChanged);
            // 
            // RBGRadioButton
            // 
            this.RBGRadioButton.AutoSize = true;
            this.RBGRadioButton.Location = new System.Drawing.Point(9, 55);
            this.RBGRadioButton.Name = "RBGRadioButton";
            this.RBGRadioButton.Size = new System.Drawing.Size(48, 17);
            this.RBGRadioButton.TabIndex = 6;
            this.RBGRadioButton.TabStop = true;
            this.RBGRadioButton.Text = "RBG";
            this.RBGRadioButton.UseVisualStyleBackColor = true;
            this.RBGRadioButton.CheckedChanged += new System.EventHandler(this.RBGRadioButton_CheckedChanged);
            // 
            // BRGRadioButton
            // 
            this.BRGRadioButton.AutoSize = true;
            this.BRGRadioButton.Location = new System.Drawing.Point(9, 78);
            this.BRGRadioButton.Name = "BRGRadioButton";
            this.BRGRadioButton.Size = new System.Drawing.Size(48, 17);
            this.BRGRadioButton.TabIndex = 7;
            this.BRGRadioButton.TabStop = true;
            this.BRGRadioButton.Text = "BRG";
            this.BRGRadioButton.UseVisualStyleBackColor = true;
            this.BRGRadioButton.CheckedChanged += new System.EventHandler(this.BRGRadioButton_CheckedChanged);
            // 
            // BGRRadioButton
            // 
            this.BGRRadioButton.AutoSize = true;
            this.BGRRadioButton.Location = new System.Drawing.Point(9, 101);
            this.BGRRadioButton.Name = "BGRRadioButton";
            this.BGRRadioButton.Size = new System.Drawing.Size(48, 17);
            this.BGRRadioButton.TabIndex = 8;
            this.BGRRadioButton.TabStop = true;
            this.BGRRadioButton.Text = "BGR";
            this.BGRRadioButton.UseVisualStyleBackColor = true;
            this.BGRRadioButton.CheckedChanged += new System.EventHandler(this.BGRRadioButton_CheckedChanged);
            // 
            // GBRRadioButton
            // 
            this.GBRRadioButton.AutoSize = true;
            this.GBRRadioButton.Checked = true;
            this.GBRRadioButton.Location = new System.Drawing.Point(9, 124);
            this.GBRRadioButton.Name = "GBRRadioButton";
            this.GBRRadioButton.Size = new System.Drawing.Size(48, 17);
            this.GBRRadioButton.TabIndex = 9;
            this.GBRRadioButton.TabStop = true;
            this.GBRRadioButton.Text = "GBR";
            this.GBRRadioButton.UseVisualStyleBackColor = true;
            this.GBRRadioButton.CheckedChanged += new System.EventHandler(this.GBRRadioButton_CheckedChanged);
            // 
            // GRBRadioButton
            // 
            this.GRBRadioButton.AutoSize = true;
            this.GRBRadioButton.Location = new System.Drawing.Point(9, 147);
            this.GRBRadioButton.Name = "GRBRadioButton";
            this.GRBRadioButton.Size = new System.Drawing.Size(48, 17);
            this.GRBRadioButton.TabIndex = 10;
            this.GRBRadioButton.TabStop = true;
            this.GRBRadioButton.Text = "GRB";
            this.GRBRadioButton.UseVisualStyleBackColor = true;
            this.GRBRadioButton.CheckedChanged += new System.EventHandler(this.GRBRadioButton_CheckedChanged);
            // 
            // HLSLRotateChannelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 522);
            this.Controls.Add(this.Options);
            this.Name = "HLSLRotateChannelsForm";
            this.Text = "HLSLRotateChannelsForm";
            this.Options.ResumeLayout(false);
            this.Options.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox Options;
        private System.Windows.Forms.Label FilterLabel;
        private System.Windows.Forms.RadioButton GBRRadioButton;
        private System.Windows.Forms.RadioButton BGRRadioButton;
        private System.Windows.Forms.RadioButton BRGRadioButton;
        private System.Windows.Forms.RadioButton RBGRadioButton;
        private System.Windows.Forms.RadioButton RGBRadioButton;
        private System.Windows.Forms.RadioButton GRBRadioButton;
    }
}