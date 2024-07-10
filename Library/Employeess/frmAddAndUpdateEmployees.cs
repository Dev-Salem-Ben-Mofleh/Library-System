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
    public partial class frmAddAndUpdateEmployees : Form
    {
        public enum enMode { Add = 0, Update = 1 };
        private enMode _mode;
        int _EmployeeID;
        bool ValditeNumberForSalary;
        bool ValaditeNumberForPhoneNumber;
        clsEmployees _Employee;
        clsPersons _Person;

        public frmAddAndUpdateEmployees(int EmployeeID)
        {
            _EmployeeID = EmployeeID;

            if (_EmployeeID == -1)
                _mode = enMode.Add;
            else
                _mode = enMode.Update;
            InitializeComponent();
        }
        private void _LoadData()
        {
            cbPermisson.SelectedIndex = 0;
            if (_mode == enMode.Add)
            {
                lblMode.Text = "ADD NEW EMPLOYEES";
                _Employee = new clsEmployees();
                _Person = new clsPersons();

                return;
            }

            _Employee = clsEmployees.Find(_EmployeeID);
            _Person = clsPersons.Find(_Employee.PersonID);
            if (_Employee == null || _Person == null)
            {
                MessageBox.Show("This form will be closed because No Employee with ID = " + _EmployeeID);
                this.Close();
                return;
            }

            lblMode.Text = "EDIT EMPLOYEE  ";
            txtEmployeeID.Text = _Employee.EmployeeID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtLastName.Text = _Person.LastName;
            txtsalary.Text = _Employee.Salary.ToString();
            txtPassword.Text = _Person.Password;
            txtPhoneNmber.Text = _Person.PhoneNumber;
            txtUserName.Text = _Person.UserName;
            txtEmail.Text = _Person.Email;
            cbPermisson.Text = _Person.Permissions;

        }

        private bool _SavePerson()
        {

            _Person.FirstName = txtFirstName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.Password = txtPassword.Text;
            _Person.PhoneNumber = txtPhoneNmber.Text;
            _Person.UserName = txtUserName.Text;
            _Person.Email = txtEmail.Text;
            _Person.Permissions = cbPermisson.Text;

            if (_Person.Save())
            {
                _Employee.PersonID = _Person.PersonID;
                return true;
            }
            else
                return false;

        }

        private bool _Save()
        {

            _Employee.EmployeeID = _EmployeeID;
            _Employee.Salary =Convert.ToDecimal(txtsalary.Text);

            if (_SavePerson() && _Employee.Save())
            {
                MessageBox.Show("Employee Saved Successfully With ID= " + _Employee.EmployeeID, "Saved", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Employee Is not Saved Successfully.", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return false;
            }

            _mode = enMode.Update;
            lblMode.Text = "EDIT EMPLOYEE WITH ID = " + _Employee.EmployeeID;
            txtEmployeeID.Text = _Employee.EmployeeID.ToString();
            return true;

        }

        private void frmAddAndUpdateEmployees_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsValidaited.ValditionAddAndUpdateEmployees(errorProvider1, txtFirstName, txtLastName, txtUserName
                , txtsalary, txtEmail, txtPassword, txtPhoneNmber) && ValaditeNumberForPhoneNumber && ValditeNumberForSalary)
            {
                if (_Save())
                    this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtsalary_Validated(object sender, EventArgs e)
        {
            ValditeNumberForSalary = clsValidaited.ValidatedTextNumber(errorProvider1,
                txtsalary);
        }

        private void txtPhoneNmber_Validated(object sender, EventArgs e)
        {
            ValaditeNumberForPhoneNumber=clsValidaited.ValidatedTextNumber(errorProvider1,
                txtPhoneNmber);
        }
    }
}
