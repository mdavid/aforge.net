using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AForge.Imaging;

namespace BlobsExplorer
{
    public partial class MainForm : Form
    {
        public MainForm( )
        {
            InitializeComponent( );
        }

        // Exit from application
        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.Close( );
        }

        // Open file
        private void openToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( openFileDialog.ShowDialog( ) == DialogResult.OK )
            {
                try
                {
                    ProcessImage( (Bitmap) Bitmap.FromFile( openFileDialog.FileName ) );
                }
                catch
                {
                    MessageBox.Show( "Failed loading selected image file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        // Process image
        private void ProcessImage( Bitmap image )
        {
            int foundBlobsCount = blobsBrowser.SetImage( image );

            blobsCountLabel.Text = string.Format( "Found blobs' count: {0}", foundBlobsCount );
        }

        // Blob was selected - display its information
        private void blobsBrowser_BlobSelected( object sender, Blob blob )
        {
            propertyGrid.SelectedObject = blob;
            propertyGrid.ExpandAllGridItems( );
        }
    }
}
