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
    public partial class frmScreenBooksForMembers : Form
    {
        clsPersons _persons;
        public frmScreenBooksForMembers(clsPersons persons)
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

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
          clsShowScreens.ShowAddBorrowingsForMember((int)dgvListOfBooks.CurrentRow.Cells[0].Value
                    , clsMembers.FindByPersonID(_persons.PersonID).MemberID);
        }

        private void frmScreenBooksForMembers_Load(object sender, EventArgs e)
        {
            cbSearchBooks.SelectedIndex = 0;

            _LoadAllDataFromDatabase();
        }

        private void txtSearchBooks_TextChanged(object sender, EventArgs e)
        {
            _SerchBooks();
        }

        private void btnBorroing_Click(object sender, EventArgs e)
        {
            this.Hide();
            clsShowScreens.ShowBorrowingScreenForMember(_persons);
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            this.Hide();
            clsShowScreens.ShowReservationScreenForMember(_persons);
        }

        private void btnFine_Click(object sender, EventArgs e)
        {
            this.Hide();
            clsShowScreens.ShowFinesScreenForMember(_persons);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            clsShowScreens.ShowProfileScreenForMember(_persons);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            clsShowScreens.ShowLogOutScreen();
        }

        private void cbSearchBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadAllDataFromDatabase();
        }
    }
}
