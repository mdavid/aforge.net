using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AForge.AutoUpdater;

namespace AutoUpdaterDemo
{
    public partial class MainForm : Form
    {
        Updater updater;

        public MainForm()
        {
            InitializeComponent();
            testUpdate();
        }

        private void testUpdate()
        {
            updater = new Updater("version.txt",
                "http://franknagl.de/updates/AutoUpdaterDemo/newVersion.txt",
                "AutoUpdaterDemo.exe");
            updater.OnCheckUpdateEvent += new OnCheckUpdateEventHandler(updateAvailable);
        }

        private void updateAvailable()
        {
            notifyIcon.ShowBalloonTip(0, "Update", "Update available", ToolTipIcon.Info);
            updateButton.Visible = true;
        }

        /// <summary>
        /// Handles the Click event of the checkUpdateButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void checkUpdateButton_Click(object sender, EventArgs e)
        {
            if (!updater.Usercheck())
                MessageBox.Show("No update available.");
        }

        /// <summary>
        /// Handles the Click event of the updateButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update?", "Make update?",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
                updater.MakeUpdate();
        }
    }
}