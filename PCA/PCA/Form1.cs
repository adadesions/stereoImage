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
//using Components;
using Accord.Controls;
using Accord.IO;
using Accord.Math;
using Accord.Statistics.Analysis;

namespace PCA
{
    public partial class Form1 : Form
    {
        private PrincipalComponentAnalysis pca;
        private DescriptiveAnalysis sda;

        protected override void OnLoad(EventArgs e)
        {
            Array methods = Enum.GetValues(typeof(AnalysisMethod));
            this.cbMethod.DataSource = methods;
        }        

        public class PointOnFace
        {            
            public double[] PointX { get; set; }
            public double[] PointY { get; set; }
            public double[] PointZ { get; set; }
        }

        public class InitialPoint
        {
            public double[] PointX { get; set; }
            public double[] PointY { get; set; }
            public double[] PointZ { get; set; }
        }

        static string json = File.ReadAllText("../initialpoint.json");
        static InitialPoint init = JsonConvert.DeserializeObject<InitialPoint>(json);
        public static double[] pointx = init.PointX;
        public static double[] pointy = init.PointY;
        public static double[] pointz = init.PointZ;

        Rectangle[] recStore = new Rectangle[37];
        //public double[][] sourceMatrix { get; set; }

        public Form1()
        {
            //dgvFeatureVectors.AutoGenerateColumns = true;
            this.DoubleBuffered = true;
            InitializeComponent();                                   
        }

        double[] average = new double[111];

