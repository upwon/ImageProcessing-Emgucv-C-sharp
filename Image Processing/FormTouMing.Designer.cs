namespace Image_Processing
{
    partial class FormTouMing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTouMing));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butTouMingBH = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labTouMingBH = new System.Windows.Forms.Label();
            this.textTouMingBH = new System.Windows.Forms.TextBox();
            this.trackBarTouMingBH = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTouMingBH)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butTouMingBH);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 135);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // butTouMingBH
            // 
            this.butTouMingBH.Location = new System.Drawing.Point(6, 102);
            this.butTouMingBH.Name = "butTouMingBH";
            this.butTouMingBH.Size = new System.Drawing.Size(346, 27);
            this.butTouMingBH.TabIndex = 39;
            this.butTouMingBH.Text = "确定";
            this.butTouMingBH.UseVisualStyleBackColor = true;
            this.butTouMingBH.Click += new System.EventHandler(this.butTouMingBH_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labTouMingBH);
            this.panel5.Controls.Add(this.textTouMingBH);
            this.panel5.Controls.Add(this.trackBarTouMingBH);
            this.panel5.Location = new System.Drawing.Point(6, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(348, 66);
            this.panel5.TabIndex = 47;
            // 
            // labTouMingBH
            // 
            this.labTouMingBH.AutoSize = true;
            this.labTouMingBH.Location = new System.Drawing.Point(8, 24);
            this.labTouMingBH.Name = "labTouMingBH";
            this.labTouMingBH.Size = new System.Drawing.Size(71, 12);
            this.labTouMingBH.TabIndex = 0;
            this.labTouMingBH.Text = "请调节 a 值";
            // 
            // textTouMingBH
            // 
            this.textTouMingBH.Location = new System.Drawing.Point(291, 19);
            this.textTouMingBH.Name = "textTouMingBH";
            this.textTouMingBH.Size = new System.Drawing.Size(44, 21);
            this.textTouMingBH.TabIndex = 40;
            // 
            // trackBarTouMingBH
            // 
            this.trackBarTouMingBH.Location = new System.Drawing.Point(89, 13);
            this.trackBarTouMingBH.Maximum = 255;
            this.trackBarTouMingBH.Name = "trackBarTouMingBH";
            this.trackBarTouMingBH.Size = new System.Drawing.Size(196, 45);
            this.trackBarTouMingBH.TabIndex = 38;
            this.trackBarTouMingBH.Value = 128;
            this.trackBarTouMingBH.Scroll += new System.EventHandler(this.trackBarTouMingBH_Scroll);
            // 
            // FormTouMing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(382, 162);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTouMing";
            this.Text = "透明变换";
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTouMingBH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butTouMingBH;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labTouMingBH;
        private System.Windows.Forms.TextBox textTouMingBH;
        private System.Windows.Forms.TrackBar trackBarTouMingBH;
    }
}