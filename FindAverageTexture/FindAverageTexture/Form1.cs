using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using Newtonsoft.Json;

namespace FindAverageTexture
{
    public partial class Form1 : Form
    {
        public struct Triangle{
            public int x1 { get; set; }
            public int x2 { get; set; }
            public int x3 { get; set; }
            public int y1 { get; set; }
            public int y2 { get; set; }
            public int y3 { get; set; }
        }

        public class Pixel
        {
            public int[][] pixel { get; set; }
        }
        public class InitialPoint
        {
            public int Face { get; set; }
            public int[] PointX { get; set; }
            public int[] PointY { get; set; }
            public int[] PointZ { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
            
        }

        static string json = File.ReadAllText("../initialpoint.json");
        static InitialPoint init = JsonConvert.DeserializeObject<InitialPoint>(json);

        public static int face = init.Face;
        public static int[] pointx = init.PointX;
        public static int[] pointy = init.PointY;
        public static int[] pointz = init.PointZ;

        Triangle[] Triangles = new Triangle[62];
        int[] average = new int[129575]; // 355*365=129,575
        int[][] temppixel = new int[355][];

        public void PrepareTraiangle()
        {
            
            decimal value = (numericUpDown1.Value); //ค่าเลือก หมายเลขหน้า
            int faceInt = decimal.ToInt32(value); //แปลงเป็น int
            string json = File.ReadAllText("../PointFaceC" + faceInt + ".json");
            InitialPoint init = JsonConvert.DeserializeObject<InitialPoint>(json);

            Triangles[0].x1 = init.PointX[0];
            Triangles[0].y1 = init.PointY[0]; //p1
            Triangles[0].x2 = init.PointX[4];
            Triangles[0].y2 = init.PointY[4];//p2
            Triangles[0].x3 = init.PointX[5];
            Triangles[0].y3 = init.PointY[5];//p3

            Triangles[1].x1 = init.PointX[0];
            Triangles[1].y1 = init.PointY[0];//p1
            Triangles[1].x2 = init.PointX[2];
            Triangles[1].y2 = init.PointY[2];//p2
            Triangles[1].x3 = init.PointX[5];
            Triangles[1].y3 = init.PointY[5];//p3

            Triangles[2].x1 = init.PointX[0];
            Triangles[2].y1 = init.PointY[0];//p1
            Triangles[2].x2 = init.PointX[2];
            Triangles[2].y2 = init.PointY[2];//p2
            Triangles[2].x3 = init.PointX[3];
            Triangles[2].y3 = init.PointY[3];//p3

            Triangles[3].x1 = init.PointX[0];
            Triangles[3].y1 = init.PointY[0];//p1
            Triangles[3].x2 = init.PointX[1];
            Triangles[3].y2 = init.PointY[1];//p2
            Triangles[3].x3 = init.PointX[3];
            Triangles[3].y3 = init.PointY[3];//p3

            Triangles[4].x1 = init.PointX[1];
            Triangles[4].y1 = init.PointY[1];//p1
            Triangles[4].x2 = init.PointX[3];
            Triangles[4].y2 = init.PointY[3];//p2
            Triangles[4].x3 = init.PointX[6];
            Triangles[4].y3 = init.PointY[6];//p3

            Triangles[5].x1 = init.PointX[1];
            Triangles[5].y1 = init.PointY[1];//p1
            Triangles[5].x2 = init.PointX[6];
            Triangles[5].y2 = init.PointY[6];//p2
            Triangles[5].x3 = init.PointX[7];
            Triangles[5].y3 = init.PointY[7];//p3

            Triangles[6].x1 = init.PointX[4];
            Triangles[6].y1 = init.PointY[4];//p1
            Triangles[6].x2 = init.PointX[5];
            Triangles[6].y2 = init.PointY[5];//p2
            Triangles[6].x3 = init.PointX[8];
            Triangles[6].y3 = init.PointY[8];//p3

            Triangles[7].x1 = init.PointX[5];
            Triangles[7].y1 = init.PointY[5];//p1
            Triangles[7].x2 = init.PointX[2];
            Triangles[7].y2 = init.PointY[2];//p2
            Triangles[7].x3 = init.PointX[13];
            Triangles[7].y3 = init.PointY[13];//p3

            Triangles[8].x1 = init.PointX[2];
            Triangles[8].y1 = init.PointY[2];//p1
            Triangles[8].x2 = init.PointX[3];
            Triangles[8].y2 = init.PointY[3];//p2
            Triangles[8].x3 = init.PointX[13];
            Triangles[8].y3 = init.PointY[13];//p3

            Triangles[9].x1 = init.PointX[3];
            Triangles[9].y1 = init.PointY[3];//p1
            Triangles[9].x2 = init.PointX[6];
            Triangles[9].y2 = init.PointY[6];//p2
            Triangles[9].x3 = init.PointX[13];
            Triangles[9].y3 = init.PointY[13];//p3

            Triangles[10].x1 = init.PointX[6];
            Triangles[10].y1 = init.PointY[6];//p1
            Triangles[10].x2 = init.PointX[7];
            Triangles[10].y2 = init.PointY[7];//p2
            Triangles[10].x3 = init.PointX[9];
            Triangles[10].y3 = init.PointY[9];//p3

            Triangles[11].x1 = init.PointX[5];
            Triangles[11].y1 = init.PointY[5];//p1
            Triangles[11].x2 = init.PointX[8];
            Triangles[11].y2 = init.PointY[8];//p2
            Triangles[11].x3 = init.PointX[13];
            Triangles[11].y3 = init.PointY[13];//p3

            Triangles[12].x1 = init.PointX[6];
            Triangles[12].y1 = init.PointY[6];//p1
            Triangles[12].x2 = init.PointX[9];
            Triangles[12].y2 = init.PointY[9];//p2
            Triangles[12].x3 = init.PointX[13];
            Triangles[12].y3 = init.PointY[13];//p3

            Triangles[13].x1 = init.PointX[4];
            Triangles[13].y1 = init.PointY[4];//p1
            Triangles[13].x2 = init.PointX[8];
            Triangles[13].y2 = init.PointY[8];//p2
            Triangles[13].x3 = init.PointX[10];
            Triangles[13].y3 = init.PointY[10];//p3

            Triangles[14].x1 = init.PointX[8];
            Triangles[14].y1 = init.PointY[8];//p1
            Triangles[14].x2 = init.PointX[10];
            Triangles[14].y2 = init.PointY[10];//p2
            Triangles[14].x3 = init.PointX[13];
            Triangles[14].y3 = init.PointY[13];//p3

            Triangles[15].x1 = init.PointX[9];
            Triangles[15].y1 = init.PointY[9];//p1
            Triangles[15].x2 = init.PointX[11];
            Triangles[15].y2 = init.PointY[11];//p2
            Triangles[15].x3 = init.PointX[13];
            Triangles[15].y3 = init.PointY[13];//p3

            Triangles[16].x1 = init.PointX[9];
            Triangles[16].y1 = init.PointY[9];//p1
            Triangles[16].x2 = init.PointX[11];
            Triangles[16].y2 = init.PointY[11];//p2
            Triangles[16].x3 = init.PointX[7];
            Triangles[16].y3 = init.PointY[7];//p3

            Triangles[17].x1 = init.PointX[4];
            Triangles[17].y1 = init.PointY[4];//p1
            Triangles[17].x2 = init.PointX[15];
            Triangles[17].y2 = init.PointY[15];//p2
            Triangles[17].x3 = init.PointX[12];
            Triangles[17].y3 = init.PointY[12];//p3

            Triangles[18].x1 = init.PointX[4];
            Triangles[18].y1 = init.PointY[4];//p1
            Triangles[18].x2 = init.PointX[10];
            Triangles[18].y2 = init.PointY[10];//p2
            Triangles[18].x3 = init.PointX[12];
            Triangles[18].y3 = init.PointY[12];//p3

            Triangles[19].x1 = init.PointX[10];
            Triangles[19].y1 = init.PointY[10];//p1
            Triangles[19].x2 = init.PointX[12];
            Triangles[19].y2 = init.PointY[12];//p2
            Triangles[19].x3 = init.PointX[13];
            Triangles[19].y3 = init.PointY[13];//p3

            Triangles[20].x1 = init.PointX[11];
            Triangles[20].y1 = init.PointY[11];//p1
            Triangles[20].x2 = init.PointX[13];
            Triangles[20].y2 = init.PointY[13];//p2
            Triangles[20].x3 = init.PointX[14];
            Triangles[20].y3 = init.PointY[14];//p3

            Triangles[21].x1 = init.PointX[11];
            Triangles[21].y1 = init.PointY[11];//p1
            Triangles[21].x2 = init.PointX[14];
            Triangles[21].y2 = init.PointY[14];//p2
            Triangles[21].x3 = init.PointX[18];
            Triangles[21].y3 = init.PointY[18];//p3

            Triangles[22].x1 = init.PointX[7];
            Triangles[22].y1 = init.PointY[7];//p1
            Triangles[22].x2 = init.PointX[11];
            Triangles[22].y2 = init.PointY[11];//p2
            Triangles[22].x3 = init.PointX[18];
            Triangles[22].y3 = init.PointY[18];//p3

            Triangles[23].x1 = init.PointX[12];
            Triangles[23].y1 = init.PointY[12];//p1
            Triangles[23].x2 = init.PointX[15];
            Triangles[23].y2 = init.PointY[15];//p2
            Triangles[23].x3 = init.PointX[16];
            Triangles[23].y3 = init.PointY[16];//p3

            Triangles[24].x1 = init.PointX[12];
            Triangles[24].y1 = init.PointY[12];//p1
            Triangles[24].x2 = init.PointX[16];
            Triangles[24].y2 = init.PointY[16];//p2
            Triangles[24].x3 = init.PointX[22];
            Triangles[24].y3 = init.PointY[22];//p3

            Triangles[25].x1 = init.PointX[12];
            Triangles[25].y1 = init.PointY[12];//p1
            Triangles[25].x2 = init.PointX[19];
            Triangles[25].y2 = init.PointY[19];//p2
            Triangles[25].x3 = init.PointX[22];
            Triangles[25].y3 = init.PointY[22];//p3

            Triangles[26].x1 = init.PointX[12];
            Triangles[26].y1 = init.PointY[12];//p1
            Triangles[26].x2 = init.PointX[13];
            Triangles[26].y2 = init.PointY[13];//p2
            Triangles[26].x3 = init.PointX[19];
            Triangles[26].y3 = init.PointY[19];//p3

            Triangles[27].x1 = init.PointX[13];
            Triangles[27].y1 = init.PointY[13];//p1
            Triangles[27].x2 = init.PointX[19];
            Triangles[27].y2 = init.PointY[19];//p2
            Triangles[27].x3 = init.PointX[20];
            Triangles[27].y3 = init.PointY[20];//p3

            Triangles[28].x1 = init.PointX[13];
            Triangles[28].y1 = init.PointY[13];//p1
            Triangles[28].x2 = init.PointX[20];
            Triangles[28].y2 = init.PointY[20];//p2
            Triangles[28].x3 = init.PointX[21];
            Triangles[28].y3 = init.PointY[21];//p3

            Triangles[29].x1 = init.PointX[13];
            Triangles[29].y1 = init.PointY[13];//p1
            Triangles[29].x2 = init.PointX[14];
            Triangles[29].y2 = init.PointY[14];//p2
            Triangles[29].x3 = init.PointX[21];
            Triangles[29].y3 = init.PointY[21];//p3

            Triangles[30].x1 = init.PointX[14];
            Triangles[30].y1 = init.PointY[14];//p1
            Triangles[30].x2 = init.PointX[21];
            Triangles[30].y2 = init.PointY[21];//p2
            Triangles[30].x3 = init.PointX[17];
            Triangles[30].y3 = init.PointY[17];//p3

            Triangles[31].x1 = init.PointX[14];
            Triangles[31].y1 = init.PointY[14];//p1
            Triangles[31].x2 = init.PointX[17];
            Triangles[31].y2 = init.PointY[17];//p2
            Triangles[31].x3 = init.PointX[18];
            Triangles[31].y3 = init.PointY[18];//p3

            Triangles[32].x1 = init.PointX[15];
            Triangles[32].y1 = init.PointY[15];//p1
            Triangles[32].x2 = init.PointX[16];
            Triangles[32].y2 = init.PointY[16];//p2
            Triangles[32].x3 = init.PointX[27];
            Triangles[32].y3 = init.PointY[27];//p3

            Triangles[33].x1 = init.PointX[16];
            Triangles[33].y1 = init.PointY[16];//p1
            Triangles[33].x2 = init.PointX[22];
            Triangles[33].y2 = init.PointY[22];//p2
            Triangles[33].x3 = init.PointX[27];
            Triangles[33].y3 = init.PointY[27];//p3

            Triangles[34].x1 = init.PointX[22];
            Triangles[34].y1 = init.PointY[22];//p1
            Triangles[34].x2 = init.PointX[28];
            Triangles[34].y2 = init.PointY[28];//p2
            Triangles[34].x3 = init.PointX[27];
            Triangles[34].y3 = init.PointY[27];//p3

            Triangles[35].x1 = init.PointX[22];
            Triangles[35].y1 = init.PointY[22];//p1
            Triangles[35].x2 = init.PointX[24];
            Triangles[35].y2 = init.PointY[24];//p2
            Triangles[35].x3 = init.PointX[28];
            Triangles[35].y3 = init.PointY[28];//p3

            Triangles[36].x1 = init.PointX[19];
            Triangles[36].y1 = init.PointY[19];//p1
            Triangles[36].x2 = init.PointX[24];
            Triangles[36].y2 = init.PointY[24];//p2
            Triangles[36].x3 = init.PointX[22];
            Triangles[36].y3 = init.PointY[22];//p3

            Triangles[37].x1 = init.PointX[19];
            Triangles[37].y1 = init.PointY[19];//p1
            Triangles[37].x2 = init.PointX[24];
            Triangles[37].y2 = init.PointY[24];//p2
            Triangles[37].x3 = init.PointX[25];
            Triangles[37].y3 = init.PointY[25];//p3

            Triangles[38].x1 = init.PointX[19];
            Triangles[38].y1 = init.PointY[19];//p1
            Triangles[38].x2 = init.PointX[20];
            Triangles[38].y2 = init.PointY[20];//p2
            Triangles[38].x3 = init.PointX[25];
            Triangles[38].y3 = init.PointY[25];//p3

            Triangles[39].x1 = init.PointX[21];
            Triangles[39].y1 = init.PointY[21];//p1
            Triangles[39].x2 = init.PointX[25];
            Triangles[39].y2 = init.PointY[25];//p2
            Triangles[39].x3 = init.PointX[20];
            Triangles[39].y3 = init.PointY[20];//p3

            Triangles[40].x1 = init.PointX[23];
            Triangles[40].y1 = init.PointY[23];//p1
            Triangles[40].x2 = init.PointX[21];
            Triangles[40].y2 = init.PointY[21];//p2
            Triangles[40].x3 = init.PointX[25];
            Triangles[40].y3 = init.PointY[25];//p3

            Triangles[41].x1 = init.PointX[23];
            Triangles[41].y1 = init.PointY[23];//p1
            Triangles[41].x2 = init.PointX[21];
            Triangles[41].y2 = init.PointY[21];//p2
            Triangles[41].x3 = init.PointX[17];
            Triangles[41].y3 = init.PointY[17];//p3

            Triangles[42].x1 = init.PointX[17];
            Triangles[42].y1 = init.PointY[17];//p1
            Triangles[42].x2 = init.PointX[23];
            Triangles[42].y2 = init.PointY[23];//p2
            Triangles[42].x3 = init.PointX[30];
            Triangles[42].y3 = init.PointY[30];//p3

            Triangles[43].x1 = init.PointX[17];
            Triangles[43].y1 = init.PointY[17];//p1
            Triangles[43].x2 = init.PointX[18];
            Triangles[43].y2 = init.PointY[18];//p2
            Triangles[43].x3 = init.PointX[30];
            Triangles[43].y3 = init.PointY[30];//p3

            Triangles[44].x1 = init.PointX[27];
            Triangles[44].y1 = init.PointY[27];//p1
            Triangles[44].x2 = init.PointX[28];
            Triangles[44].y2 = init.PointY[28];//p2
            Triangles[44].x3 = init.PointX[35];
            Triangles[44].y3 = init.PointY[35];//p3

            Triangles[45].x1 = init.PointX[24];
            Triangles[45].y1 = init.PointY[24];//p1
            Triangles[45].x2 = init.PointX[28];
            Triangles[45].y2 = init.PointY[28];//p2
            Triangles[45].x3 = init.PointX[31];
            Triangles[45].y3 = init.PointY[31];//p3

            Triangles[46].x1 = init.PointX[24];
            Triangles[46].y1 = init.PointY[24];//p1
            Triangles[46].x2 = init.PointX[25];
            Triangles[46].y2 = init.PointY[25];//p2
            Triangles[46].x3 = init.PointX[31];
            Triangles[46].y3 = init.PointY[31];//p3

            Triangles[47].x1 = init.PointX[25];
            Triangles[47].y1 = init.PointY[25];//p1
            Triangles[47].x2 = init.PointX[31];
            Triangles[47].y2 = init.PointY[31];//p2
            Triangles[47].x3 = init.PointX[32];
            Triangles[47].y3 = init.PointY[32];//p3

            Triangles[48].x1 = init.PointX[25];
            Triangles[48].y1 = init.PointY[25];//p1
            Triangles[48].x2 = init.PointX[32];
            Triangles[48].y2 = init.PointY[32];//p2
            Triangles[48].x3 = init.PointX[33];
            Triangles[48].y3 = init.PointY[33];//p3

            Triangles[49].x1 = init.PointX[25];
            Triangles[49].y1 = init.PointY[25];//p1
            Triangles[49].x2 = init.PointX[26];
            Triangles[49].y2 = init.PointY[26];//p2
            Triangles[49].x3 = init.PointX[33];
            Triangles[49].y3 = init.PointY[33];//p3

            Triangles[50].x1 = init.PointX[26];
            Triangles[50].y1 = init.PointY[26];//p1
            Triangles[50].x2 = init.PointX[25];
            Triangles[50].y2 = init.PointY[25];//p2
            Triangles[50].x3 = init.PointX[23];
            Triangles[50].y3 = init.PointY[23];//p3

            Triangles[51].x1 = init.PointX[23];
            Triangles[51].y1 = init.PointY[23];//p1
            Triangles[51].x2 = init.PointX[29];
            Triangles[51].y2 = init.PointY[29];//p2
            Triangles[51].x3 = init.PointX[26];
            Triangles[51].y3 = init.PointY[26];//p3

            Triangles[52].x1 = init.PointX[23];
            Triangles[52].y1 = init.PointY[23];//p1
            Triangles[52].x2 = init.PointX[29];
            Triangles[52].y2 = init.PointY[29];//p2
            Triangles[52].x3 = init.PointX[30];
            Triangles[52].y3 = init.PointY[30];//p3

            Triangles[53].x1 = init.PointX[26];
            Triangles[53].y1 = init.PointY[26];//p1
            Triangles[53].x2 = init.PointX[29];
            Triangles[53].y2 = init.PointY[29];//p2
            Triangles[53].x3 = init.PointX[33];
            Triangles[53].y3 = init.PointY[33];//p3

            Triangles[54].x1 = init.PointX[29];
            Triangles[54].y1 = init.PointY[29];//p1
            Triangles[54].x2 = init.PointX[30];
            Triangles[54].y2 = init.PointY[30];//p2
            Triangles[54].x3 = init.PointX[36];
            Triangles[54].y3 = init.PointY[36];//p3

            Triangles[55].x1 = init.PointX[28];
            Triangles[55].y1 = init.PointY[28];//p1
            Triangles[55].x2 = init.PointX[31];
            Triangles[55].y2 = init.PointY[31];//p2
            Triangles[55].x3 = init.PointX[35];
            Triangles[55].y3 = init.PointY[35];//p3

            Triangles[56].x1 = init.PointX[31];
            Triangles[56].y1 = init.PointY[31];//p1
            Triangles[56].x2 = init.PointX[34];
            Triangles[56].y2 = init.PointY[34];//p2
            Triangles[56].x3 = init.PointX[35];
            Triangles[56].y3 = init.PointY[35];//p3

            Triangles[57].x1 = init.PointX[31];
            Triangles[57].y1 = init.PointY[31];//p1
            Triangles[57].x2 = init.PointX[32];
            Triangles[57].y2 = init.PointY[32];//p2
            Triangles[57].x3 = init.PointX[34];
            Triangles[57].y3 = init.PointY[34];//p3

            Triangles[58].x1 = init.PointX[32];
            Triangles[58].y1 = init.PointY[32];//p1
            Triangles[58].x2 = init.PointX[33];
            Triangles[58].y2 = init.PointY[33];//p2
            Triangles[58].x3 = init.PointX[34];
            Triangles[58].y3 = init.PointY[34];//p3

            Triangles[59].x1 = init.PointX[33];
            Triangles[59].y1 = init.PointY[33];//p1
            Triangles[59].x2 = init.PointX[34];
            Triangles[59].y2 = init.PointY[34];//p2
            Triangles[59].x3 = init.PointX[36];
            Triangles[59].y3 = init.PointY[36];//p3

            Triangles[60].x1 = init.PointX[29];
            Triangles[60].y1 = init.PointY[29];//p1
            Triangles[60].x2 = init.PointX[33];
            Triangles[60].y2 = init.PointY[33];//p2
            Triangles[60].x3 = init.PointX[36];
            Triangles[60].y3 = init.PointY[36];//p3

            Triangles[61].x1 = init.PointX[35];
            Triangles[61].y1 = init.PointY[35];//p1
            Triangles[61].x2 = init.PointX[34];
            Triangles[61].y2 = init.PointY[34];//p2
            Triangles[61].x3 = init.PointX[36];
            Triangles[61].y3 = init.PointY[36];//p3

        }
        private int Calculate_Alpha(int x, int y, int tri, ref int x_alphaa, ref int y_alphaa)
        {
            double ALPHA1 = 0, ALPHA2 = 0, ALPHA3 = 0, 
                Triangle1 = 0, Triangle2 = 0, Triangle3 = 0, 
                S = 0, A = 0, B = 0, C = 0, D = 0,
                APOW = 0, BPOW = 0, CPOW = 0, DPOW = 0, 
                AB = 0, AC = 0, AD = 0, BC = 0, BD = 0, CD = 0, DC = 0,
                A_ADD_B = 0, A_ADD_C = 0, A_ADD_D = 0, B_ADD_C = 0, B_ADD_D = 0, C_ADD_D = 0,
                Area_Triangle1, Area_Triangle2, Area_Triangle3;
            //Distance point to point     AB =sqrt( (x2-x1)^2 + (y2-y1)^2 )
            A = x - Triangles[tri].x1;
            D = y - Triangles[tri].y1;
            APOW = Math.Pow(A, 2);
            DPOW = Math.Pow(D, 2);
            A_ADD_D = APOW + DPOW;
            AD = Math.Sqrt(A_ADD_D);

            A = Triangles[tri].x1 - Triangles[tri].x2;
            B = Triangles[tri].y1 - Triangles[tri].y2;
            APOW = A * A;
            BPOW = B * B;
            A_ADD_B = APOW + BPOW;
            AB = Math.Sqrt(A_ADD_B);

            B = Triangles[tri].x2 - x;
            D = Triangles[tri].y2 - y;
            BPOW = Math.Pow(B, 2);
            DPOW = Math.Pow(D, 2);
            B_ADD_D = BPOW + DPOW;
            BD = Math.Sqrt(B_ADD_D);

            S = (AD + AB + BD) / 2;
            Triangle1 = S * (S - AD) * (S - AB) * (S - BD);
            Area_Triangle1 = Math.Sqrt(Triangle1);
            //---------------------------------------------------------------------------------------
            A = Triangles[tri].x3 - Triangles[tri].x1;
            C = Triangles[tri].y3 - Triangles[tri].y1;
            APOW = Math.Pow(A, 2);
            CPOW = Math.Pow(C, 2);
            A_ADD_C = APOW + CPOW;
            AC = Math.Sqrt(A_ADD_C);

            A = Triangles[tri].x1 - x;
            D = Triangles[tri].y1 - y;
            APOW = Math.Pow(A, 2);
            DPOW = Math.Pow(D, 2);
            A_ADD_D = APOW + DPOW;
            AD = Math.Sqrt(A_ADD_D);

            C = Triangles[tri].x3 - x;
            D = Triangles[tri].y3 - y;
            CPOW = Math.Pow(C, 2);
            DPOW = Math.Pow(D, 2);
            C_ADD_D = CPOW + DPOW;
            CD = Math.Sqrt(C_ADD_D);

            S = (AC + AD + CD) / 2;
            Triangle2 = S * (S - AC) * (S - AD) * (S - CD);
            Area_Triangle2 = Math.Sqrt(Triangle2);
            //----------------------------------------------------------
            B = Triangles[tri].x3 - Triangles[tri].x2;
            C = Triangles[tri].y3 - Triangles[tri].y2;
            BPOW = Math.Pow(B, 2);
            CPOW = Math.Pow(C, 2);
            B_ADD_C = BPOW + CPOW;
            BC = Math.Sqrt(B_ADD_C);

            B = Triangles[tri].x2 - x;
            D = Triangles[tri].y2 - y;
            BPOW = Math.Pow(B, 2);
            DPOW = Math.Pow(D, 2);
            B_ADD_D = BPOW + DPOW;
            BD = Math.Sqrt(B_ADD_D);

            D = Triangles[tri].x3 - x;
            C = Triangles[tri].y3 - y;
            CPOW = Math.Pow(C, 2);
            DPOW = Math.Pow(D, 2);
            C_ADD_D = CPOW + DPOW;
            CD = Math.Sqrt(C_ADD_D);

            S = (BC + BD + CD) / 2;
            Triangle3 = S * (S - BC) * (S - BD) * (S - CD);
            Area_Triangle3 = Math.Sqrt(Triangle3);
            //--------------------------------------------------------
            ALPHA1 = Area_Triangle1 / (Area_Triangle1 + Area_Triangle2 + Area_Triangle3);
            ALPHA2 = Area_Triangle2 / (Area_Triangle1 + Area_Triangle2 + Area_Triangle3);
            ALPHA3 = Area_Triangle3 / (Area_Triangle1 + Area_Triangle2 + Area_Triangle3);

            double x1_alpha, x2_alpha, x3_alpha, x_alpha, y1_alpha, y2_alpha, y3_alpha, y_alpha;
            x1_alpha = ALPHA1 * Triangles[tri].x1;
            x2_alpha = ALPHA2 * Triangles[tri].x2;
            x3_alpha = ALPHA3 * Triangles[tri].x3;
            x_alpha = x1_alpha + x2_alpha + x3_alpha;

            y1_alpha = ALPHA1 * Triangles[tri].y1;
            y2_alpha = ALPHA2 * Triangles[tri].y2;
            y3_alpha = ALPHA3 * Triangles[tri].y3;
            y_alpha = y1_alpha + y2_alpha + y3_alpha;
            
            x_alphaa = Convert.ToInt32(x_alpha);
            y_alphaa = Convert.ToInt32(y_alpha);
            return 0;
        }
        private int Calculate_Crossproduct(int x, int y, int tri, ref double q1, ref double q2, ref double q3)
        {
            double q1x, q1y, q2x, q2y, q3x, q3y;

            q1x = (Triangles[tri].x1 - x);//P1 - จุดที่ต้องกาทดสอบว่า อยู่ใน/นอก
            q1y = (Triangles[tri].y1 - y);//P1 - จุดที่ต้องกาทดสอบว่า อยู่ใน/นอก
            q2x = (Triangles[tri].x2 - x);//P2 - จุดที่ต้องกาทดสอบว่า อยู่ใน/นอก
            q2y = (Triangles[tri].y2 - y);//P2 - จุดที่ต้องกาทดสอบว่า อยู่ใน/นอก
            q3x = (Triangles[tri].x3 - x);//P3 - จุดที่ต้องกาทดสอบว่า อยู่ใน/นอก
            q3y = (Triangles[tri].y3 - y);//P3 - จุดที่ต้องกาทดสอบว่า อยู่ใน/นอก
            q1 = ((q1x * q2y) - (q1y * q2x)); // 1 x 2
            q2 = ((q2x * q3y) - (q2y * q3x)); // 2 x 3
            q3 = ((q3x * q1y) - (q3y * q1x)); // 3 x 1

            return 0;
        }
        public void get_pixel()
        {
            //Console.WriteLine(System.IO.Directory.GetCurrentDirectory());             
            int[][] pixel = new int[355][];
            for (int a=0;a<355;a++)
            {
                pixel[a] = new int[365];
            }
            decimal value = (numericUpDown1.Value); //ค่าเลือก หมายเลขหน้า
            int faceInt = decimal.ToInt32(value); //แปลงเป็น int
            Bitmap myBitmap = new Bitmap("../Crop/c"+faceInt+".jpg");            
            for (int x = 0; x < myBitmap.Width; x++)
            {
                for (int y = 0; y < myBitmap.Height; y++)
                {                                                                       
                    //for triangle
                    //U x V = Ux*Vy-Uy*Vx
                    //Triangle Area  s=a+b+c / 2   >  sqrt(s(s-a)(s-b)(s-c))                   
                    for(int tri = 0; tri < 62; tri++)
                    {
                        double q1 = 0, q2 = 0, q3 = 0;
                        double checktri = 0;
                        Calculate_Crossproduct(x, y, tri, ref q1, ref q2, ref q3);

                        if ((q1 > 0) && (q2 > 0) && (q3 > 0))
                        {
                            int x_alphaa=0, y_alphaa=0;
                            Calculate_Alpha(x,y,tri,ref x_alphaa, ref y_alphaa);

                            Color colorpixel = myBitmap.GetPixel(x_alphaa, y_alphaa);

                            //Console.WriteLine("x = " + x + " y = " + y);
                            //Console.WriteLine("x_alphaa = " + x_alphaa + " y_alphaa = " + y_alphaa);
                            pixel[x][y] = colorpixel.R;

                            //Console.WriteLine("x = " + x + " y = " + y);
                            //Console.WriteLine("xalpha = " + x_alpha + " yalpha = " + y_alpha);
                            //Console.WriteLine("x_alphaa = " + x_alphaa + " y_alphaa = " + y_alphaa);
                            //Console.WriteLine(pixel[x][y]);
                            //Console.WriteLine("-----------------------------------");
                            checktri = 1;
                            break;
                            //Console.WriteLine("q1 = " + q1 + " q2 = " + q2 + " q3 = " + q3);                           
                        }

                        else if ((q1 < 0) && (q2 < 0) && (q3 < 0))
                        {
                            int x_alphaa = 0, y_alphaa = 0;
                            Calculate_Alpha(x, y, tri, ref x_alphaa, ref y_alphaa);

                            Color colorpixel = myBitmap.GetPixel(x_alphaa, y_alphaa);

                            //Console.WriteLine("x = " + x + " y = " + y);
                            //Console.WriteLine("x_alphaa = " + x_alphaa + " y_alphaa = " + y_alphaa);
                            //Console.WriteLine("-----------------------------------");
                            pixel[x][y] = colorpixel.R;

                            checktri = 1;
                            break;                                                    
                        }

                        else if(checktri==0 && tri==61)
                        {
                            //Console.WriteLine("Triangle :" + tri);
                            //Console.WriteLine("x = " + x + " y = " + y);
                            //Console.WriteLine("Blank");
                            //Console.WriteLine("-----------------------------------");
                            pixel[x][y] = 0;                            
                        }
                    }
                    
                }
                
            }
            
            string json = JsonConvert.SerializeObject(pixel);
            System.IO.File.WriteAllText("../Pixel/Pixel" + faceInt + ".json", json);
            Console.WriteLine("Done");
        }
               
