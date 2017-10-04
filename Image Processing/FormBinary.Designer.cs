namespace Image_Processing
{
    partial class FormBinary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBinary));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butBinary = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labBinary = new System.Windows.Forms.Label();
            this.textBinary = new System.Windows.Forms.TextBox();
            this.trackBarBinary = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBinary)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butBinary);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 135);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // butBinary
            // 
            this.butBinary.Location = new System.Drawing.Point(6, 102);
            this.butBinary.Name = "butBinary";
            this.butBinary.Size = new System.Drawing.Size(380, 27);
            this.butBinary.TabIndex = 39;
            this.butBinary.Text = "确定";
            this.butBinary.UseVisualStyleBackColor = true;
            this.butBinary.Click += new System.EventHandler(this.butBinary_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labBinary);
            this.panel5.Controls.Add(this.textBinary);
            this.panel5.Controls.Add(this.trackBarBinary);
            this.panel5.Location = new System.Drawing.Point(6, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(380, 66);
            this.panel5.TabIndex = 47;
            // 
            // labBinary
            // 
            this.labBinary.AutoSize = true;
            this.labBinary.Location = new System.Drawing.Point(8, 24);
            this.labBinary.Name = "labBinary";
            this.labBinary.Size = new System.Drawing.Size(113, 12);
            this.labBinary.TabIndex = 0;
            this.labBinary.Text = "请调节二值化的阈值";
            // 
            // textBinary
            // 
            this.textBinary.Location = new System.Drawing.Point(324, 21);
            this.textBinary.Name = "textBinary";
            this.textBinary.Size = new System.Drawing.Size(44, 21);
            this.textBinary.TabIndex = 40;
            // 
            // trackBarBinary
            // 
            this.trackBarBinary.Location = new System.Drawing.Point(122, 15);
            this.trackBarBinary.Maximum = 255;
            this.trackBarBinary.Name = "trackBarBinary";
            this.trackBarBinary.Size = new System.Drawing.Size(196, 45);
            this.trackBarBinary.TabIndex = 38;
            this.trackBarBinary.Value = 128;
            this.trackBarBinary.Scroll += new System.EventHandler(this.trackBarBinary_Scroll);
            // 
            // FormBinary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(416, 162);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBinary";
            this.Text = "简单二值化";
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBinary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butBinary;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labBinary;
        private System.Windows.Forms.TextBox textBinary;
        private System.Windows.Forms.TrackBar trackBarBinary;
    }
}