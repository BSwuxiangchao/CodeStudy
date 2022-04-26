namespace UIDemo1
{
    partial class SocketServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textIP = new System.Windows.Forms.TextBox();
            this.textPort = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cboIpPort = new System.Windows.Forms.ComboBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(27, 13);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(134, 21);
            this.textIP.TabIndex = 0;
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(187, 13);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(65, 21);
            this.textPort.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "开始监听";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboIpPort
            // 
            this.cboIpPort.FormattingEnabled = true;
            this.cboIpPort.Location = new System.Drawing.Point(391, 13);
            this.cboIpPort.Name = "cboIpPort";
            this.cboIpPort.Size = new System.Drawing.Size(121, 20);
            this.cboIpPort.TabIndex = 3;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(27, 71);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(552, 139);
            this.txtLog.TabIndex = 4;
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(27, 239);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(552, 99);
            this.txtMsg.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(504, 351);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "发送消息";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SocketServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 386);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.cboIpPort);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textIP);
            this.Name = "SocketServer";
            this.Text = "SocketServer";
            this.Load += new System.EventHandler(this.SocketServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboIpPort;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button button2;
    }
}