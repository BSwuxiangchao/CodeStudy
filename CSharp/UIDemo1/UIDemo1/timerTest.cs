using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIDemo1
{
    public partial class timerTest : Form
    {
        bool flag = false;


        public timerTest()
        {
            InitializeComponent();
        }

        private void timerTest_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"./resource/wangwang.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag)
            {
                pictureBox1.Image = Image.FromFile(@"./resource/baishicola.jpg");
                flag = false;
            }
            else
            {
                pictureBox1.Image = Image.FromFile(@"./resource/wangwang.jpg");
                flag = true;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();

        }
    }
}
