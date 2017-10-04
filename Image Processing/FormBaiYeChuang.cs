using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class FormBaiYeChuang : Form
    {
        public int baiyechuang;
        public FormBaiYeChuang()
        {
            InitializeComponent();
        }

        private void butPingYi_Click(object sender, EventArgs e)
        {
            baiyechuang = int.Parse(textBaiYiChuang.Text);
            this.Close();
        }
    }
}