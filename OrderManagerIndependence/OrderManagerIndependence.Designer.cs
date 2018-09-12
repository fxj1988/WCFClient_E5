namespace OrderManagerIndependence
{
    partial class OrderManagerIndependence
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBuyPhone = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.txtOrderEnd = new System.Windows.Forms.TextBox();
            this.txtOrderBegin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBuyPhone
            // 
            this.btnBuyPhone.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBuyPhone.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBuyPhone.Location = new System.Drawing.Point(11, 13);
            this.btnBuyPhone.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuyPhone.Name = "btnBuyPhone";
            this.btnBuyPhone.Size = new System.Drawing.Size(90, 79);
            this.btnBuyPhone.TabIndex = 18;
            this.btnBuyPhone.Text = "下单";
            this.btnBuyPhone.UseVisualStyleBackColor = true;
            this.btnBuyPhone.Click += new System.EventHandler(this.btnBuyPhone_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "线程数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "下单起始ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "下单结束ID";
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Location = new System.Drawing.Point(172, 13);
            this.txtThreadCount.Name = "txtThreadCount";
            this.txtThreadCount.Size = new System.Drawing.Size(100, 21);
            this.txtThreadCount.TabIndex = 22;
            this.txtThreadCount.Text = "20";
            // 
            // txtOrderEnd
            // 
            this.txtOrderEnd.Location = new System.Drawing.Point(172, 73);
            this.txtOrderEnd.Name = "txtOrderEnd";
            this.txtOrderEnd.Size = new System.Drawing.Size(100, 21);
            this.txtOrderEnd.TabIndex = 23;
            this.txtOrderEnd.Text = "6542";
            // 
            // txtOrderBegin
            // 
            this.txtOrderBegin.Location = new System.Drawing.Point(172, 42);
            this.txtOrderBegin.Name = "txtOrderBegin";
            this.txtOrderBegin.Size = new System.Drawing.Size(100, 21);
            this.txtOrderBegin.TabIndex = 24;
            this.txtOrderBegin.Text = "6000";
            // 
            // OrderManagerIndependence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtOrderBegin);
            this.Controls.Add(this.txtOrderEnd);
            this.Controls.Add(this.txtThreadCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuyPhone);
            this.Name = "OrderManagerIndependence";
            this.Text = "OrderManagerIndependence";
            this.Load += new System.EventHandler(this.OrderManagerIndependence_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuyPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtThreadCount;
        private System.Windows.Forms.TextBox txtOrderEnd;
        private System.Windows.Forms.TextBox txtOrderBegin;
    }
}

