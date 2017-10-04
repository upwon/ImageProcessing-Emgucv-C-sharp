using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class FormTouMing : Form
    {
        int value;
        public FormTouMing()
        {
            InitializeComponent();
        }

        private void trackBarTouMingBH_Scroll(object sender, EventArgs e)
        {
            //拉动滑动条调节α的值
            textTouMingBH.Text = trackBarTouMingBH.Value.ToString();
        }

        public int TouMingBHValue()
        {
            // 以下两种方法都行
            value = trackBarTouMingBH.Value;//通过滑动条给 a 赋值
            //LD = int.Parse(textLD.Text);
            
            return value;
        }

        private void butTouMingBH_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}