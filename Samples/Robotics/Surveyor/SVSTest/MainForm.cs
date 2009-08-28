// Surveyor SVS test application
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Andrew Kirillov, 2007-2009
// andrew.kirillov@aforgenet.com
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AForge.Video;
using AForge.Robotics.Surveyor;

namespace SVSTest
{
    public partial class MainForm : Form
    {
        private SVS svs = new SVS( );

        // statistics length
        private const int statLength = 15;
        // current statistics index
        private int statIndex = 0;
        // ready statistics values
        private int statReady = 0;
        // statistics array
        private int[] statCount1 = new int[statLength];
        private int[] statCount2 = new int[statLength];
        
        // Class constructor
        public MainForm( )
        {
            InitializeComponent( );

            EnableContols( false );
        }

        // On form closing
        private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            Disconnect( );
        }

        // Enable/disable connection controls
        private void EnableContols( bool enable )
        {
            connectButton.Enabled    = !enable;
            disconnectButton.Enabled = enable;
        }

        // On "Connect" button click
        private void connectButton_Click( object sender, EventArgs e )
        {
            if ( Connect( ipBox.Text ) )
            {
                EnableContols( true );
                statusLabel.Text = "Connected";
            }
            else
            {
                MessageBox.Show( "Failed connecting to SVS.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        // On "Disconnect" buttong click
        private void disconnectButton_Click( object sender, EventArgs e )
        {
            Disconnect( );
            statusLabel.Text = "Disconnected";
            fpsLabel.Text = string.Empty;
            fpsLabel.Text = string.Empty;
        }

        // Connect to SVS
        private bool Connect( string host )
        {
            bool result = true;

            try
            {
                svs.Connect( host );

                // start left camera
                SVS.Camera leftCamera = svs.GetLeftCamera( );
//                leftCamera.SetQuality( 5 );
                leftCameraPlayer.VideoSource = leftCamera;
                leftCameraPlayer.Start( );

                // start right camera
                SVS.Camera rightCamera = svs.GetRightCamera( );
//                rightCamera.SetQuality( 5 );
                rightCameraPlayer.VideoSource = rightCamera;
                rightCameraPlayer.Start( );

                // reset statistics
                statIndex = statReady = 0;

                // start timer
                timer.Start( );
            }
            catch
            {
                result = false;
            }

            return result;
        }

        // Disconnect from Qwerk
        private void Disconnect( )
        {
            // if (  )
            {
                timer.Stop( );

                if ( leftCameraPlayer.VideoSource != null )
                {
                    leftCameraPlayer.VideoSource.SignalToStop( );
                    leftCameraPlayer.VideoSource.WaitForStop( );
                    leftCameraPlayer.VideoSource = null;
                }

                if ( rightCameraPlayer.VideoSource != null )
                {
                    rightCameraPlayer.VideoSource.SignalToStop( );
                    rightCameraPlayer.VideoSource.WaitForStop( );
                    rightCameraPlayer.VideoSource = null;
                }

                svs.Disconnect( );

                EnableContols( false );
            }
        }

        // On timer's tick
        private void timer_Tick( object sender, EventArgs e )
        {
            // update camaeras' FPS
            if ( ( leftCameraPlayer.VideoSource != null ) || ( rightCameraPlayer.VideoSource != null ) )
            {
                // get number of frames for the last second
                if ( leftCameraPlayer.VideoSource != null )
                {
                    statCount1[statIndex] = leftCameraPlayer.VideoSource.FramesReceived;
                }
                if ( rightCameraPlayer.VideoSource != null )
                {
                    statCount2[statIndex] = rightCameraPlayer.VideoSource.FramesReceived;
                }

                // increment indexes
                if ( ++statIndex >= statLength )
                    statIndex = 0;
                if ( statReady < statLength )
                    statReady++;

                float fps1 = 0;
                float fps2 = 0;

                // calculate average value
                for ( int i = 0; i < statReady; i++ )
                {
                    fps1 += statCount1[i];
                    fps2 += statCount2[i];
                }
                fps1 /= statReady;
                fps2 /= statReady;

                fpsLabel.Text = string.Format( "L: {0:F2} fps, R: {1:F2} fps",
                    fps1, fps2 );
            }
        }

        private void button1_Click( object sender, EventArgs e )
        {

            svs.GetVersion( );

            // svs.RunningTime( );
        }

        private void button2_Click( object sender, EventArgs e )
        {
            if ( leftCameraPlayer.VideoSource != null )
            {
                SVS.Camera camera = (SVS.Camera) leftCameraPlayer.VideoSource;

                camera.SetQuality( 1 );
                camera.SetResolution( SVS.CameraResolution.Large );
            }
        }

        private void button3_Click( object sender, EventArgs e )
        {
            if ( leftCameraPlayer.VideoSource != null )
            {
                SVS.Camera camera = (SVS.Camera) leftCameraPlayer.VideoSource;

                camera.SetQuality( 5 );
                camera.SetResolution( SVS.CameraResolution.Small );
            }
        }
    }
}
