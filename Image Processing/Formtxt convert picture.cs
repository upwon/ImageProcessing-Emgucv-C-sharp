using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Image_Processing
{
    public partial class Formtxtconpic : Form
    {
        public Formtxtconpic()
        {
            InitializeComponent();
           
        }
#region//保存图片
        private void btn_savepic_Click(object sender, EventArgs e)//保存
        {
            Graphics myGraphics = this.CreateGraphics();
            saveFileDialog1.Filter = "*.png|*.png|*.jpeg|*.jpg|*.bmp|*.bmp";
            Bitmap myBitmap = new Bitmap(textBox1.Width, textBox1.Height);
            myGraphics = Graphics.FromImage(myBitmap);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                switch (comboBox_pictype.Text)
                {

                    case ".jpg":
                        myGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, textBox1.Width, textBox1.Height);
                        myGraphics.DrawString(textBox1.Text, new Font(textBox1.Font.FontFamily.Name.ToString(), textBox1.Font.Size), new SolidBrush(Color.Black), new Point(0, 2));
                        myBitmap.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);

                        myGraphics.Dispose();
                        myBitmap.Dispose();
                        break;
                    case ".bmp":
                        myGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, textBox1.Width, textBox1.Height);
                        myGraphics.DrawString(textBox1.Text, new Font(textBox1.Font.FontFamily.Name.ToString(), textBox1.Font.Size), new SolidBrush(Color.Black), new Point(0, 2));
                        myBitmap.Save(saveFileDialog1.FileName, ImageFormat.Bmp);

                        myGraphics.Dispose();
                        myBitmap.Dispose();
                        break;
                    case ".png":
                        myGraphics.FillRectangle(new SolidBrush(Color.Transparent), 0, 0, textBox1.Width, textBox1.Height);
                        myGraphics.DrawString(textBox1.Text, new Font(textBox1.Font.FontFamily.Name.ToString(), textBox1.Font.Size), new SolidBrush(Color.Black), new Point(0, 2));
                        myBitmap.Save(saveFileDialog1.FileName, ImageFormat.Png);

                        myGraphics.Dispose();
                        myBitmap.Dispose();
                        break;
                }

                /* switch (comboBox_pictype.Text)
                 {
                     case ".jpg":
                         myGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, textBox1.Width, textBox1.Height);
                         myGraphics.DrawString(textBox1.Text, new Font(textBox1.Font.FontFamily.Name.ToString(), textBox1.Font.Size), new SolidBrush(Color.Black), new Point(0, 2));
                         myBitmap.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);

                         myGraphics.Dispose();
                         myBitmap.Dispose();
                         break;
                     case ".bmp":
                         myGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, textBox1.Width, textBox1.Height);
                         myGraphics.DrawString(textBox1.Text, new Font(textBox1.Font.FontFamily.Name.ToString(), textBox1.Font.Size), new SolidBrush(Color.Black), new Point(0, 2));
                         myBitmap.Save(saveFileDialog1.FileName, ImageFormat.Bmp);

                         myGraphics.Dispose();
                         myBitmap.Dispose();
                         break;
                     case ".png":
                         myGraphics.FillRectangle(new SolidBrush(Color.Transparent), 0, 0, textBox1.Width, textBox1.Height);
                         myGraphics.DrawString(textBox1.Text, new Font(textBox1.Font.FontFamily.Name.ToString(), textBox1.Font.Size), new SolidBrush(Color.Black), new Point(0, 2));
                         myBitmap.Save(saveFileDialog1.FileName, ImageFormat.Png);

                         myGraphics.Dispose();
                         myBitmap.Dispose();
                         break;
                 }*/
            }
        }
#endregion

        private void Formtxtconpic_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = (int)textBox1.Font.Size;   //获取textbox的大小
           // button_font.Text = textBox1 .Font.FontFamily.Name.ToString();
            button_font.Text = "字体选择";


            // numericUpDown1.Value = (int)textBox1.Font.Size;   //获取textbox的大小
            // button_font.Text = textBox1.Font.FontFamily.Name.ToString();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Font = new Font(button_font.Text.ToString(), (float)numericUpDown1.Value);
            // textBox1.Font = new Font(button_font.Text.ToString(), (float)numericUpDown1.Value);
            //richTextBox1.Font= new Font(button_font.Text.ToString(), (float)numericUpDown1.Value);
        }

        private void button_font_Click(object sender, EventArgs e)
        {
            FontDialog fdig = new FontDialog();
            if (fdig.ShowDialog() == DialogResult.Cancel)
                return;

           // richTextBox1.Font = fdig.Font;
          textBox1.Font = fdig.Font;


            //button_font.Text = textBox1.Font.FontFamily.Name.ToString();

            button_font.Text = textBox1.Font.FontFamily.Name.ToString();

            numericUpDown1.Value = (int)fdig.Font.Size;
        }
    }
}
