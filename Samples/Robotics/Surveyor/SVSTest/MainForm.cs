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
                MessageBox.Show( "Failed connecting to Qwerk.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        // On "Disconnect" buttong click
        private void disconnectButton_Click( object sender, EventArgs e )
        {
            Disconnect( );
            statusLabel.Text = "Disconnected";
            fpsLabel.Text = string.Empty;
        }

        // Connect to SVS
        private bool Connect( string host )
        {
            bool result = true;

            try
            {
                // start left camera
                SVS.Camera leftCamera = new SVS.Camera( host, 10001 );
                leftCameraPlayer.VideoSource = leftCamera;
                leftCameraPlayer.Start( );

                // start right camera
                SVS.Camera rightCamera = new SVS.Camera( host, 10002 );
                rightCameraPlayer.VideoSource = rightCamera;
                rightCameraPlayer.Start( );

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
            // if ( qwerk.IsConnected )
            {
                // timer.Stop( );

                if ( leftCameraPlayer.VideoSource != null )
                {
                    leftCameraPlayer.VideoSource.SignalToStop( );
                    leftCameraPlayer.VideoSource.WaitForStop( );
                }

                if ( rightCameraPlayer.VideoSource != null )
                {
                    rightCameraPlayer.VideoSource.SignalToStop( );
                    rightCameraPlayer.VideoSource.WaitForStop( );
                }
                /*
                try
                {
                    // stop Qwerk's camera
                    Qwerk.Video qwerkVideo = qwerk.GetVideoService( );
                    qwerkVideo.SignalToStop( );
                    qwerkVideo.WaitForStop( );

                    // turn of all LEDs and disconnect
                    qwerk.GetLedsService( ).SetLedsState( Qwerk.LedState.Off );
                }
                catch
                {
                }

                qwerk.Disconnect( );*/

                EnableContols( false );
            }
        }
    }
}
