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
    public partial class frmScreenMembers : Form
    {
        clsPersons _persons;
        public frmScreenMembers(clsPersons persons)
        {
            _persons = persons;
            InitializeComponent();
        }

        
        stMemberScreenVar MemberScreenVar;
        public struct stMemberScreenVar
        {
            public int SearchMemberID;
            public string SearchMemberName;
            public string SearchMemberUserName;
            public string SearchMemberLibraryCard;


        }

        private DataTable _dataTable = new DataTable();
        private DataView _dataView = new DataView();
        private void _LoadAllDataFromDatabase()
        {
            _dataTable = clsMembers.GetAllInfoMembers();
            _dataView = _dataTable.DefaultView;
            dgvListOfMembers.DataSource = _dataView;
        }
        private void _SerchMemeber()
        {
            if (txtSearchMembers.Text == "")
            {
                _LoadAllDataFromDatabase();
                return;
            }

            switch (cbSearchMembers.Text.ToLower())
            {
                case "id":
                    if (int.TryParse((txtSearchMembers.Text), out int Memberid))
                    {
                        MemberScreenVar.SearchMemberID = Memberid;
                        _dataView.RowFilter = $"MemberID={MemberScreenVar.SearchMemberID}";
                        dgvListOfMembers.Refresh();
                    }
                    else
                    {
                        MemberScreenVar.SearchMemberID = 0;
                        _dataView.RowFilter = $"MemberID={MemberScreenVar.SearchMemberID}";
                        dgvListOfMembers.Refresh();
                    }

                    break;

                case "name":
                    MemberScreenVar.SearchMemberName = txtSearchMembers.Text;
                    _dataView.RowFilter = $" FullName like '{MemberScreenVar.SearchMemberName}%' ";
                    dgvListOfMembers.Refresh();
                    break;

                case "username":
                    MemberScreenVar.SearchMemberUserName = txtSearchMembers.Text;
                    _dataView.RowFilter = $" UserName like '{MemberScreenVar.SearchMemberUserName}%' ";
                    dgvListOfMembers.Refresh();

                    break;

                case "librarycard":
                    MemberScreenVar.SearchMemberLibraryCard = txtSearchMembers.Text;
                    _dataView.RowFilter = $" LibraryCardNumber like '{MemberScreenVar.SearchMemberLibraryCard}%' ";
                    dgvListOfMembers.Refresh();
                    break;
                default:
                    _LoadAllDataFromDatabase();
                    break;
            }
        }
        private void _DeleteMember()
        {
            if (MessageBox.Show("Are you sure you want to delete Member ["
                + dgvListOfMembers.CurrentRow.Cells[0].Value + "]", "Confirm Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsMembers.DeleteMember((int)dgvListOfMembers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Member Deleted Successfully."
                        , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadAllDataFromDatabase();
                }

                else
                    MessageBox.Show("Member is not deleted,because he has borrowing Or reservation book."
                        , "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowAddMemberScreen(-1,"");

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowUpdateMembers((int)dgvListOfMembers.CurrentRow.Cells[0].Value,
                dgvListOfMembers.CurrentRow.Cells[6].Value.ToString());

        }

        private void cbSearchMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadAllDataFromDatabase();
        }

        private void frmScreenMembers_Load(object sender, EventArgs e)
        {
            cbSearchMembers.SelectedIndex = 0;

            _LoadAllDataFromDatabase();

        }



        


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_persons.Permissions == "Admin")
            {
                _DeleteMember();

            }
            else
                MessageBox.Show("You do not have Permission to delete.", "Error", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
        }

        private void txtSearchMembers_TextChanged(object sender, EventArgs e)
        {
            _SerchMemeber();
        }


        
    }
}
