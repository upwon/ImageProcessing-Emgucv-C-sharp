using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class FormLiangDu : Form
    {
        int LD;
        public FormLiangDu()
        {
            InitializeComponent();
        }
        private void trackBarLD_Scroll(object sender, EventArgs e)
        {
            //拉动亮度滑杆后，滑杆的值改变，将滑杆的值在文本框中显示，作为亮度的调节值
            textLD.Text = trackBarLD.Value.ToString();
        }
        public int LDValue()
        {
            // 以下两种方法都行
            LD = trackBarLD.Value;//通过滑动条调节亮度值
            //LD = int.Parse(textLD.Text);

            return LD;
        }
        private void butLD_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}