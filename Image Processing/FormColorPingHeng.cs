using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class FormColorPingHeng : Form
    {
        public FormColorPingHeng()
        {
            InitializeComponent();
        }
        public int valueR, valueG, valueB;

        private void trackBarR_Scroll(object sender, EventArgs e)
        {
            //拉动滑动条改变红色分量
            textR.Text = trackBarR.Value.ToString();
            valueR = trackBarR.Value;
        }

        private void trackBarG_Scroll(object sender, EventArgs e)
        {
            //拉动滑动条改变绿色分量
            textG.Text = trackBarG.Value.ToString();
            valueG = trackBarG.Value;
        }

        private void trackBarB_Scroll(object sender, EventArgs e)
        {
            //拉动滑动条改变蓝色分量
            textB.Text = trackBarB.Value.ToString();
            valueB = trackBarB.Value;
        }

        private void butColorPingHeng_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
       
    }
}