namespace ImageViewer
{
    partial class MainForm
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog( );
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip( );
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator( );
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.statusStrip = new System.Windows.Forms.StatusStrip( );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.pictureBox = new AForge.Controls.PictureBox( );
            this.mainMenuStrip.SuspendLayout( );
            this.panel1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "All files (*.*)|*.*|Flexible Image Transport System images (*.fit, *.fits)|*.fit;" +
                "*.fits|PNM (Portable Any Map) images (*.pbm, *.pgm, *.ppm, *.pnm)|*.pbm;*.pgm;*." +
                "ppm;*.pnm";
            this.openFileDialog.Title = "Select image file";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem} );
            this.mainMenuStrip.Location = new System.Drawing.Point( 0, 0 );
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size( 341, 24 );
            this.mainMenuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem} );
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size( 37, 20 );
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ( (System.Windows.Forms.Keys) ( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O ) ) );
            this.openToolStripMenuItem.Size = new System.Drawing.Size( 146, 22 );
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler( this.openToolStripMenuItem_Click );
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size( 143, 6 );
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size( 146, 22 );
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler( this.exitToolStripMenuItem_Click );
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point( 0, 284 );
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size( 341, 22 );
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.pictureBox );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point( 0, 24 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 341, 260 );
            this.panel1.TabIndex = 2;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Image = null;
            this.pictureBox.Location = new System.Drawing.Point( 10, 10 );
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size( 320, 240 );
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 341, 306 );
            this.Controls.Add( this.panel1 );
            this.Controls.Add( this.statusStrip );
            this.Controls.Add( this.mainMenuStrip );
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Image Viewer";
            this.mainMenuStrip.ResumeLayout( false );
            this.mainMenuStrip.PerformLayout( );
            this.panel1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel panel1;
        private AForge.Controls.PictureBox pictureBox;
    }
}

