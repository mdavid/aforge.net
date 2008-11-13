using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace AForge.AutoUpdater
{
    /// <summary>
    /// Declares the event handler for available updates 
    /// </summary>
    public delegate void OnCheckUpdateEventHandler();


    /// <summary>
    /// Checks a program for an update, simply 
    /// by reading out an textfile with update informations.
    /// </summary>
    public class Updater
    {
        private const string updateDir = "tempUpdate/";
        /// <summary>
        /// Handles the OnCheckUpdateEvent at the client.        
        /// </summary>
        public OnCheckUpdateEventHandler OnCheckUpdateEvent;
        private Timer check;
        private Timer firstCheck;
        private string oldPath;
        private string newPath;
        private string programExe;

        /// <summary>
        /// Checks a program for an update, simply 
        /// by reading out an textfile with update informations.
        /// </summary>
        /// <remarks>
        /// <para>The first check is done after 5 seconds, 
        /// and a periodic check will done every 2 hours.</para>
        /// <para>The textfile consists of:</para>
        ///<para>In first line the version number, e.g.
        /// <code>Version;1.0</code></para> 
        /// <para>In all other lines two markers:</para>
        /// <para><code>Copy</code>, for files to update (e.g. Copy;newFile.exe)</para>
        /// <para><code>Delete</code>, for files to delete (e.g. Delete;oldFile.exe)</para>
        /// <para>All <code>copy</code>-files will be updates by copy and paste, 
        /// existing files will be override.</para>
        ///</remarks>
        /// <param name="oldPath">Path to the old textfile with the version number.</param>
        /// <param name="newPath">Path of the new textfile with the update informations 
        /// and new version number.</param>
        /// <param name="programExe">The exe file to restart the program</param>
        public Updater(string oldPath, string newPath, string programExe)
        {
            // first check after 5 seconds
            // periodic check all 2 hours
            Init(oldPath, newPath, programExe, 1000 * 5, 1000 * (2 * 3600));

        }

        /// <summary>
        /// Overloaded. Checks a program for an update, simply 
        /// by reading out an textfile with update informations.
        /// </summary>
        /// <remarks>
        /// <para>The textfile consists of:</para>
        ///<para>In first line the version number, e.g.
        /// <code>Version;1.0</code></para> 
        /// <para>In all other lines two markers:</para>
        /// <para><code>Copy</code>, for files to update (e.g. Copy;newFile.exe)</para>
        /// <para><code>Delete</code>, for files to delete (e.g. Delete;oldFile.exe)</para>
        /// <para>All <code>copy</code>-files will be updates by copy and paste, 
        /// existing files will be override.</para>
        ///</remarks>
        /// <param name="oldPath">Path to the old textfile with the version number.</param>
        /// <param name="newPath">Path of the new textfile with the update informations 
        /// and new version number.</param>
        /// <param name="programExe">The exe file to restart the program</param>
        /// <param name="firstCheckValue">Point in time of first check for update (in minutes)</param>
        /// <param name="periodicCheckValue">Point in time of periodic check for update (in minutes)</param>
        public Updater(string oldPath, string newPath, string programExe,
            int firstCheckValue, int periodicCheckValue)
        {
            Init(oldPath, newPath, programExe, firstCheckValue, periodicCheckValue);
        }

        /// <summary>
        /// Interface to check for updates manually, e.g. by the user.
        /// </summary>
        /// <returns>true, if an update is available</returns>
        public bool Usercheck()
        {
            //if (check == null)
            //    return true;
            if (CheckUpdate(oldPath, newPath))
            {
                FirecheckUpdateEvent();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Makes the update.
        /// </summary>
        /// <returns>True if the update was successful, otherwise false.</returns>
        public bool MakeUpdate()
        {
            try
            {
                ProgressBar bar = InitFormAndProgressBar();
                //get url of the new files
                string url = newPath.Remove(newPath.LastIndexOf('/') + 1);
                //get name of update file (e.g. update.csv)
                string updateFile = updateDir + newPath.Substring(newPath.LastIndexOf('/') + 1);
                Directory.CreateDirectory(updateDir);
                WebClient client = new WebClient();
                //download update file (e.g. update.csv)
                client.DownloadFile(newPath, updateFile);
                StreamReader r = new StreamReader(updateFile);
                List<string> copyFiles = new List<string>();
                string s;

                while ((s = r.ReadLine()) != null)
                {
                    if (s.StartsWith("Copy"))
                        copyFiles.Add(s.Substring(s.IndexOf(';') + 1));
                }

                bar.Maximum = 2 * copyFiles.Count;
                //copy all new files into the updateDir
                for (int i = 0; i < copyFiles.Count; i++)
                {
                    client.DownloadFile(url + copyFiles[i], updateDir + copyFiles[i]);
                    bar.PerformStep();
                }
                copyFiles.Clear();
                r.Close();
                client.Dispose();
                System.Windows.Forms.Application.OpenForms[0].Dispose();

                System.Diagnostics.ProcessStartInfo startInfo =
                new System.Diagnostics.ProcessStartInfo
                    ("update.exe", updateFile+" "+programExe+" "+oldPath);
                //startInfo.UseShellExecute = false;//hide the java shell
                System.Diagnostics.Process process =
                    System.Diagnostics.Process.Start(startInfo);
                //tProcess.WaitForExit();

                return true;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Update failed.", "Error",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

        }

        /// <summary>
        /// Inits the updater.
        /// </summary>
        /// <param name="oldPath">The old path.</param>
        /// <param name="newPath">The new path.</param>
        /// <param name="programExe">The program exe.</param>
        /// <param name="firstCheckValue">The first check value.</param>
        /// <param name="periodicCheckValue">The periodic check value.</param>
        private void Init(string oldPath, string newPath, string programExe,
                          int firstCheckValue, int periodicCheckValue)
        {
            this.oldPath = oldPath;
            this.newPath = newPath;
            this.programExe = programExe;

            check = new Timer();
            firstCheck = new Timer();            
            
            firstCheck.Interval = firstCheckValue;
            firstCheck.Tick += new EventHandler(FirstCheckUpdate_Tick);
            firstCheck.Enabled = true;
            
            check.Interval = periodicCheckValue;
            check.Tick += new EventHandler(CheckUpdate_Tick);
            check.Enabled = true;
        }

        /// <summary>
        /// Fires the checkUpdateEvent.
        /// </summary>
        private void FirecheckUpdateEvent()
        {
            //fire the event now
            if (this.OnCheckUpdateEvent != null) //is there a EventHandler?
            {
                this.OnCheckUpdateEvent.Invoke(); //calls its EventHandler                
            }
            else { } //if not, ignore
        }

        private void FirstCheckUpdate_Tick(object sender, EventArgs e)
        {
            if (CheckUpdate(oldPath, newPath))
            {
                FirecheckUpdateEvent();
                check.Stop();
                check.Dispose();
                check = null;
            }
            firstCheck.Stop();
            firstCheck.Dispose();
            firstCheck = null;
        }

        private void CheckUpdate_Tick(object sender, EventArgs e)
        {
            if (CheckUpdate(oldPath, newPath))
            {
                FirecheckUpdateEvent();
                check.Stop();
                check.Dispose();
                check = null;
            }
        }

        private static bool CheckUpdate(string oldPath, string newPath)
        {
            try
            {
                WebRequest request = WebRequest.Create(newPath);
                WebResponse response = request.GetResponse();
                StreamReader r = new StreamReader(response.GetResponseStream());
                string newVersion = r.ReadLine();
                newVersion = newVersion.Substring(newVersion.IndexOf(';') + 1);
                if (ReadFloatData(oldPath, 1, ';') < 
                    float.Parse(newVersion, 
                    System.Globalization.CultureInfo.CreateSpecificCulture("en-us")))
                {
                    r.Close();
                    return true;
                }
                r.Close();
            }
            catch (/*System.Net.WebException*/Exception)
            {
                return false;
            }
            return false;
        }

        private static ProgressBar InitFormAndProgressBar()
        {
            Form updateForm = new Form();
            ProgressBar bar = new ProgressBar();
            Label label = new Label();
            updateForm.Controls.Add(bar);
            updateForm.Controls.Add(label);

            //init the form
            updateForm.Text = "Updating...";
            updateForm.Width = 300;
            updateForm.Height = 200;
            updateForm.BackColor = System.Drawing.Color.Lavender;
            updateForm.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            //init the label
            label.Text = "Updating...";
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(100, 30);

            //init the progressBar
            bar.Location = new System.Drawing.Point(100, 70);
            bar.Value = 0;
            bar.Step = 1;

            updateForm.Show();
            updateForm.Refresh();
            return bar;
        }

        /// <summary>
        /// Reads out a float data from a line of a file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="line">The line.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        private static float ReadFloatData(String filename, int line, char delimiter)
        {
            string content = "";
            float row = 0;
            if (File.Exists(filename))
            {
                StreamReader tFile = new StreamReader(filename, System.Text.Encoding.Default);
                while (!tFile.EndOfStream && row < line)
                {
                    row++;
                    content = tFile.ReadLine();
                }
                tFile.Close();
                if (row < line)
                    content = "";
            }

            content = content.Substring(content.IndexOf(delimiter) + 1);
            float data = //float.Parse(content);
            float.Parse(content, System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
            
            return data;
        }
    }
}
