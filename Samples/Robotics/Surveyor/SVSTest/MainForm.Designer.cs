namespace SVSTest
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
            this.components = new System.ComponentModel.Container( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.disconnectButton = new System.Windows.Forms.Button( );
            this.connectButton = new System.Windows.Forms.Button( );
            this.ipBox = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.statusStrip = new System.Windows.Forms.StatusStrip( );
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel( );
            this.fpsLabel = new System.Windows.Forms.ToolStripStatusLabel( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.leftCameraPlayer = new AForge.Controls.VideoSourcePlayer( );
            this.groupBox3 = new System.Windows.Forms.GroupBox( );
            this.rightCameraPlayer = new AForge.Controls.VideoSourcePlayer( );
            this.timer = new System.Windows.Forms.Timer( this.components );
            this.groupBox1.SuspendLayout( );
            this.statusStrip.SuspendLayout( );
            this.groupBox2.SuspendLayout( );
            this.groupBox3.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.disconnectButton );
            this.groupBox1.Controls.Add( this.connectButton );
            this.groupBox1.Controls.Add( this.ipBox );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Location = new System.Drawing.Point( 10, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 342, 60 );
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SVS Connection";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point( 260, 24 );
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size( 75, 23 );
            this.disconnectButton.TabIndex = 3;
            this.disconnectButton.Text = "&Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler( this.disconnectButton_Click );
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point( 180, 24 );
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size( 75, 23 );
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "&Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler( this.connectButton_Click );
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point( 75, 25 );
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size( 100, 20 );
            this.ipBox.TabIndex = 1;
            this.ipBox.Text = "169.254.0.10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 10, 27 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 61, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address:";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.fpsLabel} );
            this.statusStrip.Location = new System.Drawing.Point( 0, 459 );
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size( 858, 22 );
            this.statusStrip.TabIndex = 3;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = false;
            this.statusLabel.BorderSides = ( (System.Windows.Forms.ToolStripStatusLabelBorderSides) ( ( ( ( System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top )
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right )
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom ) ) );
            this.statusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size( 100, 17 );
            this.statusLabel.Text = "Disconnected";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fpsLabel
            // 
            this.fpsLabel.BorderSides = ( (System.Windows.Forms.ToolStripStatusLabelBorderSides) ( ( ( ( System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top )
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right )
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom ) ) );
            this.fpsLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size( 743, 17 );
            this.fpsLabel.Spring = true;
            this.fpsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.leftCameraPlayer );
            this.groupBox2.Location = new System.Drawing.Point( 10, 75 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 342, 272 );
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Left Camera View";
            // 
            // leftCameraPlayer
            // 
            this.leftCameraPlayer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.leftCameraPlayer.ForeColor = System.Drawing.Color.White;
            this.leftCameraPlayer.Location = new System.Drawing.Point( 10, 20 );
            this.leftCameraPlayer.Name = "leftCameraPlayer";
            this.leftCameraPlayer.Size = new System.Drawing.Size( 322, 242 );
            this.leftCameraPlayer.TabIndex = 0;
            this.leftCameraPlayer.VideoSource = null;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add( this.rightCameraPlayer );
            this.groupBox3.Location = new System.Drawing.Point( 360, 75 );
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size( 342, 272 );
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Right Camera View";
            // 
            // rightCameraPlayer
            // 
            this.rightCameraPlayer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.rightCameraPlayer.ForeColor = System.Drawing.Color.White;
            this.rightCameraPlayer.Location = new System.Drawing.Point( 10, 20 );
            this.rightCameraPlayer.Name = "rightCameraPlayer";
            this.rightCameraPlayer.Size = new System.Drawing.Size( 322, 242 );
            this.rightCameraPlayer.TabIndex = 0;
            this.rightCameraPlayer.VideoSource = null;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler( this.timer_Tick );
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 858, 481 );
            this.Controls.Add( this.groupBox3 );
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.statusStrip );
            this.Controls.Add( this.groupBox1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Surveyor SVS Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.MainForm_FormClosing );
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout( );
            this.statusStrip.ResumeLayout( false );
            this.statusStrip.PerformLayout( );
            this.groupBox2.ResumeLayout( false );
            this.groupBox3.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel fpsLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private AForge.Controls.VideoSourcePlayer leftCameraPlayer;
        private System.Windows.Forms.GroupBox groupBox3;
        private AForge.Controls.VideoSourcePlayer rightCameraPlayer;
        private System.Windows.Forms.Timer timer;
    }
}

