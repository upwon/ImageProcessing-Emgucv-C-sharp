using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class FormBinary : Form
    {
        int value;
        public FormBinary()
        {
            InitializeComponent();
        }

        private void trackBarBinary_Scroll(object sender, EventArgs e)
        {
            //调节二值化的阈值
            textBinary.Text = trackBarBinary.Value.ToString();
        }

        public int BinaryValue()
        {
            // 以下两种方法都行
            value = trackBarBinary.Value;//通过滑动条调节二值化的阈值
            //LD = int.Parse(textLD.Text);

            return value;
        }

        private void butBinary_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}