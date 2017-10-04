namespace Image_Processing
{
    partial class FormColorPingHeng
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormColorPingHeng));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelR = new System.Windows.Forms.Label();
            this.textR = new System.Windows.Forms.TextBox();
            this.trackBarR = new System.Windows.Forms.TrackBar();
            this.labelB = new System.Windows.Forms.Label();
            this.textB = new System.Windows.Forms.TextBox();
            this.trackBarB = new System.Windows.Forms.TrackBar();
            this.labelG = new System.Windows.Forms.Label();
            this.textG = new System.Windows.Forms.TextBox();
            this.trackBarG = new System.Windows.Forms.TrackBar();
            this.butColorPingHeng = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarG)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelR);
            this.groupBox1.Controls.Add(this.textR);
            this.groupBox1.Controls.Add(this.trackBarR);
            this.groupBox1.Controls.Add(this.labelB);
            this.groupBox1.Controls.Add(this.textB);
            this.groupBox1.Controls.Add(this.trackBarB);
            this.groupBox1.Controls.Add(this.labelG);
            this.groupBox1.Controls.Add(this.textG);
            this.groupBox1.Controls.Add(this.trackBarG);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 174);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HSI 分量调节";
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.Location = new System.Drawing.Point(6, 31);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(23, 12);
            this.labelR.TabIndex = 47;
            this.labelR.Text = "R：";
            // 
            // textR
            // 
            this.textR.Location = new System.Drawing.Point(244, 28);
            this.textR.Name = "textR";
            this.textR.Size = new System.Drawing.Size(44, 21);
            this.textR.TabIndex = 49;
            // 
            // trackBarR
            // 
            this.trackBarR.Location = new System.Drawing.Point(42, 20);
            this.trackBarR.Maximum = 255;
            this.trackBarR.Name = "trackBarR";
            this.trackBarR.Size = new System.Drawing.Size(196, 45);
            this.trackBarR.TabIndex = 48;
            this.trackBarR.Scroll += new System.EventHandler(this.trackBarR_Scroll);
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(6, 133);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(23, 12);
            this.labelB.TabIndex = 44;
            this.labelB.Text = "B：";
            // 
            // textB
            // 
            this.textB.Location = new System.Drawing.Point(244, 130);
            this.textB.Name = "textB";
            this.textB.Size = new System.Drawing.Size(44, 21);
            this.textB.TabIndex = 46;
            // 
            // trackBarB
            // 
            this.trackBarB.Location = new System.Drawing.Point(42, 122);
            this.trackBarB.Maximum = 255;
            this.trackBarB.Name = "trackBarB";
            this.trackBarB.Size = new System.Drawing.Size(196, 45);
            this.trackBarB.TabIndex = 45;
            this.trackBarB.Scroll += new System.EventHandler(this.trackBarB_Scroll);
            // 
            // labelG
            // 
            this.labelG.AutoSize = true;
            this.labelG.Location = new System.Drawing.Point(6, 82);
            this.labelG.Name = "labelG";
            this.labelG.Size = new System.Drawing.Size(23, 12);
            this.labelG.TabIndex = 41;
            this.labelG.Text = "G：";
            // 
            // textG
            // 
            this.textG.Location = new System.Drawing.Point(244, 79);
            this.textG.Name = "textG";
            this.textG.Size = new System.Drawing.Size(44, 21);
            this.textG.TabIndex = 43;
            // 
            // trackBarG
            // 
            this.trackBarG.Location = new System.Drawing.Point(42, 71);
            this.trackBarG.Maximum = 255;
            this.trackBarG.Name = "trackBarG";
            this.trackBarG.Size = new System.Drawing.Size(196, 45);
            this.trackBarG.TabIndex = 42;
            this.trackBarG.Scroll += new System.EventHandler(this.trackBarG_Scroll);
            // 
            // butColorPingHeng
            // 
            this.butColorPingHeng.Location = new System.Drawing.Point(13, 192);
            this.butColorPingHeng.Name = "butColorPingHeng";
            this.butColorPingHeng.Size = new System.Drawing.Size(302, 32);
            this.butColorPingHeng.TabIndex = 2;
            this.butColorPingHeng.Text = "确定";
            this.butColorPingHeng.UseVisualStyleBackColor = true;
            this.butColorPingHeng.Click += new System.EventHandler(this.butColorPingHeng_Click);
            // 
            // FormColorPingHeng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(327, 236);
            this.Controls.Add(this.butColorPingHeng);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormColorPingHeng";
            this.Text = "图像色彩平衡处理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.TextBox textR;
        private System.Windows.Forms.TrackBar trackBarR;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.TextBox textB;
        private System.Windows.Forms.TrackBar trackBarB;
        private System.Windows.Forms.Label labelG;
        private System.Windows.Forms.TextBox textG;
        private System.Windows.Forms.TrackBar trackBarG;
        private System.Windows.Forms.Button butColorPingHeng;
    }
}