        public void Cal_Avg_Pixel()
        {
            for (int temp = 0; temp < 355; temp++)
            {
                temppixel[temp] = new int[365]; // resolution crop image 355*365 
            }
            decimal value = (numericUpDown2.Value); //ค่าเลือก หมายเลขหน้า
            int NumberOfFaceMax = decimal.ToInt32(value); //แปลงเป็น int
            int[][] sourceMatrix = new int[NumberOfFaceMax][]; //จำนวนหน้า

            for (int i = 0; i < NumberOfFaceMax; i++) //;NumberOfFaceMax Must corresponding Array SourceMatrix if not Error in Learn PCA
            {
                sourceMatrix[i] = new int[129575]; //Pixel 355*365
            }

            for (int faceInt = 0; faceInt < NumberOfFaceMax; faceInt++)
            { //Insert All PointFace to array 
                int faceIntt = faceInt + 1;
                string json = File.ReadAllText("../Pixel/Pixel" + faceIntt + ".json");
                int[][] pixel = JsonConvert.DeserializeObject<int[][]>(json);
                for (int t = 0; t < 355; t++) //init point x y z  if not point x y z can't update value follow json
                {
                    for (int g = 0; g < 365; g++)
                    {
                        temppixel[t][g] = pixel[t][g];

                    }

                }

                // Create a matrix from the source data table
                //double[][] sourceMatrix = new double[][] { new double[] { 2, 3, 5 }, new double[] { 5, 6, 10 }, new double[] { 10, 15, 30 } };

                //insert data to array
                int xx = 0, yy = 0;
                for (int x = 0; x < 129575; x++)
                {

                    sourceMatrix[faceInt][x] = pixel[xx][yy];
                    ++yy;
                    if (yy % 365 == 0)
                    {
                        ++xx;
                        yy = 0;
                    }
                    //Console.WriteLine("x[" + x + "] :" + sourceMatrix[faceInt][x] + "\n");
                }

            }//load all face done

            //prepare Value Sum all face per point ซัมของทุกหน้าจาก1จุด

            int[][] SumOf1Pixel = new int[129575][]; //129575 from 355*365 pixel
            for (int i = 0; i < 129575; i++)
            {
                SumOf1Pixel[i] = new int[NumberOfFaceMax];
            }

            //Add Value all face per 1 Dimension(111 = 37 Point*3 Dimension) to sum1point
            for (int point = 0; point < 129575; point++) //loop dimension
            {
                for (int face = 0; face < NumberOfFaceMax; face++) //loop face
                {
                    if (face == 0)
                    {
                        SumOf1Pixel[point][face] = sourceMatrix[face][point];
                        //Console.WriteLine(face + " : " + sum1point[point][face]);
                    }
                    if (face != 0)
                    {
                        SumOf1Pixel[point][face] = SumOf1Pixel[point][face - 1] + sourceMatrix[face][point];
                        //Console.WriteLine(face + " : "+ sum1point[point][face]);
                    }

                    //calculate average all point
                    ////SumOf1Point[point][face] > last index face is value sum of all face
                    if (face == NumberOfFaceMax - 1)
                    {
                        average[point] = SumOf1Pixel[point][face] / NumberOfFaceMax;
                        //Console.WriteLine(face + "\n");
                        //Console.WriteLine("Point " + point + ": " + average[point]);
                    }
                }//end inside for loop
            }//end outside for loop

            Console.WriteLine(face + "\n");
            Console.WriteLine("Point " + 75750 + ": " + average[75750]);

        }

        private void Start_Click(object sender, EventArgs e)
        {            
            get_pixel();
            MessageBox.Show("Get pixel Done");
        }

        private void Prepare_Triangle_Click(object sender, EventArgs e)
        {
            PrepareTraiangle();
            MessageBox.Show("Prepare Done Now Click Start To Get Pixel");
        }
      
        private void Average_Click(object sender, EventArgs e)
        {
            Cal_Avg_Pixel();
            MessageBox.Show("Calculate Done Now Click Save");
        }

    }
}
