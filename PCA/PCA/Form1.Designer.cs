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
            this.Average = new System.Windows.Forms.TabPage();
            this.SaveAvg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeatureVectors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AveragePoint)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.EigenVector.SuspendLayout();
            this.Average.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbMethod
            // 
            this.cbMethod.FormattingEnabled = true;
            this.cbMethod.Items.AddRange(new object[] {
            "Center",
            "Standardize"});
            this.cbMethod.Location = new System.Drawing.Point(136, 50);
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(100, 21);
            this.cbMethod.TabIndex = 2;
            this.cbMethod.Text = "SelectMethod";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(136, 7);
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
            this.LoadFace.Location = new System.Drawing.Point(15, 93);
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
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "AnalysisMethod(Center)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Number of Face (max)";
            // 
            // dgvFeatureVectors
            // 
            this.dgvFeatureVectors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeatureVectors.Location = new System.Drawing.Point(3, 3);
            this.dgvFeatureVectors.Name = "dgvFeatureVectors";
            this.dgvFeatureVectors.Size = new System.Drawing.Size(623, 260);
            this.dgvFeatureVectors.TabIndex = 8;
            // 
            // ShowEigenVector
            // 
            this.ShowEigenVector.Location = new System.Drawing.Point(15, 161);
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
            this.AveragePoint.Size = new System.Drawing.Size(629, 298);
            this.AveragePoint.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.EigenVector);
            this.tabControl1.Controls.Add(this.Average);
            this.tabControl1.Location = new System.Drawing.Point(242, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 330);
            this.tabControl1.TabIndex = 12;
            // 
            // EigenVector
            // 
            this.EigenVector.Controls.Add(this.dgvFeatureVectors);
            this.EigenVector.Location = new System.Drawing.Point(4, 22);
            this.EigenVector.Name = "EigenVector";
            this.EigenVector.Padding = new System.Windows.Forms.Padding(3);
            this.EigenVector.Size = new System.Drawing.Size(632, 304);
            this.EigenVector.TabIndex = 0;
            this.EigenVector.Text = "EigenVector";
            this.EigenVector.UseVisualStyleBackColor = true;
            // 
            // Average
            // 
            this.Average.Controls.Add(this.AveragePoint);
            this.Average.Location = new System.Drawing.Point(4, 22);
            this.Average.Name = "Average";
            this.Average.Padding = new System.Windows.Forms.Padding(3);
            this.Average.Size = new System.Drawing.Size(632, 304);
            this.Average.TabIndex = 1;
            this.Average.Text = "Average";
            this.Average.UseVisualStyleBackColor = true;
            // 
            // SaveAvg
            // 
            this.SaveAvg.Location = new System.Drawing.Point(15, 223);
            this.SaveAvg.Name = "SaveAvg";
            this.SaveAvg.Size = new System.Drawing.Size(213, 42);
            this.SaveAvg.TabIndex = 13;
            this.SaveAvg.Text = "Save Avg Value";
            this.SaveAvg.UseVisualStyleBackColor = true;
            this.SaveAvg.Click += new System.EventHandler(this.SaveAvg_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 357);
            this.Controls.Add(this.SaveAvg);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ShowEigenVector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoadFace);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.cbMethod);
            this.Name = "Form1";
            this.Text = "PCA";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeatureVectors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AveragePoint)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.EigenVector.ResumeLayout(false);
            this.Average.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