        private void LoadFace_Click(object sender, EventArgs e)
        {
            decimal value = (numericUpDown1.Value); //ค่าเลือก หมายเลขหน้า
            int NumberOfFaceMax = decimal.ToInt32(value); //แปลงเป็น int
            double[][] sourceMatrix = new double[NumberOfFaceMax][]; //จำนวนหน้า

            for (int i = 0; i < NumberOfFaceMax; i++) //;NumberOfFaceMax Must corresponding Array if not Error in Learn PCA
            {
                sourceMatrix[i] = new double[111]; //จำนวนมิติ หรือ ค่าระบุตำแหน่งจุดบนหน้า x1-x37 ,y1-y37 ,z1-z37
            }

            for (int faceInt = 0; faceInt < NumberOfFaceMax; faceInt++) { //Insert All PointFace to array 
                int faceIntt = faceInt+1;
                string Cropjson = File.ReadAllText("../PointFaceCrop/PointFaceC" + faceIntt + ".json");
                InitialPoint Cropinit = JsonConvert.DeserializeObject<InitialPoint>(Cropjson);
                string json = File.ReadAllText("../PointFace/PointFace" + faceIntt + ".json");
                InitialPoint zinit = JsonConvert.DeserializeObject<InitialPoint>(json);
                for (int t = 0; t < 37; t++) //init point x y z  if not point x y z can't update value follow json
                {
                    pointx[t] = Cropinit.PointX[t];
                    pointy[t] = Cropinit.PointY[t];
                    pointz[t] = zinit.PointZ[t];
                }

                // Create a matrix from the source data table
                //double[][] sourceMatrix = new double[][] { new double[] { 2, 3, 5 }, new double[] { 5, 6, 10 }, new double[] { 10, 15, 30 } };

                //insert data to array
                for (int x = 0; x < 37; x++)
                {
                    sourceMatrix[faceInt][x] = pointx[x]+50; //+50 เพื่อขยับภาพห่างขอบ
                    //Console.WriteLine("x[" + x + "] :" + sourceMatrix[faceInt][x] + "\n");
                }
                for (int y = 0; y < 37; y++)
                {
                    sourceMatrix[faceInt][y + 37] = pointy[y]+50; //+50 เพื่อขยับภาพห่างขอบ
                    //Console.WriteLine("y[" + y + "] :" + sourceMatrix[faceInt][y+37] + "\n");
                }
                for (int z = 0; z < 37; z++)
                {
                    sourceMatrix[faceInt][z + 74] = pointz[z];
                } //Check OK!!!!
            }//load all face done

            //....................................MEAN FACE................................................
            //prepare Value Sum all face per point ซัมของทุกหน้าจาก1จุด
            //double[] average = new double[111];
            double[][] SumOf1Point = new double[111][]; //111 from 37point * 3 -> 3 from x y z
            for (int i=0;i<111;i++)
            {
                SumOf1Point[i] = new double[NumberOfFaceMax];
            }

            //Add Value all face per 1 Dimension(111 = 37 Point*3 Dimension) to sum1point
            for (int point = 0; point < 111; point++) //loop dimension
            {
                for (int face = 0; face < NumberOfFaceMax; face++) //loop face
                {
                    if(face == 0)
                    {
                        SumOf1Point[point][face] = sourceMatrix[face][point];
                        //Console.WriteLine(face + " : " + sum1point[point][face]);
                    }
                    if(face != 0)
                    {                      
                        SumOf1Point[point][face] = SumOf1Point[point][face - 1] + sourceMatrix[face][point];
                        //Console.WriteLine(face + " : "+ sum1point[point][face]);
                    }

                    //calculate average all point
                    ////SumOf1Point[point][face] > last index face is value sum of all face
                    if (face == NumberOfFaceMax - 1) 
                    {
                        average[point] = SumOf1Point[point][face] / NumberOfFaceMax;
                        //Console.WriteLine(face + "\n");
                        //Console.WriteLine("Point " + point + ": " + average[point]);
                    }
                }//end inside for loop
            }//end outside for loop
            //.............................FINISH MEAN FACE..........CHECK..OK!!.........................

            //.........................For Show on Tab Average...........................................
            double[][] averageBeauty = new double[37][]; 
            for(int a = 0 ; a < 37; a++) //37 from point on face
            {
                averageBeauty[a] = new double[3];  //3 from x y z
            }
            for(int x = 0; x < 37; x++)
            {
                averageBeauty[x][0] = average[x];
                pointx[x] = Math.Round(average[x]);                
            }
            for (int y = 0; y < 37; y++)
            {
                averageBeauty[y][1] = average[y+37];
                pointy[y] = Math.Round(average[y+37]);
            }
            for (int z = 0; z < 37; z++)
            {
                averageBeauty[z][2] = average[z+74];
                pointz[z] = Math.Round(average[z+74]);
            }
            //............................Finish Show on Tab Average..................................
            var method = (PrincipalComponentMethod)cbMethod.SelectedValue;
            // Create the Principal Component Analysis of the data
            pca = new PrincipalComponentAnalysis(method);

            pca.Learn(sourceMatrix);  // Finally, compute the analysis!
            MessageBox.Show("Learn PCA Done");
            AveragePoint.DataSource = new ArrayDataView(averageBeauty); //x1 to x37 y1 to y37 z1 to z37
            
            Invalidate(true);
         
        }

        private void ShowEigenVector_Click(object sender, EventArgs e)
        {
            dgvFeatureVectors.DataSource = new ArrayDataView(pca.ComponentVectors);//EigenVector Matrix
            double[][] vectors = pca.ComponentVectors;
            int Lenrow = vectors.Length;
            int Lencol = vectors[0].Length;
            Console.WriteLine(" LengthRow :" + vectors.Length + "\n");
            Console.WriteLine(" LengthCol :" + vectors[0].Length + "\n");
            MessageBox.Show(" Row :" + vectors.Length + "\n" + " Col :" + vectors[0].Length + "\n");
            
            Invalidate(true);
        }

