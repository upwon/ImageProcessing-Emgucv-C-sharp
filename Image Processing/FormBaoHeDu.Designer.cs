namespace Image_Processing
{
    partial class FormBaoHeDu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBaoHeDu));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelH = new System.Windows.Forms.Label();
            this.textH = new System.Windows.Forms.TextBox();
            this.trackBarH = new System.Windows.Forms.TrackBar();
            this.labelI = new System.Windows.Forms.Label();
            this.textI = new System.Windows.Forms.TextBox();
            this.trackBarI = new System.Windows.Forms.TrackBar();
            this.labelS = new System.Windows.Forms.Label();
            this.textS = new System.Windows.Forms.TextBox();
            this.trackBarS = new System.Windows.Forms.TrackBar();
            this.butBaoHeDu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelH);
            this.groupBox1.Controls.Add(this.textH);
            this.groupBox1.Controls.Add(this.trackBarH);
            this.groupBox1.Controls.Add(this.labelI);
            this.groupBox1.Controls.Add(this.textI);
            this.groupBox1.Controls.Add(this.trackBarI);
            this.groupBox1.Controls.Add(this.labelS);
            this.groupBox1.Controls.Add(this.textS);
            this.groupBox1.Controls.Add(this.trackBarS);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HSI 分量调节";
            // 
            // labelH
            // 
            this.labelH.AutoSize = true;
            this.labelH.Location = new System.Drawing.Point(6, 31);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(23, 12);
            this.labelH.TabIndex = 47;
            this.labelH.Text = "H：";
            // 
            // textH
            // 
            this.textH.Location = new System.Drawing.Point(244, 28);
            this.textH.Name = "textH";
            this.textH.Size = new System.Drawing.Size(44, 21);
            this.textH.TabIndex = 49;
            // 
            // trackBarH
            // 
            this.trackBarH.Location = new System.Drawing.Point(42, 20);
            this.trackBarH.Maximum = 360;
            this.trackBarH.Name = "trackBarH";
            this.trackBarH.Size = new System.Drawing.Size(196, 45);
            this.trackBarH.TabIndex = 48;
            this.trackBarH.Scroll += new System.EventHandler(this.trackBarH_Scroll);
            // 
            // labelI
            // 
            this.labelI.AutoSize = true;
            this.labelI.Location = new System.Drawing.Point(6, 133);
            this.labelI.Name = "labelI";
            this.labelI.Size = new System.Drawing.Size(23, 12);
            this.labelI.TabIndex = 44;
            this.labelI.Text = "I：";
            // 
            // textI
            // 
            this.textI.Location = new System.Drawing.Point(244, 130);
            this.textI.Name = "textI";
            this.textI.Size = new System.Drawing.Size(44, 21);
            this.textI.TabIndex = 46;
            // 
            // trackBarI
            // 
            this.trackBarI.Location = new System.Drawing.Point(42, 122);
            this.trackBarI.Maximum = 255;
            this.trackBarI.Name = "trackBarI";
            this.trackBarI.Size = new System.Drawing.Size(196, 45);
            this.trackBarI.TabIndex = 45;
            this.trackBarI.Scroll += new System.EventHandler(this.trackBarI_Scroll);
            // 
            // labelS
            // 
            this.labelS.AutoSize = true;
            this.labelS.Location = new System.Drawing.Point(6, 82);
            this.labelS.Name = "labelS";
            this.labelS.Size = new System.Drawing.Size(23, 12);
            this.labelS.TabIndex = 41;
            this.labelS.Text = "S：";
            // 
            // textS
            // 
            this.textS.Location = new System.Drawing.Point(244, 79);
            this.textS.Name = "textS";
            this.textS.Size = new System.Drawing.Size(44, 21);
            this.textS.TabIndex = 43;
            // 
            // trackBarS
            // 
            this.trackBarS.Location = new System.Drawing.Point(42, 71);
            this.trackBarS.Maximum = 255;
            this.trackBarS.Name = "trackBarS";
            this.trackBarS.Size = new System.Drawing.Size(196, 45);
            this.trackBarS.TabIndex = 42;
            this.trackBarS.Scroll += new System.EventHandler(this.trackBarS_Scroll);
            // 
            // butBaoHeDu
            // 
            this.butBaoHeDu.Location = new System.Drawing.Point(12, 192);
            this.butBaoHeDu.Name = "butBaoHeDu";
            this.butBaoHeDu.Size = new System.Drawing.Size(302, 32);
            this.butBaoHeDu.TabIndex = 1;
            this.butBaoHeDu.Text = "确定";
            this.butBaoHeDu.UseVisualStyleBackColor = true;
            this.butBaoHeDu.Click += new System.EventHandler(this.butBaoHeDu_Click);
            // 
            // FormBaoHeDu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(328, 234);
            this.Controls.Add(this.butBaoHeDu);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBaoHeDu";
            this.Text = "饱和度调节";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelH;
        private System.Windows.Forms.TextBox textH;
        private System.Windows.Forms.TrackBar trackBarH;
        private System.Windows.Forms.Label labelI;
        private System.Windows.Forms.TextBox textI;
        private System.Windows.Forms.TrackBar trackBarI;
        private System.Windows.Forms.Label labelS;
        private System.Windows.Forms.TextBox textS;
        private System.Windows.Forms.TrackBar trackBarS;
        private System.Windows.Forms.Button butBaoHeDu;
    }
}