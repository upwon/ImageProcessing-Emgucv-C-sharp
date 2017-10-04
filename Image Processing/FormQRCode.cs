using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ZXing;
using ZXing.QrCode.Internal;
using ZXing.Common;
using System.IO;
using ZXing.QrCode;

namespace Image_Processing
{
    public partial class FormQRCode : Form
    {
        public FormQRCode()
        {
            InitializeComponent();
        }


        private BarCodeClass bcc = new BarCodeClass();

        private DocementBase _docement;

        private void FormQRCode_Load(object sender, EventArgs e)
        {
            txtMsg.Text = System.DateTime.Now.ToString("yyyyMMddhhmmss").Substring(0, 12);
        }



      /*  private void buttonBarcode_Click(object sender, EventArgs e)
        {
            bcc.CreateQuickMark(pictureBoxRs, txtMsg.Text);
        }
*/
        private void buttonQrcode_Click_1(object sender, EventArgs e)
        {
            bcc.CreateBarCode(pictureBoxRs, txtMsg.Text);
        }

        private void buttonBarcode_Click_1(object sender, EventArgs e)
        {
            bcc.CreateQuickMark(pictureBoxRs, txtMsg.Text);
        }
        private void buttonAnalysis_Click(object sender, EventArgs e)
        {
            if (pictureBoxRs.Image == null)

            {

                MessageBox.Show("请录入图像后再进行解码!");

                return;
            }
            BarcodeReader reader = new BarcodeReader();

            Result result = reader.Decode((Bitmap)pictureBoxRs.Image);

            MessageBox.Show(result.Text);
        }

  


      
        private void buttonPrint_Click_1(object sender, EventArgs e)
        {
            if (pictureBoxRs.Image == null)

            {

                MessageBox.Show("You Must Load an Image first!");

                return;

            }

            else

            {

                _docement = new imageDocument(pictureBoxRs.Image);

            }

            _docement.showPrintPreviewDialog();
        }
    }
}

  
    

