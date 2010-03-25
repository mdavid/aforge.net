namespace ShaderBasedImageProcessor
{
    partial class HLSLOriginalForm
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
            this.NoOptionsLabel = new System.Windows.Forms.Label();
            this.Options.SuspendLayout();
            this.SuspendLayout();
            // 
            // Options
            // 
            this.Options.Controls.Add(this.NoOptionsLabel);
            this.Options.Location = new System.Drawing.Point(12, 12);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(250, 500);
            this.Options.TabIndex = 1;
            this.Options.TabStop = false;
            this.Options.Text = "Options";
            // 
            // NoOptionsLabel
            // 
            this.NoOptionsLabel.AutoSize = true;
            this.NoOptionsLabel.Location = new System.Drawing.Point(7, 20);
            this.NoOptionsLabel.Name = "NoOptionsLabel";
            this.NoOptionsLabel.Size = new System.Drawing.Size(60, 13);
            this.NoOptionsLabel.TabIndex = 0;
            this.NoOptionsLabel.Text = "No Options";
            // 
            // HLSLInvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 522);
            this.Controls.Add(this.Options);
            this.Name = "HLSLInvertForm";
            this.Text = "HLSLInvertForm";
            this.Options.ResumeLayout(false);
            this.Options.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox Options;
        private System.Windows.Forms.Label NoOptionsLabel;
    }
}