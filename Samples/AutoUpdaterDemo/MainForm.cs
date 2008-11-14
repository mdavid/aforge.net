// AForge AutoUpdater demo
// AForge.NET framework
//
// Copyright © Frank Nagl, 2008
// admin@franknagl.de
// www.franknagl.de
//

namespace AutoUpdaterDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using AForge.AutoUpdater;
    using System.IO;

    /// <summary>
    /// Small program to demonstrate the function and the handling of the AutoUpdater.
    /// </summary>
    public partial class MainForm : Form
    {
        Updater updater;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            updater = new Updater("version.txt",
                "http://franknagl.de/updates/AutoUpdaterDemo/newVersion.txt",
                "AutoUpdaterDemo.exe");
            //Second possibility to initialize the updater (here with same properties)
            //updater = new Updater("version.txt",
            //    "http://franknagl.de/updates/AutoUpdaterDemo/newVersion.txt",
            //    "AutoUpdaterDemo.exe", 
            //     1000 * 5,            //first check for update
            //     1000 * (2 * 3600));  //periodic check for update
            updater.OnCheckUpdateEvent += new OnCheckUpdateEventHandler(updateAvailable);
        }

        /// <summary>
        /// Called by the <see cref="OnCheckUpdateEventHandler"/>.
        /// Checks if there is an update available.
        /// </summary>
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
            {
                if (MessageBox.Show("No update available. " +
                    "Should I delete the update (so you can update again)?",
                    "No update available",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    WriteLine("version.txt", 1, "Version;1.0", true);
                    WriteLine("version.txt", 2, "ReleaseDate;2008-11-13", true);
                    File.Delete("UpdatedFile.txt");
                    File.CreateText("IWillBeDeletedAfterUpdate.txt");
                    MessageBox.Show("Update is retracted. You can update again.");
                };
            }
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

        /// <summary>
        /// Writes the passed text in the passed line of the file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="line">The line number.</param>
        /// <param name="text">The text.</param>
        /// <param name="replace">Replace text (t) or paste (f)</param>
        private static void WriteLine(String filename, int line, string text, bool replace)
        {
            string content = "";
            string[] delimiter = { "\r\n" };

            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename, System.Text.Encoding.Default);
                content = reader.ReadToEnd();
                reader.Close();
            }

            string[] cols = content.Split(delimiter, StringSplitOptions.None);

            if (cols.Length >= line)
            {
                if (!replace)
                    cols[line - 1] = text + "\r\n" + cols[line - 1];
                else
                    cols[line - 1] = text;

                content = "";
                for (int x = 0; x < cols.Length - 1; x++)
                {
                    content += cols[x] + "\r\n";
                }
                content += cols[cols.Length - 1];

            }
            else
            {
                for (int x = 0; x < line - cols.Length; x++)
                    content += "\r\n";

                content += text;
            }


            StreamWriter writer = new StreamWriter(filename);
            writer.Write(content);
            writer.Close();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}