namespace FindAverageTexture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Start = new System.Windows.Forms.Button();
            this.Prepare_Triangle = new System.Windows.Forms.Button();
            this.Average = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.DrawPixel = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Cal_Single_Pixel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.DrawPixel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(488, 19);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(92, 20);
            this.numericUpDown1.TabIndex = 1;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(387, 96);
            this.Start.Name = "Start";
            this.Start.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Start.Size = new System.Drawing.Size(193, 36);
            this.Start.TabIndex = 2;
            this.Start.Text = "Get_Pixel";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Prepare_Triangle
            // 
            this.Prepare_Triangle.Location = new System.Drawing.Point(387, 48);
            this.Prepare_Triangle.Name = "Prepare_Triangle";
            this.Prepare_Triangle.Size = new System.Drawing.Size(193, 42);
            this.Prepare_Triangle.TabIndex = 3;
            this.Prepare_Triangle.Text = "Prepare_Triangle";
            this.Prepare_Triangle.UseVisualStyleBackColor = true;
            this.Prepare_Triangle.Click += new System.EventHandler(this.Prepare_Triangle_Click);
            // 
            // Average
            // 
            this.Average.Location = new System.Drawing.Point(387, 181);
            this.Average.Name = "Average";
            this.Average.Size = new System.Drawing.Size(193, 41);
            this.Average.TabIndex = 4;
            this.Average.Text = "Cal_Avg_Pixel";
            this.Average.UseVisualStyleBackColor = true;
            this.Average.Click += new System.EventHandler(this.Average_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filename Must Sequential";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(488, 155);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(92, 20);
            this.numericUpDown2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Max Number of File";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "File number";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.DrawPixel);
            this.tabControl1.Location = new System.Drawing.Point(7, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 411);
            this.tabControl1.TabIndex = 9;
            // 
            // DrawPixel
            // 
            this.DrawPixel.AutoScroll = true;
            this.DrawPixel.Controls.Add(this.pictureBox1);
            this.DrawPixel.Location = new System.Drawing.Point(4, 22);
            this.DrawPixel.Name = "DrawPixel";
            this.DrawPixel.Padding = new System.Windows.Forms.Padding(3);
            this.DrawPixel.Size = new System.Drawing.Size(367, 385);
            this.DrawPixel.TabIndex = 0;
            this.DrawPixel.Text = "DrawPixel";
            this.DrawPixel.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(355, 365);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Cal_Single_Pixel
            // 
            this.Cal_Single_Pixel.Location = new System.Drawing.Point(388, 228);
            this.Cal_Single_Pixel.Name = "Cal_Single_Pixel";
            this.Cal_Single_Pixel.Size = new System.Drawing.Size(193, 41);
            this.Cal_Single_Pixel.TabIndex = 10;
            this.Cal_Single_Pixel.Text = "Cal_Single_Pixel";
            this.Cal_Single_Pixel.UseVisualStyleBackColor = true;
            this.Cal_Single_Pixel.Click += new System.EventHandler(this.Cal_Single_Pixel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 440);
            this.Controls.Add(this.Cal_Single_Pixel);
            this.Controls.Add(this.Average);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Prepare_Triangle);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.numericUpDown1);
            this.Name = "Form1";
            this.Text = "MeanTexture";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.DrawPixel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Prepare_Triangle;
        private System.Windows.Forms.Button Average;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage DrawPixel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Cal_Single_Pixel;
    }
}

