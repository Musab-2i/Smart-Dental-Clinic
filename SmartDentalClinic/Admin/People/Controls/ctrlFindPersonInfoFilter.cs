using SmartDentalClinic.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDentalClinic.Admin.People.Controls
{
    public partial class ctrlFindPersonInfoFilter : UserControl
    {
        public ctrlFindPersonInfoFilter()
        {
            InitializeComponent();
        }
        private clsPeople _Person;

        public class DataBackEventArgs : EventArgs
        {
            public string FullName { get; set; }
            public int PersonID { get; set; }

            public DataBackEventArgs(string fullName, int personID)
            {
                FullName = fullName;
                PersonID = personID;
            }
        }
        public event EventHandler<DataBackEventArgs> OnPersonSelected;
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
            }
            if (cbSearchPerson.Text == "Person ID")
            {
                // السماح فقط بالأرقام (IsDigit) وزر المسح Backspace (IsControl)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // إلغاء الضغطة تماماً وكأنها لم تحدث!
                }
            }
        }
        private bool CheckIfTextBoxValueIsValidToSearch()
        {
            if (string.IsNullOrWhiteSpace(txtFilterValue.Text))
                return false;

            return true;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _Person = null;
            switch (cbSearchPerson.Text)
            {
                case "National ID":
                    if (CheckIfTextBoxValueIsValidToSearch())
                    {
                        string NationalID = txtFilterValue.Text.Trim();
                        _Person = clsPeople.Find(NationalID);
                        if(_Person == null)
                        {
                            MessageBox.Show("No person found with this National ID.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                    break;
                case "Person ID":
                    if (CheckIfTextBoxValueIsValidToSearch())
                    {
                        int PersonID = Convert.ToInt32(txtFilterValue.Text.Trim());
                        _Person = clsPeople.Find(PersonID);
                        if (_Person == null)
                        {
                            MessageBox.Show("No person found with this Person ID.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    break;
            }
            if (_Person != null)
                OnPersonSelected?.Invoke(this, new DataBackEventArgs(_Person.FullName, _Person.PersonID));
        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }
    }
}
