namespace ComputerGraphicsLab2
{
    partial class Form1
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
            this.OriginalPicture = new System.Windows.Forms.PictureBox();
            this.WorkedPicture = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.octree = new System.Windows.Forms.RadioButton();
            this.kmax = new System.Windows.Forms.TextBox();
            this.subdivision_kg = new System.Windows.Forms.TextBox();
            this.subdivision_kb = new System.Windows.Forms.TextBox();
            this.subdivision_kr = new System.Windows.Forms.TextBox();
            this.uniform = new System.Windows.Forms.RadioButton();
            this.ditherMatrix = new System.Windows.Forms.NumericUpDown();
            this.GrayscaleLevel = new System.Windows.Forms.NumericUpDown();
            this.Refresh = new System.Windows.Forms.Button();
            this.OrderedDitheringRadioButton = new System.Windows.Forms.RadioButton();
            this.RandomDitheringRadioButton = new System.Windows.Forms.RadioButton();
            this.Erosing = new System.Windows.Forms.Button();
            this.Dilating = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Customizing = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Grayscale = new System.Windows.Forms.Button();
            this.Inversion = new System.Windows.Forms.Button();
            this.OpenPicture = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ContrastTrackBar = new System.Windows.Forms.TrackBar();
            this.BrightnessTrackBar = new System.Windows.Forms.TrackBar();
            this.ContrastValue = new System.Windows.Forms.Label();
            this.BrightnessValue = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Reset = new System.Windows.Forms.Button();
            this.Apply = new System.Windows.Forms.Button();
            this.BValue = new System.Windows.Forms.Label();
            this.CVal = new System.Windows.Forms.Label();
            this.Off = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkedPicture)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ditherMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleLevel)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackBar)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // OriginalPicture
            // 
            this.OriginalPicture.Location = new System.Drawing.Point(12, 84);
            this.OriginalPicture.Name = "OriginalPicture";
            this.OriginalPicture.Size = new System.Drawing.Size(695, 505);
            this.OriginalPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OriginalPicture.TabIndex = 0;
            this.OriginalPicture.TabStop = false;
            // 
            // WorkedPicture
            // 
            this.WorkedPicture.Location = new System.Drawing.Point(713, 84);
            this.WorkedPicture.Name = "WorkedPicture";
            this.WorkedPicture.Size = new System.Drawing.Size(634, 505);
            this.WorkedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WorkedPicture.TabIndex = 1;
            this.WorkedPicture.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Off);
            this.panel1.Controls.Add(this.octree);
            this.panel1.Controls.Add(this.kmax);
            this.panel1.Controls.Add(this.subdivision_kg);
            this.panel1.Controls.Add(this.subdivision_kb);
            this.panel1.Controls.Add(this.subdivision_kr);
            this.panel1.Controls.Add(this.uniform);
            this.panel1.Controls.Add(this.ditherMatrix);
            this.panel1.Controls.Add(this.GrayscaleLevel);
            this.panel1.Controls.Add(this.Refresh);
            this.panel1.Controls.Add(this.OrderedDitheringRadioButton);
            this.panel1.Controls.Add(this.RandomDitheringRadioButton);
            this.panel1.Location = new System.Drawing.Point(1353, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 647);
            this.panel1.TabIndex = 2;
            // 
            // octree
            // 
            this.octree.AutoSize = true;
            this.octree.Location = new System.Drawing.Point(39, 179);
            this.octree.Name = "octree";
            this.octree.Size = new System.Drawing.Size(117, 17);
            this.octree.TabIndex = 14;
            this.octree.Text = "Octree quantization";
            this.octree.UseVisualStyleBackColor = true;
            this.octree.CheckedChanged += new System.EventHandler(this.octree_CheckedChanged);
            // 
            // kmax
            // 
            this.kmax.Location = new System.Drawing.Point(56, 202);
            this.kmax.Name = "kmax";
            this.kmax.Size = new System.Drawing.Size(100, 20);
            this.kmax.TabIndex = 13;
            // 
            // subdivision_kg
            // 
            this.subdivision_kg.Location = new System.Drawing.Point(62, 153);
            this.subdivision_kg.Name = "subdivision_kg";
            this.subdivision_kg.Size = new System.Drawing.Size(63, 20);
            this.subdivision_kg.TabIndex = 12;
            // 
            // subdivision_kb
            // 
            this.subdivision_kb.Location = new System.Drawing.Point(128, 153);
            this.subdivision_kb.Name = "subdivision_kb";
            this.subdivision_kb.Size = new System.Drawing.Size(58, 20);
            this.subdivision_kb.TabIndex = 11;
            // 
            // subdivision_kr
            // 
            this.subdivision_kr.Location = new System.Drawing.Point(3, 153);
            this.subdivision_kr.Name = "subdivision_kr";
            this.subdivision_kr.Size = new System.Drawing.Size(55, 20);
            this.subdivision_kr.TabIndex = 10;
            // 
            // uniform
            // 
            this.uniform.AutoSize = true;
            this.uniform.Location = new System.Drawing.Point(38, 130);
            this.uniform.Name = "uniform";
            this.uniform.Size = new System.Drawing.Size(121, 17);
            this.uniform.TabIndex = 9;
            this.uniform.Text = "Uniform quantization";
            this.uniform.UseVisualStyleBackColor = true;
            this.uniform.CheckedChanged += new System.EventHandler(this.uniform_CheckedChanged);
            // 
            // ditherMatrix
            // 
            this.ditherMatrix.Location = new System.Drawing.Point(39, 75);
            this.ditherMatrix.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.ditherMatrix.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ditherMatrix.Name = "ditherMatrix";
            this.ditherMatrix.Size = new System.Drawing.Size(120, 20);
            this.ditherMatrix.TabIndex = 8;
            this.ditherMatrix.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // GrayscaleLevel
            // 
            this.GrayscaleLevel.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.GrayscaleLevel.Location = new System.Drawing.Point(39, 26);
            this.GrayscaleLevel.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.GrayscaleLevel.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.GrayscaleLevel.Name = "GrayscaleLevel";
            this.GrayscaleLevel.Size = new System.Drawing.Size(120, 20);
            this.GrayscaleLevel.TabIndex = 7;
            this.GrayscaleLevel.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(60, 101);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(75, 23);
            this.Refresh.TabIndex = 6;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.DitherCheckBoxCheckedHandler);
            // 
            // OrderedDitheringRadioButton
            // 
            this.OrderedDitheringRadioButton.AutoSize = true;
            this.OrderedDitheringRadioButton.Location = new System.Drawing.Point(62, 52);
            this.OrderedDitheringRadioButton.Name = "OrderedDitheringRadioButton";
            this.OrderedDitheringRadioButton.Size = new System.Drawing.Size(63, 17);
            this.OrderedDitheringRadioButton.TabIndex = 5;
            this.OrderedDitheringRadioButton.Text = "Ordered";
            this.OrderedDitheringRadioButton.UseVisualStyleBackColor = true;
            this.OrderedDitheringRadioButton.CheckedChanged += new System.EventHandler(this.OrderedDitheringRadioButton_CheckedChanged);
            // 
            // RandomDitheringRadioButton
            // 
            this.RandomDitheringRadioButton.AutoSize = true;
            this.RandomDitheringRadioButton.Location = new System.Drawing.Point(60, 3);
            this.RandomDitheringRadioButton.Name = "RandomDitheringRadioButton";
            this.RandomDitheringRadioButton.Size = new System.Drawing.Size(65, 17);
            this.RandomDitheringRadioButton.TabIndex = 4;
            this.RandomDitheringRadioButton.Text = "Random";
            this.RandomDitheringRadioButton.UseVisualStyleBackColor = true;
            this.RandomDitheringRadioButton.CheckedChanged += new System.EventHandler(this.DitherCheckBoxCheckedHandler);
            // 
            // Erosing
            // 
            this.Erosing.Location = new System.Drawing.Point(675, 19);
            this.Erosing.Name = "Erosing";
            this.Erosing.Size = new System.Drawing.Size(75, 23);
            this.Erosing.TabIndex = 1;
            this.Erosing.Text = "Erosion";
            this.Erosing.UseVisualStyleBackColor = true;
            this.Erosing.Click += new System.EventHandler(this.Erosing_Click);
            // 
            // Dilating
            // 
            this.Dilating.Location = new System.Drawing.Point(594, 19);
            this.Dilating.Name = "Dilating";
            this.Dilating.Size = new System.Drawing.Size(75, 23);
            this.Dilating.TabIndex = 0;
            this.Dilating.Text = "Dilation";
            this.Dilating.UseVisualStyleBackColor = true;
            this.Dilating.Click += new System.EventHandler(this.Dilating_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Customizing);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.Grayscale);
            this.panel2.Controls.Add(this.Inversion);
            this.panel2.Controls.Add(this.OpenPicture);
            this.panel2.Controls.Add(this.Dilating);
            this.panel2.Controls.Add(this.Erosing);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1335, 66);
            this.panel2.TabIndex = 3;
            // 
            // Customizing
            // 
            this.Customizing.Location = new System.Drawing.Point(453, 19);
            this.Customizing.Name = "Customizing";
            this.Customizing.Size = new System.Drawing.Size(135, 23);
            this.Customizing.TabIndex = 4;
            this.Customizing.Text = "Customize";
            this.Customizing.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(246, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(201, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // Grayscale
            // 
            this.Grayscale.Location = new System.Drawing.Point(165, 21);
            this.Grayscale.Name = "Grayscale";
            this.Grayscale.Size = new System.Drawing.Size(75, 23);
            this.Grayscale.TabIndex = 2;
            this.Grayscale.Text = "Grayscale";
            this.Grayscale.UseVisualStyleBackColor = true;
            this.Grayscale.Click += new System.EventHandler(this.Grayscale_Click);
            // 
            // Inversion
            // 
            this.Inversion.Location = new System.Drawing.Point(84, 21);
            this.Inversion.Name = "Inversion";
            this.Inversion.Size = new System.Drawing.Size(75, 23);
            this.Inversion.TabIndex = 1;
            this.Inversion.Text = "Invert";
            this.Inversion.UseVisualStyleBackColor = true;
            this.Inversion.Click += new System.EventHandler(this.Inversion_Click);
            // 
            // OpenPicture
            // 
            this.OpenPicture.Location = new System.Drawing.Point(3, 21);
            this.OpenPicture.Name = "OpenPicture";
            this.OpenPicture.Size = new System.Drawing.Size(75, 23);
            this.OpenPicture.TabIndex = 0;
            this.OpenPicture.Text = "Open";
            this.OpenPicture.UseVisualStyleBackColor = true;
            this.OpenPicture.Click += new System.EventHandler(this.OpenPicture_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.CVal);
            this.panel3.Controls.Add(this.BValue);
            this.panel3.Controls.Add(this.ContrastTrackBar);
            this.panel3.Controls.Add(this.BrightnessTrackBar);
            this.panel3.Controls.Add(this.ContrastValue);
            this.panel3.Controls.Add(this.BrightnessValue);
            this.panel3.Location = new System.Drawing.Point(12, 595);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1335, 136);
            this.panel3.TabIndex = 4;
            // 
            // ContrastTrackBar
            // 
            this.ContrastTrackBar.Location = new System.Drawing.Point(90, 70);
            this.ContrastTrackBar.Maximum = 100;
            this.ContrastTrackBar.Name = "ContrastTrackBar";
            this.ContrastTrackBar.Size = new System.Drawing.Size(399, 45);
            this.ContrastTrackBar.SmallChange = 5;
            this.ContrastTrackBar.TabIndex = 4;
            this.ContrastTrackBar.TickFrequency = 5;
            this.ContrastTrackBar.Scroll += new System.EventHandler(this.ContrastTrackBar_Scroll);
            // 
            // BrightnessTrackBar
            // 
            this.BrightnessTrackBar.Location = new System.Drawing.Point(90, 19);
            this.BrightnessTrackBar.Maximum = 100;
            this.BrightnessTrackBar.Name = "BrightnessTrackBar";
            this.BrightnessTrackBar.Size = new System.Drawing.Size(399, 45);
            this.BrightnessTrackBar.SmallChange = 5;
            this.BrightnessTrackBar.TabIndex = 4;
            this.BrightnessTrackBar.TickFrequency = 5;
            this.BrightnessTrackBar.Scroll += new System.EventHandler(this.BrightnessTrackBar_Scroll);
            // 
            // ContrastValue
            // 
            this.ContrastValue.AutoSize = true;
            this.ContrastValue.Location = new System.Drawing.Point(27, 82);
            this.ContrastValue.Name = "ContrastValue";
            this.ContrastValue.Size = new System.Drawing.Size(46, 13);
            this.ContrastValue.TabIndex = 1;
            this.ContrastValue.Text = "Contrast";
            // 
            // BrightnessValue
            // 
            this.BrightnessValue.AutoSize = true;
            this.BrightnessValue.Location = new System.Drawing.Point(28, 33);
            this.BrightnessValue.Name = "BrightnessValue";
            this.BrightnessValue.Size = new System.Drawing.Size(56, 13);
            this.BrightnessValue.TabIndex = 0;
            this.BrightnessValue.Text = "Brightness";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Reset);
            this.panel4.Controls.Add(this.Apply);
            this.panel4.Location = new System.Drawing.Point(1353, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(189, 66);
            this.panel4.TabIndex = 5;
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(99, 21);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 1;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Apply
            // 
            this.Apply.Location = new System.Drawing.Point(18, 21);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(75, 23);
            this.Apply.TabIndex = 0;
            this.Apply.Text = "Apply";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // BValue
            // 
            this.BValue.AutoSize = true;
            this.BValue.Location = new System.Drawing.Point(495, 33);
            this.BValue.Name = "BValue";
            this.BValue.Size = new System.Drawing.Size(13, 13);
            this.BValue.TabIndex = 5;
            this.BValue.Text = "0";
            // 
            // CVal
            // 
            this.CVal.AutoSize = true;
            this.CVal.Location = new System.Drawing.Point(495, 82);
            this.CVal.Name = "CVal";
            this.CVal.Size = new System.Drawing.Size(13, 13);
            this.CVal.TabIndex = 6;
            this.CVal.Text = "0";
            // 
            // Off
            // 
            this.Off.AutoSize = true;
            this.Off.Checked = true;
            this.Off.Location = new System.Drawing.Point(80, 558);
            this.Off.Name = "Off";
            this.Off.Size = new System.Drawing.Size(45, 17);
            this.Off.TabIndex = 15;
            this.Off.TabStop = true;
            this.Off.Text = "OFF";
            this.Off.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1554, 743);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.WorkedPicture);
            this.Controls.Add(this.OriginalPicture);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkedPicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ditherMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleLevel)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackBar)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox OriginalPicture;
        private System.Windows.Forms.PictureBox WorkedPicture;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Erosing;
        private System.Windows.Forms.Button Dilating;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Customizing;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Grayscale;
        private System.Windows.Forms.Button Inversion;
        private System.Windows.Forms.Button OpenPicture;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TrackBar BrightnessTrackBar;
        private System.Windows.Forms.Label ContrastValue;
        private System.Windows.Forms.Label BrightnessValue;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.TrackBar ContrastTrackBar;
        public System.Windows.Forms.RadioButton RandomDitheringRadioButton;
        public System.Windows.Forms.RadioButton OrderedDitheringRadioButton;
        private new System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.NumericUpDown ditherMatrix;
        private System.Windows.Forms.RadioButton octree;
        private System.Windows.Forms.TextBox kmax;
        private System.Windows.Forms.TextBox subdivision_kg;
        private System.Windows.Forms.TextBox subdivision_kb;
        private System.Windows.Forms.TextBox subdivision_kr;
        private System.Windows.Forms.RadioButton uniform;
        public System.Windows.Forms.NumericUpDown GrayscaleLevel;
        private System.Windows.Forms.Label CVal;
        private System.Windows.Forms.Label BValue;
        private System.Windows.Forms.RadioButton Off;
    }
}

