namespace PCA
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
            this.cbMethod = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.LoadFace = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvFeatureVectors = new System.Windows.Forms.DataGridView();
            this.ShowEigenVector = new System.Windows.Forms.Button();
            this.AveragePoint = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.EigenVector = new System.Windows.Forms.TabPage();
            this.Save_Avg_Value_Json = new System.Windows.Forms.Button();
            this.SaveAvg = new System.Windows.Forms.Button();
            this.Average = new System.Windows.Forms.TabPage();
            this.DrawFace = new System.Windows.Forms.TabPage();
            this.Load_Average_Face = new System.Windows.Forms.Button();
            this.trackBar20 = new System.Windows.Forms.TrackBar();
            this.trackBar19 = new System.Windows.Forms.TrackBar();
            this.trackBar18 = new System.Windows.Forms.TrackBar();
            this.trackBar17 = new System.Windows.Forms.TrackBar();
            this.trackBar16 = new System.Windows.Forms.TrackBar();
            this.trackBar15 = new System.Windows.Forms.TrackBar();
            this.trackBar14 = new System.Windows.Forms.TrackBar();
            this.trackBar13 = new System.Windows.Forms.TrackBar();
            this.trackBar12 = new System.Windows.Forms.TrackBar();
            this.trackBar11 = new System.Windows.Forms.TrackBar();
            this.trackBar10 = new System.Windows.Forms.TrackBar();
            this.trackBar9 = new System.Windows.Forms.TrackBar();
            this.trackBar8 = new System.Windows.Forms.TrackBar();
            this.trackBar7 = new System.Windows.Forms.TrackBar();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Save_MeanFaceXY_Text = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeatureVectors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AveragePoint)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.EigenVector.SuspendLayout();
            this.Average.SuspendLayout();
            this.DrawFace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbMethod
            // 
            this.cbMethod.FormattingEnabled = true;
            this.cbMethod.Items.AddRange(new object[] {
            "Center",
            "Standardize"});
            this.cbMethod.Location = new System.Drawing.Point(9, 61);
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(100, 21);
            this.cbMethod.TabIndex = 2;
            this.cbMethod.Text = "SelectMethod";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(9, 22);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // LoadFace
            // 
            this.LoadFace.Location = new System.Drawing.Point(6, 88);
            this.LoadFace.Name = "LoadFace";
            this.LoadFace.Size = new System.Drawing.Size(214, 41);
            this.LoadFace.TabIndex = 4;
            this.LoadFace.Text = "LoadFace and Learn";
            this.LoadFace.UseVisualStyleBackColor = true;
            this.LoadFace.Click += new System.EventHandler(this.LoadFace_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "AnalysisMethod(Center)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Number of Face (max)";
            // 
            // dgvFeatureVectors
            // 
            this.dgvFeatureVectors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeatureVectors.Location = new System.Drawing.Point(226, 6);
            this.dgvFeatureVectors.Name = "dgvFeatureVectors";
            this.dgvFeatureVectors.Size = new System.Drawing.Size(826, 513);
            this.dgvFeatureVectors.TabIndex = 8;
            // 
            // ShowEigenVector
            // 
            this.ShowEigenVector.Location = new System.Drawing.Point(6, 135);
            this.ShowEigenVector.Name = "ShowEigenVector";
            this.ShowEigenVector.Size = new System.Drawing.Size(213, 43);
            this.ShowEigenVector.TabIndex = 9;
            this.ShowEigenVector.Text = "ShowEigenVector";
            this.ShowEigenVector.UseVisualStyleBackColor = true;
            this.ShowEigenVector.Click += new System.EventHandler(this.ShowEigenVector_Click);
            // 
            // AveragePoint
            // 
            this.AveragePoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AveragePoint.Location = new System.Drawing.Point(0, 6);
            this.AveragePoint.Name = "AveragePoint";
            this.AveragePoint.Size = new System.Drawing.Size(1055, 516);
            this.AveragePoint.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.EigenVector);
            this.tabControl1.Controls.Add(this.Average);
            this.tabControl1.Controls.Add(this.DrawFace);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1066, 551);
            this.tabControl1.TabIndex = 12;
            // 
            // EigenVector
            // 
            this.EigenVector.AutoScroll = true;
            this.EigenVector.Controls.Add(this.Save_MeanFaceXY_Text);
            this.EigenVector.Controls.Add(this.Save_Avg_Value_Json);
            this.EigenVector.Controls.Add(this.SaveAvg);
            this.EigenVector.Controls.Add(this.cbMethod);
            this.EigenVector.Controls.Add(this.label1);
            this.EigenVector.Controls.Add(this.label2);
            this.EigenVector.Controls.Add(this.numericUpDown1);
            this.EigenVector.Controls.Add(this.ShowEigenVector);
            this.EigenVector.Controls.Add(this.dgvFeatureVectors);
            this.EigenVector.Controls.Add(this.LoadFace);
            this.EigenVector.Location = new System.Drawing.Point(4, 22);
            this.EigenVector.Name = "EigenVector";
            this.EigenVector.Padding = new System.Windows.Forms.Padding(3);
            this.EigenVector.Size = new System.Drawing.Size(1058, 525);
            this.EigenVector.TabIndex = 0;
            this.EigenVector.Text = "EigenVector";
            this.EigenVector.UseVisualStyleBackColor = true;
            // 
            // Save_Avg_Value_Json
            // 
            this.Save_Avg_Value_Json.Location = new System.Drawing.Point(6, 278);
            this.Save_Avg_Value_Json.Name = "Save_Avg_Value_Json";
            this.Save_Avg_Value_Json.Size = new System.Drawing.Size(213, 42);
            this.Save_Avg_Value_Json.TabIndex = 14;
            this.Save_Avg_Value_Json.Text = "Save Mean Face Json";
            this.Save_Avg_Value_Json.UseVisualStyleBackColor = true;
            this.Save_Avg_Value_Json.Click += new System.EventHandler(this.Save_Avg_Value_Json_Click);
            // 
            // SaveAvg
            // 
            this.SaveAvg.Location = new System.Drawing.Point(6, 184);
            this.SaveAvg.Name = "SaveAvg";
            this.SaveAvg.Size = new System.Drawing.Size(213, 42);
            this.SaveAvg.TabIndex = 13;
            this.SaveAvg.Text = "Save MeanFaceXYZ Text";
            this.SaveAvg.UseVisualStyleBackColor = true;
            this.SaveAvg.Click += new System.EventHandler(this.SaveAvg_Click);
            // 
            // Average
            // 
            this.Average.AutoScroll = true;
            this.Average.Controls.Add(this.AveragePoint);
            this.Average.Location = new System.Drawing.Point(4, 22);
            this.Average.Name = "Average";
            this.Average.Padding = new System.Windows.Forms.Padding(3);
            this.Average.Size = new System.Drawing.Size(1058, 525);
            this.Average.TabIndex = 1;
            this.Average.Text = "Average";
            this.Average.UseVisualStyleBackColor = true;
            // 
            // DrawFace
            // 
            this.DrawFace.AutoScroll = true;
            this.DrawFace.Controls.Add(this.Load_Average_Face);
            this.DrawFace.Controls.Add(this.trackBar20);
            this.DrawFace.Controls.Add(this.trackBar19);
            this.DrawFace.Controls.Add(this.trackBar18);
            this.DrawFace.Controls.Add(this.trackBar17);
            this.DrawFace.Controls.Add(this.trackBar16);
            this.DrawFace.Controls.Add(this.trackBar15);
            this.DrawFace.Controls.Add(this.trackBar14);
            this.DrawFace.Controls.Add(this.trackBar13);
            this.DrawFace.Controls.Add(this.trackBar12);
            this.DrawFace.Controls.Add(this.trackBar11);
            this.DrawFace.Controls.Add(this.trackBar10);
            this.DrawFace.Controls.Add(this.trackBar9);
            this.DrawFace.Controls.Add(this.trackBar8);
            this.DrawFace.Controls.Add(this.trackBar7);
            this.DrawFace.Controls.Add(this.trackBar6);
            this.DrawFace.Controls.Add(this.trackBar5);
            this.DrawFace.Controls.Add(this.trackBar4);
            this.DrawFace.Controls.Add(this.trackBar3);
            this.DrawFace.Controls.Add(this.trackBar2);
            this.DrawFace.Controls.Add(this.trackBar1);
            this.DrawFace.Controls.Add(this.pictureBox1);
            this.DrawFace.Location = new System.Drawing.Point(4, 22);
            this.DrawFace.Name = "DrawFace";
            this.DrawFace.Size = new System.Drawing.Size(1058, 525);
            this.DrawFace.TabIndex = 2;
            this.DrawFace.Text = "DrawFace";
            this.DrawFace.UseVisualStyleBackColor = true;
            // 
            // Load_Average_Face
            // 
            this.Load_Average_Face.Location = new System.Drawing.Point(773, 8);
            this.Load_Average_Face.Name = "Load_Average_Face";
            this.Load_Average_Face.Size = new System.Drawing.Size(159, 40);
            this.Load_Average_Face.TabIndex = 21;
            this.Load_Average_Face.Text = "Load Mean Face";
            this.Load_Average_Face.UseVisualStyleBackColor = true;
            this.Load_Average_Face.Click += new System.EventHandler(this.Load_Average_Face_Click);
            // 
            // trackBar20
            // 
            this.trackBar20.LargeChange = 1;
            this.trackBar20.Location = new System.Drawing.Point(932, 522);
            this.trackBar20.Maximum = 5;
            this.trackBar20.Minimum = -5;
            this.trackBar20.Name = "trackBar20";
            this.trackBar20.Size = new System.Drawing.Size(106, 45);
            this.trackBar20.TabIndex = 20;
            this.trackBar20.Scroll += new System.EventHandler(this.trackBar20_Scroll);
            // 
            // trackBar19
            // 
            this.trackBar19.LargeChange = 1;
            this.trackBar19.Location = new System.Drawing.Point(935, 471);
            this.trackBar19.Maximum = 5;
            this.trackBar19.Minimum = -5;
            this.trackBar19.Name = "trackBar19";
            this.trackBar19.Size = new System.Drawing.Size(105, 45);
            this.trackBar19.TabIndex = 19;
            this.trackBar19.Scroll += new System.EventHandler(this.trackBar19_Scroll);
            // 
            // trackBar18
            // 
            this.trackBar18.LargeChange = 1;
            this.trackBar18.Location = new System.Drawing.Point(934, 420);
            this.trackBar18.Maximum = 5;
            this.trackBar18.Minimum = -5;
            this.trackBar18.Name = "trackBar18";
            this.trackBar18.Size = new System.Drawing.Size(106, 45);
            this.trackBar18.TabIndex = 18;
            this.trackBar18.Scroll += new System.EventHandler(this.trackBar18_Scroll);
            // 
            // trackBar17
            // 
            this.trackBar17.LargeChange = 1;
            this.trackBar17.Location = new System.Drawing.Point(934, 369);
            this.trackBar17.Maximum = 5;
            this.trackBar17.Minimum = -5;
            this.trackBar17.Name = "trackBar17";
            this.trackBar17.Size = new System.Drawing.Size(105, 45);
            this.trackBar17.TabIndex = 17;
            this.trackBar17.Scroll += new System.EventHandler(this.trackBar17_Scroll);
            // 
            // trackBar16
            // 
            this.trackBar16.LargeChange = 1;
            this.trackBar16.Location = new System.Drawing.Point(934, 318);
            this.trackBar16.Maximum = 5;
            this.trackBar16.Minimum = -5;
            this.trackBar16.Name = "trackBar16";
            this.trackBar16.Size = new System.Drawing.Size(105, 45);
            this.trackBar16.TabIndex = 16;
            this.trackBar16.Scroll += new System.EventHandler(this.trackBar16_Scroll);
            // 
            // trackBar15
            // 
            this.trackBar15.LargeChange = 1;
            this.trackBar15.Location = new System.Drawing.Point(934, 267);
            this.trackBar15.Maximum = 5;
            this.trackBar15.Minimum = -5;
            this.trackBar15.Name = "trackBar15";
            this.trackBar15.Size = new System.Drawing.Size(105, 45);
            this.trackBar15.TabIndex = 15;
            this.trackBar15.Scroll += new System.EventHandler(this.trackBar15_Scroll);
            // 
            // trackBar14
            // 
            this.trackBar14.LargeChange = 1;
            this.trackBar14.Location = new System.Drawing.Point(934, 216);
            this.trackBar14.Maximum = 5;
            this.trackBar14.Minimum = -5;
            this.trackBar14.Name = "trackBar14";
            this.trackBar14.Size = new System.Drawing.Size(105, 45);
            this.trackBar14.TabIndex = 14;
            this.trackBar14.Scroll += new System.EventHandler(this.trackBar14_Scroll);
            // 
            // trackBar13
            // 
            this.trackBar13.LargeChange = 1;
            this.trackBar13.Location = new System.Drawing.Point(934, 165);
            this.trackBar13.Maximum = 5;
            this.trackBar13.Minimum = -5;
            this.trackBar13.Name = "trackBar13";
            this.trackBar13.Size = new System.Drawing.Size(105, 45);
            this.trackBar13.TabIndex = 13;
            this.trackBar13.Scroll += new System.EventHandler(this.trackBar13_Scroll);
            // 
            // trackBar12
            // 
            this.trackBar12.LargeChange = 1;
            this.trackBar12.Location = new System.Drawing.Point(934, 114);
            this.trackBar12.Maximum = 5;
            this.trackBar12.Minimum = -5;
            this.trackBar12.Name = "trackBar12";
            this.trackBar12.Size = new System.Drawing.Size(105, 45);
            this.trackBar12.TabIndex = 12;
            this.trackBar12.Scroll += new System.EventHandler(this.trackBar12_Scroll);
            // 
            // trackBar11
            // 
            this.trackBar11.LargeChange = 1;
            this.trackBar11.Location = new System.Drawing.Point(934, 63);
            this.trackBar11.Maximum = 5;
            this.trackBar11.Minimum = -5;
            this.trackBar11.Name = "trackBar11";
            this.trackBar11.Size = new System.Drawing.Size(104, 45);
            this.trackBar11.TabIndex = 11;
            this.trackBar11.Scroll += new System.EventHandler(this.trackBar11_Scroll);
            // 
            // trackBar10
            // 
            this.trackBar10.LargeChange = 1;
            this.trackBar10.Location = new System.Drawing.Point(772, 522);
            this.trackBar10.Maximum = 5;
            this.trackBar10.Minimum = -5;
            this.trackBar10.Name = "trackBar10";
            this.trackBar10.Size = new System.Drawing.Size(105, 45);
            this.trackBar10.TabIndex = 10;
            this.trackBar10.Scroll += new System.EventHandler(this.trackBar10_Scroll);
            // 
            // trackBar9
            // 
            this.trackBar9.LargeChange = 1;
            this.trackBar9.Location = new System.Drawing.Point(772, 471);
            this.trackBar9.Maximum = 5;
            this.trackBar9.Minimum = -5;
            this.trackBar9.Name = "trackBar9";
            this.trackBar9.Size = new System.Drawing.Size(105, 45);
            this.trackBar9.TabIndex = 9;
            this.trackBar9.Scroll += new System.EventHandler(this.trackBar9_Scroll);
            // 
            // trackBar8
            // 
            this.trackBar8.LargeChange = 1;
            this.trackBar8.Location = new System.Drawing.Point(772, 420);
            this.trackBar8.Maximum = 5;
            this.trackBar8.Minimum = -5;
            this.trackBar8.Name = "trackBar8";
            this.trackBar8.Size = new System.Drawing.Size(105, 45);
            this.trackBar8.TabIndex = 8;
            this.trackBar8.Scroll += new System.EventHandler(this.trackBar8_Scroll);
            // 
            // trackBar7
            // 
            this.trackBar7.Location = new System.Drawing.Point(772, 369);
            this.trackBar7.Maximum = 5;
            this.trackBar7.Minimum = -5;
            this.trackBar7.Name = "trackBar7";
            this.trackBar7.Size = new System.Drawing.Size(105, 45);
            this.trackBar7.TabIndex = 7;
            this.trackBar7.Scroll += new System.EventHandler(this.trackBar7_Scroll);
            // 
            // trackBar6
            // 
            this.trackBar6.LargeChange = 1;
            this.trackBar6.Location = new System.Drawing.Point(772, 318);
            this.trackBar6.Maximum = 5;
            this.trackBar6.Minimum = -5;
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Size = new System.Drawing.Size(105, 45);
            this.trackBar6.TabIndex = 6;
            this.trackBar6.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // trackBar5
            // 
            this.trackBar5.LargeChange = 1;
            this.trackBar5.Location = new System.Drawing.Point(772, 267);
            this.trackBar5.Maximum = 5;
            this.trackBar5.Minimum = -5;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(105, 45);
            this.trackBar5.TabIndex = 5;
            this.trackBar5.Scroll += new System.EventHandler(this.trackBar5_Scroll);
            // 
            // trackBar4
            // 
            this.trackBar4.LargeChange = 1;
            this.trackBar4.Location = new System.Drawing.Point(772, 216);
            this.trackBar4.Maximum = 5;
            this.trackBar4.Minimum = -5;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(105, 45);
            this.trackBar4.TabIndex = 4;
            this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.LargeChange = 1;
            this.trackBar3.Location = new System.Drawing.Point(772, 165);
            this.trackBar3.Maximum = 5;
            this.trackBar3.Minimum = -5;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(105, 45);
            this.trackBar3.TabIndex = 3;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 1;
            this.trackBar2.Location = new System.Drawing.Point(772, 114);
            this.trackBar2.Maximum = 5;
            this.trackBar2.Minimum = -5;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(105, 45);
            this.trackBar2.TabIndex = 2;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(772, 63);
            this.trackBar1.Maximum = 5;
            this.trackBar1.Minimum = -5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(105, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(710, 730);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Save_MeanFaceXY_Text
            // 
            this.Save_MeanFaceXY_Text.Location = new System.Drawing.Point(6, 232);
            this.Save_MeanFaceXY_Text.Name = "Save_MeanFaceXY_Text";
            this.Save_MeanFaceXY_Text.Size = new System.Drawing.Size(213, 40);
            this.Save_MeanFaceXY_Text.TabIndex = 15;
            this.Save_MeanFaceXY_Text.Text = "Save MeanFaceXY Text";
            this.Save_MeanFaceXY_Text.UseVisualStyleBackColor = true;
            this.Save_MeanFaceXY_Text.Click += new System.EventHandler(this.Save_MeanFaceXY_Text_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1090, 575);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "PCA";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeatureVectors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AveragePoint)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.EigenVector.ResumeLayout(false);
            this.EigenVector.PerformLayout();
            this.Average.ResumeLayout(false);
            this.DrawFace.ResumeLayout(false);
            this.DrawFace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbMethod;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button LoadFace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvFeatureVectors;
        private System.Windows.Forms.Button ShowEigenVector;
        private System.Windows.Forms.DataGridView AveragePoint;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage EigenVector;
        private System.Windows.Forms.TabPage Average;
        private System.Windows.Forms.Button SaveAvg;
        private System.Windows.Forms.TabPage DrawFace;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar6;
        private System.Windows.Forms.TrackBar trackBar9;
        private System.Windows.Forms.TrackBar trackBar8;
        private System.Windows.Forms.TrackBar trackBar7;
        private System.Windows.Forms.TrackBar trackBar15;
        private System.Windows.Forms.TrackBar trackBar14;
        private System.Windows.Forms.TrackBar trackBar13;
        private System.Windows.Forms.TrackBar trackBar12;
        private System.Windows.Forms.TrackBar trackBar11;
        private System.Windows.Forms.TrackBar trackBar10;
        private System.Windows.Forms.TrackBar trackBar18;
        private System.Windows.Forms.TrackBar trackBar17;
        private System.Windows.Forms.TrackBar trackBar16;
        private System.Windows.Forms.TrackBar trackBar20;
        private System.Windows.Forms.TrackBar trackBar19;
        private System.Windows.Forms.Button Save_Avg_Value_Json;
        private System.Windows.Forms.Button Load_Average_Face;
        private System.Windows.Forms.Button Save_MeanFaceXY_Text;
    }
}

