using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using AForge.Imaging.Filters;

namespace SVSTest
{
    public partial class StereoViewForm : Form
    {
        private ManualResetEvent leftFrameIsAvailable;
        private ManualResetEvent rightFrameIsAvailable;

        private Thread backgroundThread;

        private Bitmap leftFrame;
        private Bitmap rightFrame;

        private StereoAnaglyph stereoFilter = new StereoAnaglyph( );

        bool needToExit = false;

        public StereoViewForm( )
        {
            InitializeComponent( );

            leftFrameIsAvailable  = new ManualResetEvent( false );
            rightFrameIsAvailable = new ManualResetEvent( false );

            backgroundThread = new Thread( new ThreadStart( stereoThread ) );
            backgroundThread.Start( );
        }

        // Closing the form
        private void StereoViewForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            needToExit = true;

            leftFrameIsAvailable.Set( );
            rightFrameIsAvailable.Set( );

            backgroundThread.Join( );
        }

        public void OnNewLeftFrame( object sender, ref Bitmap image )
        {
            lock ( this )
            {
                if ( leftFrame != null )
                    leftFrame.Dispose( );

                leftFrame = AForge.Imaging.Image.Clone( image );

                leftFrameIsAvailable.Set( );
            }
        }

        public void OnNewRightFrame( object sender, ref Bitmap image )
        {
            lock ( this )
            {
                if ( rightFrame != null )
                    rightFrame.Dispose( );

                rightFrame = AForge.Imaging.Image.Clone( image );

                rightFrameIsAvailable.Set( );
            }
        }

        private void stereoThread( )
        {
            while ( true )
            {
                leftFrameIsAvailable.WaitOne( );
                rightFrameIsAvailable.WaitOne( );

                if ( needToExit )
                    break;

                lock ( this )
                {
                    //leftFrame.Save( "d:\\l.bmp", System.Drawing.Imaging.ImageFormat.Bmp );
                    //rightFrame.Save( "d:\\r.bmp", System.Drawing.Imaging.ImageFormat.Bmp );

                    Image old = pictureBox.Image;

                    stereoFilter.OverlayImage = rightFrame;
                    pictureBox.Image = stereoFilter.Apply( leftFrame );
                    pictureBox.Invalidate( );

                    if ( old != null )
                    {
                        old.Dispose( );
                    }
                }

                leftFrameIsAvailable.Reset( );
                rightFrameIsAvailable.Reset( );
            }
        }
    }
}
