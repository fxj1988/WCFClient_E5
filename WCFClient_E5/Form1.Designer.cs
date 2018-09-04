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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConWcf
            // 
            this.btnConWcf.Location = new System.Drawing.Point(16, 15);
            this.btnConWcf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConWcf.Name = "btnConWcf";
            this.btnConWcf.Size = new System.Drawing.Size(100, 29);
            this.btnConWcf.TabIndex = 1;
            this.btnConWcf.Text = "连接局域网WCF";
            this.btnConWcf.UseVisualStyleBackColor = true;
            this.btnConWcf.Click += new System.EventHandler(this.btnConWcf_Click);
            // 
            // btnUserInfo
            // 
            this.btnUserInfo.Location = new System.Drawing.Point(137, 15);
            this.btnUserInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUserInfo.Name = "btnUserInfo";
            this.btnUserInfo.Size = new System.Drawing.Size(100, 29);
            this.btnUserInfo.TabIndex = 4;
            this.btnUserInfo.Text = "根据ID获得用户信息";
            this.btnUserInfo.UseVisualStyleBackColor = true;
            this.btnUserInfo.Click += new System.EventHandler(this.btnUserInfo_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(245, 15);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(132, 25);
            this.txtID.TabIndex = 5;
            this.txtID.Text = "1";
            // 
            // btnEditUserInfo
            // 
            this.btnEditUserInfo.Location = new System.Drawing.Point(387, 12);
            this.btnEditUserInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditUserInfo.Name = "btnEditUserInfo";
            this.btnEditUserInfo.Size = new System.Drawing.Size(100, 29);
            this.btnEditUserInfo.TabIndex = 6;
            this.btnEditUserInfo.Text = "修改";
            this.btnEditUserInfo.UseVisualStyleBackColor = true;
            this.btnEditUserInfo.Click += new System.EventHandler(this.btnEditUserInfo_Click);
            // 
            // asyGetUserInfo
            // 
            this.asyGetUserInfo.Location = new System.Drawing.Point(495, 12);
            this.asyGetUserInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.asyGetUserInfo.Name = "asyGetUserInfo";
            this.asyGetUserInfo.Size = new System.Drawing.Size(133, 29);
            this.asyGetUserInfo.TabIndex = 9;
            this.asyGetUserInfo.Text = "异步登陆测试";
            this.asyGetUserInfo.UseVisualStyleBackColor = true;
            this.asyGetUserInfo.Click += new System.EventHandler(this.asyGetUserInfo_Click);
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(304, 58);
            this.labTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(97, 15);
            this.labTime.TabIndex = 11;
            this.labTime.Text = "服务器时间：";
            // 
            // parallelLoginTest
            // 
            this.parallelLoginTest.Location = new System.Drawing.Point(636, 12);
            this.parallelLoginTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.parallelLoginTest.Name = "parallelLoginTest";
            this.parallelLoginTest.Size = new System.Drawing.Size(133, 29);
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
            this.labHostState.Location = new System.Drawing.Point(16, 51);
            this.labHostState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labHostState.Name = "labHostState";
            this.labHostState.Size = new System.Drawing.Size(120, 25);
            this.labHostState.TabIndex = 13;
            this.labHostState.Text = "服务端状态：";
            this.labHostState.Click += new System.EventHandler(this.labHostState_Click);
            // 
            // labHostStatus
            // 
            this.labHostStatus.AutoSize = true;
            this.labHostStatus.Location = new System.Drawing.Point(137, 59);
            this.labHostStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labHostStatus.Name = "labHostStatus";
            this.labHostStatus.Size = new System.Drawing.Size(0, 15);
            this.labHostStatus.TabIndex = 14;
            // 
            // btnRdmAddr
            // 
            this.btnRdmAddr.Location = new System.Drawing.Point(920, 8);
            this.btnRdmAddr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRdmAddr.Name = "btnRdmAddr";
            this.btnRdmAddr.Size = new System.Drawing.Size(128, 36);
            this.btnRdmAddr.TabIndex = 15;
            this.btnRdmAddr.Text = "生成地址";
            this.btnRdmAddr.UseVisualStyleBackColor = true;
            this.btnRdmAddr.Click += new System.EventHandler(this.btnRdmAddr_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(506, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(542, 472);
            this.dataGridView1.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 795);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
    }
}

