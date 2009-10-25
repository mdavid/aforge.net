namespace BlobsExplorer
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
            this.mainMenu = new System.Windows.Forms.MenuStrip( );
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator( );
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.statusStrip = new System.Windows.Forms.StatusStrip( );
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog( );
            this.splitContainer = new System.Windows.Forms.SplitContainer( );
            this.propertyGrid = new System.Windows.Forms.PropertyGrid( );
            this.blobsCountLabel = new System.Windows.Forms.ToolStripStatusLabel( );
            this.blobsBrowser = new BlobsExplorer.BlobsBrowser( );
            this.mainMenu.SuspendLayout( );
            this.statusStrip.SuspendLayout( );
            this.splitContainer.Panel1.SuspendLayout( );
            this.splitContainer.Panel2.SuspendLayout( );
            this.splitContainer.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem} );
            this.mainMenu.Location = new System.Drawing.Point( 0, 0 );
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size( 531, 24 );
            this.mainMenu.TabIndex = 0;
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
            this.statusStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.blobsCountLabel} );
            this.statusStrip.Location = new System.Drawing.Point( 0, 311 );
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size( 531, 22 );
            this.statusStrip.TabIndex = 1;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image files (*.jpg,*.png,*.tif,*.bmp,*.gif)|*.jpg;*.png;*.tif;*.bmp;*.gif|JPG fil" +
                "es (*.jpg)|*.jpg|PNG files (*.png)|*.png|TIF files (*.tif)|*.tif|BMP files (*.bm" +
                "p)|*.bmp|GIF files (*.gif)|*.gif";
            this.openFileDialog.Title = "Open image file";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point( 0, 24 );
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add( this.blobsBrowser );
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add( this.propertyGrid );
            this.splitContainer.Size = new System.Drawing.Size( 531, 287 );
            this.splitContainer.SplitterDistance = 372;
            this.splitContainer.TabIndex = 2;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.Location = new System.Drawing.Point( 0, 0 );
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size( 155, 287 );
            this.propertyGrid.TabIndex = 0;
            this.propertyGrid.ToolbarVisible = false;
            // 
            // blobsCountLabel
            // 
            this.blobsCountLabel.AutoSize = false;
            this.blobsCountLabel.BorderSides = ( (System.Windows.Forms.ToolStripStatusLabelBorderSides) ( ( ( ( System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top )
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right )
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom ) ) );
            this.blobsCountLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.blobsCountLabel.Name = "blobsCountLabel";
            this.blobsCountLabel.Size = new System.Drawing.Size( 485, 17 );
            this.blobsCountLabel.Spring = true;
            this.blobsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // blobsBrowser
            // 
            this.blobsBrowser.Location = new System.Drawing.Point( 25, 22 );
            this.blobsBrowser.Name = "blobsBrowser";
            this.blobsBrowser.Size = new System.Drawing.Size( 322, 242 );
            this.blobsBrowser.TabIndex = 0;
            this.blobsBrowser.BlobSelected += new BlobsExplorer.BlobSelectionHandler( this.blobsBrowser_BlobSelected );
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 531, 333 );
            this.Controls.Add( this.splitContainer );
            this.Controls.Add( this.statusStrip );
            this.Controls.Add( this.mainMenu );
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Blobs Explorer";
            this.mainMenu.ResumeLayout( false );
            this.mainMenu.PerformLayout( );
            this.statusStrip.ResumeLayout( false );
            this.statusStrip.PerformLayout( );
            this.splitContainer.Panel1.ResumeLayout( false );
            this.splitContainer.Panel2.ResumeLayout( false );
            this.splitContainer.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private BlobsBrowser blobsBrowser;
        private System.Windows.Forms.ToolStripStatusLabel blobsCountLabel;
    }
}

