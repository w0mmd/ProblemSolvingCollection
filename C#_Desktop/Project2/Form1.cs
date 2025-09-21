using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double FirstNumber;
        private string Op = "";
        private double SecondNumber;
        private bool IsOpShown = false;

        private void LinkBtnToTxtBox_Click(object sender, EventArgs e)
        {

            if(IsOpShown)
            {
                textBox1.Clear();
                IsOpShown = false;
            }

            Button btn = (Button)sender;       
            textBox1.Text += btn.Text;
        }

        private void LinkOpToTxtBox_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (double.TryParse(textBox1.Text, out FirstNumber))
            {
                Op = btn.Text;
                textBox1.Clear();
                textBox1.Text = Op;
                IsOpShown = true;

            }
            else
            {
                MessageBox.Show("Invalid Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Result_Click(object sender, EventArgs e)
        {

            if (!double.TryParse(textBox1.Text, out SecondNumber))
            {
                MessageBox.Show("Invalid Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double Result = 0;
           
              switch(Op)
            {
                case "+":
                    Result = FirstNumber + SecondNumber;
                    break;
                case "-":
                    Result = FirstNumber - SecondNumber;
                    break;
                case "x":
                    Result = FirstNumber * SecondNumber;
                    break;
                case "/":
                    Result = FirstNumber / SecondNumber;
                    break;
                case "%":
                    Result = FirstNumber % SecondNumber;
                    break;
                default:
                    MessageBox.Show("Invalid Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            textBox1.Text = Result.ToString();

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            FirstNumber = 0;
            Op = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save";
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text Files (*.txt) | *.txt | All Files (*.*) | *.*";
            saveFileDialog1.FilterIndex = 0;

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(saveFileDialog1.FileName);
            }
        }
    }
}
