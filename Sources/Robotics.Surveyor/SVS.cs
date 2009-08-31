// AForge Surveyor Robotics Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Andrew Kirillov, 2007-2009
// andrew.kirillov@aforgenet.com
//

namespace AForge.Robotics.Surveyor
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;

    /// <summary>
    /// Manipulation of Surveyor SVS (Stereo Vision System) board.
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// 
    public partial class SVS
    {
        // host address if connection was established
        private string hostAddress;
        // communicators used for communication with SVS
        private SVSCommunicator communicator1 = null;
        private SVSCommunicator communicator2 = null;
        // SVS cameras
        private SVS.Camera leftCamera;
        private SVS.Camera rightCamera;

        private string sync1 = "1";
        private string sync2 = "1";

        /// <summary>
        /// SVS's host address.
        /// </summary>
        /// 
        /// <remarks><para>The property keeps SVS's IP address if the class is connected
        /// to SVS board, otherwise it equals to <see langword="null."/>.</para></remarks>
        ///
        public string HostAddress
        {
            get { return hostAddress; }
        }

        /// <summary>
        /// Connection state.
        /// </summary>
        /// 
        /// <remarks><para>The property equals to <see langword="true"/> if the class is connected
        /// to SVS board, otherwise it equals to <see langword="false"/>.</para></remarks>
        /// 
        public bool IsConnected
        {
            get { return ( hostAddress != null ); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SVS"/> class.
        /// </summary>
        ///
        public SVS( )
        {
        }

        /// <summary>
        /// Connect to SVS board.
        /// </summary>
        /// 
        /// <param name="ipAddress">IP address of SVS board.</param>
        /// 
        /// <remarks><para>The method establishes connection to SVS board. If it succeeds then
        /// other methods can be used to manipulate the board.</para>
        /// 
        /// <para><note>The method call <see cref="Disconnect"/> before making any connection
        /// attempts to make sure previous connection is closed.</note></para>
        /// </remarks>
        /// 
        /// <exception cref="ConnectionFailedException">Failed connecting to SVS.</exception>
        /// 
        public void Connect( string ipAddress )
        {
            // close previous connection
            Disconnect( );

            lock ( sync1 )
            {
                lock ( sync2 )
                {
                    try
                    {
                        communicator1 = new SVSCommunicator( );
                        communicator2 = new SVSCommunicator( );

                        communicator1.Connect( ipAddress, 10001 );
                        communicator2.Connect( ipAddress, 10002 );

                        hostAddress = null;
                    }
                    catch
                    {
                        Disconnect( );

                        throw new ConnectionFailedException( "Failed connecting to SVS." );
                    }
                }
            }
        }

        /// <summary>
        /// Disconnect from SVS device.
        /// </summary>
        /// 
        /// <remarks><para>The method disconnects from SVS board making all other methods
        /// unavailable (except <see cref="Connect"/> method). In the case if user
        /// obtained instance of left or right camera using <see cref="GetLeftCamera"/> or
        /// <see cref="GetRightCamera"/> method, the video will be stopped automatically
        /// (and those <see cref="Camera"/> instances should be discarded).
        /// </para></remarks>
        /// 
        public void Disconnect( )
        {
            lock ( sync1 )
            {
                lock ( sync2 )
                {
                    hostAddress = null;

                    // signal cameras to stop
                    if ( leftCamera != null )
                    {
                        leftCamera.SignalToStop( );
                    }
                    if ( rightCamera != null )
                    {
                        rightCamera.SignalToStop( );
                    }

                    // wait until cameras stop or abort them
                    if ( leftCamera != null )
                    {
                        // wait for aroung 250 ms
                        for ( int i = 0; ( i < 5 ) && ( leftCamera.IsRunning ); i++ )
                        {
                            System.Threading.Thread.Sleep( 50 );
                        }
                        // abort camera if it can not be stopped
                        if ( leftCamera.IsRunning )
                        {
                            leftCamera.Stop( );
                        }
                        leftCamera = null;
                    }
                    if ( rightCamera != null )
                    {
                        // wait for aroung 250 ms
                        for ( int i = 0; ( i < 5 ) && ( rightCamera.IsRunning ); i++ )
                        {
                            System.Threading.Thread.Sleep( 50 );
                        }
                        // abort camera if it can not be stopped
                        if ( rightCamera.IsRunning )
                        {
                            leftCamera.Stop( );
                        }
                        rightCamera = null;
                    }

                    if ( communicator1 != null )
                    {
                        communicator1.Disconnect( );
                        communicator1 = null;
                    }
                    if ( communicator2 != null )
                    {
                        communicator2.Disconnect( );
                        communicator2 = null;
                    }
                }
            }
        }

        /// <summary>
        /// Get left camera of SVS board the object is connected to.
        /// </summary>
        /// 
        /// <returns>Returns <see cref="Camera"/> object, which is connected to SVS's left camera.
        /// Use <see cref="Camera.Start"/> method to start the camera and start receiving new video
        /// frames.</returns>
        /// 
        /// <exception cref="NotConnectedException">Not connected to SVS. Connect to SVS board before using
        /// this method.</exception>
        /// 
        /// <exception cref="ConnectionLostException">Connection lost or communicaton failure. Try to reconnect.</exception>
        /// 
        public SVS.Camera GetLeftCamera( )
        {
            if ( leftCamera == null )
            {
                leftCamera = new Camera( SafeGetCommunicator1( ) );
            }
            return leftCamera;
        }

        /// <summary>
        /// Get right camera of SVS board the object is connected to.
        /// </summary>
        /// 
        /// <returns>Returns <see cref="Camera"/> object, which is connected to SVS's right camera.
        /// Use <see cref="Camera.Start"/> method to start the camera and start receiving new video
        /// frames.</returns>
        /// 
        /// <exception cref="NotConnectedException">Not connected to SVS. Connect to SVS board before using
        /// this method.</exception>
        /// 
        /// <exception cref="ConnectionLostException">Connection lost or communicaton failure. Try to reconnect.</exception>
        /// 
        public SVS.Camera GetRightCamera( )
        {
            if ( rightCamera == null )
            {
                rightCamera = new Camera( SafeGetCommunicator2( ) );
            }
            return rightCamera;
        }

        /// <summary>
        /// Get SVS's version string.
        /// </summary>
        /// 
        /// <returns>Returns SVS's version string.</returns>
        /// 
        /// <exception cref="NotConnectedException">Not connected to SVS. Connect to SVS board before using
        /// this method.</exception>
        /// 
        /// <exception cref="ConnectionLostException">Connection lost or communicaton failure. Try to reconnect.</exception>
        /// 
        public string GetVersion( )
        {
            byte[] response = new byte[100];

            int read = SafeGetCommunicator1( ).SendAndReceive( new byte[] { (byte) 'V' }, response );

            string str = System.Text.ASCIIEncoding.ASCII.GetString( response, 0, read );

            str = str.Replace( "##Version -", "" );
            str = str.Trim( );

            return str;
        }

        // Get first communicator safely
        private SVSCommunicator SafeGetCommunicator1( )
        {
            lock ( sync1 )
            {
                if ( communicator1 == null )
                {
                    throw new NotConnectedException( "Not connected to SVS." );
                }
                return communicator1;
            }
        }

        // Get second communicator safely
        private SVSCommunicator SafeGetCommunicator2( )
        {
            lock ( sync2 )
            {
                if ( communicator2 == null )
                {
                    throw new NotConnectedException( "Not connected to SVS." );
                }
                return communicator2;
            }
        }
    }
}
