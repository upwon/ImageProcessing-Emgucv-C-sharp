namespace Image_Processing
{
    partial class Formtxtconpic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formtxtconpic));
            this.button_font = new System.Windows.Forms.Button();
            this.btn_savepic = new System.Windows.Forms.Button();
            this.comboBox_pictype = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label111 = new System.Windows.Forms.Label();
            this.label112 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_font
            // 
            this.button_font.BackColor = System.Drawing.SystemColors.Info;
            this.button_font.Location = new System.Drawing.Point(271, 46);
            this.button_font.Margin = new System.Windows.Forms.Padding(4);
            this.button_font.Name = "button_font";
            this.button_font.Size = new System.Drawing.Size(118, 30);
            this.button_font.TabIndex = 0;
            this.button_font.Text = "字体选择";
            this.button_font.UseVisualStyleBackColor = false;
            this.button_font.Click += new System.EventHandler(this.button_font_Click);
            // 
            // btn_savepic
            // 
            this.btn_savepic.BackColor = System.Drawing.SystemColors.Info;
            this.btn_savepic.Location = new System.Drawing.Point(686, 45);
            this.btn_savepic.Margin = new System.Windows.Forms.Padding(4);
            this.btn_savepic.Name = "btn_savepic";
            this.btn_savepic.Size = new System.Drawing.Size(93, 30);
            this.btn_savepic.TabIndex = 0;
            this.btn_savepic.Text = "保存";
            this.btn_savepic.UseVisualStyleBackColor = false;
            this.btn_savepic.Click += new System.EventHandler(this.btn_savepic_Click);
            // 
            // comboBox_pictype
            // 
            this.comboBox_pictype.BackColor = System.Drawing.SystemColors.Info;
            this.comboBox_pictype.FormattingEnabled = true;
            this.comboBox_pictype.Items.AddRange(new object[] {
            ".jpg",
            ".bmp",
            ".png"});
            this.comboBox_pictype.Location = new System.Drawing.Point(530, 50);
            this.comboBox_pictype.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_pictype.Name = "comboBox_pictype";
            this.comboBox_pictype.Size = new System.Drawing.Size(121, 23);
            this.comboBox_pictype.TabIndex = 1;
            this.comboBox_pictype.Text = ".jpg";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.SystemColors.Info;
            this.numericUpDown1.Location = new System.Drawing.Point(162, 47);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(73, 25);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.BackColor = System.Drawing.SystemColors.Window;
            this.label111.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label111.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label111.Location = new System.Drawing.Point(78, 50);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(66, 19);
            this.label111.TabIndex = 4;
            this.label111.Text = "字号：";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.BackColor = System.Drawing.SystemColors.Window;
            this.label112.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label112.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label112.Location = new System.Drawing.Point(419, 53);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(104, 19);
            this.label112.TabIndex = 4;
            this.label112.Text = "保存格式：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(61, 119);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(681, 289);
            this.textBox1.TabIndex = 6;
            // 
            // Formtxtconpic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(818, 481);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label112);
            this.Controls.Add(this.label111);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.comboBox_pictype);
            this.Controls.Add(this.btn_savepic);
            this.Controls.Add(this.button_font);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Formtxtconpic";
            this.Text = "文字转图片";
            this.Load += new System.EventHandler(this.Formtxtconpic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_font;
        private System.Windows.Forms.Button btn_savepic;
        private System.Windows.Forms.ComboBox comboBox_pictype;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        protected System.Windows.Forms.Label label111;
        protected System.Windows.Forms.Label label112;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
    }
}