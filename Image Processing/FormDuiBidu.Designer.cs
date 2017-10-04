namespace Image_Processing
{
    partial class FormDuiBidu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDuiBidu));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butDuiBd = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labDuiBD = new System.Windows.Forms.Label();
            this.textDuiBD = new System.Windows.Forms.TextBox();
            this.trackBarDuiBD = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDuiBD)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butDuiBd);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 135);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // butDuiBd
            // 
            this.butDuiBd.Location = new System.Drawing.Point(6, 102);
            this.butDuiBd.Name = "butDuiBd";
            this.butDuiBd.Size = new System.Drawing.Size(346, 27);
            this.butDuiBd.TabIndex = 39;
            this.butDuiBd.Text = "确定";
            this.butDuiBd.UseVisualStyleBackColor = true;
            this.butDuiBd.Click += new System.EventHandler(this.butDuiBd_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labDuiBD);
            this.panel5.Controls.Add(this.textDuiBD);
            this.panel5.Controls.Add(this.trackBarDuiBD);
            this.panel5.Location = new System.Drawing.Point(6, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(348, 66);
            this.panel5.TabIndex = 47;
            // 
            // labDuiBD
            // 
            this.labDuiBD.AutoSize = true;
            this.labDuiBD.Location = new System.Drawing.Point(8, 24);
            this.labDuiBD.Name = "labDuiBD";
            this.labDuiBD.Size = new System.Drawing.Size(77, 12);
            this.labDuiBD.TabIndex = 0;
            this.labDuiBD.Text = "请调节对比度";
            // 
            // textDuiBD
            // 
            this.textDuiBD.Location = new System.Drawing.Point(291, 19);
            this.textDuiBD.Name = "textDuiBD";
            this.textDuiBD.Size = new System.Drawing.Size(44, 21);
            this.textDuiBD.TabIndex = 40;
            // 
            // trackBarDuiBD
            // 
            this.trackBarDuiBD.Location = new System.Drawing.Point(89, 13);
            this.trackBarDuiBD.Maximum = 100;
            this.trackBarDuiBD.Minimum = -100;
            this.trackBarDuiBD.Name = "trackBarDuiBD";
            this.trackBarDuiBD.Size = new System.Drawing.Size(196, 45);
            this.trackBarDuiBD.TabIndex = 38;
            this.trackBarDuiBD.Scroll += new System.EventHandler(this.trackBarDuiBD_Scroll);
            // 
            // FormDuiBidu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(380, 159);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDuiBidu";
            this.Text = "对比度调节";
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDuiBD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butDuiBd;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labDuiBD;
        private System.Windows.Forms.TextBox textDuiBD;
        private System.Windows.Forms.TrackBar trackBarDuiBD;
    }
}