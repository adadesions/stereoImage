using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace TrainPointFace
{
    public partial class TrainPointFace : Form
    {
        public class InitialPoint
        {
            public double[] PointX { get; set; }
            public double[] PointY { get; set; }
            public double[] PointZ { get; set; }
        }
        public class InitialPoint2
        {
            public double[] PointX { get; set; }
            public double[] PointY { get; set; }
            public double[] PointZ { get; set; }
        }
        public class PointOnFace
        {
            public int Face { get; set; }
            public double[] PointX { get; set; }
            public double[] PointY { get; set; }
            public double[] PointZ { get; set; }
        }

        static string json = File.ReadAllText("../initialpoint.json");
        static InitialPoint init = JsonConvert.DeserializeObject<InitialPoint>(json);
        static string json2 = File.ReadAllText("../initialpoint.json");
        static InitialPoint2 init2 = JsonConvert.DeserializeObject<InitialPoint2>(json);

        public static double[] pointx = init.PointX;
        public static double[] pointy = init.PointY;
        public static double[] pointxcrop = init2.PointX;
        public static double[] pointycrop = init2.PointY;

        public int pointmove; //ตัวแปรกำหนดค่าว่าจุดไหนจะขยับตามเม้า
        private Point MouseDownLocation;
        Rectangle[] recStore = new Rectangle[37];
        Rectangle[] CroprecStore = new Rectangle[37];

        public TrainPointFace()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int[] pointxx = new int[37];
            int[] pointyy = new int[37];
            for (int i = 0; i < 37; i++)
            {
                pointxx[i] = Convert.ToInt32(pointx[i]);
                pointyy[i] = Convert.ToInt32(pointy[i]);
                recStore[i] = new Rectangle((pointxx[i]), (pointyy[i]), 10, 10);
                e.Graphics.FillEllipse(Brushes.Blue, recStore[i]);
            }
            Update(); //ลื่น ใช้กับจุดขยับตามเม้า
            //Refresh(); //ตรงนี้ทำให้หน่วงและทำให้จุดขยับตามเม้าได้
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            double[] differencex = new double[37];
            double[] differencey = new double[37];
            double holdx = 8, holdy = 8;

            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i <= 36; i++) //calculate difference X,Y all point
                {
                    differencex[i] = Math.Abs(e.X - pointx[i]);
                    differencey[i] = Math.Abs(e.Y - pointy[i]);
                }

                for (int i = 0; i <= 36; i++) //loop search point near mouse
                {
                    if (differencex[i] < holdx && differencey[i] < holdy)
                    {
                        holdx = differencex[i];
                        holdy = differencey[i];
                        pointmove = i;
                        Console.WriteLine("Point" + pointmove);
                        //finish search pointmove
                    }
                    //finish condition search pointmove
                }
                //end loop search pointmove
                Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //pointmove
                MouseDownLocation = e.Location;
                recStore[pointmove] = new Rectangle(e.X, e.Y, 10, 10);
                pointx[pointmove] = e.X;
                pointy[pointmove] = e.Y;
                Console.WriteLine("Point" + pointmove + "X = " + MouseDownLocation.X);
                Console.WriteLine("Point" + pointmove + "Y = " + MouseDownLocation.Y);
                Invalidate(true);
                //finish pointmove
            }
        }

        private void Select_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image img = Image.FromFile(open.FileName);
                pictureBox1.Image = img;
            }
        }

        private void LoadPoint_Click(object sender, EventArgs e)
        {
            decimal value = (numericUpDown1.Value); //ค่าเลือก หมายเลขหน้า
            int faceInt = decimal.ToInt32(value); //แปลงเป็น int            
            bool checkfile = File.Exists("../PointFace" + faceInt + ".json");
            Console.WriteLine(checkfile);
            if (checkfile == true)
            {
                string json = File.ReadAllText("../PointFace" + faceInt + ".json");
                InitialPoint init = JsonConvert.DeserializeObject<InitialPoint>(json);
                for (int t = 0; t < 37; t++)
                {
                    pointx[t] = init.PointX[t];
                    pointy[t] = init.PointY[t];
                }
                MessageBox.Show("Load Point Face" + faceInt);
            }
            else
            {
                MessageBox.Show("File Not Found");
            }
            Invalidate(true);
        }

        private void save_txt_Click(object sender, EventArgs e) //For Open CV c++
        {
            decimal value = (numericUpDown1.Value); //ค่าเลือก หมายเลขหน้า
            int faceInt = decimal.ToInt32(value); //แปลงเป็น int
            DialogResult result = MessageBox.Show("Save To " + value, "Save txt", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...                
                string face = faceInt.ToString();
                PointOnFace updatepoint = new PointOnFace();
                updatepoint.Face = faceInt;
                updatepoint.PointX = pointx;
                updatepoint.PointY = pointy;
                //updatepoint.PointZ = pointz;
                string path = "../PointFaceC" + faceInt + ".txt";
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        for (int k = 0; k <= 36; k++)
                        {
                            sw.Write(pointx[k] + " " + pointy[k] + "\n");
                        }
                        sw.Close();
                    }
                    Console.WriteLine("File create!!!!");
                }
                MessageBox.Show("Save To Face" + faceInt);
                Invalidate(true);

            }
            else if (result == DialogResult.No)
            {
                //no...
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            decimal value = (numericUpDown1.Value); //ค่าเลือก หมายเลขหน้า
            int faceInt = decimal.ToInt32(value); //แปลงเป็น int
            DialogResult result = MessageBox.Show("Save To Face " + value, "Save Json", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...               
                string face = faceInt.ToString();
                PointOnFace updatepoint = new PointOnFace();
                updatepoint.Face = faceInt;
                updatepoint.PointX = pointx;
                updatepoint.PointY = pointy;
                //updatepoint.PointZ = pointz;

                string json = JsonConvert.SerializeObject(updatepoint);

                //write string to file
                System.IO.File.WriteAllText("../PointFace" + faceInt + ".json", json);
                //save to emgu2\bin\
                Console.WriteLine("file create!!!!");
                MessageBox.Show("Save To Face" + faceInt);
            }
            else if (result == DialogResult.No)
            {
                //no...
            }

        }



        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            int[] pointxx = new int[37];
            int[] pointyy = new int[37];
            for (int i = 0; i < 37; i++)
            {
                pointxx[i] = Convert.ToInt32(pointxcrop[i]);
                pointyy[i] = Convert.ToInt32(pointycrop[i]);
                CroprecStore[i] = new Rectangle((pointxx[i]), (pointyy[i]), 10, 10);
                e.Graphics.FillEllipse(Brushes.OrangeRed, CroprecStore[i]);
            }
            Update(); //ลื่น ใช้กับจุดขยับตามเม้า
        }

        private void save_crop_Click(object sender, EventArgs e) //Json
        {
            decimal value = (numericUpDown2.Value); //ค่าเลือก หมายเลขหน้า
            int faceInt = decimal.ToInt32(value); //แปลงเป็น int
            DialogResult result = MessageBox.Show("Save To Face " + value, "Save Json", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...               
                string face = faceInt.ToString();
                PointOnFace updatepoint = new PointOnFace();
                updatepoint.Face = faceInt;
                updatepoint.PointX = pointx;
                updatepoint.PointY = pointy;
                //updatepoint.PointZ = pointz;

                string json = JsonConvert.SerializeObject(updatepoint);

                //write string to file
                System.IO.File.WriteAllText("../PointFaceC" + faceInt + ".json", json);
                //save to emgu2\bin\
                Console.WriteLine("file create!!!!");
                MessageBox.Show("Save To PointFaceC" + faceInt);
            }
            else if (result == DialogResult.No)
            {
                //no...
            }
        }

        private void LoadPointCrop_Click(object sender, EventArgs e)
        {
            decimal value = (numericUpDown2.Value); //ค่าเลือก หมายเลขหน้า
            int faceInt = decimal.ToInt32(value); //แปลงเป็น int            
            bool checkfile = File.Exists("../PointFaceC" + faceInt + ".json");
            Console.WriteLine(checkfile);
            if (checkfile == true)
            {
                string json = File.ReadAllText("../PointFaceC" + faceInt + ".json");
                InitialPoint2 init = JsonConvert.DeserializeObject<InitialPoint2>(json);
                for (int t = 0; t < 37; t++)
                {
                    pointxcrop[t] = init.PointX[t];
                    pointycrop[t] = init.PointY[t];
                }
                MessageBox.Show("Load Point Face Crop" + faceInt);
            }
            else
            {
                MessageBox.Show("File Not Found");
            }
            Invalidate(true);
        }

        private void save_DrawDelaunay_gl_Click(object sender, EventArgs e) //TextFile for openGL c++
        {
            decimal value = (numericUpDown2.Value); //ค่าเลือก หมายเลขหน้า
            int faceInt = decimal.ToInt32(value); //แปลงเป็น int
            DialogResult result = MessageBox.Show("Save To " + value, "Save txt", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                double pivotx = 0,pivoty = 0;
                double pivot_y1 = 0, pivot_y2 = 0;
                //find pivot
                if (pointy[0] < pointycrop[1])
                {
                    pivot_y1 = pointycrop[0];
                }
                else if(pointy[0] == pointycrop[1])
                {
                    pivot_y1 = pointycrop[0];
                }
                else if (pointy[0] > pointycrop[1])
                {
                    pivot_y1 = pointycrop[1];
                }
                //x2.............................
                if (pointy[35] < pointycrop[36])
                {
                    pivot_y2 = pointycrop[36];
                }
                else if (pointycrop[35] == pointycrop[36])
                {
                    pivot_y2 = pointycrop[35];
                }
                else if(pointycrop[35] > pointycrop[36])
                {
                    pivot_y2 = pointycrop[35];
                }
                pivoty = (pivot_y2 + pivot_y1) /2 ;
                //finish y................
                pivotx = (pointxcrop[18] + pointxcrop[15]) /2 ;
                Console.WriteLine(pivotx);
                Console.WriteLine(pivoty);
                //finish find pivot
                //Rotate 180 degree
                for (int rotate = 0; rotate < 37; rotate++)
                {
                    pointxcrop[rotate] = ((pointxcrop[rotate] - pivotx) * (-1))  + pivotx;
                    pointycrop[rotate] = ((pointycrop[rotate] - pivoty) * (-1)) + pivoty;
                }
                //finish rotate 180 degree
                //yes...                

                string path = "../PointFaceCGL" + faceInt + ".txt";
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        for (int k = 0; k <= 36; k++)
                        {
                            sw.Write(pointxcrop[k] + " " + pointycrop[k] + "\n");
                        }
                        sw.Close();
                    }
                    Console.WriteLine("File create!!!!");
                }
                MessageBox.Show("Save To PointFaceCGL" + faceInt);
                Invalidate(true);

            }
            else if (result == DialogResult.No)
            {
                //no...
            }
        }      

        private void Select_Crop_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image img = Image.FromFile(open.FileName);
                pictureBox2.Image = img;
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            double[] differencex = new double[37];
            double[] differencey = new double[37];
            double holdx = 8, holdy = 8;

            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i <= 36; i++) //calculate difference X,Y all point
                {
                    differencex[i] = Math.Abs(e.X - pointxcrop[i]);
                    differencey[i] = Math.Abs(e.Y - pointycrop[i]);
                }

                for (int i = 0; i <= 36; i++) //loop search point near mouse
                {
                    if (differencex[i] < holdx && differencey[i] < holdy)
                    {
                        holdx = differencex[i];
                        holdy = differencey[i];
                        pointmove = i;
                        Console.WriteLine("Point" + pointmove);
                        //finish search pointmove
                    }
                    //finish condition search pointmove
                }
                //end loop search pointmove
                Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //pointmove
                MouseDownLocation = e.Location;
                CroprecStore[pointmove] = new Rectangle(e.X, e.Y, 10, 10);
                pointxcrop[pointmove] = e.X;
                pointycrop[pointmove] = e.Y;
                Console.WriteLine("Point" + pointmove + "X = " + MouseDownLocation.X);
                Console.WriteLine("Point" + pointmove + "Y = " + MouseDownLocation.Y);
                Invalidate(true);
                //finish pointmove
            }
        }
    }
}
