using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class Formrec : Form
    {//- -!、、尼玛 我感觉所谓的热区 在我这里其实就是再做一份图像出来
        public Formrec()
        {
            InitializeComponent();
            this.pictureBox_rec.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox_rec.BorderStyle = BorderStyle.Fixed3D;
            this.pictureBox_rec.Location = new Point(0, 0);
        }
        Bitmap srcImg;      //原始图片
        Bitmap infoImg;     //参考图片
        Label lbInfo;       //显示信息

        private void Formrec_Load(object sender, EventArgs e)
        {
            srcImg = new Bitmap("srcImage.jpg");        //加载图像
            infoImg = new Bitmap("infoImage.bmp");
            pictureBox_rec.Image = srcImg;                 //显示原图 - -！、尼玛感觉srcImage创建出来是多余的
            this.Width = pictureBox_rec.Width + (this.Bounds.Width - this.ClientSize.Width);
            this.Height = pictureBox_rec.Height + (this.Bounds.Height - this.ClientSize.Height);
            //设置label
            lbInfo = new Label();
            this.Controls.Add(lbInfo);
            lbInfo.Text = "图像热识别";
            lbInfo.Parent = pictureBox_rec;
            lbInfo.BackColor = Color.FromArgb(150, 0, 0, 0);
            lbInfo.ForeColor = Color.White;
            lbInfo.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void pictureBox_rec_MouseMove(object sender, MouseEventArgs e)
        {
            Color clr = infoImg.GetPixel(e.X, e.Y);         //获取在参考图对应坐标像素点的颜色信息
            if (clr.ToArgb() != Color.Black.ToArgb())
            {
                pictureBox_rec.Cursor = Cursors.Hand;          //设置手形
                if (clr.ToArgb() == Color.FromArgb(255, 255,1, 1).ToArgb())
                    lbInfo.Text = "白色小花";                   //对颜色进行判断
                else if (clr.ToArgb() == Color.FromArgb(255, 255, 1,193).ToArgb())
                    lbInfo.Text = "眼镜";
                else if (clr.ToArgb() == Color.FromArgb(255,36,1, 253).ToArgb())
                    lbInfo.Text = "蝴蝶结";
                else if (clr.ToArgb() == Color.FromArgb(255, 0, 247, 168).ToArgb())
                    lbInfo.Text = "KISS";
                else if (clr.ToArgb() == Color.FromArgb(255, 1, 247, 0).ToArgb())
                    lbInfo.Text = "蓝色小点点";
                else if (clr.ToArgb() == Color.FromArgb(255, 203, 247, 0).ToArgb())
                    lbInfo.Text = "飞机";
                else if (clr.ToArgb() == Color.FromArgb(255, 255,255, 255).ToArgb())
                    lbInfo.Text = "背景";
            }
            else
            {
                pictureBox_rec.Cursor = Cursors.Arrow;
                lbInfo.Text = "我也不知道这是什么:)";
            }
            //设置label位置
            if (e.X + 20 + lbInfo.Width >= pictureBox_rec.Width)
                lbInfo.Left = e.X - 20 - lbInfo.Width;
            else
                lbInfo.Left = e.X + 20;
            if (e.Y + 20 + lbInfo.Height >= pictureBox_rec.Height)
                lbInfo.Top = e.Y - 20 - lbInfo.Height;
            else
                lbInfo.Top = e.Y + 20;
        }
    }
}
