// AForge ImageCut demo
// AForge.NET framework
//
// Copyright © Frank Nagl, 2008
// admin@franknagl.de
// www.franknagl.de
//

namespace ImageCutDemo
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using AForge.Controls;

    /// <summary>
    /// An example application for using the ImageCut control.
    /// </summary>
    public partial class MainForm : Form
    {        
        private Bitmap finalImage;
        private ImageCut imageCut;
        private bool isLandScapeFormat = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            const byte taskbar = 35;//in pixel

            Height = SystemInformation.PrimaryMonitorSize.Height - taskbar;
            Width = SystemInformation.PrimaryMonitorSize.Width;

            overviewLabel.Location = new Point(this.Width - 215, 37);
            optionsPanel.Location = new Point(this.Width - 215, 70);

            System.Resources.ResourceManager resource = 
                new System.Resources.ResourceManager("ImageCutDemo.Properties.Resources", 
                System.Reflection.Assembly.GetExecutingAssembly());
            finalImage = new Bitmap((Bitmap)resource.GetObject("dom_erfurt"));
            InitImageCutControl();
        }

        /// <summary>
        /// Inits the image cut control.
        /// </summary>
        private void InitImageCutControl()
        {
            // 50 = tolerance space between imageCut and optionsPanel
            float wmax = Width - optionsPanel.Width - 50;
            // 80 = tolerance space for the calculation of yLocation and height of imageCut
            float hmax = Height - 80;

            imageCut = new ImageCut(finalImage, wmax, hmax);
            imageCut.OnSliderMoved += new OnSliderMovedEventHandler(OnSliderMoved);
            #region Here you could set some properties, if you like.
            //imageCut.LineStrength = 2;     
            //imageCut.BackColor = Color.Blue;                     
            //imageCut.ColorSliders = Color.Green;            
            //imageCut.ColorRolloverSlider = Color.Red;
            //imageCut.ColorSliderSpace = Color.Aqua;
            //imageCut.Transparency = 180;         
            //imageCut.MinSizeOfImage = 100;
            //imageCut.CursorDefault = Cursors.Default;
            //imageCut.CursorMoveDisplayWindow = Cursors.Hand;
            //imageCut.CursorRolloverSlider = Cursors.Arrow;
            //... (take a look at the ImageCut control, there are further properties)
            #endregion
            imageCut.Initialize();
            
            int xLocation = Width - optionsPanel.Width;// -SpaceAroundWorkingPanel;
            xLocation = (xLocation - imageCut.Width) / 2;
            int yLocation = (Height - imageCut.Height) / 2;
            imageCut.Location = new Point(xLocation, yLocation);
            this.Controls.Add(imageCut);

            sliderStrengthComboBox.Text = imageCut.LineStrength.ToString();
            transparencyComboBox.Text = imageCut.Transparency.ToString();
            minSizeComboBox.Text = "50x50";
            originalDimensionLabel.Text = imageCut.OriginalWidth.ToString() +
                                       " x " +
                                       imageCut.OriginalHeight.ToString();            

            //Adapt the NumericUpDown maximum values
            leftNumericUpDown.Maximum = imageCut.OriginalWidth;
            rightNumericUpDown.Maximum = imageCut.OriginalWidth;
            upNumericUpDown.Maximum = imageCut.OriginalHeight;
            downNumericUpDown.Maximum = imageCut.OriginalHeight;

            OnSliderMoved(); //just a trick to get the right values for the labels ;-)                      
        }

        /// <summary>
        /// Processes a dialog key. 
        /// </summary>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"></see> values that represents the key to process.</param>
        /// <returns>
        ///  true if the key was processed by the control; otherwise, false. 
        /// </returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData /*& Keys.KeyCode*/)
            {
                case Keys.Left:
                    imageCut.MoveSelectedVerticalSlider(-1);                    
                    break;
                case Keys.Right:
                    imageCut.MoveSelectedVerticalSlider(1);
                    break;
                case Keys.Up:
                    imageCut.MoveSelectedHorizontalSlider(-1);
                    break;
                case Keys.Down:
                    imageCut.MoveSelectedHorizontalSlider(1);
                    break;
                case Keys.A:
                    imageCut.ColorSliders = Color.CornflowerBlue;
                    imageCut.Refresh();
                    break;
            }            
            return false;
        }

        /// <summary>
        /// Handles the Click event of the OkButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            //Correct possible rounding errors
            imageCut.MoveSelectedVerticalSlider(0); 
            //Get the final cutted picture
            finalImage = imageCut.getCuttedImage();
            
            //Removes and disposes the imageCut-control           
            this.Controls.Remove(imageCut);
            imageCut.Dispose();
            imageCut = null;

            InitImageCutControl();            
        }

        /// <summary>
        /// Called when a slider is moved.
        /// </summary>
        public void OnSliderMoved()
        {
            leftNumericUpDown.Value = imageCut.LeftPosition;
            rightNumericUpDown.Value = imageCut.OriginalWidth - imageCut.RightPosition;
            upNumericUpDown.Value = imageCut.TopPosition;
            downNumericUpDown.Value = imageCut.OriginalHeight - imageCut.BottomPosition;            

            newDimensionLabel.Text = imageCut.ActualWidth.ToString() + 
                                       " x " +
                                       imageCut.ActualHeight.ToString();            
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.png, *.jpg, *.bmp)|*.png;*.jpg;*.jpeg;*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                finalImage = new Bitmap(dialog.FileName);
                //Removes and disposes the imageCut-control           
                this.Controls.Remove(imageCut);
                imageCut.Dispose();
                imageCut = null;
                InitImageCutControl();
            }
        }

        private void SaveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = 
                "PNG (*.png)|*.png|JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg|BMP (*.bmp)|*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FilterIndex == 1)
                    finalImage.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                else if (dialog.FilterIndex == 2)
                    finalImage.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                else if (dialog.FilterIndex == 3)
                    finalImage.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }

        private void ClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The edited image is always automatically copied to the clipboard.",
                            "Image automatically in clipboard", MessageBoxButtons.OK);  
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RatioComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ratioComboBox.Text == "None")
            {
                imageCut.Ratio = 0.0f;
                landscapeFormatRadioButton.Enabled = false;
                panelFormatRadioButton.Enabled = false;
                ratioButton.Enabled = false;
                return;
            }

            landscapeFormatRadioButton.Enabled = true;
            panelFormatRadioButton.Enabled = true;
            ratioButton.Enabled = true;
            string tData = ratioComboBox.Text;
            float tNumber1 = float.Parse(tData.Substring(0, tData.IndexOf(' ')));
            float tNumber2 = float.Parse(
                tData.Substring(tData.LastIndexOf(' '),
                                    tData.Length - tData.LastIndexOf(' ')));
            if(isLandScapeFormat)
                imageCut.Ratio = tNumber1 / tNumber2;
            else
                imageCut.Ratio = tNumber2 / tNumber1;

            //Trick to get the ratio handling
            imageCut.MoveSlider(0, Slider.Left);
        }

        private void LandscapeFormatRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isLandScapeFormat = !isLandScapeFormat;
            RatioComboBox_SelectedIndexChanged(sender, e);
        }

        private void RatioButton_Click(object sender, EventArgs e)
        {
            //Trick to get the ratio handling 
            imageCut.MoveSlider(0, Slider.Left);
        }

        #region NumericUpDown Events

        private void leftNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (imageCut.Focused)
                return;
            int newValue = (int)leftNumericUpDown.Value;
            if (imageCut.RightPosition - newValue < imageCut.MinSizeOfImage)
                leftNumericUpDown.Value = imageCut.LeftPosition;
            else
                imageCut.MoveSlider(newValue - imageCut.LeftPosition, Slider.Left);
        }

        private void rightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (imageCut.Focused)
                return;
            int newValue = (int)rightNumericUpDown.Value;
            if (newValue + imageCut.LeftPosition >
                imageCut.OriginalWidth - imageCut.MinSizeOfImage)
                rightNumericUpDown.Value =
                    imageCut.OriginalWidth - imageCut.RightPosition;
            else
                imageCut.MoveSlider((imageCut.OriginalWidth -
                                      imageCut.RightPosition) - newValue, Slider.Right);
        }

        private void upNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (imageCut.Focused)
                return;
            int newValue = (int)upNumericUpDown.Value;
            if (imageCut.BottomPosition - newValue < imageCut.MinSizeOfImage)
                upNumericUpDown.Value = imageCut.TopPosition;
            else
                imageCut.MoveSlider(newValue - imageCut.TopPosition, Slider.Top);
        }

        private void downNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (imageCut.Focused)
                return;
            int newValue = (int)downNumericUpDown.Value;
            if (newValue + imageCut.TopPosition >
                imageCut.OriginalHeight - imageCut.MinSizeOfImage)
                downNumericUpDown.Value =
                    imageCut.OriginalHeight - imageCut.BottomPosition;
            else
                imageCut.MoveSlider((imageCut.OriginalHeight -
                                      imageCut.BottomPosition) - newValue, Slider.Bottom);
        }

        private void leftNumericUpDown_KeyUp(object sender, KeyEventArgs e)
        {
            leftNumericUpDown_ValueChanged(sender, e);

            //Sets the focus to the ImageCut-Control, 
            //..otherwise the key navigation would not work
            if (e.KeyCode == Keys.Return)
                imageCut.Focus();
        }

        private void rightNumericUpDown_KeyUp(object sender, KeyEventArgs e)
        {
            rightNumericUpDown_ValueChanged(sender, e);

            //Sets the focus to the ImageCut-Control, 
            //..otherwise the key navigation would not work
            if (e.KeyCode == Keys.Return)
                imageCut.Focus();
        }

        private void upNumericUpDown_KeyUp(object sender, KeyEventArgs e)
        {
            upNumericUpDown_ValueChanged(sender, e);

            //Sets the focus to the ImageCut-Control, 
            //..otherwise the key navigation would not work
            if (e.KeyCode == Keys.Return)
                imageCut.Focus();
        }

        private void downNumericUpDown_KeyUp(object sender, KeyEventArgs e)
        {
            downNumericUpDown_ValueChanged(sender, e);

            //Sets the focus to the ImageCut-Control, 
            //..otherwise the key navigation would not work
            if (e.KeyCode == Keys.Return)
                imageCut.Focus();
        }

        #endregion NumericUpDown Events

        #region Change properties
        /// <summary>
        /// Handles the TextChanged event of the LineStrengthComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LineStrengthComboBox_TextChanged(object sender, EventArgs e)
        {
            byte strength;
            if (!byte.TryParse(sliderStrengthComboBox.Text, out strength) || strength > 7)
            {
                strength = 3;
                sliderStrengthComboBox.Text = "3";
            }
            imageCut.LineStrength = strength;
            imageCut.Refresh();
        }

        /// <summary>
        /// Handles the Click event of the generalSliderColorToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void generalSliderColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.Color = imageCut.ColorSliders;
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                imageCut.ColorSliders = colorDialog.Color;
                imageCut.Refresh();
            }
        }

        /// <summary>
        /// Handles the Click event of the rolloveredSliderColorToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void rolloveredSliderColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.Color = imageCut.ColorRolloverSlider;
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                imageCut.ColorRolloverSlider = colorDialog.Color;
                imageCut.Refresh();
            }
        }

        /// <summary>
        /// Handles the Click event of the sliderSpaceColorToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void sliderSpaceColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.Color = imageCut.ColorSliderSpace;
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                imageCut.ColorSliderSpace = colorDialog.Color;
                imageCut.Refresh();
            }
        }

        private void transparencyComboBox_TextChanged(object sender, EventArgs e)
        {
            byte t;
            if (!byte.TryParse(transparencyComboBox.Text, out t) || t > 250)
            {
                t = 220;// imageCut default value
                transparencyComboBox.Text = "220";
            }
            imageCut.Transparency = t;
            imageCut.Refresh();
        }

        private void minSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (minSizeComboBox.SelectedIndex == 0)
                imageCut.MinSizeOfImage = 20;
            else if (minSizeComboBox.SelectedIndex == 1)
            {
                if (imageCut.ActualWidth < 50)
                {
                    MessageBox.Show("The actual image size is too small.");
                    return;
                }
                else if (imageCut.ActualHeight < 50)
                {
                    MessageBox.Show("The actual image size is too small.");
                    return;
                }
                imageCut.MinSizeOfImage = 50;
            }
            else if (minSizeComboBox.SelectedIndex == 2)
            {
                if (imageCut.ActualWidth < 100)
                {
                    MessageBox.Show("The actual image size is too small.");
                    return;
                }
                else if (imageCut.ActualHeight < 100)
                {
                    MessageBox.Show("The actual image size is too small.");
                    return;
                }
                imageCut.MinSizeOfImage = 100;
            }
        }
        #endregion Change properties

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
