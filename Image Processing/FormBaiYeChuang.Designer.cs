namespace Image_Processing
{
    partial class FormBaiYeChuang
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBaiYeChuang));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBaiYiChuang = new System.Windows.Forms.TextBox();
            this.labelChuiZhiBYC = new System.Windows.Forms.Label();
            this.butPingYi = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBaiYiChuang);
            this.groupBox1.Controls.Add(this.labelChuiZhiBYC);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 90);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // textBaiYiChuang
            // 
            this.textBaiYiChuang.Location = new System.Drawing.Point(76, 54);
            this.textBaiYiChuang.Name = "textBaiYiChuang";
            this.textBaiYiChuang.Size = new System.Drawing.Size(99, 21);
            this.textBaiYiChuang.TabIndex = 2;
            // 
            // labelChuiZhiBYC
            // 
            this.labelChuiZhiBYC.AutoSize = true;
            this.labelChuiZhiBYC.Location = new System.Drawing.Point(74, 25);
            this.labelChuiZhiBYC.Name = "labelChuiZhiBYC";
            this.labelChuiZhiBYC.Size = new System.Drawing.Size(101, 12);
            this.labelChuiZhiBYC.TabIndex = 1;
            this.labelChuiZhiBYC.Text = "请输入百叶窗数目";
            // 
            // butPingYi
            // 
            this.butPingYi.Location = new System.Drawing.Point(76, 20);
            this.butPingYi.Name = "butPingYi";
            this.butPingYi.Size = new System.Drawing.Size(99, 28);
            this.butPingYi.TabIndex = 0;
            this.butPingYi.Text = "确定";
            this.butPingYi.UseVisualStyleBackColor = true;
            this.butPingYi.Click += new System.EventHandler(this.butPingYi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butPingYi);
            this.groupBox2.Location = new System.Drawing.Point(12, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 65);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // FormBaiYeChuang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(277, 188);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBaiYeChuang";
            this.Text = "百叶窗";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBaiYiChuang;
        private System.Windows.Forms.Label labelChuiZhiBYC;
        private System.Windows.Forms.Button butPingYi;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}