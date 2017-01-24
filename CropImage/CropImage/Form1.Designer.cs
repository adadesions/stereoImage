namespace CropImage
{
    partial class CropImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CropImage));
            this.SrcPicBox = new System.Windows.Forms.PictureBox();
            this.Source_Picture = new System.Windows.Forms.Label();
            this.lbCordinates = new System.Windows.Forms.Label();
            this.Crop = new System.Windows.Forms.Button();
            this.TargetPicBox = new System.Windows.Forms.PictureBox();
            this.chkCropCordinates = new System.Windows.Forms.CheckBox();
            this.tbCordinates = new System.Windows.Forms.TextBox();
            this.Select_Image = new System.Windows.Forms.Button();
            this.Target_Picture = new System.Windows.Forms.Label();
            this.Save_Image = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SrcPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SrcPicBox
            // 
            this.SrcPicBox.Image = ((System.Drawing.Image)(resources.GetObject("SrcPicBox.Image")));
            this.SrcPicBox.Location = new System.Drawing.Point(15, 25);
            this.SrcPicBox.Name = "SrcPicBox";
            this.SrcPicBox.Size = new System.Drawing.Size(710, 720);
            this.SrcPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SrcPicBox.TabIndex = 0;
            this.SrcPicBox.TabStop = false;
            this.SrcPicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.SrcPicBox_Paint);
            this.SrcPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SrcPicBox_MouseDown);
            this.SrcPicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SrcPicBox_MouseMove);
            this.SrcPicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SrcPicBox_MouseUp);
            // 
            // Source_Picture
            // 
            this.Source_Picture.AutoSize = true;
            this.Source_Picture.Location = new System.Drawing.Point(12, 9);
            this.Source_Picture.Name = "Source_Picture";
            this.Source_Picture.Size = new System.Drawing.Size(80, 13);
            this.Source_Picture.TabIndex = 1;
            this.Source_Picture.Text = "Source_Picture";
            // 
            // lbCordinates
            // 
            this.lbCordinates.AutoSize = true;
            this.lbCordinates.Location = new System.Drawing.Point(511, 9);
            this.lbCordinates.Name = "lbCordinates";
            this.lbCordinates.Size = new System.Drawing.Size(67, 13);
            this.lbCordinates.TabIndex = 2;
            this.lbCordinates.Text = "Coordinate : ";
            // 
            // Crop
            // 
            this.Crop.Location = new System.Drawing.Point(731, 60);
            this.Crop.Name = "Crop";
            this.Crop.Size = new System.Drawing.Size(119, 29);
            this.Crop.TabIndex = 3;
            this.Crop.Text = "Crop";
            this.Crop.UseVisualStyleBackColor = true;
            this.Crop.Click += new System.EventHandler(this.Crop_Click);
            // 
            // TargetPicBox
            // 
            this.TargetPicBox.Image = ((System.Drawing.Image)(resources.GetObject("TargetPicBox.Image")));
            this.TargetPicBox.Location = new System.Drawing.Point(856, 25);
            this.TargetPicBox.Name = "TargetPicBox";
            this.TargetPicBox.Size = new System.Drawing.Size(355, 365);
            this.TargetPicBox.TabIndex = 4;
            this.TargetPicBox.TabStop = false;
            // 
            // chkCropCordinates
            // 
            this.chkCropCordinates.AutoSize = true;
            this.chkCropCordinates.Location = new System.Drawing.Point(98, 8);
            this.chkCropCordinates.Name = "chkCropCordinates";
            this.chkCropCordinates.Size = new System.Drawing.Size(202, 17);
            this.chkCropCordinates.TabIndex = 5;
            this.chkCropCordinates.Text = "Crop using coordinates ( x1,y1,x2,y2 )";
            this.chkCropCordinates.UseVisualStyleBackColor = true;
            this.chkCropCordinates.CheckedChanged += new System.EventHandler(this.chkCropCordinates_CheckedChanged);
            // 
            // tbCordinates
            // 
            this.tbCordinates.Location = new System.Drawing.Point(306, 3);
            this.tbCordinates.Name = "tbCordinates";
            this.tbCordinates.Size = new System.Drawing.Size(115, 20);
            this.tbCordinates.TabIndex = 6;
            this.tbCordinates.Visible = false;
            this.tbCordinates.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCordinates_KeyPress);
            // 
            // Select_Image
            // 
            this.Select_Image.Location = new System.Drawing.Point(731, 25);
            this.Select_Image.Name = "Select_Image";
            this.Select_Image.Size = new System.Drawing.Size(119, 29);
            this.Select_Image.TabIndex = 7;
            this.Select_Image.Text = "Select Image";
            this.Select_Image.UseVisualStyleBackColor = true;
            this.Select_Image.Click += new System.EventHandler(this.Select_Image_Click);
            // 
            // Target_Picture
            // 
            this.Target_Picture.AutoSize = true;
            this.Target_Picture.Location = new System.Drawing.Point(853, 9);
            this.Target_Picture.Name = "Target_Picture";
            this.Target_Picture.Size = new System.Drawing.Size(77, 13);
            this.Target_Picture.TabIndex = 8;
            this.Target_Picture.Text = "Target_Picture";
            // 
            // Save_Image
            // 
            this.Save_Image.Location = new System.Drawing.Point(856, 410);
            this.Save_Image.Name = "Save_Image";
            this.Save_Image.Size = new System.Drawing.Size(118, 32);
            this.Save_Image.TabIndex = 9;
            this.Save_Image.Text = "Save_Image";
            this.Save_Image.UseVisualStyleBackColor = true;
            this.Save_Image.Click += new System.EventHandler(this.Save_Image_Click);
            // 
            // CropImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1284, 651);
            this.Controls.Add(this.Save_Image);
            this.Controls.Add(this.Target_Picture);
            this.Controls.Add(this.Select_Image);
            this.Controls.Add(this.tbCordinates);
            this.Controls.Add(this.chkCropCordinates);
            this.Controls.Add(this.TargetPicBox);
            this.Controls.Add(this.Crop);
            this.Controls.Add(this.lbCordinates);
            this.Controls.Add(this.Source_Picture);
            this.Controls.Add(this.SrcPicBox);
            this.Name = "CropImage";
            this.Text = "CropImage";
            ((System.ComponentModel.ISupportInitialize)(this.SrcPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SrcPicBox;
        private System.Windows.Forms.Label Source_Picture;
        private System.Windows.Forms.Label lbCordinates;
        private System.Windows.Forms.Button Crop;
        private System.Windows.Forms.PictureBox TargetPicBox;
        private System.Windows.Forms.CheckBox chkCropCordinates;
        private System.Windows.Forms.TextBox tbCordinates;
        private System.Windows.Forms.Button Select_Image;
        private System.Windows.Forms.Label Target_Picture;
        private System.Windows.Forms.Button Save_Image;
    }
}

