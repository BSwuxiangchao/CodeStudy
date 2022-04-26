
namespace TCPServerUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnCloseSer = new System.Windows.Forms.Button();
            this.cbxClients = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.listBoxRecMsg = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(25, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "服务器端口号";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(155, 20);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(152, 21);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(155, 71);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(152, 21);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "8081";
            // 
            // btnCloseSer
            // 
            this.btnCloseSer.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCloseSer.Location = new System.Drawing.Point(365, 20);
            this.btnCloseSer.Name = "btnCloseSer";
            this.btnCloseSer.Size = new System.Drawing.Size(80, 72);
            this.btnCloseSer.TabIndex = 3;
            this.btnCloseSer.Text = "打开服务器";
            this.btnCloseSer.UseVisualStyleBackColor = false;
            this.btnCloseSer.Click += new System.EventHandler(this.btnCloseSer_Click);
            // 
            // cbxClients
            // 
            this.cbxClients.FormattingEnabled = true;
            this.cbxClients.Location = new System.Drawing.Point(469, 23);
            this.cbxClients.Name = "cbxClients";
            this.cbxClients.Size = new System.Drawing.Size(121, 20);
            this.cbxClients.TabIndex = 4;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(29, 391);
            this.btnSend.Name = "btnSend";
            this.btnSend.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSend.Size = new System.Drawing.Size(561, 37);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Location = new System.Drawing.Point(29, 276);
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(561, 109);
            this.txtSendMsg.TabIndex = 6;
            // 
            // listBoxRecMsg
            // 
            this.listBoxRecMsg.FormattingEnabled = true;
            this.listBoxRecMsg.ItemHeight = 12;
            this.listBoxRecMsg.Location = new System.Drawing.Point(29, 112);
            this.listBoxRecMsg.Name = "listBoxRecMsg";
            this.listBoxRecMsg.Size = new System.Drawing.Size(561, 148);
            this.listBoxRecMsg.TabIndex = 7;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(469, 71);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(121, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "清除客户端";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(624, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.listBoxRecMsg);
            this.Controls.Add(this.txtSendMsg);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cbxClients);
            this.Controls.Add(this.btnCloseSer);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "TCP服务器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnCloseSer;
        private System.Windows.Forms.ComboBox cbxClients;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.ListBox listBoxRecMsg;
        private System.Windows.Forms.Button btnClear;
    }
}

