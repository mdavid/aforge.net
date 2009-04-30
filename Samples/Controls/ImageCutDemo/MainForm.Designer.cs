namespace ImageCutDemo
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.okButton = new System.Windows.Forms.Button();
            this.newDimensionLabel = new System.Windows.Forms.Label();
            this.newSizeLabel = new System.Windows.Forms.Label();
            this.originalDimensionLabel = new System.Windows.Forms.Label();
            this.originalLabel = new System.Windows.Forms.Label();
            this.imageDimensionLabel = new System.Windows.Forms.Label();
            this.downLabel = new System.Windows.Forms.Label();
            this.upLabel = new System.Windows.Forms.Label();
            this.rightLabel = new System.Windows.Forms.Label();
            this.leftLabel = new System.Windows.Forms.Label();
            this.cuttingHandleLabel = new System.Windows.Forms.Label();
            this.panelFormatRadioButton = new System.Windows.Forms.RadioButton();
            this.landscapeFormatRadioButton = new System.Windows.Forms.RadioButton();
            this.ratioComboBox = new System.Windows.Forms.ComboBox();
            this.aspectRatioLabel = new System.Windows.Forms.Label();
            this.cutOptionsLabel = new System.Windows.Forms.Label();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.downNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.upNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.rightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.leftNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ratioButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sliderStrengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sliderStrengthComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.optionsToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.generalSliderColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.rolloveredSliderColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sliderSpaceColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparencyComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.minimumSizeOfImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minSizeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.overviewLabel = new System.Windows.Forms.Label();
            this.optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftNumericUpDown)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.SystemColors.Control;
            this.okButton.Location = new System.Drawing.Point(13, 335);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(90, 25);
            this.okButton.TabIndex = 23;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // newDimensionLabel
            // 
            this.newDimensionLabel.Location = new System.Drawing.Point(115, 310);
            this.newDimensionLabel.Name = "newDimensionLabel";
            this.newDimensionLabel.Size = new System.Drawing.Size(125, 19);
            this.newDimensionLabel.TabIndex = 22;
            this.newDimensionLabel.Text = "newDimensionLabel";
            // 
            // newSizeLabel
            // 
            this.newSizeLabel.Location = new System.Drawing.Point(31, 310);
            this.newSizeLabel.Name = "newSizeLabel";
            this.newSizeLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.newSizeLabel.Size = new System.Drawing.Size(65, 19);
            this.newSizeLabel.TabIndex = 21;
            this.newSizeLabel.Text = "New size";
            // 
            // originalDimensionLabel
            // 
            this.originalDimensionLabel.Location = new System.Drawing.Point(115, 285);
            this.originalDimensionLabel.Name = "originalDimensionLabel";
            this.originalDimensionLabel.Size = new System.Drawing.Size(124, 19);
            this.originalDimensionLabel.TabIndex = 20;
            this.originalDimensionLabel.Text = "origDimensionLabel";
            // 
            // originalLabel
            // 
            this.originalLabel.Location = new System.Drawing.Point(31, 285);
            this.originalLabel.Name = "originalLabel";
            this.originalLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.originalLabel.Size = new System.Drawing.Size(65, 19);
            this.originalLabel.TabIndex = 19;
            this.originalLabel.Text = "Original";
            // 
            // imageDimensionLabel
            // 
            this.imageDimensionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageDimensionLabel.Location = new System.Drawing.Point(13, 260);
            this.imageDimensionLabel.Name = "imageDimensionLabel";
            this.imageDimensionLabel.Size = new System.Drawing.Size(110, 19);
            this.imageDimensionLabel.TabIndex = 18;
            this.imageDimensionLabel.Text = "Image dimension";
            // 
            // downLabel
            // 
            this.downLabel.Location = new System.Drawing.Point(31, 223);
            this.downLabel.Name = "downLabel";
            this.downLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.downLabel.Size = new System.Drawing.Size(65, 19);
            this.downLabel.TabIndex = 15;
            this.downLabel.Text = "Down";
            // 
            // upLabel
            // 
            this.upLabel.Location = new System.Drawing.Point(31, 198);
            this.upLabel.Name = "upLabel";
            this.upLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.upLabel.Size = new System.Drawing.Size(65, 19);
            this.upLabel.TabIndex = 12;
            this.upLabel.Text = "Up";
            // 
            // rightLabel
            // 
            this.rightLabel.Location = new System.Drawing.Point(31, 173);
            this.rightLabel.Name = "rightLabel";
            this.rightLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rightLabel.Size = new System.Drawing.Size(65, 19);
            this.rightLabel.TabIndex = 9;
            this.rightLabel.Text = "Right";
            // 
            // leftLabel
            // 
            this.leftLabel.Location = new System.Drawing.Point(31, 147);
            this.leftLabel.Name = "leftLabel";
            this.leftLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.leftLabel.Size = new System.Drawing.Size(65, 19);
            this.leftLabel.TabIndex = 6;
            this.leftLabel.Text = "Left";
            // 
            // cuttingHandleLabel
            // 
            this.cuttingHandleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuttingHandleLabel.Location = new System.Drawing.Point(13, 123);
            this.cuttingHandleLabel.Name = "cuttingHandleLabel";
            this.cuttingHandleLabel.Size = new System.Drawing.Size(110, 19);
            this.cuttingHandleLabel.TabIndex = 5;
            this.cuttingHandleLabel.Text = "Cutting handle";
            // 
            // panelFormatRadioButton
            // 
            this.panelFormatRadioButton.Enabled = false;
            this.panelFormatRadioButton.Location = new System.Drawing.Point(28, 89);
            this.panelFormatRadioButton.Name = "panelFormatRadioButton";
            this.panelFormatRadioButton.Size = new System.Drawing.Size(129, 19);
            this.panelFormatRadioButton.TabIndex = 4;
            this.panelFormatRadioButton.Text = "Panel format";
            // 
            // landscapeFormatRadioButton
            // 
            this.landscapeFormatRadioButton.Checked = true;
            this.landscapeFormatRadioButton.Enabled = false;
            this.landscapeFormatRadioButton.Location = new System.Drawing.Point(28, 64);
            this.landscapeFormatRadioButton.Name = "landscapeFormatRadioButton";
            this.landscapeFormatRadioButton.Size = new System.Drawing.Size(129, 19);
            this.landscapeFormatRadioButton.TabIndex = 3;
            this.landscapeFormatRadioButton.TabStop = true;
            this.landscapeFormatRadioButton.Text = "Landscape format";
            this.landscapeFormatRadioButton.CheckedChanged += new System.EventHandler(this.LandscapeFormatRadioButton_CheckedChanged);
            // 
            // ratioComboBox
            // 
            this.ratioComboBox.DropDownWidth = 91;
            this.ratioComboBox.Items.AddRange(new object[] {
            "None",
            "3 x 4",
            "20 x 25",
            "13 x 18",
            "10 x 15",
            "9 x 13"});
            this.ratioComboBox.Location = new System.Drawing.Point(116, 36);
            this.ratioComboBox.Name = "ratioComboBox";
            this.ratioComboBox.Size = new System.Drawing.Size(77, 21);
            this.ratioComboBox.TabIndex = 2;
            this.ratioComboBox.Text = "None";
            this.ratioComboBox.SelectedIndexChanged += new System.EventHandler(this.RatioComboBox_SelectedIndexChanged);
            // 
            // aspectRatioLabel
            // 
            this.aspectRatioLabel.Location = new System.Drawing.Point(28, 39);
            this.aspectRatioLabel.Name = "aspectRatioLabel";
            this.aspectRatioLabel.Size = new System.Drawing.Size(81, 19);
            this.aspectRatioLabel.TabIndex = 1;
            this.aspectRatioLabel.Text = "Aspect ratio";
            // 
            // cutOptionsLabel
            // 
            this.cutOptionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cutOptionsLabel.Location = new System.Drawing.Point(13, 12);
            this.cutOptionsLabel.Name = "cutOptionsLabel";
            this.cutOptionsLabel.Size = new System.Drawing.Size(80, 19);
            this.cutOptionsLabel.TabIndex = 0;
            this.cutOptionsLabel.Text = "Cut options";
            // 
            // optionsPanel
            // 
            this.optionsPanel.BackColor = System.Drawing.Color.Lavender;
            this.optionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsPanel.Controls.Add(this.downNumericUpDown);
            this.optionsPanel.Controls.Add(this.upNumericUpDown);
            this.optionsPanel.Controls.Add(this.rightNumericUpDown);
            this.optionsPanel.Controls.Add(this.leftNumericUpDown);
            this.optionsPanel.Controls.Add(this.ratioButton);
            this.optionsPanel.Controls.Add(this.okButton);
            this.optionsPanel.Controls.Add(this.cutOptionsLabel);
            this.optionsPanel.Controls.Add(this.newDimensionLabel);
            this.optionsPanel.Controls.Add(this.aspectRatioLabel);
            this.optionsPanel.Controls.Add(this.newSizeLabel);
            this.optionsPanel.Controls.Add(this.ratioComboBox);
            this.optionsPanel.Controls.Add(this.originalDimensionLabel);
            this.optionsPanel.Controls.Add(this.landscapeFormatRadioButton);
            this.optionsPanel.Controls.Add(this.originalLabel);
            this.optionsPanel.Controls.Add(this.panelFormatRadioButton);
            this.optionsPanel.Controls.Add(this.imageDimensionLabel);
            this.optionsPanel.Controls.Add(this.cuttingHandleLabel);
            this.optionsPanel.Controls.Add(this.leftLabel);
            this.optionsPanel.Controls.Add(this.downLabel);
            this.optionsPanel.Controls.Add(this.rightLabel);
            this.optionsPanel.Controls.Add(this.upLabel);
            this.optionsPanel.Location = new System.Drawing.Point(496, 59);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(200, 369);
            this.optionsPanel.TabIndex = 1;
            // 
            // downNumericUpDown
            // 
            this.downNumericUpDown.Location = new System.Drawing.Point(110, 221);
            this.downNumericUpDown.Name = "downNumericUpDown";
            this.downNumericUpDown.Size = new System.Drawing.Size(72, 20);
            this.downNumericUpDown.TabIndex = 28;
            this.downNumericUpDown.ValueChanged += new System.EventHandler(this.downNumericUpDown_ValueChanged);
            this.downNumericUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.downNumericUpDown_KeyUp);
            // 
            // upNumericUpDown
            // 
            this.upNumericUpDown.Location = new System.Drawing.Point(110, 196);
            this.upNumericUpDown.Name = "upNumericUpDown";
            this.upNumericUpDown.Size = new System.Drawing.Size(72, 20);
            this.upNumericUpDown.TabIndex = 27;
            this.upNumericUpDown.ValueChanged += new System.EventHandler(this.upNumericUpDown_ValueChanged);
            this.upNumericUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.upNumericUpDown_KeyUp);
            // 
            // rightNumericUpDown
            // 
            this.rightNumericUpDown.Location = new System.Drawing.Point(110, 171);
            this.rightNumericUpDown.Name = "rightNumericUpDown";
            this.rightNumericUpDown.Size = new System.Drawing.Size(72, 20);
            this.rightNumericUpDown.TabIndex = 2;
            this.rightNumericUpDown.ValueChanged += new System.EventHandler(this.rightNumericUpDown_ValueChanged);
            this.rightNumericUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rightNumericUpDown_KeyUp);
            // 
            // leftNumericUpDown
            // 
            this.leftNumericUpDown.Location = new System.Drawing.Point(110, 145);
            this.leftNumericUpDown.Name = "leftNumericUpDown";
            this.leftNumericUpDown.Size = new System.Drawing.Size(72, 20);
            this.leftNumericUpDown.TabIndex = 1;
            this.leftNumericUpDown.ValueChanged += new System.EventHandler(this.leftNumericUpDown_ValueChanged);
            this.leftNumericUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.leftNumericUpDown_KeyUp);
            // 
            // ratioButton
            // 
            this.ratioButton.BackColor = System.Drawing.SystemColors.Control;
            this.ratioButton.Enabled = false;
            this.ratioButton.Location = new System.Drawing.Point(160, 64);
            this.ratioButton.Name = "ratioButton";
            this.ratioButton.Size = new System.Drawing.Size(33, 26);
            this.ratioButton.TabIndex = 24;
            this.ratioButton.Text = "Go";
            this.ratioButton.UseVisualStyleBackColor = false;
            this.ratioButton.Click += new System.EventHandler(this.RatioButton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(694, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.saveImageToolStripMenuItem,
            this.clipboardToolStripMenuItem,
            this.fileToolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openImageToolStripMenuItem.Text = "&Open Image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveImageToolStripMenuItem.Text = "&Save image as";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.SaveImageToolStripMenuItem_Click);
            // 
            // clipboardToolStripMenuItem
            // 
            this.clipboardToolStripMenuItem.Name = "clipboardToolStripMenuItem";
            this.clipboardToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.clipboardToolStripMenuItem.Text = "&Copy image to clipboard";
            this.clipboardToolStripMenuItem.Click += new System.EventHandler(this.ClipboardToolStripMenuItem_Click);
            // 
            // fileToolStripSeparator1
            // 
            this.fileToolStripSeparator1.Name = "fileToolStripSeparator1";
            this.fileToolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sliderStrengthToolStripMenuItem,
            this.optionsToolStripSeparator1,
            this.generalSliderColorToolStripMenuItem,
            this.rolloveredSliderColorToolStripMenuItem,
            this.sliderSpaceColorToolStripMenuItem,
            this.transparencyToolStripMenuItem,
            this.optionsToolStripSeparator2,
            this.minimumSizeOfImageToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // optionsToolStripSeparator1
            // 
            this.optionsToolStripSeparator1.Name = "optionsToolStripSeparator1";
            this.optionsToolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // sliderStrengthToolStripMenuItem
            // 
            this.sliderStrengthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sliderStrengthComboBox});
            this.sliderStrengthToolStripMenuItem.Name = "sliderStrengthToolStripMenuItem";
            this.sliderStrengthToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.sliderStrengthToolStripMenuItem.Text = "Slider strengths";
            // 
            // sliderStrengthComboBox
            // 
            this.sliderStrengthComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.sliderStrengthComboBox.Name = "sliderStrengthComboBox";
            this.sliderStrengthComboBox.Size = new System.Drawing.Size(75, 21);
            this.sliderStrengthComboBox.TextChanged += new System.EventHandler(this.LineStrengthComboBox_TextChanged);
            // 
            // optionsToolStripSeparator2
            // 
            this.optionsToolStripSeparator2.Name = "optionsToolStripSeparator2";
            this.optionsToolStripSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // generalSliderColorToolStripMenuItem
            // 
            this.generalSliderColorToolStripMenuItem.Name = "generalSliderColorToolStripMenuItem";
            this.generalSliderColorToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.generalSliderColorToolStripMenuItem.Text = "General slider color";
            this.generalSliderColorToolStripMenuItem.Click += new System.EventHandler(this.generalSliderColorToolStripMenuItem_Click);
            // 
            // colorDialog
            // 
            this.colorDialog.Color = System.Drawing.Color.Red;
            this.colorDialog.FullOpen = true;
            // 
            // rolloveredSliderColorToolStripMenuItem
            // 
            this.rolloveredSliderColorToolStripMenuItem.Name = "rolloveredSliderColorToolStripMenuItem";
            this.rolloveredSliderColorToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.rolloveredSliderColorToolStripMenuItem.Text = "Rollovered slider color";
            this.rolloveredSliderColorToolStripMenuItem.Click += new System.EventHandler(this.rolloveredSliderColorToolStripMenuItem_Click);
            // 
            // sliderSpaceColorToolStripMenuItem
            // 
            this.sliderSpaceColorToolStripMenuItem.Name = "sliderSpaceColorToolStripMenuItem";
            this.sliderSpaceColorToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.sliderSpaceColorToolStripMenuItem.Text = "Slider space color";
            this.sliderSpaceColorToolStripMenuItem.Click += new System.EventHandler(this.sliderSpaceColorToolStripMenuItem_Click);
            // 
            // transparencyToolStripMenuItem
            // 
            this.transparencyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transparencyComboBox});
            this.transparencyToolStripMenuItem.Name = "transparencyToolStripMenuItem";
            this.transparencyToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.transparencyToolStripMenuItem.Text = "Transparency";
            // 
            // transparencyComboBox
            // 
            this.transparencyComboBox.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90",
            "100",
            "110",
            "120",
            "130",
            "140",
            "150",
            "160",
            "170",
            "180",
            "190",
            "200",
            "210",
            "220",
            "230",
            "240",
            "250"});
            this.transparencyComboBox.Name = "transparencyComboBox";
            this.transparencyComboBox.Size = new System.Drawing.Size(75, 21);
            this.transparencyComboBox.TextChanged += new System.EventHandler(this.transparencyComboBox_TextChanged);
            // 
            // minimumSizeOfImageToolStripMenuItem
            // 
            this.minimumSizeOfImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minSizeComboBox});
            this.minimumSizeOfImageToolStripMenuItem.Name = "minimumSizeOfImageToolStripMenuItem";
            this.minimumSizeOfImageToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.minimumSizeOfImageToolStripMenuItem.Text = "Minimum size of image";
            // 
            // minSizeComboBox
            // 
            this.minSizeComboBox.Items.AddRange(new object[] {
            "20x20",
            "50x50",
            "100x100"});
            this.minSizeComboBox.Name = "minSizeComboBox";
            this.minSizeComboBox.Size = new System.Drawing.Size(75, 21);
            this.minSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.minSizeComboBox_SelectedIndexChanged);
            // 
            // overviewLabel
            // 
            this.overviewLabel.AutoSize = true;
            this.overviewLabel.BackColor = System.Drawing.Color.Lavender;
            this.overviewLabel.Font = new System.Drawing.Font("Perpetua", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overviewLabel.ForeColor = System.Drawing.Color.MediumBlue;
            this.overviewLabel.Location = new System.Drawing.Point(496, 28);
            this.overviewLabel.Name = "overviewLabel";
            this.overviewLabel.Size = new System.Drawing.Size(180, 27);
            this.overviewLabel.TabIndex = 3;
            this.overviewLabel.Text = "Cutting an image";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(694, 443);
            this.Controls.Add(this.overviewLabel);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.optionsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ImageCutDemo";
            this.optionsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.downNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftNumericUpDown)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cutOptionsLabel;
        private System.Windows.Forms.RadioButton panelFormatRadioButton;
        private System.Windows.Forms.RadioButton landscapeFormatRadioButton;
        private System.Windows.Forms.ComboBox ratioComboBox;
        private System.Windows.Forms.Label aspectRatioLabel;
        private System.Windows.Forms.Label leftLabel;
        private System.Windows.Forms.Label cuttingHandleLabel;
        private System.Windows.Forms.Label upLabel;
        private System.Windows.Forms.Label rightLabel;
        private System.Windows.Forms.Label downLabel;
        private System.Windows.Forms.Label imageDimensionLabel;
        private System.Windows.Forms.Label originalLabel;
        private System.Windows.Forms.Label newDimensionLabel;
        private System.Windows.Forms.Label newSizeLabel;
        private System.Windows.Forms.Label originalDimensionLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator optionsToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sliderStrengthToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox sliderStrengthComboBox;
        private System.Windows.Forms.ToolStripSeparator optionsToolStripSeparator2;
        private System.Windows.Forms.Button ratioButton;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown leftNumericUpDown;
        private System.Windows.Forms.NumericUpDown rightNumericUpDown;
        private System.Windows.Forms.NumericUpDown downNumericUpDown;
        private System.Windows.Forms.NumericUpDown upNumericUpDown;
        private System.Windows.Forms.ToolStripMenuItem generalSliderColorToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripMenuItem rolloveredSliderColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sliderSpaceColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox transparencyComboBox;
        private System.Windows.Forms.ToolStripMenuItem minimumSizeOfImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox minSizeComboBox;
        private System.Windows.Forms.Label overviewLabel;
    }
}

