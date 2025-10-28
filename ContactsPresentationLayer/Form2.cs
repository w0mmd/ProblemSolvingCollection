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
    public partial class Form2 : Form
    {

       public enum enMode {AddNew = 0, Update = 1};
        private enMode _Mode;

        private int _ContactID;
        clsContact _Contact;

        public Form2(int ContactID)
        {
            InitializeComponent();

            _ContactID = ContactID;

            if(_ContactID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach(DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }

        }

        private void _LoadData()
        {
            _FillCountriesInComboBox();
            cbCountry.SelectedIndex = 0;

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add Contact";
                _Contact = new clsContact();
                return;
            }

            _Contact = clsContact.Find(_ContactID);

            if (_Contact == null)
            {
                MessageBox.Show("This message will be closed because there is no contact found!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            lblMode.Text = "Eidt ContactID = " + _ContactID;
            label3.Text = _ContactID.ToString();
            textBox1.Text = _Contact.FirstName;
            textBox2.Text = _Contact.LastName;
            textBox3.Text = _Contact.Email;
            textBox4.Text = _Contact.Phone;
            textBox5.Text = _Contact.Address;
            label9.Text = _Contact.DateOfBirth.ToString();
            dateTimePicker1.Value = _Contact.DateOfBirth;

            if(_Contact.ImagePath != "")
            {
                pictureBox1.Load(_Contact.ImagePath);
            }
            llbl_RemoveImage.Visible = (_Contact.ImagePath != "");

            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Contact.CountryID).CountryName);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            int CountryID = clsCountry.Find(cbCountry.Text).ID;

            _Contact.FirstName = textBox1.Text;
            _Contact.LastName = textBox2.Text;
            _Contact.Email = textBox3.Text;
            _Contact.Phone = textBox4.Text;
            _Contact.Address = textBox5.Text;
            _Contact.DateOfBirth = dateTimePicker1.Value;
            _Contact.CountryID = CountryID;

            if (pictureBox1.ImageLocation != null)
            {
                _Contact.ImagePath = pictureBox1.ImageLocation;
            }
            else
            {
                _Contact.ImagePath = "";
            }

            if(_Contact.Save())
            {
                MessageBox.Show("Data is saved successfully...");
            }
            else
            {
                MessageBox.Show("Data is not saved successfully...");
            }

            _Mode = enMode.Update;
            lblMode.Text = "Edit ContactID = " + _Contact.ID;
            label3.Text = _Contact.ID.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
