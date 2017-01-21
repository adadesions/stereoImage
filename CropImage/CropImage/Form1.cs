using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CropImage
{
    public partial class CropImage : Form
    {
        Boolean bHaveMouse;
        Point ptOriginal = new Point();
        Point ptLast = new Point();
        Rectangle rectCropArea;
        //Image srcImage = null;
        Bitmap sourceBitmap { get; set; }
        Bitmap targetBitmap { get; set;}

        public CropImage()
        {
            bHaveMouse = false;
            InitializeComponent();
            
        }        

        private void SrcPicBox_MouseUp(object sender, MouseEventArgs e)
        {
            // Set internal flag to know we no longer "have the mouse".
            bHaveMouse = false;

            // If we have drawn previously, draw again in that spot
            // to remove the lines.
            if (ptLast.X != -1)
            {
                Point ptCurrent = new Point(e.X, e.Y);

                // Display coordinates
                lbCordinates.Text = "Coordinates  :  " + ptOriginal.X.ToString() + ", " +
                    ptOriginal.Y.ToString() + " And " + e.X.ToString() + ", " + e.Y.ToString();

            }

            // Set flags to know that there is no "previous" line to reverse.
            ptLast.X = -1;
            ptLast.Y = -1;
            ptOriginal.X = -1;
            ptOriginal.Y = -1;
        }

        private void SrcPicBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Make a note that we "have the mouse".
            bHaveMouse = true;

            // Store the "starting point" for this rubber-band rectangle.
            ptOriginal.X = e.X;
            ptOriginal.Y = e.Y;

            // Special value lets us know that no previous
            // rectangle needs to be erased.

            // Display coordinates
            lbCordinates.Text = "Coordinates  :  " + e.X.ToString() + ", " + e.Y.ToString();

            ptLast.X = -1;
            ptLast.Y = -1;

            rectCropArea = new Rectangle(new Point(e.X, e.Y), new Size());
        }

        private void SrcPicBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point ptCurrent = new Point(e.X, e.Y);

            // If we "have the mouse", then we draw our lines.
            if (bHaveMouse)
            {
                // If we have drawn previously, draw again in
                // that spot to remove the lines.
                if (ptLast.X != -1)
                {
                    // Display Coordinates
                    lbCordinates.Text = "Coordinates  :  " + ptOriginal.X.ToString() + ", " +
                        ptOriginal.Y.ToString() + " And " + e.X.ToString() + ", " + e.Y.ToString();
                }

                // Update last point.
                ptLast = ptCurrent;

                // Draw new lines.

                // e.X - rectCropArea.X;
                // normal
                if (e.X > ptOriginal.X && e.Y > ptOriginal.Y)
                {
                    rectCropArea.Width = e.X - ptOriginal.X;

                    // e.Y - rectCropArea.Height;
                    rectCropArea.Height = e.Y - ptOriginal.Y;
                }
                else if (e.X < ptOriginal.X && e.Y > ptOriginal.Y)
                {
                    rectCropArea.Width = ptOriginal.X - e.X;
                    rectCropArea.Height = e.Y - ptOriginal.Y;
                    rectCropArea.X = e.X;
                    rectCropArea.Y = ptOriginal.Y;
                }
                else if (e.X > ptOriginal.X && e.Y < ptOriginal.Y)
                {
                    rectCropArea.Width = e.X - ptOriginal.X;
                    rectCropArea.Height = ptOriginal.Y - e.Y;

                    rectCropArea.X = ptOriginal.X;
                    rectCropArea.Y = e.Y;
                }
                else
                {
                    rectCropArea.Width = ptOriginal.X - e.X;

                    // e.Y - rectCropArea.Height;
                    rectCropArea.Height = ptOriginal.Y - e.Y;
                    rectCropArea.X = e.X;
                    rectCropArea.Y = e.Y;
                }
                SrcPicBox.Refresh();
            }
        }
       
        private void Crop_Click(object sender, EventArgs e)
        {
            TargetPicBox.Refresh();
            
            //Prepare a new Bitmap on which the cropped image will be drawn
            sourceBitmap = new Bitmap(SrcPicBox.Image, SrcPicBox.Width, SrcPicBox.Height);
            targetBitmap = new Bitmap(355, 365);
            Graphics g1 = Graphics.FromImage(sourceBitmap); //เปิดแล้ว ภาพครอปถูกเซฟด้วย
            Graphics g2 = TargetPicBox.CreateGraphics(); //ทำให้ภาพครอปขึ้นที่ TargetPic
                     
            //Checks if the co-rdinates check-box is checked. If yes, then Selection is based on co-rdinates mentioned in the textbox
            if (chkCropCordinates.Checked)
            {
                //logic to retreive co-rdinates from comma-separated string values
                lbCordinates.Text = "";
                string[] cordinates = tbCordinates.Text.ToString().Split(',');
                int cord0, cord1, cord2, cord3;

                try
                {
                    cord0 = Convert.ToInt32(cordinates[0]);
                    cord1 = Convert.ToInt32(cordinates[1]);
                    cord2 = Convert.ToInt32(cordinates[2]);
                    cord3 = Convert.ToInt32(cordinates[3]);
                }
                catch (Exception ex)
                {
                    lbCordinates.Text = ex.Message;
                    return;
                }

                //Various combinations of selection rectangle being dragged in different directions

                if ((cord0 < cord2 && cord1 < cord3))
                {
                    rectCropArea = new Rectangle(cord0, cord1, cord2 - cord0, cord3 - cord1);
                }
                else if (cord2 < cord0 && cord3 > cord1)
                {
                    rectCropArea = new Rectangle(cord2, cord1, cord0 - cord2, cord3 - cord1);
                }
                else if (cord2 > cord0 && cord3 < cord1)
                {
                    rectCropArea = new Rectangle(cord0, cord3, cord2 - cord0, cord1 - cord3);
                }
                else
                {
                    rectCropArea = new Rectangle(cord2, cord3, cord0 - cord2, cord1 - cord3);
                }
            }

            //Draw the image on the Graphics object with the new dimesions
            
            g2.DrawImage(sourceBitmap, new Rectangle(0, 0, TargetPicBox.Width, TargetPicBox.Height),
               rectCropArea, GraphicsUnit.Pixel);
            //g2 = Graphics.FromImage(targetBitmap);

            g1.DrawImage(sourceBitmap, new Rectangle(0, 0, SrcPicBox.Width, SrcPicBox.Height),
               rectCropArea, GraphicsUnit.Pixel); //ทำให้ภาพครอปเซฟ แต่ภาพตัวอย่างเพี้ยน
            
            //TargetPicBox.Image.Save(AppDomain.CurrentDomain.BaseDirectory +"10000test.jpg");   
            //Good practice to dispose the System.Drawing objects when not in use.
            //sourceBitmap.Dispose();           

        }

        private void chkCropCordinates_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCropCordinates.Checked)
            {
                tbCordinates.Visible = true;
            }
            else
            {
                tbCordinates.Visible = false;
            }
        }

        private void SrcPicBox_Paint(object sender, PaintEventArgs e)
        {
            Pen drawLine = new Pen(Color.Black);
            drawLine.DashStyle = DashStyle.Dash;
            e.Graphics.DrawRectangle(drawLine, rectCropArea);
        }

        private void Select_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image img = Image.FromFile(open.FileName);
                SrcPicBox.Image = img;
            }
        }

        private void tbCordinates_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Following allows only numbers and comma for givng expected input
            if (!char.IsControl(e.KeyChar)
       && !char.IsDigit(e.KeyChar)
       && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            //Only allow comma as separator for specifying co-ordinates
            if (e.KeyChar == ',')
            {
                e.Handled = false;
            }

        }

        private void Save_Image_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.sourceBitmap.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        this.sourceBitmap.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        this.Save_Image.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
            
            sourceBitmap.Dispose();           
        }
    }
}
