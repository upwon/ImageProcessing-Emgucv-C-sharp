using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class FormDuiBidu : Form
    {
        int DuiBD;
        public FormDuiBidu()
        {
            InitializeComponent();
        }

        private void trackBarDuiBD_Scroll(object sender, EventArgs e)
        {
            //拉动滑动条改变阈值
            textDuiBD.Text = trackBarDuiBD.Value.ToString();
        }

        public int DuiBDValue()
        {
            // 以下两种方法都行
            DuiBD = trackBarDuiBD.Value;//通过滑动条调节对比度的效果
            //LD = int.Parse(textLD.Text);

            return DuiBD;
        }

        private void butDuiBd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}