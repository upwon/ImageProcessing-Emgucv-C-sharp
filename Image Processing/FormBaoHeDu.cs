using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class FormBaoHeDu : Form
    {
        public FormBaoHeDu()
        {
            InitializeComponent();
        }

        public int valueH, valueS, valueI;

        private void trackBarH_Scroll(object sender, EventArgs e)
        {
            //拉动滑动条改变 H（色调）
            textH.Text = trackBarH.Value.ToString();
            valueH = trackBarH.Value;
        }

        private void trackBarS_Scroll(object sender, EventArgs e)
        {
            //拉动滑动条改变 S（饱和度）
            textS.Text = trackBarS.Value.ToString();
            valueS = trackBarS.Value;
        }

        private void trackBarI_Scroll(object sender, EventArgs e)
        {
            //拉动滑动条改变 I（亮度） 
            textI.Text = trackBarI.Value.ToString();
            valueI = trackBarI.Value;
        }

        private void butBaoHeDu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
       
    }
}