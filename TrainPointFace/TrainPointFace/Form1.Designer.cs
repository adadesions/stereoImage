namespace TrainPointFace
{
    partial class TrainPointFace
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.save_txt = new System.Windows.Forms.Button();
            this.LoadPoint = new System.Windows.Forms.Button();
            this.Select_Image = new System.Windows.Forms.Button();
            this.save_crop = new System.Windows.Forms.Button();
            this.LoadPointCrop = new System.Windows.Forms.Button();
            this.save_DrawDelaunay_gl = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TrainPoint = new System.Windows.Forms.TabPage();
            this.TrainCrop = new System.Windows.Forms.TabPage();
            this.Select_Crop_Image = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.TrainPoint.SuspendLayout();
            this.TrainCrop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(710, 730);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(766, 17);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(98, 20);
            this.numericUpDown1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(717, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Face";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(734, 140);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(130, 45);
            this.save.TabIndex = 3;
            this.save.Text = "save json";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // save_txt
            // 
            this.save_txt.Location = new System.Drawing.Point(733, 191);
            this.save_txt.Name = "save_txt";
            this.save_txt.Size = new System.Drawing.Size(131, 45);
            this.save_txt.TabIndex = 4;
            this.save_txt.Text = "save txt";
            this.save_txt.UseVisualStyleBackColor = true;
            this.save_txt.Click += new System.EventHandler(this.save_txt_Click);
            // 
            // LoadPoint
            // 
            this.LoadPoint.Location = new System.Drawing.Point(734, 94);
            this.LoadPoint.Name = "LoadPoint";
            this.LoadPoint.Size = new System.Drawing.Size(130, 40);
            this.LoadPoint.TabIndex = 5;
            this.LoadPoint.Text = "Load_Image_Point";
            this.LoadPoint.UseVisualStyleBackColor = true;
            this.LoadPoint.Click += new System.EventHandler(this.LoadPoint_Click);
            // 
            // Select_Image
            // 
            this.Select_Image.Location = new System.Drawing.Point(734, 43);
            this.Select_Image.Name = "Select_Image";
            this.Select_Image.Size = new System.Drawing.Size(130, 45);
            this.Select_Image.TabIndex = 6;
            this.Select_Image.Text = "Select Image";
            this.Select_Image.UseVisualStyleBackColor = true;
            this.Select_Image.Click += new System.EventHandler(this.Select_Image_Click);
            // 
            // save_crop
            // 
            this.save_crop.Location = new System.Drawing.Point(729, 105);
            this.save_crop.Name = "save_crop";
            this.save_crop.Size = new System.Drawing.Size(151, 41);
            this.save_crop.TabIndex = 7;
            this.save_crop.Text = "Save Crop Json";
            this.save_crop.UseVisualStyleBackColor = true;
            this.save_crop.Click += new System.EventHandler(this.save_crop_Click);
            // 
            // LoadPointCrop
            // 
            this.LoadPointCrop.Location = new System.Drawing.Point(729, 152);
            this.LoadPointCrop.Name = "LoadPointCrop";
            this.LoadPointCrop.Size = new System.Drawing.Size(151, 44);
            this.LoadPointCrop.TabIndex = 8;
            this.LoadPointCrop.Text = "Load_CropImage_Point";
            this.LoadPointCrop.UseVisualStyleBackColor = true;
            this.LoadPointCrop.Click += new System.EventHandler(this.LoadPointCrop_Click);
            // 
            // save_DrawDelaunay_gl
            // 
            this.save_DrawDelaunay_gl.Location = new System.Drawing.Point(729, 202);
            this.save_DrawDelaunay_gl.Name = "save_DrawDelaunay_gl";
            this.save_DrawDelaunay_gl.Size = new System.Drawing.Size(151, 44);
            this.save_DrawDelaunay_gl.TabIndex = 9;
            this.save_DrawDelaunay_gl.Text = "SaveRotate_180Deg_txtFile";
            this.save_DrawDelaunay_gl.UseVisualStyleBackColor = true;
            this.save_DrawDelaunay_gl.Click += new System.EventHandler(this.save_DrawDelaunay_gl_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TrainPoint);
            this.tabControl1.Controls.Add(this.TrainCrop);
            this.tabControl1.Location = new System.Drawing.Point(5, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(906, 730);
            this.tabControl1.TabIndex = 10;
            // 
            // TrainPoint
            // 
            this.TrainPoint.AutoScroll = true;
            this.TrainPoint.Controls.Add(this.pictureBox1);
            this.TrainPoint.Controls.Add(this.label1);
            this.TrainPoint.Controls.Add(this.numericUpDown1);
            this.TrainPoint.Controls.Add(this.Select_Image);
            this.TrainPoint.Controls.Add(this.save_txt);
            this.TrainPoint.Controls.Add(this.LoadPoint);
            this.TrainPoint.Controls.Add(this.save);
            this.TrainPoint.Location = new System.Drawing.Point(4, 22);
            this.TrainPoint.Name = "TrainPoint";
            this.TrainPoint.Padding = new System.Windows.Forms.Padding(3);
            this.TrainPoint.Size = new System.Drawing.Size(898, 704);
            this.TrainPoint.TabIndex = 0;
            this.TrainPoint.Text = "TrainPoint";
            this.TrainPoint.UseVisualStyleBackColor = true;
            // 
            // TrainCrop
            // 
            this.TrainCrop.AutoScroll = true;
            this.TrainCrop.Controls.Add(this.Select_Crop_Image);
            this.TrainCrop.Controls.Add(this.numericUpDown2);
            this.TrainCrop.Controls.Add(this.pictureBox2);
            this.TrainCrop.Controls.Add(this.save_DrawDelaunay_gl);
            this.TrainCrop.Controls.Add(this.label2);
            this.TrainCrop.Controls.Add(this.LoadPointCrop);
            this.TrainCrop.Controls.Add(this.save_crop);
            this.TrainCrop.Location = new System.Drawing.Point(4, 22);
            this.TrainCrop.Name = "TrainCrop";
            this.TrainCrop.Padding = new System.Windows.Forms.Padding(3);
            this.TrainCrop.Size = new System.Drawing.Size(1020, 704);
            this.TrainCrop.TabIndex = 1;
            this.TrainCrop.Text = "TrainCrop";
            this.TrainCrop.UseVisualStyleBackColor = true;
            // 
            // Select_Crop_Image
            // 
            this.Select_Crop_Image.Location = new System.Drawing.Point(729, 58);
            this.Select_Crop_Image.Name = "Select_Crop_Image";
            this.Select_Crop_Image.Size = new System.Drawing.Size(151, 41);
            this.Select_Crop_Image.TabIndex = 14;
            this.Select_Crop_Image.Text = "Select Crop Image";
            this.Select_Crop_Image.UseVisualStyleBackColor = true;
            this.Select_Crop_Image.Click += new System.EventHandler(this.Select_Crop_Image_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(769, 19);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(111, 20);
            this.numericUpDown2.TabIndex = 13;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(710, 730);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(726, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Face";
            // 
            // TrainPointFace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(939, 477);
            this.Controls.Add(this.tabControl1);
            this.Name = "TrainPointFace";
            this.Text = "TrainPointFace";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.TrainPoint.ResumeLayout(false);
            this.TrainPoint.PerformLayout();
            this.TrainCrop.ResumeLayout(false);
            this.TrainCrop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button save_txt;
        private System.Windows.Forms.Button LoadPoint;
        private System.Windows.Forms.Button Select_Image;
        private System.Windows.Forms.Button save_crop;
        private System.Windows.Forms.Button LoadPointCrop;
        private System.Windows.Forms.Button save_DrawDelaunay_gl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TrainPoint;
        private System.Windows.Forms.TabPage TrainCrop;
        private System.Windows.Forms.Button Select_Crop_Image;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
    }
}

