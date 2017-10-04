using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class FormPingYi : Form
    {
        int X, Y;        
        public int XValue()
        {    
            X = int.Parse(textX.Text);
            return X;
        }
        public int YValue()
        {
            Y = int.Parse(textY.Text);

            return Y;
        }
        public FormPingYi()
        {
            InitializeComponent();
        }

        private void butPingYi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}