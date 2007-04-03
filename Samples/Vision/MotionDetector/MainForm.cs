// AForge.NET Framework
// Motion Detection sample application
//
// Copyright © Andrew Kirillov, 2007
// andrew.kirillov@gmail.com
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using AForge.Video;
using AForge.Video.VFW;
using AForge.Vision;

namespace MotionDetector
{
    public partial class MainForm : Form
    {
        // motion detector
        IMotionDetector detector = null;

        // statistics length
        private const int statLength = 15;
        // current statistics index
        private int statIndex = 0;
        // ready statistics values
        private int statReady = 0;
        // statistics array
        private int[] statCount = new int[statLength];


        // Constructor
        public MainForm( )
        {
            InitializeComponent( );

            cameraWindow.AutoSize = true;
        }

        // Application's main form is closing
        private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            CloseVideoSource( );
        }

        // "Exit" menu item clicked
        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.Close( );
        }

        // "About" menu item clicked
        private void aboutToolStripMenuItem_Click( object sender, EventArgs e )
        {

        }

        // "Open" menu item clieck - open AVI file
        private void openToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( openFileDialog.ShowDialog( ) == DialogResult.OK )
            {
                // create video source
                AVIFileVideoSource fileSource = new AVIFileVideoSource( openFileDialog.FileName );

                OpenVideoSource( fileSource );
            }
        }

        // Open video source
        private void OpenVideoSource( IVideoSource source )
        {
            // set busy cursor
            this.Cursor = Cursors.WaitCursor;

            // close previous video source
            CloseVideoSource( );

            // create camera
            Camera camera = new Camera( source, detector );
            // start camera
            camera.Start( );

            // attach camera to camera window
            cameraWindow.Camera = camera;

            // reset statistics
            statIndex = statReady = 0;

            // start timer
            timer.Start( );

            this.Cursor = Cursors.Default;
        }

        // Close current video source
        private void CloseVideoSource( )
        {
            Camera camera = cameraWindow.Camera;

            if ( camera != null )
            {
                // stop timer
                timer.Stop( );

                // detach camera from camera window
                cameraWindow.Camera = null;

                // signal camera to stop
                camera.SignalToStop( );
                // wait 2 seconds until camera stops
                for ( int i = 0; ( i < 20 ) && ( camera.IsRunning ); i++ )
                {
                    Thread.Sleep( 100 );
                }
                if ( camera.IsRunning )
                    camera.Stop( );
                camera = null;

                // reset motion detector
                if ( detector != null )
                    detector.Reset( );
            }
        }

        // On timer event - gather statistics
        private void timer_Tick( object sender, EventArgs e )
        {
            Camera camera = cameraWindow.Camera;

            if ( camera != null )
            {
                // get number of frames for the last second
                statCount[statIndex] = camera.FramesReceived;

                // increment indexes
                if ( ++statIndex >= statLength )
                    statIndex = 0;
                if ( statReady < statLength )
                    statReady++;

                float fps = 0;

                // calculate average value
                for ( int i = 0; i < statReady; i++ )
                {
                    fps += statCount[i];
                }
                fps /= statReady;

                statCount[statIndex] = 0;

                fpsLabel.Text = fps.ToString( "F2" ) + " fps";
            }
        }

        // Main window resized
        private void MainForm_SizeChanged( object sender, EventArgs e )
        {
            cameraWindow.UpdatePosition( );
        }
    }
}