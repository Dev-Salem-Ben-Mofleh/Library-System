using LibraryBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class frmScreenProfile : Form
    {
        clsPersons _Person;
        public frmScreenProfile(clsPersons persons)
        {
            _Person = persons;
            _MemberID = clsMembers.FindByPersonID(_Person.PersonID).MemberID;

            InitializeComponent();
        }
        int _MemberID;
        bool ValaditeNumberForPhoneNumber;


        clsMembers _Member;

        private void _NotEnable()
        {
            txtMemberId.Enabled = false;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtLibraryCatd.Enabled= false;
            txtPassword.Enabled = false;
            txtPhoneNumber.Enabled = false;
            txtUserName.Enabled = false;
            txtEmail.Enabled = false;
        }
        private void _Enable()
        {
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtPassword.Enabled = true;
            txtPhoneNumber.Enabled = true;
            txtUserName.Enabled = true;
            txtEmail.Enabled = true;
        }


        private void _LoadData()
        {
            _NotEnable();
            _Member  = clsMembers.Find(_MemberID);
            _Person = clsPersons.Find(_Member.PerosnID);

            if (_Member == null || _Person == null)
            {

                MessageBox.Show("This form will be closed because No Member or Person with ID = " + _MemberID);
                this.Close();
                return;
            }

            txtMemberId.Text = _Member.MemberID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtLastName.Text = _Person.LastName;
            txtLibraryCatd.Text = _Member.LibraryCardNumber;
            txtPassword.Text = _Person.Password;
            txtPhoneNumber.Text = _Person.PhoneNumber;
            txtUserName.Text = _Person.UserName;
            txtEmail.Text = _Person.Email;
       

        }

        private bool _SavePerson()
        {

            _Person.FirstName = txtFirstName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.Password = txtPassword.Text;
            _Person.PhoneNumber = txtPhoneNumber.Text;
            _Person.UserName = txtUserName.Text;
            _Person.Email = txtEmail.Text;
            _Person.Permissions = "Member";

            if (_Person.Save())
            {
                _Member.PerosnID = _Person.PersonID;
                return true;
            }
            else
                return false;

        }

        private bool _Save()
        {
            if (_SavePerson() && _Member.Save())
            {
                MessageBox.Show("Edit your information Saved Successfully with ID = " + _Member.MemberID + " And Library Card = "
                    + _Member.LibraryCardNumber, "Saved", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                _LoadData();
                return true;

            }
            else
            
                MessageBox.Show("Error: Member Is not Saved Successfully.", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return false;
            
        }

        private void _ChangeButtonToShow()
        {
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;


        }
        private void _ChangeButtonToHide()
        {
            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;


        }

        private void frmScreenProfile_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _Enable();
            _ChangeButtonToShow();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsValidaited.ValditionAddAndUpdateMember(errorProvider1, txtFirstName, txtLastName, txtUserName,
                 txtEmail, txtPassword, txtPhoneNumber) &&  ValaditeNumberForPhoneNumber)
            {
                if (_Save())
                {
                    _ChangeButtonToHide();
                    _NotEnable();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _ChangeButtonToHide();
            _NotEnable();

        }

            
        private void txtPhoneNumber_Validated(object sender, EventArgs e)
        {
            ValaditeNumberForPhoneNumber = clsValidaited.ValidatedTextNumberText(errorProvider1, txtPhoneNumber);
        }
    }
}
