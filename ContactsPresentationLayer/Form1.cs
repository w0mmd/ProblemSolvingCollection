using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsPresentationLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void _RefreshContactsList()
        {
            dgvAllContacts.DataSource = clsContact.GetAllContacts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           _RefreshContactsList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form2(-1);
            form.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form2((int)dgvAllContacts.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _RefreshContactsList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete contact [" + dgvAllContacts.CurrentRow.Cells[0].Value + "]?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {

                if (clsContact.DeleteContact((int)dgvAllContacts.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Contact is deleted successfully...", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshContactsList();
                }
                else
                {
                    MessageBox.Show("Contact is not deleted...", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
