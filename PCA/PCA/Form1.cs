﻿using System;
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
            public int Face { get; set; }
            public int[] PointX { get; set; }
            public int[] PointY { get; set; }
            public int[] PointZ { get; set; }
        }

        public class InitialPoint
        {
            public int[] PointX { get; set; }
            public int[] PointY { get; set; }
            public int[] PointZ { get; set; }
        }

        public static int[] pointx = new int[37];
        public static int[] pointy = new int[37];
        public static int[] pointz = new int[37];

        //public double[][] sourceMatrix { get; set; }

        public Form1()
        {
            //dgvFeatureVectors.AutoGenerateColumns = true;
            this.DoubleBuffered = true;
            InitializeComponent();                                   
        }
        
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
                string json = File.ReadAllText("../PointFace/PointFace" + faceIntt + ".json");
                InitialPoint init = JsonConvert.DeserializeObject<InitialPoint>(json);
                for (int t = 0; t < 37; t++) //init point x y z  if not point x y z can't update value follow json
                {
                    pointx[t] = init.PointX[t];
                    pointy[t] = init.PointY[t];
                    pointz[t] = init.PointZ[t];
                }

                // Create a matrix from the source data table
                //double[][] sourceMatrix = new double[][] { new double[] { 2, 3, 5 }, new double[] { 5, 6, 10 }, new double[] { 10, 15, 30 } };

                //insert data to array
                for (int x = 0; x < 37; x++)
                {
                    sourceMatrix[faceInt][x] = pointx[x];
                    //Console.WriteLine("x[" + x + "] :" + sourceMatrix[faceInt][x] + "\n");
                }
                for (int y = 0; y < 37; y++)
                {
                    sourceMatrix[faceInt][y + 37] = pointy[y];
                    //Console.WriteLine("y[" + y + "] :" + sourceMatrix[faceInt][y] + "\n");
                }
                for (int z = 0; z < 37; z++)
                {
                    sourceMatrix[faceInt][z + 74] = pointz[z];
                }
            }//load all face done

            //prepare Value Sum all of face per point
            double[] average = new double[111];
            double[][] SumOf1Point = new double[111][];
            for (int i=0;i<111;i++)
            {
                SumOf1Point[i] = new double[NumberOfFaceMax];
            }

            //Add Value all face per point to sum1point
            for (int point = 0; point < 111; point++)
            {
                for (int face = 0; face < NumberOfFaceMax; face++)
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
                        Console.WriteLine(face + "\n");
                        Console.WriteLine("Point " + point + ": " + average[point]);
                    }
                }//end inside for loop
            }//end outside for loop

            var method = (PrincipalComponentMethod)cbMethod.SelectedValue;
            // Create the Principal Component Analysis of the data
            pca = new PrincipalComponentAnalysis(method);

            pca.Learn(sourceMatrix);  // Finally, compute the analysis!
            MessageBox.Show("Learn PCA Done");          
                       
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


    }
}
