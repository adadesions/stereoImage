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

namespace FindZ
{
    public partial class Form1 : Form
    {
        public class InitialPoint
        {
            public int Face { get; set; }
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

        public static int face = init.Face;
        public static int[] pointx = init.PointX;
        public static int[] pointy = init.PointY;
        public static int[] pointz = init.PointZ;

        public Form1()
        {
            InitializeComponent();
        }

        Rectangle[] recStore = new Rectangle[37];

        private void LoadPoint_Click(object sender, EventArgs e)
        {
            
            decimal value = (numericUpDown1.Value); //ค่าเลือก หมายเลขหน้า
            int faceInt = decimal.ToInt32(value); //แปลงเป็น int            
            bool checkfile = File.Exists("../PointFace" + faceInt + ".json");
            Console.WriteLine(checkfile);
            if(checkfile == true)
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

        private void imageBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 37; i++)
            {
                recStore[i] = new Rectangle((pointx[i]), (pointy[i]), 10, 10);
                e.Graphics.FillEllipse(Brushes.Red, recStore[i]);
            }            
        }

        private void UpdateZ_Click(object sender, EventArgs e)
        {
            decimal value = (numericUpDown2.Value); //ค่าเลือก หมายเลขหน้า
            DialogResult result = MessageBox.Show("Update To "+value, "UpdateZ", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...
                String[] textz = new String[37];
                textz[0] = textBox1.Text;
                textz[1] = textBox2.Text;
                textz[2] = textBox3.Text;
                textz[3] = textBox4.Text;
                textz[4] = textBox5.Text;
                textz[5] = textBox6.Text;
                textz[6] = textBox7.Text;
                textz[7] = textBox8.Text;
                textz[8] = textBox9.Text;
                textz[9] = textBox10.Text;
                textz[10] = textBox11.Text;
                textz[11] = textBox12.Text;
                textz[12] = textBox13.Text;
                textz[13] = textBox14.Text;
                textz[14] = textBox15.Text;
                textz[15] = textBox16.Text;
                textz[16] = textBox17.Text;
                textz[17] = textBox18.Text;
                textz[18] = textBox19.Text;
                textz[19] = textBox20.Text;
                textz[20] = textBox21.Text;
                textz[21] = textBox22.Text;
                textz[22] = textBox23.Text;
                textz[23] = textBox24.Text;
                textz[24] = textBox25.Text;
                textz[25] = textBox26.Text;
                textz[26] = textBox27.Text;
                textz[27] = textBox28.Text;
                textz[28] = textBox29.Text;
                textz[29] = textBox30.Text;
                textz[30] = textBox31.Text;
                textz[31] = textBox32.Text;
                textz[32] = textBox33.Text;
                textz[33] = textBox34.Text;
                textz[34] = textBox35.Text;
                textz[35] = textBox36.Text;
                textz[36] = textBox37.Text;
                int[] numZ = new int[37];
                for (int k = 0; k < 37; k++)
                {
                    numZ[k] = Int32.Parse(textz[k]);
                }
                //decimal value = (numericUpDown2.Value); //ค่าเลือก หมายเลขหน้า
                int faceInt = decimal.ToInt32(value); //แปลงเป็น int
                string face = faceInt.ToString();
                PointOnFace updatepoint = new PointOnFace();
                updatepoint.Face = faceInt;
                updatepoint.PointX = pointx;
                updatepoint.PointY = pointy;
                updatepoint.PointZ = numZ;

                string json = JsonConvert.SerializeObject(updatepoint);

                //write string to file
                System.IO.File.WriteAllText("../PointFace" + faceInt + ".json", json);
                //save to emgu2\bin\
                Console.WriteLine("File Update!!!!");
                MessageBox.Show("Save To Face" + faceInt);
                Invalidate(true);
            }
            else if (result == DialogResult.No)
            {
                //no...
            }
            
        }

        private void Cleartext_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure", "Clear Text", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                textBox6.Text = string.Empty;
                textBox7.Text = string.Empty;
                textBox8.Text = string.Empty;
                textBox9.Text = string.Empty;
                textBox10.Text = string.Empty;
                textBox11.Text = string.Empty;
                textBox12.Text = string.Empty;
                textBox13.Text = string.Empty;
                textBox14.Text = string.Empty;
                textBox15.Text = string.Empty;
                textBox16.Text = string.Empty;
                textBox17.Text = string.Empty;
                textBox18.Text = string.Empty;
                textBox19.Text = string.Empty;
                textBox20.Text = string.Empty;
                textBox21.Text = string.Empty;
                textBox22.Text = string.Empty;
                textBox23.Text = string.Empty;
                textBox24.Text = string.Empty;
                textBox25.Text = string.Empty;
                textBox26.Text = string.Empty;
                textBox27.Text = string.Empty;
                textBox28.Text = string.Empty;
                textBox29.Text = string.Empty;
                textBox30.Text = string.Empty;
                textBox31.Text = string.Empty;
                textBox32.Text = string.Empty;
                textBox33.Text = string.Empty;
                textBox34.Text = string.Empty;
                textBox35.Text = string.Empty;
                textBox36.Text = string.Empty;
                textBox37.Text = string.Empty;
                Invalidate(true);
            }
            else if (result == DialogResult.No)
            {
                //no...
            }            
        }
    }
}
