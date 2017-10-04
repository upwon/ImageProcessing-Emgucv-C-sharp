using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;

namespace Image_Processing
{
    class imageDocument : DocementBase

    {

        private Image _Image;



        public Image Image

        {

            get

            {

                return _Image;

            }

            set

            {

                _Image = value;



                if (_Image != null)

                {

                    if (_Image.Size.Width > _Image.Size.Height)

                        DefaultPageSettings.Landscape = true;

                    else

                        DefaultPageSettings.Landscape = false;

                }

            }

        }





        public imageDocument()

        {



        }




        public imageDocument(Image image)

        {

            this.Image = image;

        }




        protected override void OnPrintPage (PrintPageEventArgs e)

        {

            if (Image == null)

            {

                throw new InvalidOperationException();

            }



            Rectangle bestFit = GetBestFitRectangle(e.MarginBounds, Image.Size);



            e.Graphics.DrawImage(Image, bestFit);



            e.Graphics.DrawRectangle(Pens.Black, bestFit);

            e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds);

        }



        // 保持高度比：参数为(打印边界的Rectangularle对象，图像大小的Size对象)

        protected Rectangle GetBestFitRectangle(Rectangle toContain, Size objectSize)

        {

            //检查页面是水平还是竖直的。

            bool containerLandscape = false;

            if (toContain.Width > toContain.Height)

                containerLandscape = true;



            //高度比=图像的高/图像的宽

            float aspectRatio = (float)objectSize.Height / (float)objectSize.Width;

            //得到页面左上角的坐标

            int midContainerX = toContain.Left + (toContain.Width / 2);

            int midContainerY = toContain.Top + (toContain.Height / 2);



            int x1 = 0, x2 = 0, y1 = 0, y2 = 0;

            if (containerLandscape == false)

            {

                //竖直图像

                x1 = toContain.Left;

                x2 = toContain.Right;

                //调整之后的height

                int adjustedHeight = (int)((float)toContain.Width * aspectRatio);



                y1 = midContainerY - (adjustedHeight / 2);

                y2 = y1 + adjustedHeight;

            }

            else

            {

                y1 = toContain.Top;

                y2 = toContain.Bottom;

                //调整之后的height

                int adjustedWidth = (int)((float)toContain.Height / aspectRatio);



                x1 = midContainerX - (adjustedWidth / 2);

                x2 = x1 + adjustedWidth;

            }

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);

        }

    }
}