        private void SaveAvg_Click(object sender, EventArgs e) //Mean Face text
        {
            DialogResult result = MessageBox.Show("Save To PCA/PCA/bin", "Save txt", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...                

                string path = "../PointFaceCropAverageXYZ" + ".txt";
                //if (!File.Exists(path))
                //{
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        for (int k = 0; k <= 36; k++)
                        {
                            int averageX_int = Convert.ToInt32(average[k]);
                            int averageY_int = Convert.ToInt32(average[k+37]);
                            int averageZ_int = Convert.ToInt32(average[k + 74]);
                            double averageX_double = averageX_int/1000;
                            double averageY_double = averageY_int / 1000;
                            double averageZ_double = averageZ_int / 1000;
                        sw.Write(averageX_double + " " + averageY_double + " "+ averageZ_double +"\n");
                        }
                        sw.Close();
                    }
                    Console.WriteLine("File create!!!!");
                //}
                MessageBox.Show("Save File");
                Invalidate(true);

            }
            else if (result == DialogResult.No)
            {
                //no...
            }
        }

        private void Save_Avg_Value_Json_Click(object sender, EventArgs e) //Mean Face json
        {
            DialogResult result = MessageBox.Show("Save Average Point", "Save Json", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...               
                //string face = faceInt.ToString();
                PointOnFace updatepoint = new PointOnFace();
                //updatepoint.Face = faceInt;
                updatepoint.PointX = pointx;
                updatepoint.PointY = pointy;
                updatepoint.PointZ = pointz;

                string json = JsonConvert.SerializeObject(updatepoint);

                //write string to file
                System.IO.File.WriteAllText("../AveragePoint.json", json);
                //save to emgu2\bin\
                Console.WriteLine("file create!!!!");
                MessageBox.Show("Save Average Point");
            }
            else if (result == DialogResult.No)
            {
                //no...
            }
        }

