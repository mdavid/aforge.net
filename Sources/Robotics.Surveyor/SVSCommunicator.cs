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
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using AForge;

    internal class SVSCommunicator
    {
        private IPEndPoint endPoint = null;

        // Connecton end-point
        public IPEndPoint EndPoint
        {
            get { return endPoint; }
        }

        // socket used for communication with SVS
        Socket socket = null;
        // background communicaton thread
        private Thread thread = null;
        // event signaling thread to exit
        private ManualResetEvent stopEvent = null;
        // event signaling about available request in communication queue
        private AutoResetEvent requestIsAvailable;
        // event sugnaling about available response
        private AutoResetEvent replyIsAvailable;

        // last processed request which requires reply
        private CommunicationRequest lastRequestWithReply;

        // communication request
        private class CommunicationRequest
        {
            public byte[] Request;
            public byte[] ResponseBuffer;
            public int    BytesRead; // -1 on error

            public CommunicationRequest( byte[] request )
            {
                this.Request = request;
            }
            public CommunicationRequest( byte[] request, byte[] responseBuffer )
            {
                this.Request = request;
                this.ResponseBuffer = responseBuffer;
            }
        }

        // communication queue
        Queue<CommunicationRequest> communicationQueue = new Queue<CommunicationRequest>( );

        public SVSCommunicator( ) { }

        // Connect to SVS using specfied IP and port number
        public void Connect( string ip, int port )
        {
            lock ( this )
            {
                if ( socket != null )
                    return;

                try
                {
                    // make sure communication queue is empty
                    communicationQueue.Clear( );

                    endPoint = new IPEndPoint( IPAddress.Parse( ip ), Convert.ToInt16( port ) );
                    // create TCP/IP socket and set timeouts
                    socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
                    socket.ReceiveTimeout = 5000;
                    socket.SendTimeout    = 1000;

                    // connect to SVS
                    socket.Connect( endPoint );

                    // create events
                    stopEvent = new ManualResetEvent( false );

                    requestIsAvailable = new AutoResetEvent( false );
                    replyIsAvailable = new AutoResetEvent( false );

                    // create and start new thread
                    thread = new Thread( new ThreadStart( CommunicationThread ) );
                    thread.Start( );
                }
                catch ( SocketException )
                {
                    throw new ConnectionFailedException( "Failed connecting to SVS." );
                }
            }
        }

        // Disconnect from SVS
        public void Disconnect( )
        {
            lock ( this )
            {
                if ( thread != null )
                {
                    // signal worker thread to stop
                    stopEvent.Set( );
                    requestIsAvailable.Set( );
                    replyIsAvailable.Set( );

                    // wait for aroung 1 s
                    for ( int i = 0; ( i < 20 ) && ( thread.Join( 0 ) == false ); i++ )
                    {
                        System.Threading.Thread.Sleep( 50 );
                    }
                    // abort thread if it can not be stopped
                    if ( thread.Join( 0 ) == false )
                    {
                        thread.Abort( );
                    }

                    thread = null;

                    // release events
                    stopEvent.Close( );
                    stopEvent = null;

                    requestIsAvailable.Close( );
                    requestIsAvailable = null;

                    replyIsAvailable.Close( );
                    replyIsAvailable = null;
                }

                if ( socket != null )
                {
                    if ( socket.Connected )
                    {
                        socket.Disconnect( false );
                    }
                    socket.Close( );
                    socket = null;
                    endPoint = null;
                }
            }
        }

        // Try to reconnect to SVS
        private void Reconnect( )
        {
            if ( socket != null )
            {
                if ( socket.Connected )
                {
                    socket.Disconnect( false );
                }
                socket.Close( );

                // create TCP/IP socket and set timeouts
                socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
                socket.ReceiveTimeout = 5000;
                socket.SendTimeout    = 1000;

                // connect to SVS
                socket.Connect( endPoint );
            }
        }

        // Enqueue request and leave - don't wait for reply
        public void Send( byte[] request )
        {
            lock ( communicationQueue )
            {
                communicationQueue.Enqueue( new CommunicationRequest( request ) );
            }
            if ( requestIsAvailable != null )
            {
                requestIsAvailable.Set( );
            }
        }

        // Enqueue request and wait for reply
        public int SendAndReceive( byte[] request, byte[] responseBuffer )
        {
            lock ( this )
            {
                if ( socket == null )
                {
                    // handle error
                    throw new NotConnectedException( "Not connected to SVS." );
                }

                lock ( communicationQueue )
                {
                    communicationQueue.Enqueue( new CommunicationRequest( request, responseBuffer ) );
                }
                requestIsAvailable.Set( );

                // waiting for reply
                replyIsAvailable.WaitOne( );

                // no reply since we got disconnect request from user - background thread is exiting
                if ( lastRequestWithReply == null )
                    return 0;

                // get number of bytes read
                int bytesRead = lastRequestWithReply.BytesRead;

                // clean the last reply
                lastRequestWithReply = null;

                if ( bytesRead < 0 )
                {
                    // handle error
                    throw new ConnectionLostException( "Connection lost or communicaton failure." );
                }

                return bytesRead;
            }
        }

        // size of portion to read at once
        private const int readSize = 1024;

        // Communication thread
        private void CommunicationThread( )
        {
            bool lastRequestFailed = false;

            while ( !stopEvent.WaitOne( 0, true ) )
            {
                // wait for any request
                requestIsAvailable.WaitOne( );

                while ( !stopEvent.WaitOne( 0, true ) )
                {
                    // get next communication request from queue
                    CommunicationRequest cr = null;

                    lock ( communicationQueue )
                    {
                        if ( communicationQueue.Count == 0 )
                            break;
                        cr = communicationQueue.Dequeue( );
                    }

                    try
                    {
                        // try to reconnect if we had communication issues on last request
                        if ( lastRequestFailed )
                        {
                            Reconnect( );
                            lastRequestFailed = false;
                        }


                        // System.Diagnostics.Debug.WriteLine( ">> " +
                        //    System.Text.ASCIIEncoding.ASCII.GetString( cr.Request ) );


                        // send request
                        socket.Send( cr.Request );

                        // read response
                        if ( cr.ResponseBuffer != null )
                        {
                            int bytesToRead = Math.Min( readSize, cr.ResponseBuffer.Length );

                            // receive first portion
                            cr.BytesRead = socket.Receive( cr.ResponseBuffer, 0, bytesToRead, SocketFlags.None );

                            // check if response contains image
                            if ( cr.BytesRead > 10 )
                            {
                                if (
                                    ( cr.ResponseBuffer[0] == (byte) '#' ) &&
                                    ( cr.ResponseBuffer[1] == (byte) '#' ) &&
                                    ( cr.ResponseBuffer[2] == (byte) 'I' ) &&
                                    ( cr.ResponseBuffer[3] == (byte) 'M' ) &&
                                    ( cr.ResponseBuffer[4] == (byte) 'J' ) )
                                {
                                    // extract image size
                                    int imageSize = System.BitConverter.ToInt32( cr.ResponseBuffer, 6 );

                                    bytesToRead = imageSize + 10 - cr.BytesRead;

                                    if ( bytesToRead > cr.ResponseBuffer.Length - cr.BytesRead )
                                    {
                                        // response buffer is too small
                                        throw new ApplicationException( );
                                    }

                                    // read the rest
                                    while ( !stopEvent.WaitOne( 0, true ) )
                                    {
                                        int read = socket.Receive( cr.ResponseBuffer, cr.BytesRead,
                                            Math.Min( readSize, bytesToRead ), SocketFlags.None );

                                        cr.BytesRead += read;
                                        bytesToRead -= read;

                                        if ( bytesToRead == 0 )
                                            break;
                                    }
                                }
                            }

                            // System.Diagnostics.Debug.WriteLine( "<< (" + cr.BytesRead + ") " +
                            //     System.Text.ASCIIEncoding.ASCII.GetString( cr.ResponseBuffer, 0, Math.Min( 5, cr.BytesRead ) ) );
                        }
                        else
                        {
                            // read reply and throw it away, since nobody wants it
                            byte[] buffer = new byte[100];

                            while ( !stopEvent.WaitOne( 0, true ) )
                            {
                                int read = socket.Receive( buffer, 0, 100, SocketFlags.None );

                                if ( ( read < 100 ) && ( socket.Available == 0 ) )
                                {
                                    // System.Diagnostics.Debug.WriteLine( "<< " +
                                    //    System.Text.ASCIIEncoding.ASCII.GetString( buffer, 0, read ) );
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                        lastRequestFailed = true;
                        // report about falure
                        cr.BytesRead = -1;
                    }
                    finally
                    {
                        // signal about available response to waiting caller
                        if ( ( !stopEvent.WaitOne( 0, true ) ) && ( cr.ResponseBuffer != null ) )
                        {
                            lastRequestWithReply = cr;
                            replyIsAvailable.Set( );
                        }
                    }
                }
            }
        }
    }
}
