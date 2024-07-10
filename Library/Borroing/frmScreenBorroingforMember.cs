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
using static Library.frmCirculation;

namespace Library
{
    public partial class frmScreenBorroingforMember : Form
    {
        clsPersons _persons;
        public frmScreenBorroingforMember(clsPersons persons)
        {
            _persons = persons;
            MemberID = clsMembers.FindByPersonID(_persons.PersonID).MemberID;
            

            InitializeComponent();
        }
        clsFines _fines;
        clsBookCopies _BookCopies;
        clsBorrowingRecords _borrowingRecords;
        int MemberID;
        int SearchBorroingID;
        int _CopyID;
        stFineScreenVar fineScreenVar;

        public struct stFineScreenVar
        {
            public decimal FineAmount;
            public int FineNumberOfDays;
        }
        private DataTable _dataTable = new DataTable();
        private DataView _dataView = new DataView();
        private void _LoadDataFromDatabase()
        {
            _dataTable = clsBorrowingRecords.GetAllBorrowingRecord();
            _dataView = _dataTable.DefaultView;
            dgvListOfBorrowings.DataSource = _dataView;
        }
        private void _SerchBorrowing()
        {
            if (txtSearchBorroingID.Text == "")
            {
                _LoadDataFromDatabase();
                return;
            }

            if (int.TryParse((txtSearchBorroingID.Text), out int BorrowingID))
            {
               SearchBorroingID = BorrowingID;
                _dataView.RowFilter = $"BorrowingRecordID={SearchBorroingID}";
                dgvListOfBorrowings.Refresh();
                return;
            }
            else
            {
                SearchBorroingID = 0;
                _dataView.RowFilter = $"BorrowingRecordID={SearchBorroingID}";
                dgvListOfBorrowings.Refresh();
            }
        }

        private bool _SaveFines()
        {
            _fines = new clsFines();
            _fines.BorrowingRecordID = (int)dgvListOfBorrowings.CurrentRow.Cells[0].Value;
            _fines.MemberID = (int)dgvListOfBorrowings.CurrentRow.Cells[1].Value;
            if (fineScreenVar.FineAmount <= 0)
            {
                _fines.FineAmount = 0;
                _fines.PaymentStatus = true;
                _fines.NumberOfLateDays = 0;

            }
            else
            {
                _fines.FineAmount = fineScreenVar.FineAmount;
                _fines.PaymentStatus = false;
                _fines.NumberOfLateDays = fineScreenVar.FineNumberOfDays;
            }


            if (_fines.Save())
            {
                // MessageBox.Show("Data Saved Successfully.", "Successfull", MessageBoxButtons.OK
                //   , MessageBoxIcon.Information);
                return true;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK
                   , MessageBoxIcon.Error);
            return false;

        }
        private bool _SaveBorroingRecord()
        {
            _borrowingRecords.ActualReturnDate = DateTime.Now.ToString("dd-MM-yyyy");

            if (_borrowingRecords.Save())
            {
                // MessageBox.Show("Data Saved Successfully.", "Successfull", MessageBoxButtons.OK
                //  , MessageBoxIcon.Information);
                return true;
            }

            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK
                   , MessageBoxIcon.Error);
            return false;
        }
        private void _UpdateCopies(int CopyID)
        {
            _BookCopies = clsBookCopies.Find(CopyID);
            if (_BookCopies == null)
                return;

             _CopyID = CopyID;
            _BookCopies.AvailabilityStatus = false;

            if (_BookCopies.Save())
            {
                // MessageBox.Sshow("Data Saved Successfully.", "Successfull", MessageBoxButtons.OK
                //  , MessageBoxIcon.Information);
                return;
            }

            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK
                   , MessageBoxIcon.Error);
        }

        private void _FineCalculate()
        {
            fineScreenVar.FineAmount = clsSetting.CalculateFines(ref fineScreenVar.FineNumberOfDays);

        }

        private void _ReturnBook()
        {
            int CopyID;
            CopyID = (int)dgvListOfBorrowings.CurrentRow.Cells[2].Value;
            _borrowingRecords = clsBorrowingRecords.Find((int)dgvListOfBorrowings.CurrentRow.Cells[0].Value);


            if (_borrowingRecords.ActualReturnDate != "")
            {
                MessageBox.Show("This Record is Aleardy Retruned", "Confirm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to Return this book ", "Confirm ",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                fineScreenVar.FineNumberOfDays = clsBorrowingRecords.ReturnBook((DateTime)dgvListOfBorrowings.CurrentRow.Cells[3].Value,
                    DateTime.Now);
                _FineCalculate();
                if (_SaveBorroingRecord() && _SaveFines())
                {
                    MessageBox.Show("Returning Record Saved successfully Retruned " +
                    "You have to Check Table Fines ,if the member has fine or not with RecordFineID = " +
                    _fines.FineID, "Confirm",
           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadDataFromDatabase();
                    _UpdateCopies(CopyID);
                }
            }
        }


        private void frmScreenBorroingforMember_Load(object sender, EventArgs e)
        {
            _LoadDataFromDatabase();
        }

        private void txtSearchBorroingID_TextChanged(object sender, EventArgs e)
        {
            _SerchBorrowing();
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            _ReturnBook();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ReturnBook();
        }


    }
}
