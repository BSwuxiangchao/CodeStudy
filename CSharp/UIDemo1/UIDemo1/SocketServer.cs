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
    public partial class SocketServer : Form
    {
        public SocketServer()
        {
            InitializeComponent();
        }

        private void SocketServer_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ip地址
            IPAddress ip = IPAddress.Parse(textIP.Text);
            //port端口
            IPEndPoint point = new IPEndPoint(ip, int.Parse(textPort.Text));
            /*
                *AddressFamily.InterNetWork：使用 IP4地址。
 
  SocketType.Stream：支持可靠、双向、基于连接的字节流，而不重复数据。此类型的 Socket 与单个对方主机进行通信，并且在通信开始之前需要远程主机连接。Stream 使用传输控制协议 (Tcp)ProtocolType 和 InterNetworkAddressFamily。
 
  ProtocolType.Tcp：使用传输控制协议。
  */

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Bind(point);
                socket.Listen(10);
                ShowMsg("服务器开始监听");
                Thread thread = new Thread(AcceptInfo);
                thread.IsBackground = true;
                thread.Start(socket);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        //记录通信用的socket
        Dictionary<string, Socket> dic = new Dictionary<string, Socket>();
        
        void ShowMsg(string msg)
        {
            txtLog.AppendText(msg + "\r\n");
        }

        void AcceptInfo(Object o)
        {
            Socket socket = o as Socket;
            while (true)
            {
                try
                {
                    Socket tSocket = socket.Accept();
                    string point = tSocket.RemoteEndPoint.ToString();
                    ShowMsg(point + "连接成功!");
                    cboIpPort.Items.Add(point);
                    if(cboIpPort.Text == "")
                    {
                        cboIpPort.Text = point;
                    }
                    dic.Add(point, tSocket);

                    //接收消息
                    Thread th = new Thread(ReceiveMsg);
                    th.IsBackground = true;
                    th.Start(tSocket);
                }
                catch(Exception ex)
                {
                    ShowMsg(ex.Message);
                    break;
                }
                
            }
        }

        void ReceiveMsg(Object o)
        {
            Socket client = o as Socket;
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int n = client.Receive(buffer);
                    //将字节转换成字符串
                    string words = Encoding.UTF8.GetString(buffer, 0, n);
                    ShowMsg(client.RemoteEndPoint.ToString() + ":" + words);

                }
                catch(Exception ex)
                {
                    ShowMsg(ex.Message);
                    break;
                }
            }
        }

        private void SocketServer_FormClosing(object sender, FormClosedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMsg.Text != "")
                {
                    ShowMsg("发送:" + txtMsg.Text);
                    string ip = cboIpPort.Text;
                    byte[] buffer = Encoding.UTF8.GetBytes(txtMsg.Text);
                    dic[ip].Send(buffer);
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
