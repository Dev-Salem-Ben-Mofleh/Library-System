using LibraryBusinessLayer;
using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using static Library.frmMainScreen;
using System.Net;

namespace Library
{
    public partial class frmScreenAuthor : Form
    {
        clsPersons _persons;
        public frmScreenAuthor(clsPersons persons)
        {
            _persons = persons;
            InitializeComponent();
        }

        AuthorScreenVar authorScreenVar;
        private DataTable _dataTable = new DataTable();
        private DataView _dataView = new DataView();
        private void _LoadAllDataFromDatabase()
        {
            _dataTable = clsAuthors.GetAllInfoAuthors();
            _dataView = _dataTable.DefaultView;
            dgvListOfAuthorss.DataSource = _dataView;
        }
        private void _SerchAuthors()
        {
            if (txtSearchAuthors.Text == "")
            {
                _LoadAllDataFromDatabase();
                return;
            }

            switch (cbSearchAuthor.Text.ToLower())
            {
                case "authorid":
                    if (int.TryParse((txtSearchAuthors.Text), out int Authorid))
                    {
                        authorScreenVar.SearchAuthorID = Authorid;
                        _dataView.RowFilter = $"AuthorID={authorScreenVar.SearchAuthorID}";
                        dgvListOfAuthorss.Refresh();
                    }
                    else
                    {
                        authorScreenVar.SearchAuthorID = 0;
                        _dataView.RowFilter = $"AuthorID={authorScreenVar.SearchAuthorID}";
                        dgvListOfAuthorss.Refresh();
                    }
                    break;


                case "authorname":
                    authorScreenVar.SearchAuthorName = txtSearchAuthors.Text;
                    _dataView.RowFilter = $" AuthorName like '{authorScreenVar.SearchAuthorName}%' ";
                    dgvListOfAuthorss.Refresh();
                    break;

                case "educationname":
                    authorScreenVar.SearchEducationName = txtSearchAuthors.Text;
                    _dataView.RowFilter = $" EducationName like '{authorScreenVar.SearchEducationName}%' ";
                    dgvListOfAuthorss.Refresh();
                    break;



                default:
                    _LoadAllDataFromDatabase();
                    break;
            }
        }


        public struct AuthorScreenVar
        {
            public int SearchAuthorID;
            public string SearchAuthorName;
            public string SearchEducationName;
        }
     
        private void _DeleteAuthor()
        {
            if (MessageBox.Show("Are you sure you want to delete Author ["
                + dgvListOfAuthorss.CurrentRow.Cells[0].Value + "]", "Confirm Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsAuthors.DeleteAuthor((int)dgvListOfAuthorss.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Author Deleted Successfully", " Deleted",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadAllDataFromDatabase();
                }

                else
                    MessageBox.Show("Author is not deleted,Because he has Books","Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnShwoDetails_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowDetailsAuthorsScreen(dgvListOfAuthorss.CurrentRow.Cells[1].Value.ToString(),
               (int)dgvListOfAuthorss.CurrentRow.Cells[0].Value);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowAddAuthorScreen(-1);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowUpdateAuthors((int)dgvListOfAuthorss.CurrentRow.Cells[0].Value);
        }

        private void dgvListOfBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearchAuthors_TextChanged(object sender, EventArgs e)
        {
            _SerchAuthors();
        }

        private void cbSearchAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadAllDataFromDatabase();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_persons.Permissions == "Admin")
                _DeleteAuthor();
            else 
                MessageBox.Show("You do not have Permission to delete .", "Error", MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
        }

        private void frmScreenAuthor_Load(object sender, EventArgs e)
        {
            cbSearchAuthor.SelectedIndex = 0;
            _LoadAllDataFromDatabase();
        }




    }

}
