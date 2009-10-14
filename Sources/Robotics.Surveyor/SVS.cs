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
        /// <summary>
        /// Enumeration of SVS's Blackfin cameras.
        /// </summary>
        /// 
        /// <remarks><para>Since SVS board consists of two SRV-1 Blackfin cameras, the enumeration
        /// is used by different methods to specify which one to access.</para></remarks>
        /// 
        public enum Camera
        {
            /// <summary>
            /// Left camera (default port number is 10000).
            /// </summary>
            Left,
            /// <summary>
            /// Right camera (default port number is 10001).
            /// </summary>
            Right
        }

        // host address if connection was established
        private string hostAddress;
        // communicators used for communication with SVS
        private SRV1 communicator1 = null;
        private SRV1 communicator2 = null;
        // SVS cameras
        private SRV1Camera leftCamera;
        private SRV1Camera rightCamera;

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
        /// to SVS board, otherwise it equals to <see langword="false"/>.</para>
        /// 
        /// <para><note>The property is not updated by the class, when connection was lost or
        /// communication failure was detected (which results into <see cref="ConnectionLostException"/>
        /// exception). The property only shows status of <see cref="Connect"/> method.</note></para>
        /// </remarks>
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
        /// <para><note>The method calls <see cref="Disconnect"/> before making any connection
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
                        communicator1 = new SRV1( );
                        communicator2 = new SRV1( );

                        communicator1.Connect( ipAddress, 10001 );
                        communicator2.Connect( ipAddress, 10002 );

                        hostAddress = ipAddress;
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
        /// obtained instance of left or right camera using <see cref="GetCamera"/>
        /// method, the video will be stopped automatically (and those <see cref="SRV1Camera"/>
        /// instances should be discarded).
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
        /// Get SVS's camera.
        /// </summary>
        /// 
        /// <returns>Returns <see cref="SRV1Camera"/> object, which is connected to SVS's Blackfin camera.
        /// Use <see cref="SRV1Camera.Start"/> method to start the camera and start receiving video
        /// frames from it.</returns>
        /// 
        /// <remarks><para>The method provides an instance of <see cref="SRV1Camera"/>, which can be used
        /// for receiving continuous video frames from the SVS board.
        /// In the case if only one image is required, the <see cref="GetImage"/> method can be used.</para>
        /// 
        /// <para>Sample usage:</para>
        /// <code>
        /// // get SRV-1 camera
        /// SRV1Camera camera = svs.GetCamera( SVS.Camera.Left );
        /// // set NewFrame event handler
        /// camera.NewFrame += new NewFrameEventHandler( video_NewFrame );
        /// // start the video source
        /// camera.Start( );
        /// // ...
        /// 
        /// private void video_NewFrame( object sender, NewFrameEventArgs eventArgs )
        /// {
        ///     // get new frame
        ///     Bitmap bitmap = eventArgs.Frame;
        ///     // process the frame
        /// }
        /// </code>
        /// </remarks>
        /// 
        /// <exception cref="NotConnectedException">Not connected to SVS. Connect to SVS board before using
        /// this method.</exception>
        /// 
        public SRV1Camera GetCamera( Camera camera )
        {
            if ( camera == Camera.Left )
            {
                if ( leftCamera == null )
                {
                    leftCamera = SafeGetCommunicator1( ).GetCamera( );
                }
                return leftCamera;
            }

            if ( rightCamera == null )
            {
                rightCamera = SafeGetCommunicator2( ).GetCamera( );
            }
            return rightCamera;
        }

        /// <summary>
        /// Get single image from the SVS board.
        /// </summary>
        /// 
        /// <param name="camera">Camera to get image from.</param>
        /// 
        /// <returns>Returns image received from the specified camera of the SVS board or
        /// <see langword="null"/> if failed decoding provided response.</returns>
        /// 
        /// <remarks><para>The method provides single video frame retrieved from the specified SVS's
        /// camera. However in many cases it is required to receive video frames one after another, so
        /// the <see cref="GetCamera"/> method is more preferred for continuous video frames.</para></remarks>
        ///
        /// <exception cref="NotConnectedException">Not connected to SRV-1. Connect to SRV-1 before using
        /// this method.</exception>
        /// <exception cref="ConnectionLostException">Connection lost or communicaton failure. Try to reconnect.</exception>
        /// 
        public Bitmap GetImage( Camera camera )
        {
            return ( camera == Camera.Left ) ?
                SafeGetCommunicator1( ).GetImage( ) : SafeGetCommunicator2( ).GetImage( );
        }

        /// <summary>
        /// Get direct access to one of the SVS's SRV-1 Blackfin cameras.
        /// </summary>
        /// 
        /// <param name="camera">SRV-1 Blackfin to get direct access to.</param>
        /// 
        /// <returns>Returns <see cref="SRV1"/> object connected to the requested
        /// SRV-1 Blackfin camera.</returns>
        /// 
        /// <remarks><para>The method provides direct access to one of the SVS's SRV-1
        /// Blackfin cameras, so it could be possible to send some direct commands to it
        /// using <see cref="SRV1.Send"/> and <see cref="SRV1.SendAndReceive"/> methods.</para></remarks>
        /// 
        /// <exception cref="NotConnectedException">Not connected to SVS. Connect to SVS board before using
        /// this method.</exception>
        ///
        public SRV1 GetDirectAccessToSRV1( Camera camera )
        {
            return ( camera == Camera.Left ) ? SafeGetCommunicator1( ) : SafeGetCommunicator2( );
        }

        /// <summary>
        /// Get SVS board's firmware version string.
        /// </summary>
        /// 
        /// <returns>Returns SVS's version string.</returns>
        /// 
        /// <exception cref="NotConnectedException">Not connected to SVS. Connect to SVS board before using
        /// this method.</exception>
        /// <exception cref="ConnectionLostException">Connection lost or communicaton failure. Try to reconnect.</exception>
        /// 
        public string GetVersion( )
        {
            string str = SafeGetCommunicator1( ).GetVersion( );

            str = str.Replace( "##Version -", "" );
            str = str.Trim( );

            // remove "(stereo master)" or (stereo slave)" string
            int specificInfoPos = str.IndexOf( " (stereo " );
            if ( specificInfoPos != -1 )
            {
                str = str.Substring( 0, specificInfoPos );
            }

            return str;
        }

        /// <summary>
        /// Get SVS's board's running time.
        /// </summary>
        /// 
        /// <returns>Returns SVS boards running time in milliseconds.</returns>
        /// 
        /// <exception cref="NotConnectedException">Not connected to SVS. Connect to SVS board before using
        /// this method.</exception>
        /// <exception cref="ConnectionLostException">Connection lost or communicaton failure. Try to reconnect.</exception>
        /// <exception cref="ApplicationException">Failed parsing response from SVS.</exception>
        /// 
        public long GetRunningTime( )
        {
            return SafeGetCommunicator1( ).GetRunningTime( );
        }

        /// <summary>
        /// Run motors connected to the SVS board.
        /// </summary>
        /// 
        /// <param name="leftSpeed">Left motor's speed, [-127, 127].</param>
        /// <param name="rightSpeed">Right motor's speed, [-127, 127].</param>
        /// <param name="duration">Time duration to run motors measured in number
        /// of 10 milliseconds (0 for infinity).</param>
        /// 
        /// <remarks><para>The method sets specified speed to both motors connected to
        /// the SVS board. The maximum absolute speed equals to 127, but the sign specifies
        /// direction of motor's rotation (forward or backward).
        /// </para></remarks>
        /// 
        /// <exception cref="NotConnectedException">Not connected to SVS. Connect to SVS board before using
        /// this method.</exception>
        /// 
        public void RunMotors( sbyte leftSpeed, sbyte rightSpeed, byte duration )
        {
            SafeGetCommunicator1( ).RunMotors( leftSpeed, rightSpeed, duration );
        }

        /// <summary>
        /// Stop both motors.
        /// </summary>
        /// 
        /// <remarks><para>The method stops both motors connected to the SVS board by calling
        /// <see cref="RunMotors"/> method specifying 0 for motors' speed.</para></remarks>
        /// 
        /// <exception cref="NotConnectedException">Not connected to SVS. Connect to SVS board before using
        /// this method.</exception>
        /// 
        public void StopMotors( )
        {
            RunMotors( 0, 0, 0 );
        }

        /// <summary>
        /// Control motors connected to SVS board using predefined commands.
        /// </summary>
        /// 
        /// <param name="command">Motor command to send to the SVS board.</param>
        /// 
        /// <remarks><para><note>Controlling SVS motors with this method is only available
        /// after at least one direct motor command is sent, which is done using <see cref="StopMotors"/> or
        /// <see cref="RunMotors"/> methods.</note></para></remarks>
        /// 
        /// <exception cref="NotConnectedException">Not connected to SVS. Connect to SVS board before using
        /// this method.</exception>
        /// 
        public void ControlMotors( SRV1.MotorCommand command )
        {
            SafeGetCommunicator1( ).ControlMotors( command );
        }

        // Get first communicator safely
        private SRV1 SafeGetCommunicator1( )
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
        private SRV1 SafeGetCommunicator2( )
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
