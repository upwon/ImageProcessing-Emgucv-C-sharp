using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.IO;

namespace Image_Processing
{
    public partial class FormImage : Form
    {
        private Bitmap originalBt;//定义三个位图变量
        private Bitmap bt1;
        private Bitmap bt2;
       
        public FormImage()
        {
            InitializeComponent();
            Size size = new Size(1400, 780);  //第一个参数是宽度，第二个参数是高度

            this.Size = size;
        }
            //显示时间             
        private void timerMain_Tick(object sender, EventArgs e)
        {
            panelDate.Text = System.DateTime.Now.ToLongDateString();   //显示年月日
            panelTime.Text = System.DateTime.Now.ToLongTimeString();   //显示时分秒
        }

       /* private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormAbout()).ShowDialog();
        }
*/
        private void 打开图像ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "位图文件(*.bmp)|*.bmp|Jpeg文件(*.jpg)|*.jpg";//判断是否为指定类型的图片文件
            ofd.FilterIndex = 2;
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = System.Drawing.Image.FromFile(ofd.FileName.ToString());
                    panelPath.Text = "文件路径:" + ofd.FileName;//显示文件所在路径
                    panelSize.Text = pictureBox1.Image.Width.ToString() + "×" + pictureBox1.Image.Height.ToString(); //显示图片的大小
                }
                originalBt = new Bitmap(pictureBox1.Image);//将图片框内的图像赋给一个变量对象，保存着原始的图片
            }
            catch (Exception)//打开文件可能出现异常
            {
            } 
        }

        //对当前处理的图像进行复原，还原到原始图片
        private void 还原ToolStripMenuItem_Click(object sender, EventArgs e)//还原
        {
            
            pictureBox2.Image = originalBt;
            pictureBox2.Refresh();  //更新
        }

        private void 重载ToolStripMenuItem_Click(object sender, EventArgs e)//把图像框2的图像赋值给图像框1
        {
            try
            {
                bt2 = new Bitmap(pictureBox2.Image);
                pictureBox1.Image = bt2;
                pictureBox1.Refresh();
            }
            catch (Exception)
            { }
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)//另存为图像
        {
            
            SaveFileDialog newpicture = new SaveFileDialog();
            newpicture.Filter = ("jpg文件(*.jpg)|.jpg|位图文件(*.gif)|.gif");

            if (newpicture.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(newpicture.FileName);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)//退出程序
        {
            
            Application.Exit();
        }

        private void 负像ToolStripMenuItem_Click(object sender, EventArgs e)//负像
        {
             if (pictureBox1.Image == null)
             {
                 MessageBox.Show("错误，没有导入图片！");//判断图片框是否有图片，如果无图片，则给出错误信息
                 return;
             }
             bt1 = new Bitmap(pictureBox1.Image);
             bt2 = new Bitmap(pictureBox1.Image); //定义两个位图对象
             Color color = new Color();//定义一个颜色对象
             int Red, Green, Blue;
             for (int i = 0; i < bt1.Width; i++)
             {
                 for (int j = 1; j < bt2.Height; j++)
                 {
                     color = bt1.GetPixel(i, j); //获取每个像素的色彩信息

                     Red = 255 - color.R;
                     Green = 255 - color.G;
                     Blue = 255 - color.B;//负像处理

                     bt2.SetPixel(i, j, Color.FromArgb(Red, Green, Blue));
                 }
                 pictureBox2.Refresh();//刷新图片框
                 pictureBox2.Image = bt2;
             }

           /* 
            //以底片效果显示图像
            try
            {
                int Height = this.pictureBox1.Image.Height;
                int Width = this.pictureBox1.Image.Width;
                Bitmap newbitmap = new Bitmap(Width, Height);
                Bitmap oldbitmap = (Bitmap)this.pictureBox1.Image;
                Color pixel;
                for (int x = 1; x < Width; x++)
                {
                    for (int y = 1; y < Height; y++)
                    {
                        int r, g, b;
                        pixel = oldbitmap.GetPixel(x, y);
                        r = 255 - pixel.R;
                        g = 255 - pixel.G;
                        b = 255 - pixel.B;
                        newbitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
                this.pictureBox2.Image = newbitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

        private void 灰度化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");//判断图片框是否有图片，如果无图片，则给出错误信息
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image); //定义两个位图对象
            Color color = new Color();//定义一个颜色对象            
            for (int i = 0; i < bt1.Width; i++)
            {
                for (int j = 0; j < bt1.Height; j++)
                {
                    color = bt1.GetPixel(i, j); //获取每个像素的色彩信息
                    int n = (int)((color.G * 59 + color.R * 30 + color.B * 11) / 100); //根据GRB的不同的权值生成新的灰度值
                    bt2.SetPixel(i, j, Color.FromArgb(n, n, n)); //给该像素的每种色彩分量均赋予相同的灰度值，完成灰度图像的转换
                }
                pictureBox2.Refresh();//刷新图片框
                pictureBox2.Image = bt2;
            }
        }


        private void 黑白效果ToolStripMenuItem_Click(object sender, EventArgs e)//以黑白效果显示图像
        {
            
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image); //定义两个位图对象
            try
            {
                int Height = this.pictureBox1.Image.Height;
                int Width = this.pictureBox1.Image.Width;
                Bitmap newBitmap = new Bitmap(Width, Height);
                Bitmap oldBitmap = (Bitmap)this.pictureBox1.Image;
                Color pixel;

                for (int i = 0; i < bt1.Width; i++)
                {
                    for (int j = 0; j < bt1.Height; j++)
                    {
                        pixel = bt1.GetPixel(i, j);//获取每个像素的色彩信息
                        int r, g, b, Result = 0;
                        r = pixel.R;
                        g = pixel.G;
                        b = pixel.B;
                        Result = ((r + g + b) / 3);//平均值法，生成新的黑白值
                        bt2.SetPixel(i, j, Color.FromArgb(Result, Result, Result));//给该像素的每种色彩分量均赋予相同的度值，完成黑白图像的转换

                        // color = bt1.GetPixel(i, j); 
                        
                    }
                    pictureBox2.Refresh();//刷新图片框
                    pictureBox2.Image = bt2;
                }

          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }
        }

        private void 平移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }

            FormPingYi formPingYi = new FormPingYi();
            formPingYi.ShowDialog();
            int x = formPingYi.XValue();
            int y = formPingYi.YValue();//设置图像偏移量

            if (x >= 0 && y >= 0)
            {
                bt1 = new Bitmap(pictureBox1.Image);
                //bt2 = new Bitmap(pictureBox1.Image);
                bt2 = new Bitmap(pictureBox1.Width + x, pictureBox1.Height + y);//【掌握此方法】
                int R, G, B;
                int[, ,] RGB = new int[pictureBox1.Image.Width, pictureBox1.Image.Height, 3];
                for (int i = 0; i < bt1.Width; i++)
                {
                    for (int j = 0; j < bt1.Height; j++)
                    {
                        Color color = bt1.GetPixel(i, j);
                        RGB[i, j, 0] = color.R;
                        RGB[i, j, 1] = color.G;
                        RGB[i, j, 2] = color.B;
                    }
                }
                for (int i = 0; i < bt1.Width; i++)
                {
                    for (int j = 0; j < bt1.Height; j++)
                    {
                        R = RGB[i, j, 0];
                        G = RGB[i, j, 1];
                        B = RGB[i, j, 2];
                        bt2.SetPixel(i + x, j + y, Color.FromArgb(R, G, B));
                    }
                    pictureBox2.Refresh();
                    pictureBox2.Image = bt2;
                }
            }
            else
            {
                MessageBox.Show("错误，请输入非负数！");
            }
        }

        private void 加噪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            Random random = new Random();//定义一个随机类的对象ran
            for (int i = 0; i < bt1.Width; i++)
            {
                for (int j = 0; j < bt1.Height; j++)
                {
                    int R, G, B;
                    double ran = random.NextDouble();//返回介于0.0~1.0之间的数
                    R = bt1.GetPixel(i, j).R;
                    G = bt1.GetPixel(i, j).G;
                    B = bt1.GetPixel(i, j).B;
                    if (ran > 0.85)
                    {
                        R = 255;
                        G = 255;
                        B = 255;
                    }
                    if (ran < 0.15)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                    }
                    bt2.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 图像缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            int k = 2;  //定义图像缩小的倍数
            bt1 = new Bitmap(pictureBox1.Image);
            //bt2 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Width / k, pictureBox1.Height / k);//两种方法
            int Red, Green, Blue;
            for (int i = 0; i < bt1.Width - 1; i++)
            {
                for (int j = 0; j < bt1.Height - 1; j++)
                {
                    Red = bt1.GetPixel(i, j).R;
                    Green = bt1.GetPixel(i, j).G;
                    Blue = bt1.GetPixel(i, j).B;
                    bt2.SetPixel((int)(i / k), (int)(j / k), Color.FromArgb(Red, Green, Blue));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 简单二值化ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");//判断图片框是否有图片，如果无图片，则给出错误信息
                return;
            }
            Color color = new Color();//定义一个色彩变量对象
            int Red, Green, Blue; //定义红、绿、蓝三色和亮度
            double Y;
            bt1 = new Bitmap(pictureBox1.Image); //定义一个位图文件并将图片框内的图像赋值给它
            bt2 = new Bitmap(pictureBox1.Image);

            FormBinary formBinary = new FormBinary();
            formBinary.ShowDialog();
            int brightThreshole = formBinary.BinaryValue();//此值用于二值化的阈值

            for (int i = 0; i < bt1.Width; i++)
            {
                for (int j = 0; j < bt1.Height; j++)//循环处理图像中的每一个像素点
                {
                    color = bt1.GetPixel(i, j); //获取当前像素点的色彩信息
                    Red = color.R; //获取当前像素点的红色分量
                    Green = color.G; //获取当前像素点的绿色分量
                    Blue = color.B; //获取当前像素点的蓝色分量
                    Y = 0.59 * Red + 0.3 * Green + 0.11 * Blue; //计算当前像素点的亮度
                    if (Y > brightThreshole) //如果当前像素点的亮度大于指定阈值
                    {
                        //那么定义一个纯白的色彩变量，即各分量均为255
                        bt2.SetPixel(i, j, Color.FromArgb(255, 255, 255)); //将白色变量赋给当前像素点
                    }
                    if (Y <= brightThreshole) //如果当前像素点的亮度小于指定阈值
                    {
                        //那么定义一个纯黑的色彩变量，即各分量均为0
                        bt2.SetPixel(i, j, Color.FromArgb(0, 0, 0)); //将黑色变量赋给当前像素点
                    }
                }
                pictureBox2.Refresh();//刷新图片框
                pictureBox2.Image = bt2; //将重新生成的图片赋值给图片框
            }
        }

        private void 透明变换ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");//判断图片框是否有图片，如果无图片，则给出错误信息
                return;
            }
            int Red, Green, Blue;
            bt1 = new Bitmap(pictureBox1.Image); //定义一个位图文件并将图片框内的图像赋值给它
            bt2 = new Bitmap(pictureBox1.Image);

            FormTouMing formTouMingBH = new FormTouMing();
            formTouMingBH.ShowDialog();
            int a = formTouMingBH.TouMingBHValue();//此值用于二值化的阈值

            for (int i = 0; i < bt1.Width; i++)
            {
                for (int j = 0; j < bt1.Height; j++)//循环处理图像中的每一个像素点
                {
                    Red = bt1.GetPixel(i, j).R;
                    Green = bt1.GetPixel(i, j).G;
                    Blue = bt1.GetPixel(i, j).B;
                    bt2.SetPixel(i, j, Color.FromArgb(a, Red, Green, Blue));  //透明处理方法---改变 a 的值即可            
                }
                pictureBox2.Refresh();//刷新图片框
                pictureBox2.Image = bt2; //将重新生成的图片赋值给图片框
            }
        }


        private void 色彩平衡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            Color color = new Color();

            FormColorPingHeng formColorPH = new FormColorPingHeng();
            formColorPH.ShowDialog();
            int R1 = formColorPH.valueR;
            int G1 = formColorPH.valueG;
            int B1 = formColorPH.valueB;
            int Red, Green, Blue;

            for (int i = 0; i < bt1.Width; i++)
            {
                for (int j = 0; j < bt1.Height; j++)
                {
                    int R, G, B;
                    color = bt1.GetPixel(i, j);
                    R = color.R;
                    G = color.G;
                    B = color.B;
                    Red = R + R1;
                    Green = G + G1;
                    Blue = B + B1;
                    if (Red > 255) Red = 255; //判断是否超出各分量允许的范围，如果大于255则只能等于255
                    if (Red < 0) Red = 0; //如果小于0则只能等于0
                    if (Green > 255) Green = 255;
                    if (Green < 0) Green = 0;
                    if (Blue > 255) Blue = 255;
                    if (Blue < 0) Blue = 0;
                    bt2.SetPixel(i, j, Color.FromArgb(Red, Green, Blue));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 上下翻转ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            for (int j = 0; j < (int)((bt1.Height - 1) / 2); j++)
            {
                for (int i = 0; i < bt1.Width; i++)
                {
                    int R1, R2, G1, G2, B1, B2;
                    R1 = bt1.GetPixel(i, j).R;
                    R2 = bt1.GetPixel(i, bt1.Height - 1 - j).R;

                    G1 = bt1.GetPixel(i, j).G;
                    G2 = bt1.GetPixel(i, bt1.Height - 1 - j).G;

                    B1 = bt1.GetPixel(i, j).B;
                    B2 = bt1.GetPixel(i, bt1.Height - 1 - j).B;

                    bt2.SetPixel(i, j, Color.FromArgb(R2, G2, B2));
                    bt2.SetPixel(i, bt1.Height - 1 - j, Color.FromArgb(R1, G1, B1));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 左右翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < (int)((bt1.Width - 1) / 2); i++)
            {
                for (int j = 0; j < bt1.Height; j++)
                {
                    int R1, R2, G1, G2, B1, B2;
                    R1 = bt1.GetPixel(i, j).R;
                    R2 = bt1.GetPixel(bt1.Width - 1 - i, j).R;

                    G1 = bt1.GetPixel(i, j).G;
                    G2 = bt1.GetPixel(bt1.Width - 1 - i, j).G;

                    B1 = bt1.GetPixel(i, j).B;
                    B2 = bt1.GetPixel(bt1.Width - 1 - i, j).B;

                    bt2.SetPixel(i, j, Color.FromArgb(R2, G2, B2));
                    bt2.SetPixel(bt1.Width - 1 - i, j, Color.FromArgb(R1, G1, B1));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 中心旋转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            for (int i = 0; i < bt1.Width; i++)
            {
                for (int j = 0; j < bt1.Height; j++)
                {
                    int R, G, B;
                    R = bt1.GetPixel(i, j).R;
                    G = bt1.GetPixel(i, j).G;
                    B = bt1.GetPixel(i, j).B;
                    bt2.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 伪彩色ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int Red, Green, Blue;
            for (int i = 0; i < bt1.Width; i++)
            {
                for (int j = 0; j < bt1.Height; j++)
                {
                    // 因为已经是灰度色，
                    // 这里只取蓝色分量作为灰度进行运算
                    int R = bt1.GetPixel(i, j).R;
                    // 伪彩色处理方法
                    Red = Green = Blue = 0;
                    switch (R / 64)
                    {
                        case 0:
                            Red = 0;
                            Green = 4 * R;
                            Blue = 255;
                            break;
                        case 1:
                            Red = 0;
                            Green = 255;
                            Blue = 511 - 4 * R;
                            break;
                        case 2:
                            Red = 4 * R - 511;
                            Green = 255;
                            Blue = 0;
                            break;
                        case 3:
                            Red = 255;
                            Green = 1023 - 4 * R;
                            Blue = 0;
                            break;
                    }
                    bt2.SetPixel(i, j, Color.FromArgb(Red, Green, Blue));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 直方图扩展ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            Color color = new Color();
            int Red, Green, Blue;
            int Low = 50, High = 150;//可以改变这Low、High的值
            int a, b;
            a = -255 * Low / (High - Low);
            b = 255 / (High - Low);     //映射方程为：y = a + b * x;
            for (int i = 0; i < bt1.Width; i++)
            {
                for (int j = 0; j < bt1.Height; j++)
                {
                    color = bt1.GetPixel(i, j);
                    Red = color.R;
                    Green = color.G;
                    Blue = color.B;

                    Red = a + b * Red;
                    Green = a + b * Green;
                    Blue = a + b * Blue;

                    if (Red > 255) Red = 255; //判断是否超出各分量允许的范围，如果大于255则只能等于255
                    if (Red < 0) Red = 0; //如果小于0则只能等于0
                    if (Green > 255) Green = 255;
                    if (Green < 0) Green = 0;
                    if (Blue > 255) Blue = 255;
                    if (Blue < 0) Blue = 0;

                    bt2.SetPixel(i, j, Color.FromArgb(Red, Green, Blue));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 亮度调节ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //亮度调节就是修改像素分量的值使得其根据调节值改变图像的亮度
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }

            FormLiangDu formLD = new FormLiangDu();
            formLD.ShowDialog();
            int value = formLD.LDValue();//用于调节亮度

            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int R, G, B;
            //逐个扫描原始图片的像素
            for (int i = 0; i < bt1.Width; i++)
            {
                for (int j = 0; j < bt1.Height; j++)
                {
                    //获取位于(i,j)坐标的像素然后提取RGB分量
                    Color color = bt1.GetPixel(i, j);
                    R = color.R;
                    G = color.G;
                    B = color.B;
                    //对RGB分量进行增加或删除，增加量为滑杆滑动的量
                    R += value;
                    G += value;
                    B += value;
                    if (R > 255) R = 255;
                    if (R < 0) R = 0;
                    if (G > 255) G = 255;
                    if (G < 0) G = 0;
                    if (B > 255) B = 255;
                    if (B < 0) B = 0;
                    bt2.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 对比度调节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            Color color = new Color();

            FormDuiBidu formDuiBD = new FormDuiBidu();
            formDuiBD.ShowDialog();
            int degree = formDuiBD.DuiBDValue();//此值用于调节对比度

            if (degree < -100) degree = -100;
            if (degree > 100) degree = 100;
            double contrast = (100.0 + degree) / 100.0;
            contrast *= contrast;

            int Red, Green, Blue;
            for (int i = 0; i < bt1.Width; i++)
            {
                for (int j = 0; j < bt1.Height; j++)
                {
                    int R, G, B; 
                    color = bt1.GetPixel(i, j);
                    R = color.R;
                    G = color.G;
                    B = color.B;

                    Red = (int)(((R / 255.0 - 0.5) * contrast + 0.5) * 255);
                    Green = (int)(((G / 255.0 - 0.5) * contrast + 0.5) * 255);
                    Blue = (int)(((B / 255.0 - 0.5) * contrast + 0.5) * 255);

                    if (Red > 255) Red = 255; //判断是否超出各分量允许的范围，如果大于255则只能等于255
                    if (Red < 0) Red = 0; //如果小于0则只能等于0
                    if (Green > 255) Green = 255;
                    if (Green < 0) Green = 0;
                    if (Blue > 255) Blue = 255;
                    if (Blue < 0) Blue = 0;

                    bt2.SetPixel(i, j, Color.FromArgb(Red, Green, Blue));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 饱和度调节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            Color color = new Color();

            FormBaoHeDu formBaoHeDu = new FormBaoHeDu();
            formBaoHeDu.ShowDialog();
            int H = formBaoHeDu.valueH;
            int S = formBaoHeDu.valueS;
            int I = formBaoHeDu.valueI;

            

            int Red, Green, Blue;
            double Hudu = Math.PI / 180;

            if (H >= 0 && H <= 120)
            {
                for (int i = 0; i < bt1.Width; i++)
                {
                    for (int j = 0; j < bt1.Height; j++)
                    {
                        int R, G, B;
                        color = bt1.GetPixel(i, j);
                        R = color.R;
                        G = color.G;
                        B = color.B;

                        Blue = B + I * (I - S);
                        Red = (int)(R + I * (1 + (S * Math.Cos(H * Hudu) / (Math.Cos((60 - H) * Hudu)))));
                        Green = G + 3 * I - (Blue + Red);

                        if (Red > 255) Red = 255; //判断是否超出各分量允许的范围，如果大于255则只能等于255
                        if (Red < 0) Red = 0; //如果小于0则只能等于0
                        if (Green > 255) Green = 255;
                        if (Green < 0) Green = 0;
                        if (Blue > 255) Blue = 255;
                        if (Blue < 0) Blue = 0;
                        bt2.SetPixel(i, j, Color.FromArgb(Red, Green, Blue));
                    }
                    pictureBox2.Refresh();
                    pictureBox2.Image = bt2;
                }
            }

            if (H >120 && H <= 240)
            {
                for (int i = 0; i < bt1.Width; i++)
                {
                    for (int j = 0; j < bt1.Height; j++)
                    {
                        int R, G, B;
                        color = bt1.GetPixel(i, j);
                        R = color.R;
                        G = color.G;
                        B = color.B;

                        Red = R + I * (I - S);
                        Green = (int)(G + I * (1 + (S * Math.Cos((H - 120) * Hudu) / (Math.Cos((180 - H) * Hudu)))));
                        Blue = B + 3 * I - (Green + Red);

                        if (Red > 255) Red = 255; //判断是否超出各分量允许的范围，如果大于255则只能等于255
                        if (Red < 0) Red = 0; //如果小于0则只能等于0
                        if (Green > 255) Green = 255;
                        if (Green < 0) Green = 0;
                        if (Blue > 255) Blue = 255;
                        if (Blue < 0) Blue = 0;
                        bt2.SetPixel(i, j, Color.FromArgb(Red, Green, Blue));
                    }
                    pictureBox2.Refresh();
                    pictureBox2.Image = bt2;
                }
            }

            if (H >240 && H <= 360)
            {
                for (int i = 0; i < bt1.Width; i++)
                {
                    for (int j = 0; j < bt1.Height; j++)
                    {
                        int R, G, B;
                        color = bt1.GetPixel(i, j);
                        R = color.R;
                        G = color.G;
                        B = color.B;

                        Green = G + I * (I - S);
                        Blue = (int)(B + I * (1 + (S * Math.Cos((H - 120) * Hudu) / (Math.Cos((300 - H) * Hudu)))));
                        Red = R + 3 * I - (Blue + Green);

                        if (Red > 255) Red = 255; //判断是否超出各分量允许的范围，如果大于255则只能等于255
                        if (Red < 0) Red = 0; //如果小于0则只能等于0
                        if (Green > 255) Green = 255;
                        if (Green < 0) Green = 0;
                        if (Blue > 255) Blue = 255;
                        if (Blue < 0) Blue = 0;
                        bt2.SetPixel(i, j, Color.FromArgb(Red, Green, Blue));
                    }
                    pictureBox2.Refresh();
                    pictureBox2.Image = bt2;
                }
            }

        }

        private void 边缘增强ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");//判断图片框是否有图片，如果无图片，则给出错误信息
                return;
            }

            FormEdgeStrengthen formES = new FormEdgeStrengthen();
            formES.ShowDialog();
            int ES = formES.EdgeStrengthen;
     
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image); //定义两个位图对象
            int R1, R2, R3, R4, R5, R6, R7, R8, Red;
            int G1, G2, G3, G4, G5, G6, G7, G8, Green;
            int B1, B2, B3, B4, B5, B6, B7, B8, Blue;
            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {
                    R1 = bt1.GetPixel(i - 1, j - 1).R;
                    R2 = bt1.GetPixel(i, j - 1).R;
                    R3 = bt1.GetPixel(i + 1, j - 1).R;
                    R4 = bt1.GetPixel(i - 1, j).R;
                    R5 = bt1.GetPixel(i + 1, j).R;
                    R6 = bt1.GetPixel(i - 1, j + 1).R;
                    R7 = bt1.GetPixel(i, j + 1).R;
                    R8 = bt1.GetPixel(i + 1, j + 1).R;
                    Red = Math.Max(Math.Max(Math.Abs(R1 - R8), Math.Abs(R6 - R3)), Math.Max(Math.Abs(R4 - R5), Math.Abs(R2 - R7)));
                   
                    G1 = bt1.GetPixel(i - 1, j - 1).G;
                    G2 = bt1.GetPixel(i, j - 1).G;
                    G3 = bt1.GetPixel(i + 1, j - 1).G;
                    G4 = bt1.GetPixel(i - 1, j).G;
                    G5 = bt1.GetPixel(i + 1, j).G;
                    G6 = bt1.GetPixel(i - 1, j + 1).G;
                    G7 = bt1.GetPixel(i, j + 1).G;
                    G8 = bt1.GetPixel(i + 1, j + 1).G;
                    Green = Math.Max(Math.Max(Math.Abs(G1 - G8), Math.Abs(G6 - G3)), Math.Max(Math.Abs(G4 - G5), Math.Abs(G2 - G7)));

                    B1 = bt1.GetPixel(i - 1, j - 1).B;
                    B2 = bt1.GetPixel(i, j - 1).B;
                    B3 = bt1.GetPixel(i + 1, j - 1).B;
                    B4 = bt1.GetPixel(i - 1, j).B;
                    B5 = bt1.GetPixel(i + 1, j).B;
                    B6 = bt1.GetPixel(i - 1, j + 1).B;
                    B7 = bt1.GetPixel(i, j + 1).B;
                    B8 = bt1.GetPixel(i + 1, j + 1).B;
                    Blue = Math.Max(Math.Max(Math.Abs(B1 - B8), Math.Abs(B6 - B3)), Math.Max(Math.Abs(B4 - B5), Math.Abs(B2 - B7)));
                   
                    if (Red < ES||Green<ES||Blue<ES)
                    {
                        bt2.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }

                    bt2.SetPixel(i, j, Color.FromArgb(Red, Green, Blue));
                }
                pictureBox2.Refresh();//刷新图片框
                pictureBox2.Image = bt2;
            }
        }

        private void 四邻域平均ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");//判断图片框是否有图片，如果无图片，则给出错误信息
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image); //定义两个位图对象
            int R1, R2, R3, R4, Red;
            int G1, G2, G3, G4, Green;
            int B1, B2, B3, B4, Blue;
            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {
                    R1 = bt1.GetPixel(i, j - 1).R;
                    R2 = bt1.GetPixel(i, j + 1).R;
                    R3 = bt1.GetPixel(i - 1, j).R;
                    R4 = bt1.GetPixel(i + 1, j).R;
                    Red = (R1 + R2 + R3 + R4) / 5;

                    G1 = bt1.GetPixel(i, j - 1).G;
                    G2 = bt1.GetPixel(i, j + 1).G;
                    G3 = bt1.GetPixel(i - 1, j).G;
                    G4 = bt1.GetPixel(i + 1, j).G;
                    Green = (G1 + G2 + G3 + G4) / 5;

                    B1 = bt1.GetPixel(i, j - 1).B;
                    B2 = bt1.GetPixel(i, j + 1).B;
                    B3 = bt1.GetPixel(i - 1, j).B;
                    B4 = bt1.GetPixel(i + 1, j).B;
                    Blue = (B1 + B2 + B3 + B4) / 5;

                    bt2.SetPixel(i, j, Color.FromArgb(Red, Green, Blue));
                }
                pictureBox2.Refresh();//刷新图片框
                pictureBox2.Image = bt2;
            }
        }

        private void 八邻域平均ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");//判断图片框是否有图片，如果无图片，则给出错误信息
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image); //定义两个位图对象
            int R1, R2, R3, R4, R5, R6, R7, R8, Red;
            int G1, G2, G3, G4, G5, G6, G7, G8, Green;
            int B1, B2, B3, B4, B5, B6, B7, B8, Blue;
            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {
                    R1 = bt1.GetPixel(i - 1, j - 1).R;
                    R2 = bt1.GetPixel(i, j - 1).R;
                    R3 = bt1.GetPixel(i + 1, j - 1).R;
                    R4 = bt1.GetPixel(i - 1, j).R;
                    R5 = bt1.GetPixel(i + 1, j).R;
                    R6 = bt1.GetPixel(i - 1, j + 1).R;
                    R7 = bt1.GetPixel(i, j + 1).R;
                    R8 = bt1.GetPixel(i + 1, j + 1).R;
                    Red = (int)(R1 + R2 + R3 + R4 + R5 + R6 + R7 + R8) / 8;

                    G1 = bt1.GetPixel(i - 1, j - 1).G;
                    G2 = bt1.GetPixel(i, j - 1).G;
                    G3 = bt1.GetPixel(i + 1, j - 1).G;
                    G4 = bt1.GetPixel(i - 1, j).G;
                    G5 = bt1.GetPixel(i + 1, j).G;
                    G6 = bt1.GetPixel(i - 1, j + 1).G;
                    G7 = bt1.GetPixel(i, j + 1).G;
                    G8 = bt1.GetPixel(i + 1, j + 1).G;
                    Green = (int)(G1 + G2 + G3 + G4 + G5 + G6 + G7 + G8) / 8;

                    B1 = bt1.GetPixel(i - 1, j - 1).B;
                    B2 = bt1.GetPixel(i, j - 1).B;
                    B3 = bt1.GetPixel(i + 1, j - 1).B;
                    B4 = bt1.GetPixel(i - 1, j).B;
                    B5 = bt1.GetPixel(i + 1, j).B;
                    B6 = bt1.GetPixel(i - 1, j + 1).B;
                    B7 = bt1.GetPixel(i, j + 1).B;
                    B8 = bt1.GetPixel(i + 1, j + 1).B;
                    Blue = (int)(B1 + B2 + B3 + B4 + B5 + B6 + B7 + B8) / 8;

                    bt2.SetPixel(i, j, Color.FromArgb(Red, Green, Blue));
                }
                pictureBox2.Refresh();//刷新图片框
                pictureBox2.Image = bt2;
            }
        }

        private void 平均值滤波ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            Color c = new Color();
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int rr, r1, rx;
            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {
                    rx = 0;
                    //为了处理3×3的像素块设置一个循环，实际就是实现8邻域的平均值滤波
                    for (int m = -1; m < 2; m++)//上下左右各距离一个像素范围内，即8邻域
                    {
                        for (int n = -1; n < 2; n++)
                        {
                            //获取该坐标的像素
                            c = bt1.GetPixel(i + m, j + n);
                            r1 = c.R;
                            rx += r1;
                        }
                    }
                    rr = (int)(rx / 9); //取平均值
                    bt2.SetPixel(i, j, Color.FromArgb(rr, rr, rr));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }

            //以下这段代码是对R、G、B三色都进行平均值滤波，由于循环太多，速度很慢，所以其他滤波就没都对三色进行处理，
            //只是对R分量进行处理，但道理都一样！

            //int rr, r1, rx, gg, g1, gx, bb, b1, bx;
            ////扫描图像的每个像素
            //for (int i = 1; i < bt1.Width - 1; i++)
            //{
            //    for (int j = 1; j < bt1.Height - 1; j++)
            //    {
            //        rx = 0;
            //        //为了处理3×3的像素块设置一个循环，实际就是实现8邻域的平均值滤波
            //        for (int m = -1; m < 2; m++)//上下左右各距离一个像素范围内，即8邻域
            //        {
            //            for (int n = -1; n < 2; n++)
            //            {
            //                //获取该坐标的像素
            //                c = bt1.GetPixel(i + m, j + n);
            //                r1 = c.R;
            //                rx += r1;
            //            }
            //        }
            //        rr = (int)(rx / 9); //取平均值
            //        gx = 0;
            //        //为了处理3×3的像素块设置一个循环，实际就是实现8邻域的平均值滤波
            //        for (int m = -1; m < 2; m++)//上下左右各距离一个像素范围内，即8邻域
            //        {
            //            for (int n = -1; n < 2; n++)
            //            {
            //                //获取该坐标的像素
            //                c = bt1.GetPixel(i + m, j + n);
            //                g1 = c.G;
            //                gx += g1;
            //            }
            //        }
            //        gg = (int)(gx / 9); //取平均值
            //        bx = 0;
            //        //为了处理3×3的像素块设置一个循环，实际就是实现8邻域的平均值滤波
            //        for (int m = -1; m < 2; m++)//上下左右各距离一个像素范围内，即8邻域
            //        {
            //            for (int n = -1; n < 2; n++)
            //            {
            //                //获取该坐标的像素
            //                c = bt1.GetPixel(i + m, j + n);
            //                b1 = c.B;
            //                bx += b1;
            //            }
            //        }
            //        bb = (int)(bx / 9); //取平均值
            //        bt2.SetPixel(i, j, Color.FromArgb(rr, gg, bb));  
            //    }
            //    pictureBox2.Refresh();
            //    pictureBox2.Image = bt2;
            //}
        }

        private void 最小值滤波ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            Color c = new Color();
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int rr, r1;
            //扫描图像的每个像素
            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {
                    rr = 0;
                    //为了处理3×3的像素块设置一个循环，实际就是实现8邻域的最小值滤波
                    for (int m = -1; m < 2; m++)
                    {
                        for (int n = -1; n < 2; n++)
                        {
                            //获取该坐标的像素
                            c = bt1.GetPixel(i + m, j + n);
                            r1 = c.R;
                            rr = r1;
                            if (rr < r1)
                                rr = r1;
                        }
                    }
                    bt2.SetPixel(i, j, Color.FromArgb(rr, rr, rr));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 最大值滤波ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            Color c = new Color();
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int rr, r1;
            //扫描图像的每个像素
            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {
                    rr = 0;
                    //为了处理3×3的像素块设置一个循环，实际就是实现8邻域的最大值滤波
                    for (int m = -1; m < 2; m++)
                    {
                        for (int n = -1; n < 2; n++)
                        {
                            //获取该坐标的像素
                            c = bt1.GetPixel(i + m, j + n);
                            r1 = c.R;
                            rr = r1;
                            if (rr > r1)
                                rr = r1;
                        }
                    }
                    bt2.SetPixel(i, j, Color.FromArgb(rr, rr, rr));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 中值滤波ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            Color c = new Color();
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int rr, r1, dm, m;
            //设置一个数组用于储存3×3像素快的r分量值
            int[] dt = new int[20];
            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {
                    rr = 0; m = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int n = -1; n < 2; n++)
                        {
                            //获取该坐标的像素并存入数组dt[]中
                            c = bt1.GetPixel(i + k, j + n);
                            r1 = c.R;
                            dt[m++] = r1;
                        }
                    }
                    for (int p = 0; p < m - 1; p++)
                    {
                        for (int q = p + 1; q < m; q++)
                        {
                            //对存与数组里的数据进行从大到小的排序
                            if (dt[p] > dt[q])
                            {
                                dm = dt[p];
                                dt[p] = dt[q];
                                dt[q] = dm;
                            }
                        }
                    }
                    //获取数值所有存储数据的中间值
                    rr = dt[(int)(m / 2)];
                    bt2.SetPixel(i, j, Color.FromArgb(rr, rr, rr));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 中点滤波ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            Color c = new Color();
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int rr, r1, dm, m;
            //设置一个数组用于储存3×3像素快的r分量值
            int[] dt = new int[20];
            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {
                    rr = 0; m = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int n = -1; n < 2; n++)
                        {
                            //获取该坐标的像素
                            c = bt1.GetPixel(i + k, j + n);
                            r1 = c.R;
                            dt[m] = r1;
                            m++;
                        }
                    }
                    for (int p = 0; p < m - 1; p++)
                    {
                        for (int q = p + 1; q < m; q++)
                        {
                            //对存与数组里的数据进行从大到小的排序
                            if (dt[p] > dt[q])
                            {
                                dm = dt[p];
                                dt[p] = dt[q];
                                dt[q] = dm;
                            }
                        }
                    }
                    //获取最大值与最小值的平均值
                    rr = (int)((dt[0] + dt[m - 1]) / 2);
                    bt2.SetPixel(i, j, Color.FromArgb(rr, rr, rr));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 修正平均滤波ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            Color c = new Color();
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int rr, r1, dm, m;
            //设置一个数组用于储存3×3像素快的r分量值
            int[] dt = new int[20];
            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {
                    rr = 0; m = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int n = -1; n < 2; n++)
                        {
                            //获取该坐标的像素
                            c = bt1.GetPixel(i + k, j + n);
                            r1 = c.R;
                            dt[m] = r1;
                            m++;
                        }
                    }
                    for (int p = 0; p < m - 1; p++)
                    {
                        for (int q = p + 1; q < m; q++)
                        {
                            //对存与数组里的数据进行从大到小的排序
                            if (dt[p] > dt[q])
                            {
                                dm = dt[p];
                                dt[p] = dt[q];
                                dt[q] = dm;
                            }
                        }
                    }
                    //获取去掉最大、最小值后的所有数的平均值，即修正后的平均值
                    for (int l = 1; l < m - 1; l++)
                        rr += dt[l];
                    rr = (int)(rr / (m - 2));
                    bt2.SetPixel(i, j, Color.FromArgb(rr, rr, rr));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 水平垂直差分ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int R1, R2, R3, R4;
            int G1, G2, G3, G4;
            int B1, B2, B3, B4;

            for (int i = 0; i < bt1.Width - 1; i++)
            {
                for (int j = 0; j < bt1.Height - 1; j++)
                {
                    ////法一：取两个分量差的最大值
                    //R1 = bt1.GetPixel(i, j).R;
                    //R2 = bt1.GetPixel(i + 1, j).R;
                    //R3 = bt1.GetPixel(i, j + 1).R;
                    //R4 = Math.Max(Math.Abs(R1 - R2), Math.Abs(R1 - R3));

                    //G1 = bt1.GetPixel(i, j).G;
                    //G2 = bt1.GetPixel(i + 1, j).G;
                    //G3 = bt1.GetPixel(i, j + 1).G;
                    //G4 = Math.Max(Math.Abs(G1 - G2), Math.Abs(G1 - G3));

                    //B1 = bt1.GetPixel(i, j).B;
                    //B2 = bt1.GetPixel(i + 1, j).B;
                    //B3 = bt1.GetPixel(i, j + 1).B;
                    //B4 = Math.Max(Math.Abs(B1 - B2), Math.Abs(B1 - B3));


                    //法二：取两个分量差的和值
                    R1 = bt1.GetPixel(i, j).R;
                    R2 = bt1.GetPixel(i + 1, j).R;
                    R3 = bt1.GetPixel(i, j + 1).R;
                    R4 = Math.Abs(R1 - R2) + Math.Abs(R1 - R3);

                    G1 = bt1.GetPixel(i, j).G;
                    G2 = bt1.GetPixel(i + 1, j).G;
                    G3 = bt1.GetPixel(i, j + 1).G;
                    G4 = Math.Abs(G1 - G2) + Math.Abs(G1 - G3);

                    B1 = bt1.GetPixel(i, j).B;
                    B2 = bt1.GetPixel(i + 1, j).B;
                    B3 = bt1.GetPixel(i, j + 1).B;
                    B4 = Math.Abs(B1 - B2) + Math.Abs(B1 - B3);

                    if (R4 >= 255) R4 = 255;
                    if (G4 >= 255) G4 = 255;//判断是否超出各分量允许的范围，如果大于255则只能等于255
                    if (B4 >= 255) B4 = 255;

                    bt2.SetPixel(i, j, Color.FromArgb(R4, G4, B4));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void robelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int R0, R1, R2, R3, R4;
            int G0, G1, G2, G3, G4;
            int B0, B1, B2, B3, B4;

            for (int i = 0; i < bt1.Width - 1; i++)
            {
                for (int j = 0; j < bt1.Height - 1; j++)
                {
                    R1 = bt1.GetPixel(i, j).R;
                    R2 = bt1.GetPixel(i + 1, j).R;
                    R3 = bt1.GetPixel(i, j + 1).R;
                    R0 = bt1.GetPixel(i + 1, j + 1).R;
                    R4 = Math.Abs(R1 - R0) + Math.Abs(R2 - R3);

                    G1 = bt1.GetPixel(i, j).G;
                    G2 = bt1.GetPixel(i + 1, j).G;
                    G3 = bt1.GetPixel(i, j + 1).G;
                    G0 = bt1.GetPixel(i + 1, j + 1).G;
                    G4 = Math.Abs(G1 - G0) + Math.Abs(G2 - G3);

                    B1 = bt1.GetPixel(i, j).B;
                    B2 = bt1.GetPixel(i + 1, j).B;
                    B3 = bt1.GetPixel(i, j + 1).B;
                    B0 = bt1.GetPixel(i + 1, j + 1).B;
                    B4 = Math.Abs(B1 - B0) + Math.Abs(B2 - B3);

                    if (R4 >= 255) R4 = 255;
                    if (G4 >= 255) G4 = 255;//判断是否超出各分量允许的范围，如果大于255则只能等于255
                    if (B4 >= 255) B4 = 255;

                    bt2.SetPixel(i, j, Color.FromArgb(R4, G4, B4));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void sobertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int R1, R2, R3, R4, R5, R6, R7, R8, R0;
            int G1, G2, G3, G4, G5, G6, G7, G8, G0;
            int B1, B2, B3, B4, B5, B6, B7, B8, B0;
            int Sxr, Sxg, Sxb, Syr, Syg, Syb;

            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {
                    R1 = bt1.GetPixel(i - 1, j - 1).R;
                    R2 = bt1.GetPixel(i, j - 1).R;
                    R3 = bt1.GetPixel(i + 1, j - 1).R;
                    R4 = bt1.GetPixel(i, j - 1).R;
                    R5 = bt1.GetPixel(i, j + 1).R;
                    R6 = bt1.GetPixel(i + 1, j - 1).R;
                    R7 = bt1.GetPixel(i + 1, j).R;
                    R8 = bt1.GetPixel(i + 1, j + 1).R;
                    Sxr = (R6 + 2 * R7 + R8) - (R1 + 2 * R2 + R3);
                    Syr = (R3 + 2 * R5 + R8) - (R1 + 2 * R4 + R6);
                    R0 = Math.Abs(Sxr) + Math.Abs(Syr);

                    G1 = bt1.GetPixel(i - 1, j - 1).G;
                    G2 = bt1.GetPixel(i, j - 1).G;
                    G3 = bt1.GetPixel(i + 1, j - 1).G;
                    G4 = bt1.GetPixel(i, j - 1).G;
                    G5 = bt1.GetPixel(i, j + 1).G;
                    G6 = bt1.GetPixel(i + 1, j - 1).G;
                    G7 = bt1.GetPixel(i + 1, j).G;
                    G8 = bt1.GetPixel(i + 1, j + 1).G;
                    Sxg = (G6 + 2 * G7 + G8) - (G1 + 2 * G2 + G3);
                    Syg = (G3 + 2 * G5 + G8) - (G1 + 2 * G4 + G6);
                    G0 = Math.Abs(Sxg) + Math.Abs(Syg);

                    B1 = bt1.GetPixel(i - 1, j - 1).B;
                    B2 = bt1.GetPixel(i, j - 1).B;
                    B3 = bt1.GetPixel(i + 1, j - 1).B;
                    B4 = bt1.GetPixel(i, j - 1).B;
                    B5 = bt1.GetPixel(i, j + 1).B;
                    B6 = bt1.GetPixel(i + 1, j - 1).B;
                    B7 = bt1.GetPixel(i + 1, j).B;
                    B8 = bt1.GetPixel(i + 1, j + 1).B;
                    Sxb = (B6 + 2 * B7 + B8) - (B1 + 2 * B2 + B3);
                    Syb = (B3 + 2 * B5 + B8) - (B1 + 2 * B4 + B6);
                    B0 = Math.Abs(Sxb) + Math.Abs(Syb);

                    if (R0 >= 255) R0 = 255;
                    if (G0 >= 255) G0 = 255;//判断是否超出各分量允许的范围，如果大于255则只能等于255
                    if (B0 >= 255) B0 = 255;

                    bt2.SetPixel(i, j, Color.FromArgb(R0, G0, B0));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void prewittToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int R1, R2, R3, R4, R5, R6, R7, R8, R0;
            int G1, G2, G3, G4, G5, G6, G7, G8, G0;
            int B1, B2, B3, B4, B5, B6, B7, B8, B0;
            int Sxr, Sxg, Sxb, Syr, Syg, Syb;

            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {
                    R1 = bt1.GetPixel(i - 1, j - 1).R;
                    R2 = bt1.GetPixel(i, j - 1).R;
                    R3 = bt1.GetPixel(i + 1, j - 1).R;
                    R4 = bt1.GetPixel(i, j - 1).R;
                    R5 = bt1.GetPixel(i, j + 1).R;
                    R6 = bt1.GetPixel(i + 1, j - 1).R;
                    R7 = bt1.GetPixel(i + 1, j).R;
                    R8 = bt1.GetPixel(i + 1, j + 1).R;
                    Sxr = (R6 + R7 + R8) - (R1 + R2 + R3);
                    Syr = (R3 + R5 + R8) - (R1 + R4 + R6);
                    R0 = Math.Abs(Sxr) + Math.Abs(Syr);

                    G1 = bt1.GetPixel(i - 1, j - 1).G;
                    G2 = bt1.GetPixel(i, j - 1).G;
                    G3 = bt1.GetPixel(i + 1, j - 1).G;
                    G4 = bt1.GetPixel(i, j - 1).G;
                    G5 = bt1.GetPixel(i, j + 1).G;
                    G6 = bt1.GetPixel(i + 1, j - 1).G;
                    G7 = bt1.GetPixel(i + 1, j).G;
                    G8 = bt1.GetPixel(i + 1, j + 1).G;
                    Sxg = (G6 + G7 + G8) - (G1 + G2 + G3);
                    Syg = (G3 + G5 + G8) - (G1 + G4 + G6);
                    G0 = Math.Abs(Sxg) + Math.Abs(Syg);

                    B1 = bt1.GetPixel(i - 1, j - 1).B;
                    B2 = bt1.GetPixel(i, j - 1).B;
                    B3 = bt1.GetPixel(i + 1, j - 1).B;
                    B4 = bt1.GetPixel(i, j - 1).B;
                    B5 = bt1.GetPixel(i, j + 1).B;
                    B6 = bt1.GetPixel(i + 1, j - 1).B;
                    B7 = bt1.GetPixel(i + 1, j).B;
                    B8 = bt1.GetPixel(i + 1, j + 1).B;
                    Sxb = (B6 + B7 + B8) - (B1 + B2 + B3);
                    Syb = (B3 + B5 + B8) - (B1 + B4 + B6);
                    B0 = Math.Abs(Sxb) + Math.Abs(Syb);

                    if (R0 >= 255) R0 = 255;
                    if (G0 >= 255) G0 = 255;//判断是否超出各分量允许的范围，如果大于255则只能等于255
                    if (B0 >= 255) B0 = 255;

                    bt2.SetPixel(i, j, Color.FromArgb(R0, G0, B0));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 右下边缘抽出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int R0, R1, R2, R3, R4;
            int G0, G1, G2, G3, G4;
            int B0, B1, B2, B3, B4;

            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {
                    R1 = bt1.GetPixel(i - 1, j).R;
                    R2 = bt1.GetPixel(i, j - 1).R;
                    R3 = bt1.GetPixel(i, j + 1).R;
                    R4 = bt1.GetPixel(i + 1, j).R;
                    R0 = Math.Abs(-2 * R1 - 2 * R2 + 2 * R3 + 2 * R4);

                    G1 = bt1.GetPixel(i - 1, j).G;
                    G2 = bt1.GetPixel(i, j - 1).G;
                    G3 = bt1.GetPixel(i, j + 1).G;
                    G4 = bt1.GetPixel(i + 1, j).G;
                    G0 = Math.Abs(-2 * G1 - 2 * G2 + 2 * G3 + 2 * G4);

                    B1 = bt1.GetPixel(i - 1, j).B;
                    B2 = bt1.GetPixel(i, j - 1).B;
                    B3 = bt1.GetPixel(i, j + 1).B;
                    B4 = bt1.GetPixel(i + 1, j).B;
                    B0 = Math.Abs(-2 * B1 - 2 * B2 + 2 * B3 + 2 * B4);

                    if (R0 >= 255) R0 = 255;
                    if (G0 >= 255) G0 = 255;//判断是否超出各分量允许的范围，如果大于255则只能等于255
                    if (B0 >= 255) B0 = 255;

                    bt2.SetPixel(i, j, Color.FromArgb(R0, G0, B0));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 拉普拉斯1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int R1, R2, R3, R4, R5, R0;
            int G1, G2, G3, G4, G5, G0;
            int B1, B2, B3, B4, B5, B0;

            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {

                    R1 = bt1.GetPixel(i, j).R;
                    R2 = bt1.GetPixel(i - 1, j).R;
                    R3 = bt1.GetPixel(i + 1, j).R;
                    R4 = bt1.GetPixel(i, j - 1).R;
                    R5 = bt1.GetPixel(i, j + 1).R;
                    R0 = Math.Abs(R2 + R3 + R4 + R5 - 4 * R1);


                    G1 = bt1.GetPixel(i, j).G;
                    G2 = bt1.GetPixel(i - 1, j).G;
                    G3 = bt1.GetPixel(i + 1, j).G;
                    G4 = bt1.GetPixel(i, j - 1).G;
                    G5 = bt1.GetPixel(i, j + 1).G;
                    G0 = Math.Abs(G2 + G3 + G4 + G5 - 4 * G1);

                    B1 = bt1.GetPixel(i, j).B;
                    B2 = bt1.GetPixel(i - 1, j).B;
                    B3 = bt1.GetPixel(i + 1, j).B;
                    B4 = bt1.GetPixel(i, j - 1).B;
                    B5 = bt1.GetPixel(i, j + 1).B;
                    B0 = Math.Abs(B2 + B3 + B4 + B5 - 4 * B1);

                    if (R0 >= 255) R0 = 255;
                    if (G0 >= 255) G0 = 255;//判断是否超出各分量允许的范围，如果大于255则只能等于255
                    if (B0 >= 255) B0 = 255;

                    bt2.SetPixel(i, j, Color.FromArgb(R0, G0, B0));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 拉普拉斯2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int R1, R2, R3, R4, R5, R6, R7, R8, R9, R;
            int G1, G2, G3, G4, G5, G6, G7, G8, G9, G;
            int B1, B2, B3, B4, B5, B6, B7, B8, B9, B;

            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {

                    R1 = bt1.GetPixel(i - 1, j - 1).R;
                    R2 = bt1.GetPixel(i - 1, j).R;
                    R3 = bt1.GetPixel(i - 1, j + 1).R;
                    R4 = bt1.GetPixel(i, j - 1).R;
                    R5 = bt1.GetPixel(i, j).R;
                    R6 = bt1.GetPixel(i, j + 1).R;
                    R7 = bt1.GetPixel(i + 1, j - 1).R;
                    R8 = bt1.GetPixel(i + 1, j).R;
                    R9 = bt1.GetPixel(i + 1, j + 1).R;
                    R = Math.Abs(R1 + R2 + R3 + R4 + R6 + R7 + R8 + R9 - 8 * R5);

                    G1 = bt1.GetPixel(i - 1, j - 1).G;
                    G2 = bt1.GetPixel(i - 1, j).G;
                    G3 = bt1.GetPixel(i - 1, j + 1).G;
                    G4 = bt1.GetPixel(i, j - 1).G;
                    G5 = bt1.GetPixel(i, j).G;
                    G6 = bt1.GetPixel(i, j + 1).G;
                    G7 = bt1.GetPixel(i + 1, j - 1).G;
                    G8 = bt1.GetPixel(i + 1, j).G;
                    G9 = bt1.GetPixel(i + 1, j + 1).G;
                    G = Math.Abs(G1 + G2 + G3 + G4 + G6 + G7 + G8 + G9 - 8 * G5);

                    B1 = bt1.GetPixel(i - 1, j - 1).B;
                    B2 = bt1.GetPixel(i - 1, j).B;
                    B3 = bt1.GetPixel(i - 1, j + 1).B;
                    B4 = bt1.GetPixel(i, j - 1).B;
                    B5 = bt1.GetPixel(i, j).B;
                    B6 = bt1.GetPixel(i, j + 1).B;
                    B7 = bt1.GetPixel(i + 1, j - 1).B;
                    B8 = bt1.GetPixel(i + 1, j).B;
                    B9 = bt1.GetPixel(i + 1, j + 1).B;
                    B = Math.Abs(B1 + B2 + B3 + B4 + B6 + B7 + B8 + B9 - 8 * B5);

                    if (R >= 255) R = 255;
                    if (G >= 255) G = 255;//判断是否超出各分量允许的范围，如果大于255则只能等于255
                    if (B >= 255) B = 255;

                    bt2.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void robinsonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int R1, R2, R3, R7, R8, R9, R;
            int G1, G2, G3, G7, G8, G9, G;
            int B1, B2, B3, B7, B8, B9, B;

            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {

                    R1 = bt1.GetPixel(i - 1, j - 1).R;
                    R2 = bt1.GetPixel(i - 1, j).R;
                    R3 = bt1.GetPixel(i - 1, j + 1).R;
                    //R4 = bt1.GetPixel(i, j - 1).R;
                    //R5 = bt1.GetPixel(i, j).R;
                    //R6 = bt1.GetPixel(i, j + 1).R;
                    R7 = bt1.GetPixel(i + 1, j - 1).R;
                    R8 = bt1.GetPixel(i + 1, j).R;
                    R9 = bt1.GetPixel(i + 1, j + 1).R;
                    R = Math.Abs(R1 + 2 * R2 + R3 - R7 - 2 * R8 - R9);

                    G1 = bt1.GetPixel(i - 1, j - 1).G;
                    G2 = bt1.GetPixel(i - 1, j).G;
                    G3 = bt1.GetPixel(i - 1, j + 1).G;
                    //G4 = bt1.GetPixel(i, j - 1).G;
                    //G5 = bt1.GetPixel(i, j).G;
                    //G6 = bt1.GetPixel(i, j + 1).G;
                    G7 = bt1.GetPixel(i + 1, j - 1).G;
                    G8 = bt1.GetPixel(i + 1, j).G;
                    G9 = bt1.GetPixel(i + 1, j + 1).G;
                    G = Math.Abs(G1 + 2 * G2 + G3 - G7 - 2 * G8 - G9);

                    B1 = bt1.GetPixel(i - 1, j - 1).B;
                    B2 = bt1.GetPixel(i - 1, j).B;
                    B3 = bt1.GetPixel(i - 1, j + 1).B;
                    //B4 = bt1.GetPixel(i, j - 1).B;
                    //B5 = bt1.GetPixel(i, j).B;
                    //B6 = bt1.GetPixel(i, j + 1).B;
                    B7 = bt1.GetPixel(i + 1, j - 1).B;
                    B8 = bt1.GetPixel(i + 1, j).B;
                    B9 = bt1.GetPixel(i + 1, j + 1).B;
                    B = Math.Abs(B1 + 2 * B2 + B3 - B7 - 2 * B8 - B9);

                    if (R >= 255) R = 255;
                    if (G >= 255) G = 255;//判断是否超出各分量允许的范围，如果大于255则只能等于255
                    if (B >= 255) B = 255;

                    bt2.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void kirschToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int R1, R2, R3, R4, R6, R7, R8, R9, R;
            int G1, G2, G3, G4, G6, G7, G8, G9, G;
            int B1, B2, B3, B4, B6, B7, B8, B9, B;

            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {

                    R1 = bt1.GetPixel(i - 1, j - 1).R;
                    R2 = bt1.GetPixel(i - 1, j).R;
                    R3 = bt1.GetPixel(i - 1, j + 1).R;
                    R4 = bt1.GetPixel(i, j - 1).R;
                    //R5 = bt1.GetPixel(i, j).R;
                    R6 = bt1.GetPixel(i, j + 1).R;
                    R7 = bt1.GetPixel(i + 1, j - 1).R;
                    R8 = bt1.GetPixel(i + 1, j).R;
                    R9 = bt1.GetPixel(i + 1, j + 1).R;
                    R = Math.Abs(5 * R1 + 5 * R2 + 5 * R3 - 3 * R4 - 3 * R6 - 3 * R7 - 3 * R8 - 3 * R9);

                    G1 = bt1.GetPixel(i - 1, j - 1).G;
                    G2 = bt1.GetPixel(i - 1, j).G;
                    G3 = bt1.GetPixel(i - 1, j + 1).G;
                    G4 = bt1.GetPixel(i, j - 1).G;
                    //G5 = bt1.GetPixel(i, j).G;
                    G6 = bt1.GetPixel(i, j + 1).G;
                    G7 = bt1.GetPixel(i + 1, j - 1).G;
                    G8 = bt1.GetPixel(i + 1, j).G;
                    G9 = bt1.GetPixel(i + 1, j + 1).G;
                    G = Math.Abs(5 * G1 + 5 * G2 + 5 * G3 - 3 * G4 - 3 * G6 - 3 * G7 - 3 * G8 - 3 * G9);

                    B1 = bt1.GetPixel(i - 1, j - 1).B;
                    B2 = bt1.GetPixel(i - 1, j).B;
                    B3 = bt1.GetPixel(i - 1, j + 1).B;
                    B4 = bt1.GetPixel(i, j - 1).B;
                    //B5 = bt1.GetPixel(i, j).B;
                    B6 = bt1.GetPixel(i, j + 1).B;
                    B7 = bt1.GetPixel(i + 1, j - 1).B;
                    B8 = bt1.GetPixel(i + 1, j).B;
                    B9 = bt1.GetPixel(i + 1, j + 1).B;
                    B = Math.Abs(5 * B1 + 5 * B2 + 5 * B3 - 3 * B4 - 3 * B6 - 3 * B7 - 3 * B8 - 3 * B9);

                    if (R >= 255) R = 255;
                    if (G >= 255) G = 255;//判断是否超出各分量允许的范围，如果大于255则只能等于255
                    if (B >= 255) B = 255;

                    bt2.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void smoothedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("对不起，暂时还不会！");
        }

        private void 水平百叶窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(bt1.Width, bt1.Height);

            FormBaiYeChuang formBYC = new FormBaiYeChuang();
            formBYC.ShowDialog();
            int c = formBYC.baiyechuang;//百叶窗的条数
            
            int dw = bt1.Width;
            int dh = bt1.Height / c;//每个条的高度
            for (int i = 0; i < dh; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    for (int k = 0; k < dw; k++)
                    {
                        bt2.SetPixel(k, i + j * dh, bt1.GetPixel(k, i + j * dh));
                    }
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
                System.Threading.Thread.Sleep(100);
            }
        }

        private void 垂直百叶窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(bt1.Width, bt1.Height);

            FormBaiYeChuang formBYC = new FormBaiYeChuang();
            formBYC.ShowDialog();           
            int c = formBYC.baiyechuang;//百叶窗的列数

            int dw = bt1.Width / c;//每列的宽度
            int dh = bt1.Height;
            for (int i = 0; i < dw; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    for (int k = 0; k < dh; k++)
                    {
                        bt2.SetPixel(i + j * dw, k, bt1.GetPixel(i + j * dw, k));
                    }                                     
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
                System.Threading.Thread.Sleep(100);        
            }
        }

        private void 垂直栅条ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);

            int c = 30;//每个栅条的宽度
            int m = 10;//每个栅条向上或向左移动的距离

            bt2 = new Bitmap(bt1.Width, bt1.Height + 2 * m);
            int dw = bt1.Width / c;
            
            for (int i = 0; i < bt1.Height; i++)
            {
                for (int j = 0; j < dw; j++)
                {
                    for (int k1 = j; k1 < bt1.Width; k1 = k1 + 2 * dw)
                    {
                        bt2.SetPixel(k1, i + 2 * m, bt1.GetPixel(k1, i));
                    }
                    for (int k2 = j + dw; k2 < bt1.Width; k2 = k2 + 2 * dw)
                    {
                        bt2.SetPixel(k2, i, bt1.GetPixel(k2, i));
                    }
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 水平栅条ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);

            int c = 30;//每个栅条高度
            int m = 10;//每个栅条向左或向右移动的距离

            bt2 = new Bitmap(bt1.Width + 2 * m, bt1.Height);
            int dh = bt1.Height / c;

            for (int i = 0; i < bt1.Width; i++)
            {
                for (int j = 0; j < dh; j++)
                {
                    for (int k1 = j; k1 < bt1.Height; k1 = k1 + 2 * dh)
                    {
                        bt2.SetPixel(i + 2 * m, k1, bt1.GetPixel(i,k1));
                    }
                    for (int k2 = j + dh; k2 < bt1.Height; k2 = k2 + 2 * dh)
                    {
                        bt2.SetPixel(i, k2, bt1.GetPixel(i, k2));
                    } 
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 霓虹ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int Red, Green, Blue;
            for (int i = 0; i < bt1.Width - 1; i++)
            {
                for (int j = 0; j < bt1.Height - 1; j++)
                {
                    int r1, r2, r3, g1, g2, g3, b1, b2, b3;

                    r1 = bt1.GetPixel(i, j).R;
                    r2 = bt1.GetPixel(i + 1, j).R;
                    r3 = bt1.GetPixel(i, j + 1).R;
                    Red = (int)(2 * Math.Sqrt((r1 - r2) * (r1 - r2) + (r1 - r3) * (r1 - r3)));

                    g1 = bt1.GetPixel(i, j).G;
                    g2 = bt1.GetPixel(i + 1, j).G;
                    g3 = bt1.GetPixel(i, j + 1).G;
                    Green = (int)(2 * Math.Sqrt((g1 - g2) * (g1 - g2) + (g1 - g3) * (g1 - g3)));

                    b1 = bt1.GetPixel(i, j).B;
                    b2 = bt1.GetPixel(i + 1, j).B;
                    b3 = bt1.GetPixel(i, j + 1).B;
                    Blue = (int)(2 * Math.Sqrt((b1 - b2) * (b1 - b2) + (b1 - b3) * (b1 - b2)));

                    if (Red > 255) Red = 255; //判断是否超出各分量允许的范围，如果大于255则只能等于255
                    if (Red < 0) Red = 0; //如果小于0则只能等于0
                    if (Green > 255) Green = 255;
                    if (Green < 0) Green = 0;
                    if (Blue > 255) Blue = 255;
                    if (Blue < 0) Blue = 0;

                    bt2.SetPixel(i, j, Color.FromArgb(Red, Green, Blue));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 马赛克ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            Color color = new Color();//定义一个颜色对象
            int Red, Green, Blue;
            int k = 16;//改变此参数可以改变马赛克方格的大小
            for (int i = 0; i < bt1.Width - k; i = i + k)
            {
                for (int j = 0; j < bt1.Height - k; j = j + k)
                {
                    color = bt1.GetPixel(i, j);
                    Red = color.R;
                    Green = color.G;
                    Blue = color.B;
                    for (int m = 0; m < k; m++)
                    {
                        for (int n = 0; n < k; n++)
                        {
                            bt2.SetPixel(i + m, j + n, Color.FromArgb(Red, Green, Blue));
                        }
                    }
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }


        //对图像像素点的像素值分别与相邻像素点的像素值相减后加上128, 然后将其作为新的像素点的值. 
        //为防止颜色值溢出， 需处理值小于 0和大于 255的情况颜色值，可以使图像产生浮雕效果。
        private void 浮雕ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int Red, Green, Blue;
            int C = 128;//可以改变C的值（C一般取128）
            for (int i = 0; i < bt1.Width-1; i++) //减1是为了防止图像坐标溢出，出现错误
            {
                for (int j = 0; j < bt1.Height-1; j++)
                {
                    int r1, r2, g1, g2, b1, b2;

                    r1 = bt1.GetPixel(i, j).R;
                    r2 = bt1.GetPixel(i +1, j + 1).R;
                    Red = r1 - r2 + C;

                    g1 = bt1.GetPixel(i, j).G;
                    g2 = bt1.GetPixel(i + 1, j + 1).G;
                    Green = g1 - g2 + C;

                    b1 = bt1.GetPixel(i, j).B;
                    b2 = bt1.GetPixel(i + 1, j + 1).B;
                    Blue = b1 - b2 + C; ;

                    if (Red > 255) Red = 255; //判断是否超出各分量允许的范围，如果大于255则只能等于255
                    if (Red < 0) Red = 0; //如果小于0则只能等于0
                    if (Green > 255) Green = 255;
                    if (Green < 0) Green = 0;
                    if (Blue > 255) Blue = 255;
                    if (Blue < 0) Blue = 0;

                    bt2.SetPixel(i, j, Color.FromArgb(Red, Green, Blue));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }

        private void 雕刻ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            int Red, Green, Blue;
            int C = 128;//可以改变C的值（C一般取128）
            for (int i = 0; i < bt1.Width - 1; i++)
            {
                for (int j = 0; j < bt1.Height - 1; j++)
                {
                    int r1, r2, g1, g2, b1, b2;

                    r1 = bt1.GetPixel(i, j).R;
                    r2 = bt1.GetPixel(i + 1, j + 1).R;
                    Red = r1 - r2 + C;

                    g1 = bt1.GetPixel(i, j).G;
                    g2 = bt1.GetPixel(i + 1, j + 1).G;
                    Green = g1 - g2 + C;

                    b1 = bt1.GetPixel(i, j).B;
                    b2 = bt1.GetPixel(i + 1, j + 1).B;
                    Blue = b1 - b2 + C; ;

                    if (Red > 255) Red = 255; //判断是否超出各分量允许的范围，如果大于255则只能等于255
                    if (Red < 0) Red = 0; //如果小于0则只能等于0
                    if (Green > 255) Green = 255;
                    if (Green < 0) Green = 0;
                    if (Blue > 255) Blue = 255;
                    if (Blue < 0) Blue = 0;

                    bt2.SetPixel(i, j, Color.FromArgb(Red, Green, Blue));
                }
                pictureBox2.Refresh();
                pictureBox2.Image = bt2;
            }
        }
#region//纹理
        private void 纹理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            try
            {
                Rectangle rect = new Rectangle(0, 0, bt2.Width, bt2.Height);  //实例化Rectangle类
                System.Drawing.Imaging.BitmapData bmpData = bt2.LockBits(rect,
                 System.Drawing.Imaging.ImageLockMode.ReadWrite, bt2.PixelFormat);      //将指定图像锁定到内存中
                IntPtr ptr = bmpData.Scan0;                                 //获得图像中第一个像素数据的地址
                int bytes = bt2.Width * bt2.Height * 3;           //设置大小
                byte[] rgbValues = new byte[bytes];//实例化byte数组
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes); //使用RGB值为声明的rgbValues数组赋值
                for (int counter = 0; counter < rgbValues.Length; counter += 3)     //初始化大小
                    rgbValues[counter] = 255;
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes); //使用RGB值为图像的像素点着色
                bt2.UnlockBits(bmpData);                           //从内存中解锁图像
                                                                   // this.BackgroundImage = bt2;							

                pictureBox2.Refresh();
                pictureBox2.Image = bt2;                                //显示设置后的图片
            }
            catch { }
        }
        #endregion
#region//雾化
        private void 雾化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
           

            //以雾化效果显示图像
            try
            {
                int Height = this.pictureBox1.Image.Height;
                int Width = this.pictureBox1.Image.Width;
                Bitmap newBitmap = new Bitmap(Width, Height);
                Bitmap oldBitmap = (Bitmap)this.pictureBox1.Image;
                Color pixel;
                for (int x = 1; x < Width - 1; x++)
                    for (int y = 1; y < Height - 1; y++)
                    {
                        System.Random MyRandom = new Random();
                        int k = MyRandom.Next(-100000,100000);
                        //像素块大小
                        int dx = x + k % 7;
                        int dy = y + k % 7;
                        if (dx >= Width)
                            dx = Width - 1;
                        if (dy >= Height)
                            dy = Height - 1;
                        if (dx < 0)
                            dx = 0;
                        if (dy < 0)
                            dy = 0;
                        pixel = oldBitmap.GetPixel(dx, dy);
                        newBitmap.SetPixel(x, y, pixel);
                    }
                pictureBox2.Refresh();//刷新图片框
                this.pictureBox2.Image = newBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }

          
        }
        #endregion
#region//油画       
        private void 油画ToolStripMenuItem_Click(object sender, EventArgs e) //以油画效果显示图像
        {
           
            
            //取得图片尺寸
            int width = this.pictureBox1.Image.Width;
            int height = this.pictureBox1.Image.Height;
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image);
            RectangleF rect = new RectangleF(0, 0, width, height);

            
            //产生随机数序列
            Random rnd = new Random();
            //取不同的值决定油画效果的不同程度
            int iModel = 2;
            int i = width - iModel;
            while (i > 1)
            {
                int j = height - iModel;
                while (j > 1)
                {
                    int iPos = rnd.Next(100000) % iModel;
                    //将该点的RGB值设置成附近iModel点之内的任一点
                    Color color =bt1.GetPixel(i + iPos, j + iPos);
                   bt2.SetPixel(i, j, color);
                    j = j - 1;
                }
                i = i - 1;
            }
            //重新绘制图像
        //   pictureBox2.Clear(Color.White);
          //  pictureBox2.DrawImage(img, new Rectangle(0, 0, width, height));

            pictureBox2.Refresh();
            pictureBox2.Image = bt2;                                //显示设置后的图片
        }

#endregion
        private void BinaryDilation()//二值图像的膨胀函数（膨胀白色）
        {
            int R;
            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {
                    R = bt1.GetPixel(i, j).R;
                    if (R == 255)
                    {
                        bt2.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i - 1, j - 1, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i, j - 1, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i + 1, j - 1, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i - 1, j, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i + 1, j, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i - 1, j + 1, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i, j + 1, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i + 1, j + 1, Color.FromArgb(255, 255, 255));
                    }
                }
                pictureBox2.Refresh();//刷新图片框
                pictureBox2.Image = bt2;
            }
        }

        private void BinaryErosion()//二值图像的腐蚀函数（腐蚀白色）
        {
            int R1, R2, R3;
            for (int i = 0; i < bt1.Width - 1; i++)
            {
                for (int j = 0; j < bt1.Height - 1; j++)
                {
                    R1 = bt1.GetPixel(i, j).R;
                    if (R1 == 255)
                    {
                        R2 = bt1.GetPixel(i, j + 1).R;
                        R3 = bt1.GetPixel(i + 1, j).R;
                        if (R2 == 255 && R3 == 255)
                        {
                            bt2.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                        else
                        {
                            bt2.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        }
                    }
                }
                pictureBox2.Refresh();//刷新图片框
                pictureBox2.Image = bt2;
            }
        }
   

        #region//膨胀
        private void 膨胀ToolStripMenuItem1_Click(object sender, EventArgs e)//专门针对二值化图像
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");//判断图片框是否有图片，如果无图片，则给出错误信息
                return;
            }
            
             

                /*try

                {
                    int w = pictureBox1.PixelWidth;

                    int h = src.PixelHeight;

                    WriteableBitmap dilationImage = new WriteableBitmap(w, h);

                    int w = pictureBox1.Image.Width;
                    int h = pictureBox1.Image.Height;

                    bt1 = new Bitmap(pictureBox1.Image);
                    bt2 = new Bitmap(pictureBox1.Image); //定义两个位图对象 

                 //   WriteableBitmap dilationImage = newWriteableBitmap(w, h);

                    byte[] temp = bt2.GetPixel.ToArray();

                    byte[] tempMask = (byte[])temp.Clone();

                    for (int j = 0; j < h; j++)

                    {

                        for (int i = 0; i < w; i++)

                        {

                            if (i == 0 || i == w - 1 || j == 0 || j == h - 1)

                            {

                                temp[i * 4 + j * w * 4] = (byte)255;

                                temp[i * 4 + 1 + j * w * 4] = (byte)255;

                                temp[i * 4 + 2 + j * w * 4] = (byte)255;

                            }

                            else

                            {

                                if (tempMask[i * 4 - 4 + j * w * 4] == 255 || tempMask[i * 4 + j * w * 4] == 255 || tempMask[i * 4 + 4 + j * w * 4] == 255

                                    || tempMask[i * 4 + (j - 1) * w * 4] == 255 || tempMask[i * 4 + (j + 1) * w * 4] == 255)

                                {

                                    temp[i * 4 + j * w * 4] = (byte)255;

                                    temp[i * 4 + 1 + j * w * 4] = (byte)255;

                                    temp[i * 4 + 2 + j * w * 4] = (byte)255;

                                }

                                else

                                {

                                    temp[i * 4 + j * w * 4] = 0;

                                    temp[i * 4 + 1 + j * w * 4] = 0;

                                    temp[i * 4 + 2 + j * w * 4] = 0;

                                }

                            }

                        }

                    }

                    Stream sTemp = bt2.PixelBuffer.AsStream();

                    sTemp.Seek(0, SeekOrigin.Begin);

                    sTemp.Write(temp, 0, w * 4 * h);

                    pictureBox2.Refresh();//刷新图片框
                    pictureBox2.Image = bt2;

                }

                catch { }

                */

              
                             bt1 = new Bitmap(pictureBox1.Image);
                              bt2 = new Bitmap(pictureBox1.Image); //定义两个位图对象 
                              BinaryDilation();
            }
#endregion

        #region//腐蚀
        private void 腐蚀ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");//判断图片框是否有图片，如果无图片，则给出错误信息
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image); //定义两个位图对象
            BinaryErosion();
        }
