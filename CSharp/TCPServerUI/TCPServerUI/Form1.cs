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
namespace TCPServerUI
{
    public partial class Form1 : Form
    {
        public Socket m_ServerSocket = null;
        public Dictionary<string, Socket> m_dicClient = new Dictionary<string, Socket>();
        private Dictionary<string, Thread> m_dicThread = new Dictionary<string, Thread>();
        Byte[] buffer = new Byte[6 * 1024 * 1024];
        public Form1()
        {
            InitializeComponent();
        }
        bool isStartSer = false;
        private void btnCloseSer_Click(object sender, EventArgs e)
        {
            if(!isStartSer)
            {
                if (txtIP.Text == "" || txtPort.Text == "")
                    return;
                m_ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress iPAddress = IPAddress.Parse(txtIP.Text);
                int port = Convert.ToInt32(txtPort.Text);
                m_ServerSocket.Bind(new IPEndPoint(iPAddress, port));
                m_ServerSocket.Listen(10);
                Task.Run(() =>
                {
                    while (true)
                    {
                        Socket cli = m_ServerSocket.Accept();
                        
                        m_dicClient.Add(cli.RemoteEndPoint.ToString(), cli);
                        //提示有客户端连接到
                        Invoke(new MethodInvoker(delegate ()
                        {
                            listBoxRecMsg.Items.Add(cli.RemoteEndPoint.ToString() + "连接到服务端");
                            cbxClients.Items.Add(cli.RemoteEndPoint.ToString());
                            cbxClients.SelectedItem = cli.RemoteEndPoint.ToString();
                        }));
                        Thread threadRcv = new Thread(new ParameterizedThreadStart(RcvData));
                        threadRcv.IsBackground = true;
                        threadRcv.Start(cli);
                        m_dicThread.Add(cli.RemoteEndPoint.ToString(), threadRcv);
                    }
                });
                Task.Run(() =>
                {
                    while(true)
                    {
                        if (m_dicClient.Count < 1)
                            continue;
                        int AllCliCount = m_dicClient.Count;
                        int[] countBeat = new int[AllCliCount];
                        for (int i = 0; i < AllCliCount; i++)
                        {
                            countBeat[i] = 0;
                        }
                        int Times = 6;
                        for(int i=0;i< Times; i++)
                        {
                            for(int index = 0;index<AllCliCount;index++)
                            {
                                Byte[] b = Encoding.UTF8.GetBytes("b");
                                int length = m_dicClient.ElementAt(index).Value.Send(b);
                                if (length > 1)
                                {
                                    countBeat[index]++;
                                }
                            }
                            Thread.Sleep(100);
                        }
                        //for (int index = 0; index < AllCliCount; index++)
                        //{
                        //    if(countBeat[index]<6)
                        //    {
                        //        m_dicClient.Remove()
                        //    }
                        //}
                    }
                });
                isStartSer = true;
                btnCloseSer.Text = "关闭服务器";
                btnCloseSer.BackColor = Color.Red;
            }
            else
            {
                isStartSer = false;
                btnCloseSer.Text = "打开服务器";
                btnCloseSer.BackColor = Color.Green;
                foreach (var key in m_dicThread.Keys)
                {
                    if (m_dicThread[key] != null)
                    {
                        m_dicThread[key].Abort();
                    }
                }
                m_dicThread.Clear();
                foreach (var key in m_dicClient.Keys)
                {
                    if (m_dicClient[key] != null)
                    {
                        m_dicClient[key].Close();
                    }
                }
                m_dicClient.Clear();
                Invoke(new MethodInvoker(delegate ()
                {
                    cbxClients.Items.Clear();
                    cbxClients.Text = "";
                }));
                
                if (m_ServerSocket != null)
                {
                    m_ServerSocket.Close();
                }
            }
            
        }

        public void RcvData(Object obj)
        {
            Socket client = (Socket)obj;
            int length = 0;
            while (true)
            {
                try
                {
                    length = client.Receive(buffer);
                    if (length > 0)
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            listBoxRecMsg.Items.Add(string.Format("{0}:{1}", 
                                client.RemoteEndPoint.ToString(),Encoding.UTF8.GetString(buffer, 0, length)));
                        }));
                    }
                }
                catch
                {
                    
                }
                
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!isStartSer)
            {
                MessageBox.Show("未开启服务器");
                return;
            }
            string strcli = cbxClients.SelectedItem.ToString();
            string msg = txtSendMsg.Text;
            Byte[] data = Encoding.UTF8.GetBytes(msg);
            m_dicClient[strcli].Send(data);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (var key in m_dicThread.Keys)
            {
                if (m_dicThread[key] != null)
                {
                    m_dicThread[key].Abort();
                }
            }
            m_dicThread.Clear();
            foreach (var key in m_dicClient.Keys)
            {
                if (m_dicClient[key] != null)
                {
                    Byte[] b = Encoding.UTF8.GetBytes("q");
                    m_dicClient[key].Send(b);
                    m_dicClient[key].Close();
                }
            }
            m_dicClient.Clear();
            Invoke(new MethodInvoker(delegate ()
            {
                cbxClients.Items.Clear();
                cbxClients.Text = "";
            }));
        }
    }
}
