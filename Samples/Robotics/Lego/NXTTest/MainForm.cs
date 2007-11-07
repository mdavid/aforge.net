// AForge.NET Framework
// Lego Mindstorm NXT test application
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

using AForge.Robotics.Lego.NXT;

namespace NXTTest
{
    public partial class MainForm : Form
    {
        // communication interface for NXT device
        SerialCommunication nxtCommunication = new SerialCommunication( "COM1" );
        // NXT brick
        NXTBrick nxt = null;

        // Constructor
        public MainForm( )
        {
            InitializeComponent( );

            nxt = new NXTBrick( nxtCommunication );

            // setup defaults
            portBox.Text = "COM7";
        }

        // On "Connect" button click
        private void connectButton_Click( object sender, EventArgs e )
        {
            nxtCommunication.PortName = portBox.Text;

            if ( nxt.Connect( ) == CommunicationStatus.Success )
            {
                System.Diagnostics.Debug.WriteLine( "Connected successfully" );

                CollectInformation( );
            }
            else
            {
                MessageBox.Show( "Failed connecting to NXT device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        // On "Disconnect" button click
        private void disconnectButton_Click( object sender, EventArgs e )
        {
            nxt.Disconnect( );

            firmwareBox.Text = string.Empty;
            protocolBox.Text = string.Empty;
            deviceNameBox.Text = string.Empty;
            btAddressBox.Text = string.Empty;
            btSignalStrengthBox.Text = string.Empty;
            freeUserFlashBox.Text = string.Empty;
        }

        // Collect information about Lego NXT brick
        private void CollectInformation( )
        {
            // ------------------------------------------------
            // get NXT version
            string firmwareVersion = null;
            string protocolVersion = null;

            if ( nxt.GetFirmwareVersion( ref protocolVersion, ref firmwareVersion ) == CommunicationStatus.Success )
            {
                firmwareBox.Text = firmwareVersion;
                protocolBox.Text = protocolVersion;
                System.Diagnostics.Debug.WriteLine( "Verion OK" );
            }
            else
            {
                System.Diagnostics.Debug.WriteLine( "Failed getting verion" );
            }

            // ------------------------------------------------
            // get device information
            string deviceName = null;
            byte[] btAddress = new byte[7];
            int btSignalStrength = 0;
            int freeUserFlesh = 0;

            if ( nxt.GetDeviceInformation( ref deviceName, ref btAddress, ref btSignalStrength, ref freeUserFlesh ) == CommunicationStatus.Success )
            {
                deviceNameBox.Text = deviceName;

                btAddressBox.Text = string.Format( "{0} {1} {2} {3} {4} {5} {6}",
                    btAddress[0].ToString( "X2" ),
                    btAddress[1].ToString( "X2" ),
                    btAddress[2].ToString( "X2" ),
                    btAddress[3].ToString( "X2" ),
                    btAddress[4].ToString( "X2" ),
                    btAddress[5].ToString( "X2" ),
                    btAddress[6].ToString( "X2" )
                );

                btSignalStrengthBox.Text = btSignalStrength.ToString( );
                freeUserFlashBox.Text = freeUserFlesh.ToString( );

                System.Diagnostics.Debug.WriteLine( "Device information OK" );
            }
            else
            {
                System.Diagnostics.Debug.WriteLine( "Failed getting device information" );
            }


            // ------------------------------------------------
            // get battery level
            int batteryLevel = 0;

            if ( nxt.GetBatteryLevel( ref batteryLevel ) == CommunicationStatus.Success )
            {
                batteryLevelBox.Text = batteryLevel.ToString( );
                System.Diagnostics.Debug.WriteLine( "Battery level OK" );
            }
            else
            {
                System.Diagnostics.Debug.WriteLine( "Failed getting battery level" );
            }
        }

        private void button1_Click( object sender, EventArgs e )
        {
            if ( nxt.SetBrickName( "Angel" ) == CommunicationStatus.Success )
            {
                System.Diagnostics.Debug.WriteLine( "Set name OK" );
            }
            else
            {
                System.Diagnostics.Debug.WriteLine( "Failed setting name" );
            }
        }
    }
}