#endregion

        #region//开运算
        //开运算数学上是先腐蚀后膨胀的结果
        //开运算的物理结果为完全删除了不能包含结构元素的对象区域，平滑
        //了对象的轮廓，断开了狭窄的连接，去掉了细小的突出部分
        private void 开运算ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");//判断图片框是否有图片，如果无图片，则给出错误信息
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image); //定义两个位图对象
            BinaryErosion();  //先腐蚀
            bt1 = new Bitmap(pictureBox2.Image);
            bt2 = new Bitmap(pictureBox2.Image);
            BinaryDilation();  //再膨胀
        }
#endregion

        #region//闭运算
        //闭运算在数学上是先膨胀再腐蚀的结果
        //闭运算的物理结果也是会平滑对象的轮廓，但是与开运算不同的是，闭运算
        //一般会将狭窄的缺口连接起来形成细长的弯口，并填充比结构元素小的洞
        private void 闭运算ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");//判断图片框是否有图片，如果无图片，则给出错误信息
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image); //定义两个位图对象
            BinaryDilation();  //先膨胀
            bt1 = new Bitmap(pictureBox2.Image);
            bt2 = new Bitmap(pictureBox2.Image);
            BinaryErosion();  //再腐蚀
        }
        #endregion

        #region//边缘提取
        private void 边缘提取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }


              bt1 = new Bitmap(pictureBox1.Image);
             bt2 = new Bitmap(pictureBox1.Image); //定义两个位图对象 

         /*   int w = pictureBox1.Width;
            int h = pictureBox1.Height;
           try
            {
                Bitmap dstBitmap = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                System.Drawing.Imaging.BitmapData srcData = bt1.LockBits(new Rectangle
                 (0, 0, w, h), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                System.Drawing.Imaging.BitmapData dstData = dstBitmap.LockBits(new Rectangle
                 (0, 0, w, h), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* pIn = (byte*)srcData.Scan0.ToPointer();
                    byte* pOut = (byte*)dstData.Scan0.ToPointer();
                    byte* p;
                    int stride = srcData.Stride;
                    for (int y = 0; y < h; y++)
                    {
                        for (int x = 0; x < w; x++)
                        {
                            //边缘八个点像素不变
                            if (x == 0 || x == w - 1 || y == 0 || y == h - 1)
                            {
                                pOut[0] = pIn[0];
                                pOut[1] = pIn[1];
                                pOut[2] = pIn[2];
                            }
                            else
                            {
                                int r0, r1, r2, r3, r4, r5, r6, r7, r8;
                                int g1, g2, g3, g4, g5, g6, g7, g8, g0;
                                int b1, b2, b3, b4, b5, b6, b7, b8, b0;
                                double vR, vG, vB;
                                //左上
                                p = pIn - stride - 3;
                                r1 = p[2];
                                g1 = p[1];
                                b1 = p[0];
                                //正上
                                p = pIn - stride;
                                r2 = p[2];
                                g2 = p[1];
                                b2 = p[0];
                                //右上
                                p = pIn - stride + 3;
                                r3 = p[2];
                                g3 = p[1];
                                b3 = p[0];
                                //左
                                p = pIn - 3;
                                r4 = p[2];
                                g4 = p[1];
                                b4 = p[0];
                                //右
                                p = pIn + 3;
                                r5 = p[2];
                                g5 = p[1];
                                b5 = p[0];
                                //左下
                                p = pIn + stride - 3;
                                r6 = p[2];
                                g6 = p[1];
                                b6 = p[0];
                                //正下
                                p = pIn + stride;
                                r7 = p[2];
                                g7 = p[1];
                                b7 = p[0];
                                // 右下 
                                p = pIn + stride + 3;
                                r8 = p[2];
                                g8 = p[1];
                                b8 = p[0];
                                //中心点
                                p = pIn;
                                r0 = p[2];
                                g0 = p[1];
                                b0 = p[0];
                                //使用模板
                                vR = (double)(Math.Abs(r1 + 2 * r4 + r6 - r3 - 2 * r5 - r8) + Math.Abs(r1 + 2 * r2 + r3 - r6 - 2 * r7 - r8));
                                vG = (double)(Math.Abs(g1 + 2 * g4 + g6 - g3 - 2 * g5 - g8) + Math.Abs(g1 + 2 * g2 + g3 - g6 - 2 * g7 - g8));
                                vB = (double)(Math.Abs(b1 + 2 * b4 + b6 - b3 - 2 * b5 - b8) + Math.Abs(b1 + 2 * b2 + b3 - b6 - 2 * b7 - b8));
                                if (vR > 0)
                                {
                                    vR = Math.Min(255, vR);
                                }
                                else
                                {
                                    vR = Math.Max(0, vR);
                                }
                                if (vG > 0)
                                {
                                    vG = Math.Min(255, vG);
                                }
                                else
                                {
                                    vG = Math.Max(0, vG);
                                }
                                if (vB > 0)
                                {
                                    vB = Math.Min(255, vB);
                                }
                                else
                                {
                                    vB = Math.Max(0, vB);
                                }
                                pOut[0] = (byte)vB;
                                pOut[1] = (byte)vG;
                                pOut[2] = (byte)vR;
                            }
                            pIn += 3;
                            pOut += 3;
                        }
                        pIn += srcData.Stride - w * 3;
                        pOut += srcData.Stride - w * 3;
                    }
                }
                bt1.UnlockBits(srcData);
                dstBitmap.UnlockBits(dstData);

                pictureBox2.Refresh();//刷新图片框
             
                pictureBox2.Image=dstBitmap;
            }
            catch
            {
                MessageBox.Show("出错");
            }
        */

       
        int w = pictureBox1.Image.Width;
        int h = pictureBox1.Image.Height;


        int Height = this.pictureBox1.Image.Height;
        int Width = this.pictureBox1.Image.Width;
        Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
        Bitmap MyBitmap = (Bitmap)this.pictureBox1.Image;
        BitmapData oldData = MyBitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb); //原图
        BitmapData newData = bitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);  //新图即边缘图
        unsafe
        {
            //首先第一段代码是提取边缘，边缘置为黑色，其他部分置为白色
            byte* pin_1 = (byte*)(oldData.Scan0.ToPointer());
            byte* pin_2 = pin_1 + (oldData.Stride);
            byte* pout = (byte*)(newData.Scan0.ToPointer());
            for (int y = 0; y < oldData.Height - 1; y++)
            {
                for (int x = 0; x < oldData.Width; x++)
                {
                    //使用robert算子
                    double b = System.Math.Sqrt(((double)pin_1[0] - (double)(pin_2[0] + 3)) * ((double)pin_1[0] - (double)(pin_2[0] + 3)) + ((double)(pin_1[0] + 3) - (double)pin_2[0]) * ((double)(pin_1[0] + 3) - (double)pin_2[0]));
                    double g = System.Math.Sqrt(((double)pin_1[1] - (double)(pin_2[1] + 3)) * ((double)pin_1[1] - (double)(pin_2[1] + 3)) + ((double)(pin_1[1] + 3) - (double)pin_2[1]) * ((double)(pin_1[1] + 3) - (double)pin_2[1]));
                    double r = System.Math.Sqrt(((double)pin_1[2] - (double)(pin_2[2] + 3)) * ((double)pin_1[2] - (double)(pin_2[2] + 3)) + ((double)(pin_1[2] + 3) - (double)pin_2[2]) * ((double)(pin_1[2] + 3) - (double)pin_2[2]));
                    double bgr = b + g + r;//博主一直在纠结要不要除以3，感觉没差，选阈值的时候调整一下就好了- -

                    if (bgr > 60) //阈值，超过阈值判定为边缘（选取适当的阈值）
                    {
                        b = 0;
                        g = 0;
                        r = 0;
                    }
                    else
                    {
                        b = 255;
                        g = 255;
                        r = 255;
                    }
                    pout[0] = (byte)(b);
                    pout[1] = (byte)(g);
                    pout[2] = (byte)(r);
                    pin_1 = pin_1 + 3;
                    pin_2 = pin_2 + 3;
                    pout = pout + 3;

                }
                pin_1 += oldData.Stride - oldData.Width * 3;
                pin_2 += oldData.Stride - oldData.Width * 3;
                pout += newData.Stride - newData.Width * 3;
            }

            //这里博主加粗了一下线条- -，不喜欢的同学可以删了这段代码
          /*  byte* pin_5 = (byte*)(newData.Scan0.ToPointer());
            for (int y = 0; y < oldData.Height - 1; y++)
            {
                for (int x = 3; x < oldData.Width-1; x++)
                {
                    if (pin_5[0] == 0 && pin_5[1] == 0 && pin_5[2] == 0)
                    {
                        pin_5[-3] = 0;
                        pin_5[-2] = 0;
                        pin_5[-1] = 0;      //边缘点的前一个像素点置为黑色（注意一定要是遍历过的像素点）                                                    
                    }
                    pin_5 += 3;

                }
                pin_5 += newData.Stride - newData.Width * 3;
            }

            //这段代码是把原图和边缘图重合
           byte* pin_3 = (byte*)(oldData.Scan0.ToPointer());
            byte* pin_4 = (byte*)(newData.Scan0.ToPointer());
            for (int y = 0; y < oldData.Height - 1; y++)
            {
                for (int x = 0; x < oldData.Width; x++)
                {
                    if (pin_4[0] == 255 && pin_4[1] == 255 && pin_4[2] == 255)
                    {
                        pin_4[0] = pin_3[0];
                        pin_4[1] = pin_3[1];
                        pin_4[2] = pin_3[2];
                    }
                    pin_3 += 3;
                    pin_4 += 3;
                }
                pin_3 += oldData.Stride - oldData.Width * 3;
                pin_4 += newData.Stride - newData.Width * 3;
            }
            //......
            */
            bitmap.UnlockBits(newData);
            MyBitmap.UnlockBits(oldData);
           // this.pictureBox2.Image = bitmap;
            pictureBox2.Refresh();//刷新图片框
            pictureBox2.Image = bitmap;
        }





        /*if (pictureBox1.Image == null)
        {
            MessageBox.Show("错误，没有导入图片！");//判断图片框是否有图片，如果无图片，则给出错误信息
            return;
        }
        bt1 = new Bitmap(pictureBox1.Image);
        bt2 = new Bitmap(pictureBox1.Image); //定义两个位图对象 
        BinaryErosion();  //先腐蚀
        bt1 = new Bitmap(pictureBox2.Image);
        bt2 = new Bitmap(pictureBox2.Image);
        int R1, R2, R3;
        for (int i = 0; i < bt1.Width ; i++)
        {
            for (int j = 0; j < bt1.Height; j++)
            {
                R1 = bt1.GetPixel(i, j).R;
                R2 = originalBt.GetPixel(i, j).R;
                R3 = R2 - R1;
                bt2.SetPixel(i, j, Color.FromArgb(R3, R3, R3));
            }
            pictureBox2.Refresh();//刷新图片框
            pictureBox2.Image = bt2;
        }*/

    }
        #endregion

        private void 灰度图像形态学ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("灰度图像的数学形态学较复杂，另外可以先转成二值图像，然后进行二值图像的形态学处理！");
        }


