using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindAverageTexture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            get_pixel();
        }

        public void get_pixel()
        {
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());

            Bitmap myBitmap = new Bitmap("../Crop/c7.jpg");
            for (int x = 0; x < myBitmap.Width; x++)
            {
                for (int y = 0; y < myBitmap.Height; y++)
                {
                    Color pixelColor = myBitmap.GetPixel(0, y);
                    // things we do with pixelColor
                    Console.WriteLine(pixelColor.R);
                }
            }

        }
    }
}
