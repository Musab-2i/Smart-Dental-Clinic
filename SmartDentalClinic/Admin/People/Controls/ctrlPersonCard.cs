using SmartDentalClinic.Business;
using SmartDentalClinic.Properties;
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

namespace SmartDentalClinic.Admin.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPeople _Person;
        private int _PersonID = -1;
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        public int PersonID
        {
            get { return _PersonID; }

        }
        public clsPeople SelectedPersonInfo { get { return _Person; } }
        private void _LoadPersonImage()
        {
            if (_Person.Gender == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void _FillPersonInfo()
        {
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalID.Text = _Person.NationalID.Trim();
            lblName.Text = _Person.FullName.Trim();
            lblGender.Text = _Person.Gender == 0 ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.PhoneNo.Trim();
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString("dd/MMM/yyyy");
            lblCountry.Text = clsCountries.Find(_Person.NationalCountryID).CountryName;
            lblAddress.Text = _Person.Address;
            _LoadPersonImage();
        }
        private void _ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblNationalID.Text = "[????]";
            lblName.Text = "[????]";
            //pbGender.Image = Resources.Man_32;
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPersonImage.Image = Resources.Male_512;
        }
        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPeople.Find(PersonID);

            if( _Person == null )
            {
                _ResetPersonInfo();
                MessageBox.Show("No Person with PersonID : " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        public void LoadPersonInfo(string NationalID)
        {
            _Person = clsPeople.Find(NationalID);

            if (_Person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No Person with NationalID : " + NationalID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
    }
}
