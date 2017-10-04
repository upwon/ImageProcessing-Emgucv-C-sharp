namespace Image_Processing
{
    partial class FormQRCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQRCode));
            this.pictureBoxRs = new System.Windows.Forms.PictureBox();
            this.buttonAnalysis = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonBarcode = new System.Windows.Forms.Button();
            this.buttonQrcode = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRs)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxRs
            // 
            this.pictureBoxRs.Location = new System.Drawing.Point(56, 163);
            this.pictureBoxRs.Name = "pictureBoxRs";
            this.pictureBoxRs.Size = new System.Drawing.Size(519, 275);
            this.pictureBoxRs.TabIndex = 10;
            this.pictureBoxRs.TabStop = false;
            // 
            // buttonAnalysis
            // 
            this.buttonAnalysis.Location = new System.Drawing.Point(347, 106);
            this.buttonAnalysis.Name = "buttonAnalysis";
            this.buttonAnalysis.Size = new System.Drawing.Size(75, 25);
            this.buttonAnalysis.TabIndex = 6;
            this.buttonAnalysis.Text = "解析";
            this.buttonAnalysis.UseVisualStyleBackColor = true;
            this.buttonAnalysis.Click += new System.EventHandler(this.buttonAnalysis_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(470, 106);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 25);
            this.buttonPrint.TabIndex = 7;
            this.buttonPrint.Text = "打印";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click_1);
            // 
            // buttonBarcode
            // 
            this.buttonBarcode.Location = new System.Drawing.Point(216, 106);
            this.buttonBarcode.Name = "buttonBarcode";
            this.buttonBarcode.Size = new System.Drawing.Size(92, 25);
            this.buttonBarcode.TabIndex = 8;
            this.buttonBarcode.Text = "生成二维码";
            this.buttonBarcode.UseVisualStyleBackColor = true;
            this.buttonBarcode.Click += new System.EventHandler(this.buttonBarcode_Click_1);
            // 
            // buttonQrcode
            // 
            this.buttonQrcode.AutoSize = true;
            this.buttonQrcode.Location = new System.Drawing.Point(83, 106);
            this.buttonQrcode.Name = "buttonQrcode";
            this.buttonQrcode.Size = new System.Drawing.Size(92, 25);
            this.buttonQrcode.TabIndex = 9;
            this.buttonQrcode.Text = "生成条形码";
            this.buttonQrcode.UseVisualStyleBackColor = true;
            this.buttonQrcode.Click += new System.EventHandler(this.buttonQrcode_Click_1);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(216, 35);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(329, 25);
            this.txtMsg.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "请输入生成内容：";
            // 
            // FormQRCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(631, 472);
            this.Controls.Add(this.pictureBoxRs);
            this.Controls.Add(this.buttonAnalysis);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonBarcode);
            this.Controls.Add(this.buttonQrcode);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormQRCode";
            this.Text = "FormQRCode";
            this.Load += new System.EventHandler(this.FormQRCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxRs;
        private System.Windows.Forms.Button buttonAnalysis;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonBarcode;
        private System.Windows.Forms.Button buttonQrcode;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label label1;
    }
}