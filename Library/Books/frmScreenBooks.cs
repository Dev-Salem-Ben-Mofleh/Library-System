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
    public partial class frmScreenBooks : Form
    {
        clsPersons _persons;
        public frmScreenBooks(clsPersons persons)
        {
            _persons = persons;
            InitializeComponent();
        }

        BookScreenVar bookScreenVar;
        public struct BookScreenVar
        {
            public int SearchBookID;
            public string SearchTital;
            public string SearchGenerName;
            public string SearchAuthorName;           

        }
        private DataTable _dataTable = new DataTable();
        private DataView _dataView = new DataView();
        private void _LoadAllDataFromDatabase()
        {
            _dataTable = clsBooks.GetAllInfoBooks();
            _dataView = _dataTable.DefaultView;
            dgvListOfBooks.DataSource = _dataView;
        }
        private void _SerchBooks()
        {
            if (txtSearchBooks.Text == "")
            {
                _LoadAllDataFromDatabase();
                return;
            }

            switch (cbSearchBooks.Text.ToLower())
            {
                case "bookid":
                    if (int.TryParse((txtSearchBooks.Text), out int Bookid))
                    {
                        bookScreenVar.SearchBookID = Bookid;
                        _dataView.RowFilter = $"BookID={bookScreenVar.SearchBookID}";
                        dgvListOfBooks.Refresh();
                    }
                    else
                    {
                        bookScreenVar.SearchBookID = 0;
                        _dataView.RowFilter = $"BookID={bookScreenVar.SearchBookID}";
                        dgvListOfBooks.Refresh();
                    }


                    break;

                case "tital":
                    bookScreenVar.SearchTital = txtSearchBooks.Text;
                    _dataView.RowFilter = $" Title like '{bookScreenVar.SearchTital}%' ";
                    dgvListOfBooks.Refresh();
                    break;

                case "gener":
                    bookScreenVar.SearchGenerName = txtSearchBooks.Text;
                    _dataView.RowFilter = $" GenerName like '{bookScreenVar.SearchGenerName}%'  ";
                    dgvListOfBooks.Refresh();
                    break;

                case "author":

                    bookScreenVar.SearchAuthorName = txtSearchBooks.Text;
                    _dataView.RowFilter = $" AuthorName like '{bookScreenVar.SearchAuthorName}%' ";
                    dgvListOfBooks.Refresh();
                    break;

                default:
                    _LoadAllDataFromDatabase();
                    break;
            }
        }

        private bool _DeleteBookCpoies()
        {
            bool AvailabilityStatus = false;
            DataTable dt = clsBookCopies.GetAllBookCopiesByBookID((int)dgvListOfBooks.CurrentRow.Cells[0].Value);

            foreach (DataRow Rows in dt.Rows)
            {
                AvailabilityStatus = (bool)Rows["AvailabilityStatus"];
                if(AvailabilityStatus)
                {
                    MessageBox.Show("The Book is Reservation you Can not Deleted"
                        , "Confirm Delete", MessageBoxButtons.OKCancel,MessageBoxIcon.Information) ;
                    return false;

                }
            }

            clsBookCopies.DeleteBookCopiesBuAvalible((int)dgvListOfBooks.CurrentRow.Cells[0].Value);
            return true;

        }
        private void _DeleteBook()
        {
            if (MessageBox.Show("Are you sure you want to delete Book ["
                + dgvListOfBooks.CurrentRow.Cells[0].Value + "]", "Confirm Delete",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.OK)

            {
                if (!_DeleteBookCpoies())
                    return;
                

                //Perform Delele and refresh
                if (clsBooks.DeleteBook((int)dgvListOfBooks.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Book Deleted Successfully.","Saved",MessageBoxButtons.OK
                        , MessageBoxIcon.Information);
                    _LoadAllDataFromDatabase();
                }

                else
                    MessageBox.Show("Book is not deleted.","Error",MessageBoxButtons.OK
                        , MessageBoxIcon.Error);

            }
        }
        private void frmScreenBooks_Load(object sender, EventArgs e)
        {
            cbSearchBooks.SelectedIndex = 0;

            _LoadAllDataFromDatabase();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowAddBooksScreen(-1);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowUpdateBooks((int)dgvListOfBooks.CurrentRow.Cells[0].Value);
        }

        private void btnShwoDetails_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowDetailsScreen((int)dgvListOfBooks.CurrentRow.Cells[0].Value,
               (string)dgvListOfBooks.CurrentRow.Cells[1].Value);
        }
    


        private void txtSearchBooks_TextChanged(object sender, EventArgs e)
        {
            _SerchBooks();
        }

        private void cbSearchBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadAllDataFromDatabase();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_persons.Permissions == "Admin")

            {
                _DeleteBook();
            }
            else
                MessageBox.Show("You do not have Permission to  delete.", "Error", MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
        }
    }
}
