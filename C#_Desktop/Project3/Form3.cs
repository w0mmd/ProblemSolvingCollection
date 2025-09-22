using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form3 : Form
    {
        private int Counter = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            int hours = (int)Count_hrs.Value;
            int minutes = (int)Count_min.Value;
            int seconds = (int)Count_sec.Value;

            Counter = (hours * 3600) + (minutes * 60) + seconds;

            TimeSpan ts = TimeSpan.FromSeconds(Counter);
            label1.Text = ts.ToString(@"hh\:mm\:ss");

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Counter > 0)
            {
                Counter--;
                TimeSpan ts = TimeSpan.FromSeconds(Counter);
                label1.Text = ts.ToString(@"hh\:mm\:ss");
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Waking up time", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
