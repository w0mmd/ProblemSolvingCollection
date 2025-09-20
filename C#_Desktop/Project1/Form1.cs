using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Encryption_and_Decryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color color = Color.Black;

            Pen pen = new Pen(color);
            pen.Width = 3;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 570, 560, 570, 55);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Text = richTextBox2.Text;
            string EncryptedText = "";

            for(int i = 0; i < Text.Length; i++)
            {
                char c = Text[i];
                char NewChar = (char)(c + 3);
                EncryptedText += NewChar;
            }

            richTextBox4.Text = EncryptedText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Text = richTextBox1.Text;
            string DecryptedText = "";

            for(int i = 0; i < Text.Length; i++)
            {
                char c = Text[i];
                char NewChar = (char)(c - 3);
                DecryptedText += NewChar;
            }

            richTextBox3.Text = DecryptedText;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Txt Files (*.txt) | *.txt | All Files (*.*) | *.*";
            saveFileDialog1.FilterIndex = 1;

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(saveFileDialog1.FileName);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Title = "Save File";
            saveFileDialog1.Filter = "Text Files (*.txt) | *.txt | All Files (*.*) | *.*";
            saveFileDialog1.FilterIndex = 0;

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(saveFileDialog1.FileName);
            }
        }
    }
}
