using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UIDemo1
{


    public partial class Form1 : Form
    {
        public static void Delay(int mm)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(mm) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }

        public Form1()
        {
            InitializeComponent();

            welcome wDialog = new welcome();
            wDialog.Show();
            Delay(3000);
            wDialog.Close();

            this.StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timerTest timeLg = new timerTest();
            timeLg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SocketServer server = new SocketServer();
            server.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SocketClient client = new SocketClient();
            client.Show();
        }
       
        private void enterButton_Click(object sender, EventArgs e)
        {
            directoryTreeView.Nodes.Clear();
            string strinputText = inputText.Text;
            if (Directory.Exists(strinputText))
            {
                TreeNode rootNode = new TreeNode(strinputText);
                directoryTreeView.Nodes.Add(rootNode);
                FindDirectory(strinputText, rootNode);
            }
            else
            {
                MessageBox.Show("输入目录不存在");
                inputText.Clear();
                directoryTreeView.Nodes.Clear();
            }
        }

        void FindDirectory(string nowDirectory, TreeNode parentNode)
        {
            try
            {
                string[] directoryArray = Directory.GetDirectories(nowDirectory);
                if (directoryArray.Length > 0)
                {
                    foreach (string item in directoryArray)
                    {
                        string str = Path.GetFileNameWithoutExtension(item);
                        TreeNode node = new TreeNode(str);
                        parentNode.Nodes.Add(node);
                        FindDirectory(item, node);
                    }
                }
            }
            catch (Exception)
            {
                parentNode.Nodes.Add("禁止访问");
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
