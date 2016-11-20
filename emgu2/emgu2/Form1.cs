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

namespace emgu2
{
    public partial class Form1 : Form
    {
        //public struct Pointonface
        //{
        //    public Pointonface(int[] f1, int[] x1, int[] y1, int[] z1)
        //    {
        //        face = f1;
        //        x = x1;
        //        y = y1;
        //        z = z1;
        //    }
        //    public int[] face;
        //    public int[] x;
        //    public int[] y;
        //    public int[] z;
        //}
        //public Pointonface point = new Pointonface(new int[37], new int[37], new int[37], new int[37]);

        //    point.face[0] = "1";
        //    point.x[0] = 121;
        //    point.y[0] = 51;
        //    point.z[0] = 0;


        public static int[] pointx ={
            275,
            481,303,445,221,279,
            471,535,303,459,293,
            463,295,380,458,205,
            246,511,555,341,381,
            420,312,447,361,385,
            409,274,321,449,486,
            356,383,412,382,348,
            417};
        public static int[] pointy ={
            123,
            118,149,146,208,187,
            183,201,217,211,233,
            234,257,246,259,313,
            280,279,314,313,302,
            315,338,337,370,375,
            369,389,391,391,391,
            407,408,407,431,486,
            485};

        /*
                public static int[] pointx ={
                    82,594,238,440,176,
                    266,441,536,230,477,
                    235,475,231,354,479,
                    96,165,551,615,305,
                    354,400,281,422,292,
                    352,410,202,257,450,
                    505,298,352,410,352,
                    285,421};

                public static int[] pointy = {
                    58, 51,101,101,198,
                    201,201,201,254,254,
                    296,296,354,345,354,
                    381,395,395,381,460,
                    460,460,486,486,556,
                    550,556,573,582,582,
                    575,610,618,610,670,
                    707,707};
        */

        public int pointmove;
        private Point MouseDownLocation;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        Rectangle[] recStore = new Rectangle[37];

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 37; i++)
            {
                //updatex[i] = (pointx[i] * 80) / 100;
                //updatey[i] = (pointy[i] * 65) / 100;
                recStore[i] = new Rectangle((pointx[i]), (pointy[i]), 8, 8);
                e.Graphics.FillEllipse(Brushes.Red, recStore[i]);
            }
            Update();
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
                        //break;
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
                recStore[pointmove] = new Rectangle(e.X, e.Y, 8, 8);
                pointx[pointmove] = e.X;
                pointy[pointmove] = e.Y;
                Console.WriteLine("Point" + pointmove + "X = " + MouseDownLocation.X);
                Console.WriteLine("Point" + pointmove + "Y = " + MouseDownLocation.Y);
                Invalidate(true);
                //finish pointmove
            }
        }

        private void save_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                decimal value = (numericUpDown1.Value);
                int faceInt= decimal.ToInt32(value);
                string face = faceInt.ToString();
                Console.WriteLine("face "+face);
                //Object selectedItem = comboBox1.SelectedItem;   
                    string path = @"C:\emgu2\face" + face + ".txt";
                    InitializeComponent();

                    if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("public static int[] pointx ={");
                            sw.WriteLine(/*updatex[0]*/pointx[0] + ",");
                            for (int k = 1; k <= 35; k++)
                            {
                                sw.Write(/*updatex[k]*/pointx[k] + ",");
                                if (k % 5 == 0 && k > 0)
                                {
                                    sw.WriteLine();
                                }
                            }
                            sw.Write(/*updatex[36]*/pointx[36]);
                            sw.WriteLine("};");
                            sw.WriteLine("public static int[] pointy ={");
                            sw.WriteLine(/*updatey[0]*/pointy[0] + ",");
                            for (int k = 1; k <= 35; k++)
                            {
                                sw.Write(/*updatey[k]*/pointy[k] + ",");
                                if (k % 5 == 0 && k > 0)
                                {
                                    sw.WriteLine();
                                }
                            }
                            sw.Write(/*updatey[36]*/pointy[36]);
                            sw.WriteLine("};");
                            sw.Close();
                        }
                        Console.WriteLine("File create!!!!");
                    }
                    else
                    {
                        File.Delete(path);
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("public static int[] pointx ={");
                            sw.WriteLine(pointx[0] + ",");
                            for (int k = 1; k <= 35; k++)
                            {
                                sw.Write(pointx[k] + ",");
                                if (k % 5 == 0 && k > 0)
                                {
                                    sw.WriteLine();
                                }
                            }
                            sw.Write(pointx[36]);
                            sw.WriteLine("};");
                            sw.WriteLine("public static int[] pointy ={");
                            sw.WriteLine(pointy[0] + ",");
                            for (int k = 1; k <= 35; k++)
                            {
                                sw.Write(pointy[k] + ",");
                                if (k % 5 == 0 && k > 0)
                                {
                                    sw.WriteLine();
                                }
                            }
                            sw.Write(pointy[36]);
                            sw.WriteLine("};");
                            sw.Close();
                        }
                        Console.WriteLine("File update!!!!");
                    }//finish else create file
            }//end if buttonleft
        }//finish function save
    }//finish class
}
