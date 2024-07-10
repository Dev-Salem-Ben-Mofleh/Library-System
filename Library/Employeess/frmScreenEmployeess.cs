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
using static Library.frmScreenAuthor;

namespace Library
{
    public partial class frmScreenEmployeess : Form
    {
        clsPersons _persons;

        public frmScreenEmployeess(clsPersons persons)
        {
            _persons = persons;
            InitializeComponent();
        }

        stEmployeeScreenVar EmployeeScreenVar;
        public struct stEmployeeScreenVar
        {
            public int SearchEmployeeID;
            public string SearchEmployeeName;
            public string SearchEmployeeUserName;


        }

        private DataTable _dataTable = new DataTable();
        private DataView _dataView = new DataView();
        private void _LoadAllDataFromDatabase()
        {
            _dataTable = clsEmployees.GetAllInfoEmployees();
            _dataView = _dataTable.DefaultView;
          dgvListOfEmpoyees.DataSource = _dataView;
        }
        private void _SerchEmployees()
        {
            if (txtSearchEmployees.Text == "")
            {
                _LoadAllDataFromDatabase();
                return;
            }

            switch (cbSearchEmployees.Text.ToLower())
            {
                case "id":
                    if (int.TryParse((txtSearchEmployees.Text), out int Employeeid))
                    {
                        EmployeeScreenVar.SearchEmployeeID = Employeeid;
                        _dataView.RowFilter = $"EmployeeID={EmployeeScreenVar.SearchEmployeeID}";
                        dgvListOfEmpoyees.Refresh();
                    }
                    else
                    {
                        EmployeeScreenVar.SearchEmployeeID = 0;
                        _dataView.RowFilter = $"EmployeeID={EmployeeScreenVar.SearchEmployeeID}";
                        dgvListOfEmpoyees.Refresh();
                    }

                    break;

                case "name":
                    EmployeeScreenVar.SearchEmployeeName = txtSearchEmployees.Text;
                    _dataView.RowFilter = $" FullName like '{EmployeeScreenVar.SearchEmployeeName}%' ";
                    dgvListOfEmpoyees.Refresh();
                    break;

                case "username":
                    EmployeeScreenVar.SearchEmployeeUserName = txtSearchEmployees.Text;
                    _dataView.RowFilter = $" UserName like '{EmployeeScreenVar.SearchEmployeeUserName}%' ";
                    dgvListOfEmpoyees.Refresh();
                    break;

                default:
                    _LoadAllDataFromDatabase();
                    break;
            }
        }

        private void _DeleteEmployee()
        {
            if (MessageBox.Show("Are you sure you want to delete Member ["
                + dgvListOfEmpoyees.CurrentRow.Cells[0].Value + "]", "Confirm Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsEmployees.DeleteEmployee((int)dgvListOfEmpoyees.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Employee Deleted Successfully."
                        , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadAllDataFromDatabase();
                }

                else
                    MessageBox.Show("Employee is not deleted."
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowAddEmployeeScreen(-1);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowUpdateEmployees((int)dgvListOfEmpoyees.CurrentRow.Cells[0].Value);
        }
        private void txtSearchEmployees_TextChanged(object sender, EventArgs e)
        {
            _SerchEmployees();
        }


        private void frmScreenEmployeess_Load(object sender, EventArgs e)
        {
            cbSearchEmployees.SelectedIndex = 0;

            _LoadAllDataFromDatabase();
        }

        private void cbSearchEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadAllDataFromDatabase();

        }

     

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _DeleteEmployee();
        }

        
    }
}
