namespace Image_Processing
{
    partial class FormEdgeStrengthen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEdgeStrengthen));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butEdgeStrengthen = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textEdgeStrengthen = new System.Windows.Forms.TextBox();
            this.trackBarEdgeStrengthen = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEdgeStrengthen)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butEdgeStrengthen);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 135);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "阈值调节";
            // 
            // butEdgeStrengthen
            // 
            this.butEdgeStrengthen.Location = new System.Drawing.Point(6, 102);
            this.butEdgeStrengthen.Name = "butEdgeStrengthen";
            this.butEdgeStrengthen.Size = new System.Drawing.Size(278, 27);
            this.butEdgeStrengthen.TabIndex = 39;
            this.butEdgeStrengthen.Text = "确定";
            this.butEdgeStrengthen.UseVisualStyleBackColor = true;
            this.butEdgeStrengthen.Click += new System.EventHandler(this.butLD_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textEdgeStrengthen);
            this.panel5.Controls.Add(this.trackBarEdgeStrengthen);
            this.panel5.Location = new System.Drawing.Point(6, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(278, 66);
            this.panel5.TabIndex = 47;
            // 
            // textEdgeStrengthen
            // 
            this.textEdgeStrengthen.Location = new System.Drawing.Point(224, 18);
            this.textEdgeStrengthen.Name = "textEdgeStrengthen";
            this.textEdgeStrengthen.Size = new System.Drawing.Size(44, 21);
            this.textEdgeStrengthen.TabIndex = 40;
            // 
            // trackBarEdgeStrengthen
            // 
            this.trackBarEdgeStrengthen.Location = new System.Drawing.Point(3, 11);
            this.trackBarEdgeStrengthen.Maximum = 255;
            this.trackBarEdgeStrengthen.Name = "trackBarEdgeStrengthen";
            this.trackBarEdgeStrengthen.Size = new System.Drawing.Size(215, 45);
            this.trackBarEdgeStrengthen.TabIndex = 38;
            this.trackBarEdgeStrengthen.Scroll += new System.EventHandler(this.trackBarEdgeStrengthen_Scroll);
            // 
            // FormEdgeStrengthen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(306, 162);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEdgeStrengthen";
            this.Text = "边缘增强";
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEdgeStrengthen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butEdgeStrengthen;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textEdgeStrengthen;
        private System.Windows.Forms.TrackBar trackBarEdgeStrengthen;
    }
}