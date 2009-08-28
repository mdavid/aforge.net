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

        SVSCommunicator communicator1 = null;
        SVSCommunicator communicator2 = null;

        public void Connect( string ipAddress )
        {
            // close previous connection
            Disconnect( );

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

                throw new ArgumentException( );
            }
        }

        /// <summary>
        /// Disconnect from SVS device.
        /// </summary>
        /// 
        public void Disconnect( )
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

        private SVS.Camera leftCamera;
        private SVS.Camera rightCamera;

        public SVS.Camera GetLeftCamera( )
        {
            if ( leftCamera == null )
            {
                leftCamera = new Camera( communicator1 );
            }
            return leftCamera;
        }

        public SVS.Camera GetRightCamera( )
        {
            if ( rightCamera == null )
            {
                rightCamera = new Camera( communicator2 );
            }
            return rightCamera;
        }

        public void GetVersion( )
        {
            byte[] response = new byte[100];

            int read = communicator1.SendAndReceive( new byte[] { (byte) 'V' }, response );

            System.Diagnostics.Debug.WriteLine(
                System.Text.ASCIIEncoding.ASCII.GetString( response, 0, read ) );


        }

        public void RunningTime( )
        {

        }
    }
}
