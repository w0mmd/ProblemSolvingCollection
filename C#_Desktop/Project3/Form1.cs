using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form1 : Form
    {

        private int Counter = 0;
        private int Counter2 = 0;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timeNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void timerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            if (Start_btn.Text == "Start")
            {
                timer1.Start();
                Start_btn.Text = "Stop";
            }
            else
            {
                timer1.Stop();
                Start_btn.Text = "Start";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Counter++;

            TimeSpan ts = TimeSpan.FromSeconds(Counter);
            label1.Text = ts.ToString(@"hh\:mm\:ss");

        }

        private void Restart_btn_Click(object sender, EventArgs e)
        {
            label1.Text = "00:00:00";
            Counter = 0;
        }

        private void Mark_btn_Click(object sender, EventArgs e)
        {

            Counter2++;

                ListViewItem item = new ListViewItem(Counter2.ToString());

                item.SubItems.Add(DateTime.Now.ToString());
                item.SubItems.Add(label1.Text);

                listView1.Items.Add(item);
      


        }
    }
}

