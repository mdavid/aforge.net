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
            this.versionLabel = new System.Windows.Forms.ToolStripStatusLabel( );
            this.fpsLabel = new System.Windows.Forms.ToolStripStatusLabel( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.leftCameraPlayer = new AForge.Controls.VideoSourcePlayer( );
            this.groupBox3 = new System.Windows.Forms.GroupBox( );
            this.rightCameraPlayer = new AForge.Controls.VideoSourcePlayer( );
            this.timer = new System.Windows.Forms.Timer( this.components );
            this.button1 = new System.Windows.Forms.Button( );
            this.button2 = new System.Windows.Forms.Button( );
            this.button3 = new System.Windows.Forms.Button( );
            this.showStereoButton = new System.Windows.Forms.Button( );
            this.button4 = new System.Windows.Forms.Button( );
            this.button5 = new System.Windows.Forms.Button( );
            this.button6 = new System.Windows.Forms.Button( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.button7 = new System.Windows.Forms.Button( );
            this.button8 = new System.Windows.Forms.Button( );
            this.button9 = new System.Windows.Forms.Button( );
            this.groupBox1.SuspendLayout( );
            this.statusStrip.SuspendLayout( );
            this.groupBox2.SuspendLayout( );
            this.groupBox3.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
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
            this.versionLabel,
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
            // versionLabel
            // 
            this.versionLabel.AutoSize = false;
            this.versionLabel.BorderSides = ( (System.Windows.Forms.ToolStripStatusLabelBorderSides) ( ( ( ( System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top )
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right )
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom ) ) );
            this.versionLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size( 350, 17 );
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fpsLabel
            // 
            this.fpsLabel.BorderSides = ( (System.Windows.Forms.ToolStripStatusLabelBorderSides) ( ( ( ( System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top )
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right )
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom ) ) );
            this.fpsLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size( 393, 17 );
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point( 302, 374 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 75, 23 );
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point( 16, 374 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 75, 23 );
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler( this.button2_Click );
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point( 110, 374 );
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size( 75, 23 );
            this.button3.TabIndex = 8;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler( this.button3_Click );
            // 
            // showStereoButton
            // 
            this.showStereoButton.Location = new System.Drawing.Point( 360, 32 );
            this.showStereoButton.Name = "showStereoButton";
            this.showStereoButton.Size = new System.Drawing.Size( 152, 23 );
            this.showStereoButton.TabIndex = 9;
            this.showStereoButton.Text = "Show &Stereo Anaglyph";
            this.showStereoButton.UseVisualStyleBackColor = true;
            this.showStereoButton.Click += new System.EventHandler( this.showStereoButton_Click );
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point( 492, 374 );
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size( 75, 23 );
            this.button4.TabIndex = 10;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler( this.button4_Click );
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point( 16, 415 );
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size( 75, 23 );
            this.button5.TabIndex = 11;
            this.button5.Text = "Forward";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler( this.button5_Click );
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point( 110, 415 );
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size( 75, 23 );
            this.button6.TabIndex = 12;
            this.button6.Text = "Backward";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler( this.button6_Click );
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point( 635, 374 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 189, 64 );
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point( 472, 415 );
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size( 75, 23 );
            this.button7.TabIndex = 14;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler( this.button7_Click );
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point( 208, 415 );
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size( 34, 23 );
            this.button8.TabIndex = 15;
            this.button8.Text = "+";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler( this.button8_Click );
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point( 248, 415 );
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size( 34, 23 );
            this.button9.TabIndex = 16;
            this.button9.Text = "-";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler( this.button9_Click );
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 858, 481 );
            this.Controls.Add( this.button9 );
            this.Controls.Add( this.button8 );
            this.Controls.Add( this.button7 );
            this.Controls.Add( this.pictureBox1 );
            this.Controls.Add( this.button6 );
            this.Controls.Add( this.button5 );
            this.Controls.Add( this.button4 );
            this.Controls.Add( this.showStereoButton );
            this.Controls.Add( this.button3 );
            this.Controls.Add( this.button2 );
            this.Controls.Add( this.button1 );
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
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripStatusLabel versionLabel;
        private System.Windows.Forms.Button showStereoButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}

