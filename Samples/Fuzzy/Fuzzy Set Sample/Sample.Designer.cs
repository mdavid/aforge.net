namespace FuzzySetSample
{
    partial class Sample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.runTestButton = new System.Windows.Forms.Button( );
            this.chart = new AForge.Controls.Chart( );
            this.label1 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.SuspendLayout( );
            // 
            // runTestButton
            // 
            this.runTestButton.Location = new System.Drawing.Point( 230, 10 );
            this.runTestButton.Name = "runTestButton";
            this.runTestButton.Size = new System.Drawing.Size( 80, 23 );
            this.runTestButton.TabIndex = 0;
            this.runTestButton.Text = "Run Test";
            this.runTestButton.UseVisualStyleBackColor = true;
            this.runTestButton.Click += new System.EventHandler( this.runTestButton_Click );
            // 
            // chart
            // 
            this.chart.Location = new System.Drawing.Point( 10, 75 );
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size( 300, 250 );
            this.chart.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point( 10, 10 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 100, 23 );
            this.label1.TabIndex = 2;
            this.label1.Text = "Cool";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightCoral;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point( 10, 40 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 100, 23 );
            this.label2.TabIndex = 3;
            this.label2.Text = "Warm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Sample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 320, 336 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.chart );
            this.Controls.Add( this.runTestButton );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Sample";
            this.Text = "Fuzzy Sets Sample";
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button runTestButton;
        private AForge.Controls.Chart chart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

