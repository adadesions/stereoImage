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

namespace emgu2
{

    public partial class Form1 : Form
    {
        public class InitialPoint
        {
            public int[] PointX { get; set; }
            public int[] PointY { get; set; }
            public int[] PointZ { get; set; }
    }

        public class PointOnFace
        {
            public int Face { get; set; }
            public int[] PointX { get; set; }
            public int[] PointY { get; set; }
            public int[] PointZ { get; set; }
        }
        static string json = File.ReadAllText("../initialpoint.json");
        static InitialPoint init = JsonConvert.DeserializeObject<InitialPoint>(json);
        //Console.WriteLine(init.PointX[0]);

        public static int[] pointx = init.PointX;
        public static int[] pointy = init.PointY;

        public int pointmove; //ตัวแปรกำหนดค่าว่าจุดไหนจะขยับตามเม้า
        private Point MouseDownLocation;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true; //ใช้กับการลากจุด
        }

        Rectangle[] recStore = new Rectangle[37];

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 37; i++)
            {
                recStore[i] = new Rectangle((pointx[i]), (pointy[i]), 10, 10);
                e.Graphics.FillEllipse(Brushes.Red, recStore[i]);
            }
            Update(); //ลื่น ใช้กับจุดขยับตามเม้า
            //Refresh(); //ตรงนี้ทำให้หน่วงและทำให้จุดขยับตามเม้าได้
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int[] differencex = new int[37];
            int[] differencey = new int[37];
            int holdx = 8, holdy = 8;

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

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void save_MouseDown(object sender, MouseEventArgs e) //save json
        {
            if (e.Button == MouseButtons.Left)
            {
                decimal value = (numericUpDown1.Value); //ค่าเลือก หมายเลขหน้า
                int faceInt = decimal.ToInt32(value); //แปลงเป็น int
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
            }//end if buttonleft
        }//finish function save
        
        private void button2_Click(object sender, EventArgs e) //Select Image
        {
            OpenFileDialog open = new OpenFileDialog();
                if(open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image img = Image.FromFile(open.FileName);               
                pictureBox1.Image = img;
              
                //Console.WriteLine(pictureBox1.ImageLocation);
                //string result;

                //result = Path.GetFileName(filepath);
            }
        }

        private void save_txt_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                decimal value = (numericUpDown1.Value); //ค่าเลือก หมายเลขหน้า
                int faceInt = decimal.ToInt32(value); //แปลงเป็น int
                string face = faceInt.ToString();
                PointOnFace updatepoint = new PointOnFace();
                updatepoint.Face = faceInt;
                updatepoint.PointX = pointx;
                updatepoint.PointY = pointy;
                //updatepoint.PointZ = pointz;
                //string path = @"C:\emgu2\face" + face + ".txt";
                string path = "../PointFace" + faceInt + ".txt";           
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
            }//end if buttonleft
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
    }//finish class
}
