using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace TCPClientUI
{
    public partial class Form1 : Form
    {
        private Socket m_client = null;
        private Thread m_rcvMgr = null;
        Byte[] buffer = new byte[1024 * 1024];
        public Form1()
        {
            InitializeComponent();
        }
        bool isConnect = false;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!isConnect)
            {
                m_client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ipaddr = IPAddress.Parse(txtAdress.Text);
                IPEndPoint iPEndPoint = new IPEndPoint(ipaddr, Convert.ToInt32(txtPort.Text));
                try
                {
                    m_client.Connect(iPEndPoint);
                }
                catch
                {
                    MessageBox.Show("客户端连接发生异常");
                    return;
                }
                m_rcvMgr = new Thread(new ThreadStart(RcvMgr));
                m_rcvMgr.IsBackground = true;
                m_rcvMgr.Start();
                btnConnect.Text = "断开";
                btnConnect.BackColor = Color.Red;
                isConnect = true;
            }
            else
            {
                if (m_client != null)
                    m_client.Close();
                if(m_rcvMgr != null)
                    m_rcvMgr.Abort();
                btnConnect.Text = "连接";
                btnConnect.BackColor = Color.Green;
                isConnect = false;
            }

        }
        public void RcvMgr()
        {
            while (true)
            {
                if (isConnect)
                {
                    try
                    {
                        int length = m_client.Receive(buffer);
                        if (length > 0)
                        {
                            Invoke(new MethodInvoker(delegate ()
                            {
                                listBoxRcvMsg.Items.Add(DateTime.Now.ToString()+" rcvMsg: " + Encoding.UTF8.GetString(buffer, 0, length));
                            }));
                            if(Encoding.UTF8.GetString(buffer, 0, length)=="q")
                            {
                                Invoke(new MethodInvoker(delegate ()
                                {
                                    btnConnect.Text = "连接";
                                    btnConnect.BackColor = Color.Green;
                                }));
                                //if (m_client != null)
                                //    m_client.Close();
                                //if (m_rcvMgr != null)
                                //    m_rcvMgr.Abort();
                                
                                
                                isConnect = false;
                            }
                        }
                    }
                    catch(Exception e)
                    {
                        return;
                    }
                    
                }
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            buffer = Encoding.UTF8.GetBytes(txtSendMsg.Text);
            m_client.Send(buffer);
        }
    }
}
