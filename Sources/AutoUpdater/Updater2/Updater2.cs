using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace AForge.AutoUpdater
{

    /// <summary>
    /// Finishs the update processes of the <code>Updater</code> class.
    /// </summary>
    public static class Updater2
    {
        /// <summary>
        /// The main entry of the program.
        /// </summary>
        /// <param name="args">The passed arguments.</param>
        [STAThread]
        static void Main(string []args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new UpdateForm(args[0], args[1], args[2]);
        }

        private class UpdateForm : Form
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="UpdateForm"/> class.
            /// </summary>
            /// <param name="updateFile">The update file.</param>
            /// <param name="programExe">The program exe.</param>
            /// <param name="programFile">The program file.</param>
            public UpdateForm(string updateFile, string programExe, string programFile)
            {
                ProgressBar bar = InitFormAndProgressBar();
                System.Threading.Thread.Sleep(3000);

                string updateDir = updateFile.Remove(updateFile.LastIndexOf('/') + 1);
                StreamReader r = new StreamReader(updateFile);
                List<string> copyFiles = new List<string>();
                List<string> deleteFiles = new List<string>();

                //Sets the new version id
                string s = r.ReadLine();                
                WriteLine(programFile, 1, s, true);

                //Sets the new release date
                s = r.ReadLine();
                WriteLine(programFile, 2, s, true);

                while ((s = r.ReadLine()) != null)
                {
                    if (s.StartsWith("Copy"))
                        copyFiles.Add(s.Substring(s.IndexOf(';') + 1));
                    if (s.StartsWith("Delete"))
                        deleteFiles.Add(s.Substring(s.IndexOf(';') + 1));
                }

                r.Close();
                bar.Value = copyFiles.Count;
                bar.Maximum = 2 * copyFiles.Count;

                //deletes all deprecated files
                for (int i = 0; i < deleteFiles.Count; i++)
                {
                    File.Delete(deleteFiles[i]);
                }

                //copy all new files into the Screenshotz dir
                for (int i = 0; i < copyFiles.Count; i++)
                {
                    File.Copy(updateDir + copyFiles[i], copyFiles[i], true);
                    bar.PerformStep();
                }
                copyFiles.Clear();
                deleteFiles.Clear();
                Directory.Delete(updateDir, true);
                System.Windows.Forms.Application.OpenForms[0].Dispose();
                //Close();//not necessary

                //Restart updated program
                if (MessageBox.Show("                     Update finished.",
                                    "Update                                     ",
                    MessageBoxButtons.OK) == DialogResult.OK)
                {
                    System.Diagnostics.ProcessStartInfo startInfo =
                        new System.Diagnostics.ProcessStartInfo(programExe);
                    System.Diagnostics.Process process =
                        System.Diagnostics.Process.Start(startInfo);
                }
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
                bar.Value = 5;//dummy value
                bar.Maximum = 10;//dummy value
                bar.Step = 1;

                updateForm.Show();
                updateForm.Refresh();
                return bar;
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
        }
    }
}