        private void Calculate_MeshMove_By_Parameter()
        {
            decimal value = (numericUpDown1.Value); //ค่าเลือก หมายเลขหน้า
            int NumberOfFaceMax = decimal.ToInt32(value); //แปลงเป็น int
            double[][] vectors = pca.ComponentVectors;
            double[] EigenVectorRow0 = new double[111];
            double[] EigenVectorRow1 = new double[111];
            double[] EigenVectorRow2 = new double[111];
            double[] EigenVectorRow3 = new double[111];
            double[] EigenVectorRow4 = new double[111];
            double[] EigenVectorRow5 = new double[111];
            double[] EigenVectorRow6 = new double[111];
            double[] EigenVectorRow7 = new double[111];
            double[] EigenVectorRow8 = new double[111];
            double[] EigenVectorRow9 = new double[111];
            double[] EigenVectorRow10 = new double[111];
            double[] EigenVectorRow11 = new double[111];
            double[] EigenVectorRow12 = new double[111];
            double[] EigenVectorRow13 = new double[111];
            double[] EigenVectorRow14 = new double[111];
            double[] EigenVectorRow15 = new double[111];
            double[] EigenVectorRow16 = new double[111];
            double[] EigenVectorRow17 = new double[111];
            double[] EigenVectorRow18 = new double[111];
            double[] EigenVectorRow19 = new double[111];
            double[] EigenVectorRow20 = new double[111];
            double[] EigenVectorRow21 = new double[111];
            double[] EigenVectorRow22 = new double[111];
            double[] EigenVectorRow23 = new double[111];
            double[] EigenVectorRow24 = new double[111];
            double[] EigenVectorRow25 = new double[111];
            double[] EigenVectorRow26 = new double[111];
            double[] EigenVectorRow27 = new double[111];
            double[] EigenVectorRow28 = new double[111];
            double[] EigenVectorRow29 = new double[111];
            double[] EigenVectorRow30 = new double[111];
            double[] EigenVectorRow31 = new double[111];
            double[] EigenVectorRow32 = new double[111];
            double[] EigenVectorRow33 = new double[111];
            double[] EigenVectorRow34 = new double[111];
            double[] EigenVectorRow35 = new double[111];
            double[] EigenVectorRow36 = new double[111];
            //Row0
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow0[dimension] = 10 * trackBar1.Value * vectors[0][dimension];
            }
            //finish Row0..................................
            //Row1
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow1[dimension] = 10 * trackBar2.Value * vectors[1][dimension];
            }
            //finish Row1..................................
            //Row2
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow2[dimension] = 10 * trackBar3.Value * vectors[2][dimension];
            }
            //finish Row2..................................
            //Row3
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow3[dimension] = 10 * trackBar4.Value * vectors[3][dimension];
            }
            //finish Row3..................................
            //Row4
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow4[dimension] = 10 * trackBar5.Value * vectors[4][dimension];
            }
            //finish Row4..................................
            //Row5
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow5[dimension] = 10 * trackBar6.Value * vectors[5][dimension];
            }
            //finish Row5..................................
            //Row6
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow6[dimension] = 10 * trackBar7.Value * vectors[6][dimension];
            }
            //finish Row6..................................
            //Row7
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow7[dimension] = 10 * trackBar8.Value * vectors[7][dimension];
            }
            //finish Row7..................................
            //Row8
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow8[dimension] = 10 * trackBar9.Value * vectors[8][dimension];
            }
            //finish Row8..................................
            //Row9
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow9[dimension] = 10 * trackBar10.Value * vectors[9][dimension];
            }
            //finish Row9..................................
            //Row10
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow10[dimension] = 10 * trackBar11.Value * vectors[10][dimension];
            }
            //finish Row10..................................
            //Row11
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow11[dimension] = 10 * trackBar12.Value * vectors[11][dimension];
            }
            //finish Row11..................................
            //Row12
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow12[dimension] = 10 * trackBar13.Value * vectors[12][dimension];
            }
            //finish Row12..................................
            //Row13
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow13[dimension] = 10 * trackBar14.Value * vectors[13][dimension];
            }
            //finish Row13..................................
            //Row14
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow14[dimension] = 10 * trackBar15.Value * vectors[14][dimension];
            }
            //finish Row14..................................
            //Row15
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow15[dimension] = 10 * trackBar16.Value * vectors[15][dimension];
            }
            //finish Row15..................................
            //Row16
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow16[dimension] = 10 * trackBar17.Value * vectors[16][dimension];
            }
            //finish Row16..................................
            //Row17
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow17[dimension] = 10 * trackBar18.Value * vectors[17][dimension];
            }
            //finish Row17..................................
            //Row18
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow18[dimension] = 10 * trackBar19.Value * vectors[18][dimension];
            }
            //finish Row18..................................
            //Row19
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow19[dimension] = 10 * trackBar20.Value * vectors[19][dimension];
            }
            //finish Row19..................................
            //Row20
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow20[dimension] = 1 * vectors[20][dimension];
            }
            //finish Row20..................................
            //Row21
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow21[dimension] = 1 * vectors[21][dimension];
            }
            //finish Row21..................................
            //Row22
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow22[dimension] = 1 * vectors[22][dimension];
            }
            //finish Row22..................................
            //Row23
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow23[dimension] = 1 * vectors[23][dimension];
            }
            //finish Row23..................................
            //Row24
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow24[dimension] = 1 * vectors[24][dimension];
            }
            //finish Row24..................................
            //Row25
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow25[dimension] = 1 * vectors[25][dimension];
            }
            //finish Row25..................................
            //Row26
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow26[dimension] = 1 * vectors[26][dimension];
            }
            //finish Row26..................................
            //Row27
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow27[dimension] = 1 * vectors[27][dimension];
            }
            //finish Row27..................................
            //Row28
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow28[dimension] = 1 * vectors[28][dimension];
            }
            //finish Row28..................................
            //Row29
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow29[dimension] = 1 * vectors[29][dimension];
            }
            //finish Row29..................................
            //Row30
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow30[dimension] = 1 * vectors[30][dimension];
            }
            //finish Row30..................................
            //Row31
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow31[dimension] = 1 * vectors[31][dimension];
            }
            //finish Row31..................................
            //Row32
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow32[dimension] = 1 * vectors[32][dimension];
            }
            //finish Row32..................................
            //Row33
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow33[dimension] = 1 * vectors[33][dimension];
            }
            //finish Row33..................................
            //Row34
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow34[dimension] = 1 * vectors[34][dimension];
            }
            //finish Row34..................................
            //Row35
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow35[dimension] = 1 * vectors[35][dimension];
            }
            //finish Row35..................................
            //Row36
            for (int dimension = 0; dimension < 111; dimension++)
            {
                EigenVectorRow36[dimension] = 1 * vectors[36][dimension];
            }
            //finish Row36..................................

            double[] SumEigenVectorForDrawMesh = new double[111];
            for (int dimension = 0; dimension < 111; dimension++)
            {
                SumEigenVectorForDrawMesh[dimension] = EigenVectorRow0[dimension] + EigenVectorRow1[dimension] + EigenVectorRow2[dimension] + EigenVectorRow3[dimension] + EigenVectorRow4[dimension] + EigenVectorRow5[dimension] + EigenVectorRow6[dimension] + EigenVectorRow7[dimension] +EigenVectorRow8[dimension] + EigenVectorRow9[dimension] + EigenVectorRow10[dimension] +EigenVectorRow11[dimension] + EigenVectorRow12[dimension] + EigenVectorRow13[dimension] +EigenVectorRow14[dimension] + EigenVectorRow15[dimension] + EigenVectorRow16[dimension] +EigenVectorRow17[dimension] + EigenVectorRow18[dimension] + EigenVectorRow19[dimension] +EigenVectorRow20[dimension] + EigenVectorRow21[dimension] + EigenVectorRow22[dimension] +EigenVectorRow23[dimension] + EigenVectorRow24[dimension] + EigenVectorRow25[dimension] +EigenVectorRow26[dimension] + EigenVectorRow27[dimension] + EigenVectorRow28[dimension] +EigenVectorRow29[dimension] + EigenVectorRow30[dimension] + EigenVectorRow31[dimension] +EigenVectorRow32[dimension] + EigenVectorRow33[dimension] + EigenVectorRow34[dimension] +EigenVectorRow35[dimension] + EigenVectorRow36[dimension];
            }
            
            for (int x = 0; x < 37; x++)
            {
                pointx[x] = average[x] + SumEigenVectorForDrawMesh[x];
                //Console.WriteLine(x + " : " + pointx[x] + "\n");
            }
            for (int y = 0; y < 37; y++)
            {
                pointy[y] = average[y+37] + SumEigenVectorForDrawMesh[y+37];
                //Console.WriteLine(y + " : " + pointy[y] + "\n");
            }

        }        

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //------------------------------------SET PIXEL------------------------------------------------------------
            if (File.Exists("../AveragePixel_R.json") && File.Exists("../AveragePixel_G.json") && File.Exists("../AveragePixel_B.json"))
            {
                // Create a Bitmap object from a file.
                Bitmap myBitmap = new Bitmap(355, 365);


                // Draw myBitmap to the screen.
                e.Graphics.DrawImage(myBitmap, 0, 0, myBitmap.Width, myBitmap.Height);

                // Set each pixel in myBitmap to black.
                string Rjson = File.ReadAllText("../AveragePixel_R.json");
                int[][] pixelR = JsonConvert.DeserializeObject<int[][]>(Rjson);
                string Gjson = File.ReadAllText("../AveragePixel_G.json");
                int[][] pixelG = JsonConvert.DeserializeObject<int[][]>(Gjson);
                string Bjson = File.ReadAllText("../AveragePixel_B.json");
                int[][] pixelB = JsonConvert.DeserializeObject<int[][]>(Bjson);
                for (int Xcount = 0; Xcount < myBitmap.Width; Xcount++)
                {
                    for (int Ycount = 0; Ycount < myBitmap.Height; Ycount++)
                    {
                        Color pixell = Color.FromArgb(pixelR[Xcount][Ycount], pixelG[Xcount][Ycount], pixelB[Xcount][Ycount]);
                        myBitmap.SetPixel(Xcount, Ycount, pixell);
                    }
                }
                float positionx = (float)pointx[15];
                float positiony = (float)pointy[0];
                // Draw myBitmap to the screen again.
                e.Graphics.DrawImage(myBitmap, positionx, positiony,
                    myBitmap.Width, myBitmap.Height);
            }
            //------------------------------------------------END SET PIXEL-----------------------------------------------

            //Prepare_AdjacencyMatrix
            string path = "../AdjacencyMatrix.txt";
            string text = File.ReadAllText(path);
            //This allows you to do one Read operation.
            string[] words = text.Split(' ');
            int m = 1;
            int[][] matrix = new int[37][];
            for (int u = 0; u < 37; u++)
            {
                matrix[u] = new int[37];
            }

