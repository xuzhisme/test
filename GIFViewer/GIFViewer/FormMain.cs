using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace GIFViewer
{
    public partial class FormMain : Form
    {

        private int pw = 800;//程序启动宽
        private int ph = 480;//程序启动高

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(Image gif)
        {
            InitializeComponent();
            GifBox(gif, picBox);

            pw = gif.Width;
            ph = gif.Height;
        }

        public FormMain(string img)
        {
            InitializeComponent();
            ImageBox(img,picBox);

            Image timg = Image.FromFile(img);
            pw = timg.Width;
            ph = timg.Height;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            int h = SystemInformation.CaptionHeight;
            this.Width=pw+20;
            this.Height = ph + h+20;
        }

        private void ImageBox(string img, PictureBox pic)
        {
            try
            {
                pic.Load(img);
            }
            catch (Exception ex)
            {
                  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GifBox(Image gif, PictureBox pic)
        {
            FrameDimension fd = new FrameDimension(gif.FrameDimensionsList[0]);
            int count = gif.GetFrameCount(System.Drawing.Imaging.FrameDimension.Time);
           
            for (int i = 0; i < count; i++)
            {
                gif.SelectActiveFrame(fd, i);
                pic.Image = gif;
            }

        }

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.jpg;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (ofd.FileName.EndsWith(".gif"))
                    {
                        Image gif = Image.FromFile(ofd.FileName);
                        GifBox(gif, picBox);
                    }
                    else
                    {
                        ImageBox(ofd.FileName, picBox);
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmQuit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void tsmAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GiFViewer 2.0\n\nMade By Master Ye");
        }

      
      
    }
}
