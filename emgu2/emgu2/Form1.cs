using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emgu2
{
    public partial class Form1 : Form
    {
        public static int[] pointx ={
            122,594,238,440,176,
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
        public int pointmove;
        private Point MouseDownLocation;
        //Rectangle rect { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;            
        }

        Rectangle rec0 = new Rectangle(pointx[0] - 8, pointy[0] - 8, 12, 12);
        Rectangle rec1 = new Rectangle(pointx[1] - 8, pointy[1] - 8, 12, 12);
        Rectangle rec2 = new Rectangle(pointx[2] - 8, pointy[2] - 8, 12, 12);
        Rectangle rec3 = new Rectangle(pointx[3] - 8, pointy[3] - 8, 12, 12);
        Rectangle rec4 = new Rectangle(pointx[4] - 8, pointy[4] - 8, 12, 12);
        Rectangle rec5 = new Rectangle(pointx[5] - 8, pointy[5] - 8, 12, 12);
        Rectangle rec6 = new Rectangle(pointx[6] - 8, pointy[6] - 8, 12, 12);
        Rectangle rec7 = new Rectangle(pointx[7] - 8, pointy[7] - 8, 12, 12);
        Rectangle rec8 = new Rectangle(pointx[8] - 8, pointy[8] - 8, 12, 12);
        Rectangle rec9 = new Rectangle(pointx[9] - 8, pointy[9] - 8, 12, 12);
        Rectangle rec10 = new Rectangle(pointx[10] - 8, pointy[10] - 8, 12, 12);
        Rectangle rec11 = new Rectangle(pointx[11] - 8, pointy[11] - 8, 12, 12);
        Rectangle rec12 = new Rectangle(pointx[12] - 8, pointy[12] - 8, 12, 12);
        Rectangle rec13 = new Rectangle(pointx[13] - 8, pointy[13] - 8, 12, 12);
        Rectangle rec14 = new Rectangle(pointx[14] - 8, pointy[14] - 8, 12, 12);
        Rectangle rec15 = new Rectangle(pointx[15] - 8, pointy[15] - 8, 12, 12);
        Rectangle rec16 = new Rectangle(pointx[16] - 8, pointy[16] - 8, 12, 12);
        Rectangle rec17 = new Rectangle(pointx[17] - 8, pointy[17] - 8, 12, 12);
        Rectangle rec18 = new Rectangle(pointx[18] - 8, pointy[18] - 8, 12, 12);
        Rectangle rec19 = new Rectangle(pointx[19] - 8, pointy[19] - 8, 12, 12);
        Rectangle rec20 = new Rectangle(pointx[20] - 8, pointy[20] - 8, 12, 12);
        Rectangle rec21 = new Rectangle(pointx[21] - 8, pointy[21] - 8, 12, 12);
        Rectangle rec22 = new Rectangle(pointx[22] - 8, pointy[22] - 8, 12, 12);
        Rectangle rec23 = new Rectangle(pointx[23] - 8, pointy[23] - 8, 12, 12);
        Rectangle rec24 = new Rectangle(pointx[24] - 8, pointy[24] - 8, 12, 12);
        Rectangle rec25 = new Rectangle(pointx[25] - 8, pointy[25] - 8, 12, 12);
        Rectangle rec26 = new Rectangle(pointx[26] - 8, pointy[26] - 8, 12, 12);
        Rectangle rec27 = new Rectangle(pointx[27] - 8, pointy[27] - 8, 12, 12);
        Rectangle rec28 = new Rectangle(pointx[28] - 8, pointy[28] - 8, 12, 12);
        Rectangle rec29 = new Rectangle(pointx[29] - 8, pointy[29] - 8, 12, 12);
        Rectangle rec30 = new Rectangle(pointx[30] - 8, pointy[30] - 8, 12, 12);
        Rectangle rec31 = new Rectangle(pointx[31] - 8, pointy[31] - 8, 12, 12);
        Rectangle rec32 = new Rectangle(pointx[32] - 8, pointy[32] - 8, 12, 12);
        Rectangle rec33 = new Rectangle(pointx[33] - 8, pointy[33] - 8, 12, 12);
        Rectangle rec34 = new Rectangle(pointx[34] - 8, pointy[34] - 8, 12, 12);
        Rectangle rec35 = new Rectangle(pointx[35] - 8, pointy[35] - 8, 12, 12);
        Rectangle rec36 = new Rectangle(pointx[36] - 8, pointy[36] - 8, 12, 12);

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, rec0);
            e.Graphics.FillEllipse(Brushes.Red, rec1);
            e.Graphics.FillEllipse(Brushes.Red, rec2);
            e.Graphics.FillEllipse(Brushes.Red, rec3);
            e.Graphics.FillEllipse(Brushes.Red, rec4);
            e.Graphics.FillEllipse(Brushes.Red, rec5);
            e.Graphics.FillEllipse(Brushes.Red, rec6);
            e.Graphics.FillEllipse(Brushes.Red, rec7);
            e.Graphics.FillEllipse(Brushes.Red, rec8);
            e.Graphics.FillEllipse(Brushes.Red, rec9);
            e.Graphics.FillEllipse(Brushes.Red, rec10);
            e.Graphics.FillEllipse(Brushes.Red, rec11);
            e.Graphics.FillEllipse(Brushes.Red, rec12);
            e.Graphics.FillEllipse(Brushes.Red, rec13);
            e.Graphics.FillEllipse(Brushes.Red, rec14);
            e.Graphics.FillEllipse(Brushes.Red, rec15);
            e.Graphics.FillEllipse(Brushes.Red, rec16);
            e.Graphics.FillEllipse(Brushes.Red, rec17);
            e.Graphics.FillEllipse(Brushes.Red, rec18);
            e.Graphics.FillEllipse(Brushes.Red, rec19);
            e.Graphics.FillEllipse(Brushes.Red, rec20);
            e.Graphics.FillEllipse(Brushes.Red, rec21);
            e.Graphics.FillEllipse(Brushes.Red, rec22);
            e.Graphics.FillEllipse(Brushes.Red, rec23);
            e.Graphics.FillEllipse(Brushes.Red, rec24);
            e.Graphics.FillEllipse(Brushes.Red, rec25);
            e.Graphics.FillEllipse(Brushes.Red, rec26);
            e.Graphics.FillEllipse(Brushes.Red, rec27);
            e.Graphics.FillEllipse(Brushes.Red, rec28);
            e.Graphics.FillEllipse(Brushes.Red, rec29);
            e.Graphics.FillEllipse(Brushes.Red, rec30);
            e.Graphics.FillEllipse(Brushes.Red, rec31);
            e.Graphics.FillEllipse(Brushes.Red, rec32);
            e.Graphics.FillEllipse(Brushes.Red, rec33);
            e.Graphics.FillEllipse(Brushes.Red, rec34);
            e.Graphics.FillEllipse(Brushes.Red, rec35);
            e.Graphics.FillEllipse(Brushes.Red, rec36);
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
                    differencex[i] = e.X - pointx[i];
                    differencey[i] = e.Y - pointy[i];
                }

                for (int i = 0; i <= 36; i++) //loop search point near mouse
                {
                    if (differencex[i] < holdx && differencey[i] < holdy)
                    {
                        holdx = differencex[i];
                        holdy = differencey[i];
                        pointmove = i;
                        Console.WriteLine("Point" + pointmove);
                        break;
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
                //select pointmove 
                if (pointmove == 0)
                {
                    rec0 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    Console.WriteLine("Point0 = " + MouseDownLocation.X);
                    Console.WriteLine("Point0 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 1)
                {
                    rec1 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    Invalidate();
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point1 = " + MouseDownLocation.X);
                    Console.WriteLine("Point1 = " + MouseDownLocation.Y);
                }
                if (pointmove == 2)
                {
                    rec2 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    Console.WriteLine("Point2 = " + MouseDownLocation.X);
                    Console.WriteLine("Point2 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 3)
                {
                    rec3 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    Invalidate();
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point3 = " + MouseDownLocation.X);
                    Console.WriteLine("Point3 = " + MouseDownLocation.Y);
                }
                if (pointmove == 4)
                {
                    rec4 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    Console.WriteLine("Point4 = " + MouseDownLocation.X);
                    Console.WriteLine("Point4 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 5)
                {
                    rec5 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point5 = " + MouseDownLocation.X);
                    Console.WriteLine("Point5 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 6)
                {
                    rec6 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    Console.WriteLine("Point6 = " + MouseDownLocation.X);
                    Console.WriteLine("Point6 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 7)
                {
                    rec7 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point7 = " + MouseDownLocation.X);
                    Console.WriteLine("Point7 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 8)
                {
                    rec8 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    Console.WriteLine("Point8 = " + MouseDownLocation.X);
                    Console.WriteLine("Point8 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 9)
                {
                    rec9 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point9 = " + MouseDownLocation.X);
                    Console.WriteLine("Point9 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 10)
                {
                    rec10 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point10 = " + MouseDownLocation.X);
                    Console.WriteLine("Point10 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 11)
                {
                    rec11 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point11 = " + MouseDownLocation.X);
                    Console.WriteLine("Point11 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 12)
                {
                    rec12 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point12 = " + MouseDownLocation.X);
                    Console.WriteLine("Point12 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 13)
                {
                    rec13 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point13 = " + MouseDownLocation.X);
                    Console.WriteLine("Point13 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 14)
                {
                    rec14 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point14 = " + MouseDownLocation.X);
                    Console.WriteLine("Point14 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 15)
                {
                    rec15 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point15 = " + MouseDownLocation.X);
                    Console.WriteLine("Point15 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 16)
                {
                    rec16 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point16 = " + MouseDownLocation.X);
                    Console.WriteLine("Point16 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 17)
                {
                    rec17 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point17 = " + MouseDownLocation.X);
                    Console.WriteLine("Point17 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 18)
                {
                    rec18 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point18 = " + MouseDownLocation.X);
                    Console.WriteLine("Point18 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 19)
                {
                    rec19 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point19 = " + MouseDownLocation.X);
                    Console.WriteLine("Point19 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 20)
                {
                    rec20 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point20 = " + MouseDownLocation.X);
                    Console.WriteLine("Point20 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 21)
                {
                    rec21 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point21 = " + MouseDownLocation.X);
                    Console.WriteLine("Point21 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 22)
                {
                    rec22 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point22 = " + MouseDownLocation.X);
                    Console.WriteLine("Point22 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 23)
                {
                    rec23 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point23 = " + MouseDownLocation.X);
                    Console.WriteLine("Point23 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 24)
                {
                    rec24 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point24 = " + MouseDownLocation.X);
                    Console.WriteLine("Point24 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 25)
                {
                    rec25 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point25 = " + MouseDownLocation.X);
                    Console.WriteLine("Point25 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 26)
                {
                    rec26 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point26 = " + MouseDownLocation.X);
                    Console.WriteLine("Point26 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 27)
                {
                    rec27 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point27 = " + MouseDownLocation.X);
                    Console.WriteLine("Point27 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 28)
                {
                    rec28 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point28 = " + MouseDownLocation.X);
                    Console.WriteLine("Point28 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 29)
                {
                    rec29 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point29 = " + MouseDownLocation.X);
                    Console.WriteLine("Point29 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 30)
                {
                    rec30 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point30 = " + MouseDownLocation.X);
                    Console.WriteLine("Point30 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 31)
                {
                    rec31 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point31 = " + MouseDownLocation.X);
                    Console.WriteLine("Point31 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 32)
                {
                    rec32 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point32 = " + MouseDownLocation.X);
                    Console.WriteLine("Point32 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 33)
                {
                    rec33 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point33 = " + MouseDownLocation.X);
                    Console.WriteLine("Point33 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 34)
                {
                    rec34 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point34 = " + MouseDownLocation.X);
                    Console.WriteLine("Point34 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 35)
                {
                    rec35 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point35 = " + MouseDownLocation.X);
                    Console.WriteLine("Point35 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                if (pointmove == 36)
                {
                    rec36 = new Rectangle(e.X - 6, e.Y - 6, 12, 12);
                    MouseDownLocation = e.Location;
                    Console.WriteLine("Point36 = " + MouseDownLocation.X);
                    Console.WriteLine("Point36 = " + MouseDownLocation.Y);
                    Invalidate();
                }
                //finish pointmove
            }

            if (e.Button == MouseButtons.Right)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }
    }
}
