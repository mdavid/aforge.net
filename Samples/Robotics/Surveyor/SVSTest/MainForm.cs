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
using AForge.Controls;
using AForge.Robotics.Surveyor;

namespace SVSTest
{
    public partial class MainForm : Form
    {
        private SVS svs = new SVS( );

        private StereoViewForm stereoViewForm;

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
            if ( stereoViewForm != null )
            {
                stereoViewForm.Close( );

            }
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
            statusLabel.Text  = "Disconnected";
            fpsLabel.Text     = string.Empty;
            versionLabel.Text = string.Empty;
        }

        // Connect to SVS
        private bool Connect( string host )
        {
            bool result = true;

            try
            {
                svs.Connect( host );

                // start left camera
                SRV1Camera leftCamera = svs.GetCamera( SVS.Camera.Left );
                leftCamera.SetResolution( SRV1Camera.Resolution.Small );
                leftCameraPlayer.VideoSource = leftCamera;
                leftCameraPlayer.Start( );

                // start right camera
                SRV1Camera rightCamera = svs.GetCamera( SVS.Camera.Right );
                rightCamera.SetResolution( SRV1Camera.Resolution.Small );
                rightCameraPlayer.VideoSource = rightCamera;
                rightCameraPlayer.Start( );

                versionLabel.Text = svs.GetVersion( );

                // reset statistics
                statIndex = statReady = 0;

                // start timer
                timer.Start( );
            }
            catch
            {
                result = false;
                Disconnect( );
            }

            return result;
        }

        // Disconnect from SVS
        private void Disconnect( )
        {
            if ( svs.IsConnected )
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
            System.Diagnostics.Debug.WriteLine( "Version 1: " +
                svs.GetDirectAccessToSRV1( SVS.Camera.Left ).GetVersion( ) );
            System.Diagnostics.Debug.WriteLine( "Version 2: " +
                svs.GetDirectAccessToSRV1( SVS.Camera.Right ).GetVersion( ) );

            long runTimeInSeconds = svs.GetDirectAccessToSRV1( SVS.Camera.Left ).GetRunningTime( ) / 1000;
            System.Diagnostics.Debug.WriteLine( "Running time 1 (mm:ss): " + ( (int) runTimeInSeconds / 60 ) + ":" + runTimeInSeconds % 60 );
            runTimeInSeconds = svs.GetDirectAccessToSRV1( SVS.Camera.Right ).GetRunningTime( ) / 1000;
            System.Diagnostics.Debug.WriteLine( "Running time 2 (mm:ss): " + ( (int) runTimeInSeconds / 60 ) + ":" + runTimeInSeconds % 60 );

            // svs.RunningTime( );
        }

        private void button2_Click( object sender, EventArgs e )
        {
            svs.RunMotors( 70, 70, 0 );
        }

        private void button3_Click( object sender, EventArgs e )
        {
            svs.StopMotors( );
        }

        private void showStereoButton_Click( object sender, EventArgs e )
        {
            if ( stereoViewForm == null )
            {
                stereoViewForm = new StereoViewForm( );
                stereoViewForm.FormClosing += new FormClosingEventHandler( stereoViewForm_OnFormClosing );

                leftCameraPlayer.NewFrame  += new VideoSourcePlayer.NewFrameHandler( stereoViewForm.OnNewLeftFrame );
                rightCameraPlayer.NewFrame += new VideoSourcePlayer.NewFrameHandler( stereoViewForm.OnNewRightFrame );
            }

            stereoViewForm.Show( );

            stereoViewForm.BringToFront( );
        }

        private void stereoViewForm_OnFormClosing( object sender, FormClosingEventArgs eventArgs )
        {
            leftCameraPlayer.NewFrame  -= new VideoSourcePlayer.NewFrameHandler( stereoViewForm.OnNewLeftFrame );
            rightCameraPlayer.NewFrame -= new VideoSourcePlayer.NewFrameHandler( stereoViewForm.OnNewRightFrame );

            stereoViewForm.FormClosing -= new FormClosingEventHandler( stereoViewForm_OnFormClosing );
            stereoViewForm = null;
        }

        private void button4_Click( object sender, EventArgs e )
        {
            // svs.ServoControl( 0x10, 0x40 );
        }

        private void button5_Click( object sender, EventArgs e )
        {
            svs.ControlMotors( SRV1.MotorCommand.DriveForward );
        }

        private void button6_Click( object sender, EventArgs e )
        {
            svs.ControlMotors( SRV1.MotorCommand.DriveBack );
        }

        private void button7_Click( object sender, EventArgs e )
        {
            pictureBox1.Image = svs.GetDirectAccessToSRV1( SVS.Camera.Left ).GetImage( );
            pictureBox1.Invalidate( );

            System.Diagnostics.Debug.WriteLine( "Done" );
        }

        private void button8_Click( object sender, EventArgs e )
        {
            //svs.ControlMotors( SRV1.MotorCommand.BalanceTowardLeft );
        }

        private void button9_Click( object sender, EventArgs e )
        {
            //svs.ControlMotors( SRV1.MotorCommand.BalanceTowardRight );

        }
    }
}
