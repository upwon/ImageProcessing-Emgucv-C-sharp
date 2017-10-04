using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace Image_Processing
{
    class DocementBase : PrintDocument
    {


        //fields

        public Font Font = new Font("Verdana", 10, GraphicsUnit.Point);



        //预览打印

        public DialogResult showPrintPreviewDialog()

        {

            PrintPreviewDialog dialog = new PrintPreviewDialog();

            dialog.Document = this;



            return dialog.ShowDialog();

        }



        //先设置后打印

        public DialogResult ShowPageSettingsDialog()

        {

            PageSetupDialog dialog = new PageSetupDialog();

            dialog.Document = this;



            return dialog.ShowDialog();

        }

      /*  public static implicit operator PrintDocument(DocementBase v)
        {
            throw new NotImplementedException();
        }*/
    }

}
