using LibraryBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class frmAddAndUpdateMembers : Form
    {
        public enum enMode { Add = 0, Update = 1 };
        private enMode _mode;
        int _MemberID;
        string _MemberCard;
        bool ValaditeNumberForPhoneNumber;
        clsMembers _Member;
        clsPersons _Person;

        public frmAddAndUpdateMembers(int MemberID,string MemberCard)
        {
            _MemberID = MemberID;
            _MemberCard = MemberCard;

            if (_MemberID == -1)
                _mode = enMode.Add;
            else
                _mode = enMode.Update;
            InitializeComponent();
        }

        private void _LoadData()
        {
            if (_mode == enMode.Add)
            {
                lblMode.Text = "ADD NEW MEMBER";
                _Member = new clsMembers();
                _Person = new clsPersons();

                return;
            }

            _Member = clsMembers.Find(_MemberID);
            _Person = clsPersons.Find(_Member.PerosnID);
            if (_Member == null || _Person==null )
            {
                MessageBox.Show("This form will be closed because No Member with ID = " + _MemberID);
                this.Close();
                return;
            }

            lblMode.Text = "EDIT MEMBER  ";
            txtMemberD.Text = _Member.MemberID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtLastName.Text = _Person.LastName;
            txtLibraryCard.Text = _Member.LibraryCardNumber;
            txtPassword.Text = _Person.Password;
            txtPhoneNmber.Text = _Person.PhoneNumber;
            txtUserName.Text = _Person.UserName;
            txtEmail.Text = _Person.Email;

        }

        private bool _SavePerson()
        {

            _Person.FirstName = txtFirstName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.Password = txtPassword.Text;
            _Person.PhoneNumber = txtPhoneNmber.Text;
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
            
            _Member.MemberID = _MemberID;
            if (_mode == enMode.Add)
                _Member.LibraryCardNumber = clsMembers.GetNewCard();
            else
                _Member.LibraryCardNumber = _MemberCard;
            if (_SavePerson() && _Member.Save())
            {
                MessageBox.Show("Member Saved Successfully with ID = " + _Member.MemberID + " And Library Card = "
                    + _Member.LibraryCardNumber, "Saved", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Member Is not Saved Successfully.", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return false;
            }

            _mode = enMode.Update;
            lblMode.Text = "EDIT Member WITH ID = " + _Member.MemberID;
            txtMemberD.Text = _Member.MemberID.ToString();
            txtLibraryCard.Text = _Member.LibraryCardNumber;
            return true;

        }

        private void frmAddAndUpdateMembers_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsValidaited.ValditionAddAndUpdateMembers(errorProvider1, txtFirstName, txtLastName, txtUserName,
                 txtEmail, txtPassword, txtPhoneNmber) && ValaditeNumberForPhoneNumber)
            {      
                if (_Save())
                    this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMode_Click(object sender, EventArgs e)
        {

        }

        private void txtPhoneNmber_Validated(object sender, EventArgs e)
        {
            ValaditeNumberForPhoneNumber = clsValidaited.ValidatedTextNumber(errorProvider1, txtPhoneNmber);
        }
    }
}
