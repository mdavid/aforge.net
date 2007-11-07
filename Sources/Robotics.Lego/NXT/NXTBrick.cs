// AForge Lego Robotics Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2007
// andrew.kirillov@gmail.com
//

namespace AForge.Robotics.Lego.NXT
{
    using System;

    /// <summary>
    /// Manipulation of Lego Mindstorms NXT device.
    /// </summary>
    /// 
    public class NXTBrick
    {
        // communication interfaced used for communication with NXT brick
        private INXTCommunicationInterface communicationInterface;
        // internal buffer used for communication
        private byte[] communicationBuffer = new byte[64];
        // last device error
        private DeviceError lastError = DeviceError.Success;

        /// <summary>
        /// Check if connection to NXT brick is established.
        /// </summary>
        /// 
        public bool IsConnected
        {
            get { return ( communicationInterface.IsConnected ); }
        }

        /// <summary>
        /// Last error code returned from device.
        /// </summary>
        /// 
        /// <remarks>The property keeps last error code returned by NXT brick during communication. The property
        /// is updated every time, when one of class's methods returns <see cref="CommunicationStatus.DeviceError"/>
        /// or <see cref="CommunicationStatus.UnknownDeviceError"/> error code.</remarks>
        /// 
        public DeviceError LastDeviceError
        {
            get { return lastError; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NXTBrick"/> class.
        /// </summary>
        /// 
        /// <param name="communicationInterface">Communication interface to use for communication with NXT device.</param>
        /// 
        public NXTBrick( INXTCommunicationInterface communicationInterface )
        {
            this.communicationInterface = communicationInterface;
        }

        /// <summary>
        /// Connect to NXT brick.
        /// </summary>
        /// 
        /// <returns>Returns <see cref="CommunicationStatus.Success"/> if connection was done successfully, or
        /// <see cref="CommunicationStatus.Failed"/> otherwise.</returns>
        /// 
        /// <remarks>If connection to NXT brick is established before the call, existing connection will be reused.
        /// If it is required to force reconnection, then <see cref="Disconnect"/> method should be called before.
        /// </remarks>
        /// 
        public CommunicationStatus Connect( )
        {
            // reset last device error
            lastError = DeviceError.Success;

            return communicationInterface.Connect( );
        }

        /// <summary>
        /// Disconnect from NXT brick.
        /// </summary>
        /// 
        public void Disconnect( )
        {
            communicationInterface.Disconnect( );
        }

        /// <summary>
        /// Get firmware version of NXT brick.
        /// </summary>
        /// 
        /// <param name="protocolVersion">Protocol version.</param>
        /// <param name="firmwareVersion">Firmware version.</param>
        /// 
        /// <returns>Returns <see cref="CommunicationStatus.Success"/> if message was read successfully, or
        /// another value describing error. In the case if <see cref="CommunicationStatus.DeviceError"/> or
        /// <see cref="CommunicationStatus.UnknownDeviceError"/> status is returned, <see cref="LastDeviceError"/>
        /// property is updated with device error code.</returns>
        ///
        public CommunicationStatus GetFirmwareVersion( ref string protocolVersion, ref string firmwareVersion )
        {
            CommunicationStatus status = CommunicationStatus.Success;

            // prepare message
            communicationBuffer[0] = (byte) CommandType.SystemCommand;
            communicationBuffer[1] = (byte) SystemCommand.GetFirmwareVersion;

            status = SendMessageAndGetReply( communicationBuffer, 2, communicationBuffer );

            if ( status == CommunicationStatus.Success )
            {
                protocolVersion = string.Format( "{0}.{1}", communicationBuffer[4], communicationBuffer[3] );
                firmwareVersion = string.Format( "{0}.{1}", communicationBuffer[6], communicationBuffer[5] );
            }
            return status;
        }

        /// <summary>
        /// Get information about NXT device.
        /// </summary>
        /// 
        /// <param name="deviceName">Device name.</param>
        /// <param name="btAddress">Bluetooth address.</param>
        /// <param name="btSignalStrength">Bluetooth signal strength.</param>
        /// <param name="freeUserFlash">Free user Flash.</param>
        /// 
        /// <returns>Returns <see cref="CommunicationStatus.Success"/> if message was read successfully, or
        /// another value describing error. In the case if <see cref="CommunicationStatus.DeviceError"/> or
        /// <see cref="CommunicationStatus.UnknownDeviceError"/> status is returned, <see cref="LastDeviceError"/>
        /// property is updated with device error code.</returns>
        /// 
        public CommunicationStatus GetDeviceInformation( ref string deviceName, ref byte[] btAddress, ref int btSignalStrength, ref int freeUserFlash )
        {
            CommunicationStatus status = CommunicationStatus.Success;

            // prepare message
            communicationBuffer[0] = (byte) CommandType.SystemCommand;
            communicationBuffer[1] = (byte) SystemCommand.GetDeviceInfo;

            status = SendMessageAndGetReply( communicationBuffer, 2, communicationBuffer );

            if ( status == CommunicationStatus.Success )
            {
                // devince name
                deviceName = System.Text.ASCIIEncoding.ASCII.GetString( communicationBuffer, 3, 15 );
                // Bluetooth address
                Array.Copy( communicationBuffer, 18, btAddress, 0, 7 );
                // Bluetooth signal strength
                btSignalStrength = communicationBuffer[25] | ( communicationBuffer[26] << 8 ) |
                    ( communicationBuffer[27] << 16 ) | ( communicationBuffer[28] << 24 );
                // free user Flash
                freeUserFlash = communicationBuffer[29] | ( communicationBuffer[30] << 8 ) |
                    ( communicationBuffer[31] << 16 ) | ( communicationBuffer[32] << 24 );
            }
            return status;
        }

        /// <summary>
        /// Get battery level of NXT device.
        /// </summary>
        /// 
        /// <param name="batteryLevel">Battery level in millivolts.</param>
        /// 
        /// <returns>Returns <see cref="CommunicationStatus.Success"/> if message was read successfully, or
        /// another value describing error. In the case if <see cref="CommunicationStatus.DeviceError"/> or
        /// <see cref="CommunicationStatus.UnknownDeviceError"/> status is returned, <see cref="LastDeviceError"/>
        /// property is updated with device error code.</returns>
        /// 
        public CommunicationStatus GetBatteryLevel( ref int batteryLevel )
        {
            CommunicationStatus status = CommunicationStatus.Success;

            // prepare message
            communicationBuffer[0] = (byte) CommandType.DirectCommand;
            communicationBuffer[1] = (byte) DirectCommand.GetBatteryLevel;

            status = SendMessageAndGetReply( communicationBuffer, 2, communicationBuffer );

            if ( status == CommunicationStatus.Success )
            {
                batteryLevel = communicationBuffer[3] | ( communicationBuffer[4] << 8 );
            }
            return status;
        }


        /// <summary>
        /// Set name of NXT device.
        /// </summary>
        /// 
        /// <param name="deviceName">Device name to set for the brick.</param>
        /// 
        /// <returns>Returns <see cref="CommunicationStatus.Success"/> if message was read successfully, or
        /// another value describing error. In the case if <see cref="CommunicationStatus.DeviceError"/> or
        /// <see cref="CommunicationStatus.UnknownDeviceError"/> status is returned, <see cref="LastDeviceError"/>
        /// property is updated with device error code.</returns>
        /// 
        public CommunicationStatus SetBrickName( string deviceName )
        {
            // prepare message
            Array.Clear( communicationBuffer, 0, 18 );
            communicationBuffer[0] = (byte) CommandType.SystemCommand;
            communicationBuffer[1] = (byte) SystemCommand.SetBrickName;
            // convert string to bytes
            System.Text.ASCIIEncoding.ASCII.GetBytes( deviceName, 0, Math.Min( deviceName.Length, 14 ), communicationBuffer, 2 );

            return SendMessageAndGetReply( communicationBuffer, 18, communicationBuffer );
        }


        #region Private methods

        /// <summary>
        /// Sends prepared message to NXT message and reads reply.
        /// </summary>
        /// 
        /// <param name="message">Buffer containing message to send.</param>
        /// <param name="messageLength">Message length in the buffer.</param>
        /// <param name="reply">Buffer, which receives reply message.</param>
        /// 
        /// <returns>Returns communication status.</returns>
        /// 
        private CommunicationStatus SendMessageAndGetReply( byte[] message, int messageLength, byte[] reply )
        {
            CommunicationStatus status = CommunicationStatus.Success;

            // send message to NXT brick
            status = communicationInterface.SendMessage( message, messageLength );

            if ( status == CommunicationStatus.Success )
            {
                int bytesRead = 0;

                // read message
                status = communicationInterface.ReadMessage( reply, ref bytesRead );

                if (  status == CommunicationStatus.Success )
                {
                    // check for errors
                    if ( reply[2] == 0 )
                    {
                        status = CommunicationStatus.Success;
                    }
                    else
                    {
                        // set last error
                        lastError = (DeviceError) reply[2];
                        // set status
                        status = ( Enum.IsDefined( typeof( DeviceError ), reply[2] ) ) ?
                            CommunicationStatus.DeviceError : CommunicationStatus.UnknownDeviceError;
                    }
                }
            }

            return status;
        }

        #endregion
    }
}
