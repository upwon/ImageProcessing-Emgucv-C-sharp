namespace Image_Processing
{
    partial class Formrec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_rec = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_rec)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_rec
            // 
            this.pictureBox_rec.Location = new System.Drawing.Point(3, 31);
            this.pictureBox_rec.Name = "pictureBox_rec";
            this.pictureBox_rec.Size = new System.Drawing.Size(649, 445);
            this.pictureBox_rec.TabIndex = 0;
            this.pictureBox_rec.TabStop = false;
            this.pictureBox_rec.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_rec_MouseMove);
            // 
            // Formrec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 530);
            this.Controls.Add(this.pictureBox_rec);
            this.Name = "Formrec";
            this.Text = "图像热识别";
            this.Load += new System.EventHandler(this.Formrec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_rec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_rec;
    }
}