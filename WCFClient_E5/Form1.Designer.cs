namespace WCFClient_E5
{
    partial class Form1
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
            this.btnConWcf = new System.Windows.Forms.Button();
            this.btnUserInfo = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnEditUserInfo = new System.Windows.Forms.Button();
            this.asyGetUserInfo = new System.Windows.Forms.Button();
            this.labTime = new System.Windows.Forms.Label();
            this.parallelLoginTest = new System.Windows.Forms.Button();
            this.labHostState = new System.Windows.Forms.Label();
            this.labHostStatus = new System.Windows.Forms.Label();
            this.btnRdmAddr = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBuyPhone = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtParNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConWcf
            // 
            this.btnConWcf.Location = new System.Drawing.Point(12, 12);
            this.btnConWcf.Name = "btnConWcf";
            this.btnConWcf.Size = new System.Drawing.Size(75, 23);
            this.btnConWcf.TabIndex = 1;
            this.btnConWcf.Text = "连接局域网WCF";
            this.btnConWcf.UseVisualStyleBackColor = true;
            this.btnConWcf.Click += new System.EventHandler(this.btnConWcf_Click);
            // 
            // btnUserInfo
            // 
            this.btnUserInfo.Location = new System.Drawing.Point(103, 12);
            this.btnUserInfo.Name = "btnUserInfo";
            this.btnUserInfo.Size = new System.Drawing.Size(75, 23);
            this.btnUserInfo.TabIndex = 4;
            this.btnUserInfo.Text = "根据ID获得用户信息";
            this.btnUserInfo.UseVisualStyleBackColor = true;
            this.btnUserInfo.Click += new System.EventHandler(this.btnUserInfo_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(184, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 21);
            this.txtID.TabIndex = 5;
            this.txtID.Text = "1";
            // 
            // btnEditUserInfo
            // 
            this.btnEditUserInfo.Location = new System.Drawing.Point(290, 10);
            this.btnEditUserInfo.Name = "btnEditUserInfo";
            this.btnEditUserInfo.Size = new System.Drawing.Size(75, 23);
            this.btnEditUserInfo.TabIndex = 6;
            this.btnEditUserInfo.Text = "修改";
            this.btnEditUserInfo.UseVisualStyleBackColor = true;
            this.btnEditUserInfo.Click += new System.EventHandler(this.btnEditUserInfo_Click);
            // 
            // asyGetUserInfo
            // 
            this.asyGetUserInfo.Location = new System.Drawing.Point(371, 10);
            this.asyGetUserInfo.Name = "asyGetUserInfo";
            this.asyGetUserInfo.Size = new System.Drawing.Size(100, 23);
            this.asyGetUserInfo.TabIndex = 9;
            this.asyGetUserInfo.Text = "异步登陆测试";
            this.asyGetUserInfo.UseVisualStyleBackColor = true;
            this.asyGetUserInfo.Click += new System.EventHandler(this.asyGetUserInfo_Click);
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(228, 46);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(77, 12);
            this.labTime.TabIndex = 11;
            this.labTime.Text = "服务器时间：";
            // 
            // parallelLoginTest
            // 
            this.parallelLoginTest.Location = new System.Drawing.Point(477, 10);
            this.parallelLoginTest.Name = "parallelLoginTest";
            this.parallelLoginTest.Size = new System.Drawing.Size(100, 23);
            this.parallelLoginTest.TabIndex = 12;
            this.parallelLoginTest.Text = "Parallel登陆测试";
            this.parallelLoginTest.UseVisualStyleBackColor = true;
            this.parallelLoginTest.Click += new System.EventHandler(this.parallelLoginTest_Click);
            // 
            // labHostState
            // 
            this.labHostState.AutoSize = true;
            this.labHostState.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labHostState.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labHostState.Location = new System.Drawing.Point(12, 41);
            this.labHostState.Name = "labHostState";
            this.labHostState.Size = new System.Drawing.Size(93, 19);
            this.labHostState.TabIndex = 13;
            this.labHostState.Text = "服务端状态：";
            this.labHostState.Click += new System.EventHandler(this.labHostState_Click);
            // 
            // labHostStatus
            // 
            this.labHostStatus.AutoSize = true;
            this.labHostStatus.Location = new System.Drawing.Point(103, 47);
            this.labHostStatus.Name = "labHostStatus";
            this.labHostStatus.Size = new System.Drawing.Size(0, 12);
            this.labHostStatus.TabIndex = 14;
            // 
            // btnRdmAddr
            // 
            this.btnRdmAddr.Location = new System.Drawing.Point(690, 6);
            this.btnRdmAddr.Margin = new System.Windows.Forms.Padding(2);
            this.btnRdmAddr.Name = "btnRdmAddr";
            this.btnRdmAddr.Size = new System.Drawing.Size(96, 29);
            this.btnRdmAddr.TabIndex = 15;
            this.btnRdmAddr.Text = "生成地址";
            this.btnRdmAddr.UseVisualStyleBackColor = true;
            this.btnRdmAddr.Click += new System.EventHandler(this.btnRdmAddr_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(380, 54);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(406, 378);
            this.dataGridView1.TabIndex = 16;
            // 
            // btnBuyPhone
            // 
            this.btnBuyPhone.Location = new System.Drawing.Point(380, 459);
            this.btnBuyPhone.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuyPhone.Name = "btnBuyPhone";
            this.btnBuyPhone.Size = new System.Drawing.Size(73, 60);
            this.btnBuyPhone.TabIndex = 17;
            this.btnBuyPhone.Text = "试买手机";
            this.btnBuyPhone.UseVisualStyleBackColor = true;
            this.btnBuyPhone.Click += new System.EventHandler(this.btnBuyPhone_Click);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(103, 90);
            this.txtTime.Margin = new System.Windows.Forms.Padding(2);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(76, 21);
            this.txtTime.TabIndex = 18;
            this.txtTime.Text = "500";
            // 
            // txtParNumber
            // 
            this.txtParNumber.Location = new System.Drawing.Point(103, 114);
            this.txtParNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtParNumber.Name = "txtParNumber";
            this.txtParNumber.Size = new System.Drawing.Size(76, 21);
            this.txtParNumber.TabIndex = 19;
            this.txtParNumber.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "status时间间隔";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "线程数";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 636);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtParNumber);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.btnBuyPhone);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRdmAddr);
            this.Controls.Add(this.labHostStatus);
            this.Controls.Add(this.labHostState);
            this.Controls.Add(this.parallelLoginTest);
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.asyGetUserInfo);
            this.Controls.Add(this.btnEditUserInfo);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnUserInfo);
            this.Controls.Add(this.btnConWcf);
            this.Name = "Form1";
            this.Text = "WCFClient";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConWcf;
        private System.Windows.Forms.Button btnUserInfo;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnEditUserInfo;
        private System.Windows.Forms.Button asyGetUserInfo;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Button parallelLoginTest;
        private System.Windows.Forms.Label labHostState;
        private System.Windows.Forms.Label labHostStatus;
        private System.Windows.Forms.Button btnRdmAddr;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBuyPhone;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtParNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

