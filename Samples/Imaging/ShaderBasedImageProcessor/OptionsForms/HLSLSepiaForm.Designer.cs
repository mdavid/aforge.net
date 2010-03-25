namespace ShaderBasedImageProcessor
{
    partial class HLSLSepiaForm
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
            this.ILabel = new System.Windows.Forms.Label();
            this.IValue = new System.Windows.Forms.Label();
            this.ITrackBar = new System.Windows.Forms.TrackBar();
            this.QLabel = new System.Windows.Forms.Label();
            this.QValue = new System.Windows.Forms.Label();
            this.QTrackBar = new System.Windows.Forms.TrackBar();
            this.FilterLabel = new System.Windows.Forms.Label();
            this.Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ITrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Options
            // 
            this.Options.Controls.Add(this.ILabel);
            this.Options.Controls.Add(this.IValue);
            this.Options.Controls.Add(this.ITrackBar);
            this.Options.Controls.Add(this.QLabel);
            this.Options.Controls.Add(this.QValue);
            this.Options.Controls.Add(this.QTrackBar);
            this.Options.Controls.Add(this.FilterLabel);
            this.Options.Location = new System.Drawing.Point(12, 12);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(250, 500);
            this.Options.TabIndex = 3;
            this.Options.TabStop = false;
            this.Options.Text = "Options";
            // 
            // ILabel
            // 
            this.ILabel.AutoSize = true;
            this.ILabel.Location = new System.Drawing.Point(6, 88);
            this.ILabel.Name = "ILabel";
            this.ILabel.Size = new System.Drawing.Size(10, 13);
            this.ILabel.TabIndex = 9;
            this.ILabel.Text = "I";
            // 
            // IValue
            // 
            this.IValue.AutoSize = true;
            this.IValue.Location = new System.Drawing.Point(208, 88);
            this.IValue.Name = "IValue";
            this.IValue.Size = new System.Drawing.Size(34, 13);
            this.IValue.TabIndex = 6;
            this.IValue.Text = "0.200";
            // 
            // ITrackBar
            // 
            this.ITrackBar.Location = new System.Drawing.Point(27, 88);
            this.ITrackBar.Maximum = 1000;
            this.ITrackBar.Minimum = 1;
            this.ITrackBar.Name = "ITrackBar";
            this.ITrackBar.Size = new System.Drawing.Size(175, 45);
            this.ITrackBar.TabIndex = 1;
            this.ITrackBar.TickFrequency = 100;
            this.ITrackBar.Value = 200;
            this.ITrackBar.ValueChanged += new System.EventHandler(this.ITrackBar_ValueChanged);
            // 
            // QLabel
            // 
            this.QLabel.AutoSize = true;
            this.QLabel.Location = new System.Drawing.Point(6, 37);
            this.QLabel.Name = "QLabel";
            this.QLabel.Size = new System.Drawing.Size(15, 13);
            this.QLabel.TabIndex = 8;
            this.QLabel.Text = "Q";
            // 
            // QValue
            // 
            this.QValue.AutoSize = true;
            this.QValue.Location = new System.Drawing.Point(208, 37);
            this.QValue.Name = "QValue";
            this.QValue.Size = new System.Drawing.Size(34, 13);
            this.QValue.TabIndex = 5;
            this.QValue.Text = "0.000";
            // 
            // QTrackBar
            // 
            this.QTrackBar.Location = new System.Drawing.Point(27, 37);
            this.QTrackBar.Maximum = 1000;
            this.QTrackBar.Name = "QTrackBar";
            this.QTrackBar.Size = new System.Drawing.Size(175, 45);
            this.QTrackBar.TabIndex = 0;
            this.QTrackBar.TickFrequency = 100;
            this.QTrackBar.ValueChanged += new System.EventHandler(this.QTrackBar_ValueChanged);
            // 
            // FilterLabel
            // 
            this.FilterLabel.AutoSize = true;
            this.FilterLabel.Location = new System.Drawing.Point(6, 16);
            this.FilterLabel.Name = "FilterLabel";
            this.FilterLabel.Size = new System.Drawing.Size(59, 13);
            this.FilterLabel.TabIndex = 4;
            this.FilterLabel.Text = "Sepia Filter";
            // 
            // HLSLSepiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 522);
            this.Controls.Add(this.Options);
            this.Name = "HLSLSepiaForm";
            this.Text = "HLSLSepiaForm";
            this.Options.ResumeLayout(false);
            this.Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ITrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox Options;
        private System.Windows.Forms.Label ILabel;
        private System.Windows.Forms.Label IValue;
        private System.Windows.Forms.TrackBar ITrackBar;
        private System.Windows.Forms.Label QLabel;
        private System.Windows.Forms.Label QValue;
        private System.Windows.Forms.TrackBar QTrackBar;
        private System.Windows.Forms.Label FilterLabel;
    }
}