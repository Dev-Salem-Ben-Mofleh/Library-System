using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryBusinessLayer;

namespace Library
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }
        clsPersons persons;

        private void _ShowMainScreenForEmployees(byte Permission)
        {
            frmMainHome frm = new frmMainHome(persons, this, Permission);
            frm.Show();
        }
        private void _ShowMainScreenForMember()
        {
            frmHomeForMember frm = new frmHomeForMember(persons, this);
            frm.Show();
        }

        private void _CheckPermissionToEnterToSystem()
        {
            persons = clsPersons.Find(txtUserName.Text, txtPassword.Text);

            switch (persons.Permissions.ToLower())
            {
                case "admin":
                    _ShowMainScreenForEmployees(1);
                    break;
                case "librarian":
                    _ShowMainScreenForEmployees(0);
                    break;
                case "assistant":
                    _ShowMainScreenForEmployees(0);
                    break;
                case "member":
                    _ShowMainScreenForMember();
                    break;
            }
        }




        private void _IsMemberOrEmployees()
        {
            if(clsPersons.isPersonExist(txtUserName.Text, txtPassword.Text) )
            {
                _CheckPermissionToEnterToSystem();
            }
            else
            {
                MessageBox.Show("The UserName or password is not correct please try again", "Error", MessageBoxButtons.OKCancel
                    , MessageBoxIcon.Error);
            }
        }
        private void btnLogIn_Click(object sender, EventArgs e)
        {
           if(clsValidaited.ValditionLogin(errorProvider1,txtUserName,txtPassword))
            _IsMemberOrEmployees();
        }



        private void txtUserName_Enter(object sender, EventArgs e)
        {
            txtUserName.Clear();

        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Clear();

        }
    }
}
