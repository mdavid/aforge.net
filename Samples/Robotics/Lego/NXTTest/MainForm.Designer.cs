namespace NXTTest
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.disconnectButton = new System.Windows.Forms.Button( );
            this.connectButton = new System.Windows.Forms.Button( );
            this.portBox = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.freeUserFlashBox = new System.Windows.Forms.TextBox( );
            this.label7 = new System.Windows.Forms.Label( );
            this.btSignalStrengthBox = new System.Windows.Forms.TextBox( );
            this.label6 = new System.Windows.Forms.Label( );
            this.btAddressBox = new System.Windows.Forms.TextBox( );
            this.label5 = new System.Windows.Forms.Label( );
            this.deviceNameBox = new System.Windows.Forms.TextBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.protocolBox = new System.Windows.Forms.TextBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.firmwareBox = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.button1 = new System.Windows.Forms.Button( );
            this.label8 = new System.Windows.Forms.Label( );
            this.batteryLevelBox = new System.Windows.Forms.TextBox( );
            this.groupBox1.SuspendLayout( );
            this.groupBox2.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.disconnectButton );
            this.groupBox1.Controls.Add( this.connectButton );
            this.groupBox1.Controls.Add( this.portBox );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Location = new System.Drawing.Point( 10, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 280, 55 );
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point( 200, 24 );
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size( 70, 23 );
            this.disconnectButton.TabIndex = 3;
            this.disconnectButton.Text = "&Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler( this.disconnectButton_Click );
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point( 125, 24 );
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size( 70, 23 );
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "&Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler( this.connectButton_Click );
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point( 70, 25 );
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size( 48, 20 );
            this.portBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 10, 28 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 56, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.batteryLevelBox );
            this.groupBox2.Controls.Add( this.label8 );
            this.groupBox2.Controls.Add( this.freeUserFlashBox );
            this.groupBox2.Controls.Add( this.label7 );
            this.groupBox2.Controls.Add( this.btSignalStrengthBox );
            this.groupBox2.Controls.Add( this.label6 );
            this.groupBox2.Controls.Add( this.btAddressBox );
            this.groupBox2.Controls.Add( this.label5 );
            this.groupBox2.Controls.Add( this.deviceNameBox );
            this.groupBox2.Controls.Add( this.label4 );
            this.groupBox2.Controls.Add( this.protocolBox );
            this.groupBox2.Controls.Add( this.label3 );
            this.groupBox2.Controls.Add( this.firmwareBox );
            this.groupBox2.Controls.Add( this.label2 );
            this.groupBox2.Location = new System.Drawing.Point( 10, 75 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 280, 222 );
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device info";
            // 
            // freeUserFlashBox
            // 
            this.freeUserFlashBox.Location = new System.Drawing.Point( 110, 145 );
            this.freeUserFlashBox.Name = "freeUserFlashBox";
            this.freeUserFlashBox.ReadOnly = true;
            this.freeUserFlashBox.Size = new System.Drawing.Size( 100, 20 );
            this.freeUserFlashBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point( 10, 148 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 82, 13 );
            this.label7.TabIndex = 2;
            this.label7.Text = "Free user Flash:";
            // 
            // btSignalStrengthBox
            // 
            this.btSignalStrengthBox.Location = new System.Drawing.Point( 110, 115 );
            this.btSignalStrengthBox.Name = "btSignalStrengthBox";
            this.btSignalStrengthBox.ReadOnly = true;
            this.btSignalStrengthBox.Size = new System.Drawing.Size( 100, 20 );
            this.btSignalStrengthBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point( 10, 118 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 80, 13 );
            this.label6.TabIndex = 8;
            this.label6.Text = "Signal strength:";
            // 
            // btAddressBox
            // 
            this.btAddressBox.Location = new System.Drawing.Point( 110, 85 );
            this.btAddressBox.Name = "btAddressBox";
            this.btAddressBox.ReadOnly = true;
            this.btAddressBox.Size = new System.Drawing.Size( 160, 20 );
            this.btAddressBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 10, 88 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 95, 13 );
            this.label5.TabIndex = 6;
            this.label5.Text = "Bluetooth address:";
            // 
            // deviceNameBox
            // 
            this.deviceNameBox.Location = new System.Drawing.Point( 110, 55 );
            this.deviceNameBox.Name = "deviceNameBox";
            this.deviceNameBox.ReadOnly = true;
            this.deviceNameBox.Size = new System.Drawing.Size( 160, 20 );
            this.deviceNameBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 10, 58 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 73, 13 );
            this.label4.TabIndex = 4;
            this.label4.Text = "Device name:";
            // 
            // protocolBox
            // 
            this.protocolBox.Location = new System.Drawing.Point( 210, 25 );
            this.protocolBox.Name = "protocolBox";
            this.protocolBox.ReadOnly = true;
            this.protocolBox.Size = new System.Drawing.Size( 60, 20 );
            this.protocolBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 155, 28 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 49, 13 );
            this.label3.TabIndex = 2;
            this.label3.Text = "Protocol:";
            // 
            // firmwareBox
            // 
            this.firmwareBox.Location = new System.Drawing.Point( 70, 25 );
            this.firmwareBox.Name = "firmwareBox";
            this.firmwareBox.ReadOnly = true;
            this.firmwareBox.Size = new System.Drawing.Size( 60, 20 );
            this.firmwareBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 10, 28 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 52, 13 );
            this.label2.TabIndex = 0;
            this.label2.Text = "Firmware:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point( 329, 133 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 75, 23 );
            this.button1.TabIndex = 2;
            this.button1.Text = "Set name";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point( 10, 178 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 68, 13 );
            this.label8.TabIndex = 11;
            this.label8.Text = "Battery level:";
            // 
            // batteryLevelBox
            // 
            this.batteryLevelBox.Location = new System.Drawing.Point( 110, 175 );
            this.batteryLevelBox.Name = "batteryLevelBox";
            this.batteryLevelBox.ReadOnly = true;
            this.batteryLevelBox.Size = new System.Drawing.Size( 100, 20 );
            this.batteryLevelBox.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 416, 309 );
            this.Controls.Add( this.button1 );
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.groupBox1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Lego NXT Test";
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout( );
            this.groupBox2.ResumeLayout( false );
            this.groupBox2.PerformLayout( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox protocolBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox firmwareBox;
        private System.Windows.Forms.TextBox deviceNameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox freeUserFlashBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox btSignalStrengthBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox btAddressBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox batteryLevelBox;
        private System.Windows.Forms.Label label8;
    }
}