#region //打开图像热识别窗口
        private void 图像热识别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formrec formitrecon = new Formrec();
            formitrecon.ShowDialog();
            
        }
        #endregion

#region//柔化效果
        private void 柔化效果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            bt1 = new Bitmap(pictureBox1.Image);
            bt2 = new Bitmap(pictureBox1.Image); //定义两个位图对象
             //高斯模板
            int[] Gauss = { 1, 2, 1, 2, 4, 2, 1, 2, 1 };
            try
            { 
                Color pixel;
                for (int i = 1; i < bt1.Width-1; i++)
                {
                    for (int j = 1; j < bt1.Height-1; j++)
                    {
                        int r = 0, g = 0, b = 0;
                        int Index = 0;
                        for (int col = -1; col <= 1; col++)
                            for (int row = -1; row <= 1; row++)
                            {
                                pixel = bt1.GetPixel(i + row, j + col);
                                r += pixel.R * Gauss[Index];
                                g += pixel.G * Gauss[Index];
                                b += pixel.B * Gauss[Index];
                                Index++;
                            }
                        r /= 16;
                        g /= 16;
                        b /= 16;
                        //处理颜色值溢出
                        r = r > 255 ? 255 : r;
                        r = r < 0 ? 0 : r;
                        g = g > 255 ? 255 : g;
                        g = g < 0 ? 0 : g;
                        b = b > 255 ? 255 : b;
                        b = b < 0 ? 0 : b;
                        bt2.SetPixel(i - 1, j- 1, Color.FromArgb(r, g, b));

                    }
                    pictureBox2.Refresh();//刷新图片框
                    pictureBox2.Image = bt2;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }
           

        }



        #endregion



       

       

#region//打开文字转图片窗口
        private void 文字转图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formtxtconpic formtxtconpic = new Formtxtconpic();
            formtxtconpic.ShowDialog();
        }
        #endregion
//#region//关于
//        private void 关于DToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            MessageBox.Show("通信卓越151王先文\n\n" + "201511106109\n\n" + "2017/9/15", "关于");
//        }
//        #endregion

        private void 二维码条形码ToolStrMenuItem_Click(object sender, EventArgs e)
        {
            FormQRCode formQRCode = new FormQRCode();
            formQRCode.ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("通信卓越151王先文\n\n" + "201511106109\n\n" + "2017/9/15", "关于");
        }

        private void 运动检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VideoSurveilance surveilance = new VideoSurveilance();
            surveilance.ShowDialog();
        }

        private void 车牌识别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicensePlateRecognitionForm licensePlateRecognition = new LicensePlateRecognitionForm();
            licensePlateRecognition.ShowDialog();
        }

        private void 锐化ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
    }
