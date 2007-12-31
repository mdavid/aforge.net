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
        private SerialCommunication nxtCommunication = new SerialCommunication( "COM1" );
        // NXT brick
        private NXTBrick nxt = null;
        // rugulation modes
        private RegulationMode[] regulationModes = new RegulationMode[]
            { RegulationMode.Idle, RegulationMode.Speed, RegulationMode.Sync };
        // run states
        private RunState[] runStates = new RunState[]
            { RunState.Idle, RunState.RampUp, RunState.Running, RunState.RampDown };

        // Constructor
        public MainForm( )
        {
            InitializeComponent( );

            nxt = new NXTBrick( nxtCommunication );

            // setup defaults
            portBox.Text = "COM8";
            motorCombo.SelectedIndex = 0;
            regulationModeCombo.SelectedIndex = 0;
            runStateCombo.SelectedIndex = 2;
        }

        // On "Connect" button click
        private void connectButton_Click( object sender, EventArgs e )
        {
            nxtCommunication.PortName = portBox.Text;

            if ( nxt.Connect( ) == CommunicationStatus.Success )
            {
                System.Diagnostics.Debug.WriteLine( "Connected successfully" );

                CollectInformation( );

                // enable controls
                resetMotorButton.Enabled    = true;
                setMotorStateButton.Enabled = true;
                getMotorStateButton.Enabled = true;
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

            // clear information
            firmwareBox.Text = string.Empty;
            protocolBox.Text = string.Empty;
            deviceNameBox.Text = string.Empty;
            btAddressBox.Text = string.Empty;
            btSignalStrengthBox.Text = string.Empty;
            freeUserFlashBox.Text = string.Empty;
            batteryLevelBox.Text = string.Empty;

            tachoCountBox.Text = string.Empty;
            blockTachoCountBox.Text = string.Empty;
            rotationCountBox.Text = string.Empty;

            // disable controls
            resetMotorButton.Enabled    = false;
            setMotorStateButton.Enabled = false;
            getMotorStateButton.Enabled = false;
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
            }
            else
            {
                System.Diagnostics.Debug.WriteLine( "Failed getting battery level" );
            }
        }

        // Returns selected motor
        private OutputPort GetSelectedMotor( )
        {
            return (OutputPort) motorCombo.SelectedIndex;
        }

        // On motor "Reset" button click
        private void resetMotorButton_Click( object sender, EventArgs e )
        {
            if ( nxt.ResetMotorPosition( GetSelectedMotor( ) ) != CommunicationStatus.Success )
            {
                System.Diagnostics.Debug.WriteLine( "Failed reseting motor" );
            }
        }

        // On motor "Set state" button click
        private void setMotorStateButton_Click( object sender, EventArgs e )
        {
            MotorState motorState = new MotorState( );

            // prepare motor's state to set
            motorState.Power = (sbyte) powerUpDown.Value;
            motorState.TurnRatio = (sbyte) turnRatioUpDown.Value;
            motorState.Mode = ( ( modeOnCheck.Checked ) ? MotorMode.On : MotorMode.None ) |
                ( ( modeBrakeCheck.Checked ) ? MotorMode.Brake : MotorMode.None ) |
                ( ( modeRegulatedBox.Checked ) ? MotorMode.Regulated : MotorMode.None );
            motorState.Regulation = regulationModes[regulationModeCombo.SelectedIndex];
            motorState.RunState = runStates[runStateCombo.SelectedIndex];
            // tacho limit
            try
            {
                motorState.TachoLimit = Math.Max( 0, Math.Min( 100000, int.Parse( tachoLimitBox.Text ) ) );
            }
            catch
            {
                motorState.TachoLimit = 1000;
                tachoLimitBox.Text = motorState.TachoLimit.ToString( );
            }

            // set motor's state
            if ( nxt.SetMotorState( GetSelectedMotor( ), motorState ) != CommunicationStatus.Success )
            {
                System.Diagnostics.Debug.WriteLine( "Failed setting motor state" );
            }
        }

        // On motor "Get state" button click
        private void getMotorStateButton_Click( object sender, EventArgs e )
        {
            MotorState motorState;

            // get motor's state
            if ( nxt.GetMotorState( GetSelectedMotor( ), out motorState ) == CommunicationStatus.Success )
            {
                tachoCountBox.Text = motorState.TachoCount.ToString( );
                blockTachoCountBox.Text = motorState.BlockTachoCount.ToString( );
                rotationCountBox.Text = motorState.RotationCount.ToString( );
            }
            else
            {
                System.Diagnostics.Debug.WriteLine( "Failed getting motor state" );
            }
        }
    }
}