//-----------------------Create AdjacencyMatrix for use in Draw Line Deluanay------------------------------
            foreach (string word in words)
            {
                if (m % 37 == 1)
                { //if i is the first integer in a row
                    matrix[m / 37][0] = Convert.ToInt32(word);
                }
                else if (m % 37 == 2)
                {
                    matrix[m / 37][1] = Convert.ToInt32(word);
                }
                else if (m % 37 == 3)
                {
                    matrix[m / 37][2] = Convert.ToInt32(word);
                }
                else if (m % 37 == 4)
                {
                    matrix[m / 37][3] = Convert.ToInt32(word);
                }
                else if (m % 37 == 5)
                {
                    matrix[m / 37][4] = Convert.ToInt32(word);
                }
                else if (m % 37 == 6)
                {
                    matrix[m / 37][5] = Convert.ToInt32(word);
                }
                else if (m % 37 == 7)
                {
                    matrix[m / 37][6] = Convert.ToInt32(word);
                }
                else if (m % 37 == 8)
                {
                    matrix[m / 37][7] = Convert.ToInt32(word);
                }
                else if (m % 37 == 9)
                {
                    matrix[m / 37][8] = Convert.ToInt32(word);
                }
                else if (m % 37 == 10)
                {
                    matrix[m / 37][9] = Convert.ToInt32(word);
                }
                else if (m % 37 == 11)
                {
                    matrix[m / 37][10] = Convert.ToInt32(word);
                }
                else if (m % 37 == 12)
                {
                    matrix[m / 37][11] = Convert.ToInt32(word);
                }
                else if (m % 37 == 13)
                {
                    matrix[m / 37][12] = Convert.ToInt32(word);
                }
                else if (m % 37 == 14)
                {
                    matrix[m / 37][13] = Convert.ToInt32(word);
                }
                else if (m % 37 == 15)
                {
                    matrix[m / 37][14] = Convert.ToInt32(word);
                }
                else if (m % 37 == 16)
                {
                    matrix[m / 37][15] = Convert.ToInt32(word);
                }
                else if (m % 37 == 17)
                {
                    matrix[m / 37][16] = Convert.ToInt32(word);
                }
                else if (m % 37 == 18)
                {
                    matrix[m / 37][17] = Convert.ToInt32(word);
                }
                else if (m % 37 == 19)
                {
                    matrix[m / 37][18] = Convert.ToInt32(word);
                }
                else if (m % 37 == 20)
                {
                    matrix[m / 37][19] = Convert.ToInt32(word);
                }
                else if (m % 37 == 21)
                {
                    matrix[m / 37][20] = Convert.ToInt32(word);
                }
                else if (m % 37 == 22)
                {
                    matrix[m / 37][21] = Convert.ToInt32(word);
                }
                else if (m % 37 == 23)
                {
                    matrix[m / 37][22] = Convert.ToInt32(word);
                }
                else if (m % 37 == 24)
                {
                    matrix[m / 37][23] = Convert.ToInt32(word);
                }
                else if (m % 37 == 25)
                {
                    matrix[m / 37][24] = Convert.ToInt32(word);
                }
                else if (m % 37 == 26)
                {
                    matrix[m / 37][25] = Convert.ToInt32(word);
                }
                else if (m % 37 == 27)
                {
                    matrix[m / 37][26] = Convert.ToInt32(word);
                }
                else if (m % 37 == 28)
                {
                    matrix[m / 37][27] = Convert.ToInt32(word);
                }
                else if (m % 37 == 29)
                {
                    matrix[m / 37][28] = Convert.ToInt32(word);
                }
                else if (m % 37 == 30)
                {
                    matrix[m / 37][29] = Convert.ToInt32(word);
                }
                else if (m % 37 == 31)
                {
                    matrix[m / 37][30] = Convert.ToInt32(word);
                }
                else if (m % 37 == 32)
                {
                    matrix[m / 37][31] = Convert.ToInt32(word);
                }
                else if (m % 37 == 33)
                {
                    matrix[m / 37][32] = Convert.ToInt32(word);
                }
                else if (m % 37 == 34)
                {
                    matrix[m / 37][33] = Convert.ToInt32(word);
                }
                else if (m % 37 == 35)
                {
                    matrix[m / 37][34] = Convert.ToInt32(word);
                }
                else if (m % 37 == 36)
                {
                    matrix[m / 37][35] = Convert.ToInt32(word);
                }
                else if (m % 37 == 0)
                {
                    matrix[(m - 1) / 37][36] = Convert.ToInt32(word);
                }
                //cout << k;		
                m++;
            }
