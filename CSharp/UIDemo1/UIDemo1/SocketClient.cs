using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace UIDemo1
{
    public partial class SocketClient : Form
    {
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public SocketClient()
        {
            InitializeComponent();
        }

        private void SocketClient_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse(txtIP.Text);
            IPEndPoint point = new IPEndPoint(ip, int.Parse(txtPort.Text));
            try
            {
                client.Connect(point);
                ShowMsg("连接成功");
                ShowMsg("服务器" + client.RemoteEndPoint.ToString());
                ShowMsg("客户端" + client.LocalEndPoint.ToString());
                //连接成功后，就可以接收服务器发送的消息了
                Thread thread = new Thread(ReceiveInfo);
                thread.IsBackground = true;
                thread.Start(); 
            }
            catch(Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        void ReceiveInfo()
        {
            while(true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int n = client.Receive(buffer);
                    string s = Encoding.UTF8.GetString(buffer,0,n);
                    ShowMsg(client.RemoteEndPoint.ToString() + ":" + s);

                }
                catch(Exception ex)
                {
                    ShowMsg(ex.Message);
                    break;
                }
            }
        }

        void ShowMsg(string msg)
        {
            txtLog.AppendText(msg + "\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(client != null)
            {
                try
                {
                    if(txtMsg.Text!="")
                    {
                        ShowMsg("发送:" + txtMsg.Text);
                        byte[] buffer = Encoding.UTF8.GetBytes(txtMsg.Text);
                        client.Send(buffer);
                        txtMsg.Clear();
                    }
                }
                catch (Exception ex)
                {
                    ShowMsg(ex.Message);
                }
            }
        }
    }
}
