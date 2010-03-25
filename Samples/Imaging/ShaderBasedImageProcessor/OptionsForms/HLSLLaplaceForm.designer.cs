namespace ShaderBasedImageProcessor
{
    partial class HLSLLaplaceForm
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
            this.VersionGroupBox = new System.Windows.Forms.GroupBox();
            this.WithDiagonalsRadioButton = new System.Windows.Forms.RadioButton();
            this.NormalRadioButton = new System.Windows.Forms.RadioButton();
            this.LaplaceTrackBar = new System.Windows.Forms.TrackBar();
            this.LaplaceStrengthLabel = new System.Windows.Forms.Label();
            this.LaplaceLabel = new System.Windows.Forms.Label();
            this.Options.SuspendLayout();
            this.VersionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LaplaceTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Options
            // 
            this.Options.Controls.Add(this.VersionGroupBox);
            this.Options.Controls.Add(this.LaplaceTrackBar);
            this.Options.Controls.Add(this.LaplaceStrengthLabel);
            this.Options.Controls.Add(this.LaplaceLabel);
            this.Options.Location = new System.Drawing.Point(12, 12);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(250, 500);
            this.Options.TabIndex = 3;
            this.Options.TabStop = false;
            this.Options.Text = "Options";
            // 
            // VersionGroupBox
            // 
            this.VersionGroupBox.Controls.Add(this.WithDiagonalsRadioButton);
            this.VersionGroupBox.Controls.Add(this.NormalRadioButton);
            this.VersionGroupBox.Location = new System.Drawing.Point(6, 84);
            this.VersionGroupBox.Name = "VersionGroupBox";
            this.VersionGroupBox.Size = new System.Drawing.Size(238, 80);
            this.VersionGroupBox.TabIndex = 6;
            this.VersionGroupBox.TabStop = false;
            this.VersionGroupBox.Text = "Versions";
            // 
            // WithDiagonalsRadioButton
            // 
            this.WithDiagonalsRadioButton.AutoSize = true;
            this.WithDiagonalsRadioButton.Location = new System.Drawing.Point(7, 44);
            this.WithDiagonalsRadioButton.Name = "WithDiagonalsRadioButton";
            this.WithDiagonalsRadioButton.Size = new System.Drawing.Size(153, 17);
            this.WithDiagonalsRadioButton.TabIndex = 2;
            this.WithDiagonalsRadioButton.TabStop = true;
            this.WithDiagonalsRadioButton.Text = "With Diagonals Coefficents";
            this.WithDiagonalsRadioButton.UseVisualStyleBackColor = true;
            this.WithDiagonalsRadioButton.CheckedChanged += new System.EventHandler(this.WithDiagonalsRadioButton_CheckedChanged);
            // 
            // NormalRadioButton
            // 
            this.NormalRadioButton.AutoSize = true;
            this.NormalRadioButton.Checked = true;
            this.NormalRadioButton.Location = new System.Drawing.Point(7, 20);
            this.NormalRadioButton.Name = "NormalRadioButton";
            this.NormalRadioButton.Size = new System.Drawing.Size(58, 17);
            this.NormalRadioButton.TabIndex = 1;
            this.NormalRadioButton.TabStop = true;
            this.NormalRadioButton.Text = "Normal";
            this.NormalRadioButton.UseVisualStyleBackColor = true;
            this.NormalRadioButton.CheckedChanged += new System.EventHandler(this.NormalRadioButton_CheckedChanged);
            // 
            // LaplaceTrackBar
            // 
            this.LaplaceTrackBar.Location = new System.Drawing.Point(6, 33);
            this.LaplaceTrackBar.Maximum = 30;
            this.LaplaceTrackBar.Minimum = 1;
            this.LaplaceTrackBar.Name = "LaplaceTrackBar";
            this.LaplaceTrackBar.Size = new System.Drawing.Size(238, 45);
            this.LaplaceTrackBar.TabIndex = 0;
            this.LaplaceTrackBar.Value = 3;
            this.LaplaceTrackBar.ValueChanged += new System.EventHandler(this.LaplaceTrackBar_ValueChanged);
            // 
            // LaplaceStrengthLabel
            // 
            this.LaplaceStrengthLabel.AutoSize = true;
            this.LaplaceStrengthLabel.Location = new System.Drawing.Point(104, 16);
            this.LaplaceStrengthLabel.Name = "LaplaceStrengthLabel";
            this.LaplaceStrengthLabel.Size = new System.Drawing.Size(13, 13);
            this.LaplaceStrengthLabel.TabIndex = 5;
            this.LaplaceStrengthLabel.Text = "3";
            // 
            // LaplaceLabel
            // 
            this.LaplaceLabel.AutoSize = true;
            this.LaplaceLabel.Location = new System.Drawing.Point(6, 16);
            this.LaplaceLabel.Name = "LaplaceLabel";
            this.LaplaceLabel.Size = new System.Drawing.Size(91, 13);
            this.LaplaceLabel.TabIndex = 4;
            this.LaplaceLabel.Text = "Laplace Strength:";
            // 
            // HLSLLaplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 522);
            this.Controls.Add(this.Options);
            this.Name = "HLSLLaplaceForm";
            this.Text = "HLSLLaplaceForm";
            this.Options.ResumeLayout(false);
            this.Options.PerformLayout();
            this.VersionGroupBox.ResumeLayout(false);
            this.VersionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LaplaceTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox Options;
        private System.Windows.Forms.TrackBar LaplaceTrackBar;
        private System.Windows.Forms.Label LaplaceStrengthLabel;
        private System.Windows.Forms.Label LaplaceLabel;
        private System.Windows.Forms.GroupBox VersionGroupBox;
        private System.Windows.Forms.RadioButton WithDiagonalsRadioButton;
        private System.Windows.Forms.RadioButton NormalRadioButton;
    }
}