//---------------------------------End Create AdjacencyMatrix--------------------------------------------
            if (!File.Exists("../AveragePoint.json"))
            {
                MessageBox.Show("File Not Found!!");
            }

            if (File.Exists("../AveragePoint.json"))
            {
//--------------------------------Draw Line Deluanay-----------------------------------------------------
                Point[] ss = new Point[37];
                for (int s = 0; s < 37; s++)
                {
                    ss[s] = new Point(Convert.ToInt32(pointx[s]) + 4, Convert.ToInt32(pointy[s]) + 4);
                    //ขยับเส้นให้ตรงจุดต้อง +4
                }

                for (int a = 0; a < 37; a++)
                { //row	
                    for (int b = 0; b < 37; b++)
                    { //column
                        if ((matrix[a][b] == 1))
                        {
                            Pen blackPen = new Pen(Color.HotPink, 3);
                            e.Graphics.DrawLine(blackPen, ss[a], ss[b]);
                        }
                    }
                }
//-------------------------------End Draw Line Deluanay----------------------------------------------------          

//---------------------------------------Draw Point-------------------------------------------------------
                int[] pointxx = new int[37];
                int[] pointyy = new int[37];
                for (int i = 0; i < 37; i++)
                {
                    pointxx[i] = Convert.ToInt32(pointx[i]);
                    pointyy[i] = Convert.ToInt32(pointy[i]);
                    recStore[i] = new Rectangle((pointxx[i]), (pointyy[i]), 10, 10);
                    e.Graphics.FillEllipse(Brushes.Blue, recStore[i]);
                }
//End Draw Point

            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar12_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar13_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar14_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar15_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar16_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar17_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar18_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar19_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        private void trackBar20_Scroll(object sender, EventArgs e)
        {
            Calculate_MeshMove_By_Parameter();
            Invalidate(true);
        }

        

        private void Load_Average_Face_Click(object sender, EventArgs e)
        {
             string json = File.ReadAllText("../AveragePoint.json");
             InitialPoint init = JsonConvert.DeserializeObject<InitialPoint>(json);
            for (int t = 0; t < 37; t++)
            {
                pointx[t] = init.PointX[t];
                pointy[t] = init.PointY[t];
            }
            Invalidate(true);
        }

    }
}
