namespace Image_Processing
{
    partial class FormLiangDu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLiangDu));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butLD = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labLD = new System.Windows.Forms.Label();
            this.textLD = new System.Windows.Forms.TextBox();
            this.trackBarLD = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLD)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butLD);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // butLD
            // 
            this.butLD.Location = new System.Drawing.Point(6, 102);
            this.butLD.Name = "butLD";
            this.butLD.Size = new System.Drawing.Size(346, 27);
            this.butLD.TabIndex = 39;
            this.butLD.Text = "确定";
            this.butLD.UseVisualStyleBackColor = true;
            this.butLD.Click += new System.EventHandler(this.butLD_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labLD);
            this.panel5.Controls.Add(this.textLD);
            this.panel5.Controls.Add(this.trackBarLD);
            this.panel5.Location = new System.Drawing.Point(6, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(348, 66);
            this.panel5.TabIndex = 47;
            // 
            // labLD
            // 
            this.labLD.AutoSize = true;
            this.labLD.Location = new System.Drawing.Point(8, 24);
            this.labLD.Name = "labLD";
            this.labLD.Size = new System.Drawing.Size(65, 12);
            this.labLD.TabIndex = 0;
            this.labLD.Text = "请调节亮度";
            // 
            // textLD
            // 
            this.textLD.Location = new System.Drawing.Point(291, 19);
            this.textLD.Name = "textLD";
            this.textLD.Size = new System.Drawing.Size(44, 21);
            this.textLD.TabIndex = 40;
            // 
            // trackBarLD
            // 
            this.trackBarLD.Location = new System.Drawing.Point(89, 13);
            this.trackBarLD.Maximum = 25;
            this.trackBarLD.Minimum = -25;
            this.trackBarLD.Name = "trackBarLD";
            this.trackBarLD.Size = new System.Drawing.Size(196, 45);
            this.trackBarLD.TabIndex = 38;
            this.trackBarLD.Scroll += new System.EventHandler(this.trackBarLD_Scroll);
            // 
            // FormLiangDu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(383, 161);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLiangDu";
            this.Text = "亮度调节";
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butLD;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labLD;
        private System.Windows.Forms.TextBox textLD;
        private System.Windows.Forms.TrackBar trackBarLD;
    }
}