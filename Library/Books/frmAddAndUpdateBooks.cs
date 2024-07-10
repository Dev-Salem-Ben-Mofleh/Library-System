using LibraryBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class frmAddAndUpdateBooks : Form 
    {
        public enum enMode { Add = 0, Update = 1 };
        private enMode _mode;
        int _BookID;
        bool ValditeNumberOfISBN;
        bool ValditeNumberOfPrice;
        clsBooks _books;
        clsBookCopies _bookCopies;

        public frmAddAndUpdateBooks(int BookID)
        {
            _BookID= BookID ;

            if (BookID == -1)
                _mode = enMode.Add;
            else
                _mode = enMode.Update;
            InitializeComponent();
        }
        private void _FillCoGener()
        {
            DataTable dt = clsGeners.GetAllGeners();
            foreach (DataRow Row in dt.Rows)
            {
                cbGeners.Items.Add(Row["GenerName"]);
            }
        }

        private void _FillCbAuthors()
        {
            DataTable dt = clsAuthors.GetAllAuthor();
            foreach (DataRow Row in dt.Rows)
            {
                cbAuthors.Items.Add(Row["AuthorName"]);
            }
        }

        private void _LoadData()
        {
            _FillCoGener();
            _FillCbAuthors();
            cbGeners.SelectedIndex = 0;
            cbAuthors.SelectedIndex = 0;
            if(_mode == enMode.Add)
            {
                lblMode.Text = "ADD NEW BOOK";
                _books = new clsBooks();
                return;
            }

            _books = clsBooks.Find(_BookID);
            if (_books == null)
            {
                MessageBox.Show("This form will be closed because No Book with ID = " + _BookID);
                this.Close();
                return;
            }

            lblMode.Text = "EDIT BOOK  ";
            txtBookID.Text= _books.BookID.ToString();
            txtISBN.Text = _books.ISBN;
            txtTitalBook.Text = _books.Tital;
            txtPrice.Text = _books.PriceBorrwoing.ToString();
            if (_books.AdditionalDetails != "")
            {
                txtAdditionalDietals.Text = _books.AdditionalDetails;
            }
            numQuantity.Value = clsBookCopies.CountCopies(_books.BookID);
            cbAuthors.SelectedIndex = cbAuthors.FindString(clsAuthors.Find(_books.AuthorID).AuthorName);
            cbGeners.SelectedIndex = cbGeners.FindString(clsGeners.Find(_books.GenreID).GenerName);
            numQuantity.Value = clsBookCopies.CountCopies(_books.BookID);
            dataPublicatioDate.Text = _books.PublicationDate.ToString();

        }
        private void _AddBookCopies(int NumberIOfCopies)
        {
            for (int i = 0; i < NumberIOfCopies; i++)
            {
                _bookCopies = new clsBookCopies();
                _bookCopies.BookID = _books.BookID;
                _bookCopies.AvailabilityStatus = false;
                _bookCopies.Save();
            }
        }
        private void _EditBookCopies(int NumberIOfCopies)
        {
            int CountCopy;
            CountCopy = clsBookCopies.CountCopies(_BookID);
            if (NumberIOfCopies == CountCopy)
                return;

            if (NumberIOfCopies > CountCopy)
            {
                NumberIOfCopies = NumberIOfCopies - CountCopy;
                _AddBookCopies(NumberIOfCopies);
            }
            else
            {
                
               if (clsBookCopies.DeleteBookCopiesBuAvalible(_BookID))
                {
                    CountCopy = clsBookCopies.CountCopies(_BookID);
                    if (CountCopy >= NumberIOfCopies)
                    {
                        MessageBox.Show("We Deleted Succssfully but Aothor BookCopies is Avaliable", "Cofigrum",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        NumberIOfCopies = NumberIOfCopies - CountCopy;
                        _AddBookCopies(NumberIOfCopies);

                    }

                }
            }
        }
        private void _FillCopiesBooks(int NumberIOfCopies)
        {
            if (_mode == enMode.Add)
            {
                _AddBookCopies(NumberIOfCopies);
            }
            else
            {
                _EditBookCopies(NumberIOfCopies);


            }


        }
        private bool _Save()
        {

            _books.AuthorID = clsAuthors.Find(cbAuthors.Text).AuthorID;
            _books.GenreID = clsGeners.Find(cbGeners.Text).GenerID;
            _books.ISBN = txtISBN.Text;
            _books.BookID = _BookID;
            _books.Tital = txtTitalBook.Text;
            _books.PriceBorrwoing =Convert.ToDecimal( txtPrice.Text);
            _books.PublicationDate = Convert.ToDateTime( dataPublicatioDate.Text);


            if (txtAdditionalDietals.Text != "")
                _books.AdditionalDetails = txtAdditionalDietals.Text;
            else
                _books.AdditionalDetails = "";

            if (_books.Save())
            {
                MessageBox.Show("Book Saved Successfully With ID = " + _books.BookID, "Saved", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                _FillCopiesBooks((int)numQuantity.Value);

            }
            else
            {
                MessageBox.Show("Error: Book Is not Saved Successfully.", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return false;
            }

            _mode = enMode.Update;
            lblMode.Text = "EDIT BOOK WITH ID = " + _books.BookID;
            txtBookID.Text = _books.BookID.ToString();
            return true;


        }
        

        private void frmAddAndUpdateBooks_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsValidaited.ValditionAddAndUpdateBooks(errorProvider1, txtTitalBook, txtISBN, txtPrice,numQuantity)
                && ValditeNumberOfISBN && ValditeNumberOfPrice) 
            {
               if( _Save())
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbGeners_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtISBN_Validated(object sender, EventArgs e)
        {
            ValditeNumberOfISBN = clsValidaited.ValidatedTextNumber(errorProvider1, txtISBN);
        }

        private void txtPrice_Validated(object sender, EventArgs e)
        {
            ValditeNumberOfPrice = clsValidaited.ValidatedTextNumber(errorProvider1, txtPrice);
        }
    }
}
