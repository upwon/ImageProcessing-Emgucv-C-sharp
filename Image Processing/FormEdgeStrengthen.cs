using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class FormEdgeStrengthen : Form
    {
        public FormEdgeStrengthen()
        {
            InitializeComponent();
        }

        public int EdgeStrengthen;

        private void trackBarEdgeStrengthen_Scroll(object sender, EventArgs e)
        {
            //通过滑竿调节阈值
            textEdgeStrengthen.Text = trackBarEdgeStrengthen.Value.ToString();
            EdgeStrengthen = trackBarEdgeStrengthen.Value;
        }

        private void butLD_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   
    }
}