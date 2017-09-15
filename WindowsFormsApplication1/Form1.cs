using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
//using System.Text;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.OCR;
using System.Drawing.Imaging;
using tessnet2;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        OcrEngine ocr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ocr = new OcrEngine();
        }

        private void sAVeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|png (*.png)|*.png";
            if(sfd.ShowDialog() == DialogResult.OK && sfd.FileName.Length >0)
            {
                pictureBox1.Image.Save(sfd.FileName);
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        public enum State
        {
            Hiding,
            Filling_With_Zeros
        };
        
        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog ofd1 = new OpenFileDialog();

            if (ofd1.ShowDialog() == DialogResult.OK && ofd1.FileName.Length > 0)
            {
                if ((myStream = ofd1.OpenFile()) != null)
                {
                    string strfilename = ofd1.FileName;
                    string filetext = File.ReadAllText(strfilename);
                    textBox1.Text = filetext;
                    x = textBox1.Text;
               
                }
               
            }
        }
        string x;
        private void textToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void imageFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|png (*.png)|*.png";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = Image.FromFile(ofd.FileName);
               
            }
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void convertToTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*   ImageFormat imageFormat = null;
               imageFormat = ImageFormat.Jpeg;
               pictureBox1.Image.Save(@"C:/Users/yashharkhani/Pictures/100000test.jpg", imageFormat);
               ocr.Image = ImageStream.FromFile("C:/Users/yashharkhani/Pictures/100000test.jpg");
               if (ocr.Process())
               {
                   textBox1.Text = " " + ocr.Text;
               }
           */
            var image = ImageFormat.Jpeg;
            var varocr = new Tesseract();
            ocr.Init(@ "C:/Program Files (x86)/Tesseract-OCR/tessdata","eng", false);
            var result = ocr.DoOCR(image, Rectangle.Empty);
            foreach (tessnet2.Word word in result)
            {
                Console.writeline(textBox1.Text);
            }
        }
        
    }
}
