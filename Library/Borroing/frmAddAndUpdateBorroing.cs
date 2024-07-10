using LibraryBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{

    public partial class frmAddAndUpdateBorroing : Form
    {
        public enum enMode { Add = 0, Update = 1 };
        private struct stBorrowingVar
        {
            public enMode _mode;
            public int _BorrowingID, _CopyID, _MemberID;
            public clsBorrowingRecords _borrowingRecords;
            public clsBookCopies _BookCopies;
            public clsMembers _Member;
            public byte ChangeIamgeOfBook ;
            public byte ChangeIamgeOfMember ;
            public int CopyID;
            public int MemebrID;
            public decimal PriceOFBook;
            public bool AvilaibleOfBook;
            public bool MemberFound;
        }

        stBorrowingVar stBorrowing;
        public frmAddAndUpdateBorroing(int BorrowingID, int CopyID, int MemberID)
        {
            stBorrowing._BorrowingID = BorrowingID;
            stBorrowing._CopyID = CopyID;
            stBorrowing._MemberID = MemberID;
            if (BorrowingID == -1)
                stBorrowing._mode = enMode.Add;
            else
                stBorrowing._mode = enMode.Update;
            InitializeComponent();
        }
        int _BookID;
        int _MemberIDM;
        int ForMember;

        public frmAddAndUpdateBorroing(int BookID, int MemberIDM)
        {
            _BookID = BookID;
            _MemberIDM = MemberIDM;
            ForMember = 1;
            stBorrowing._mode = enMode.Add;

            InitializeComponent();

        }

        private void _LoadDataForMember()
        {
           
            numBookID.Value = _BookID;
            numMemberID.Value = _MemberIDM;

        }

        private void _UpdateCopies(int CopyID)
        {
            stBorrowing._BookCopies = clsBookCopies.Find(CopyID);
            if (stBorrowing._BookCopies == null)
                return;

            stBorrowing._BookCopies.AvailabilityStatus = true;

            if (stBorrowing._BookCopies.Save())
            {
                // MessageBox.Sshow("Data Saved Successfully.", "Successfull", MessageBoxButtons.OK
                //  , MessageBoxIcon.Information);
                return;
            }

            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK
                   , MessageBoxIcon.Error);
        }
        private void _UpdateCopiesForUpdate(int CopyID)
        {
            stBorrowing._BookCopies = clsBookCopies.Find(CopyID);
            if (stBorrowing._BookCopies == null)
                return;

            stBorrowing._BookCopies.AvailabilityStatus = false;

            if (stBorrowing._BookCopies.Save())
            {
                // MessageBox.Sshow("Data Saved Successfully.", "Successfull", MessageBoxButtons.OK
                //  , MessageBoxIcon.Information);
                return;
            }

            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK
                   , MessageBoxIcon.Error);
        }
        private bool _BookisAvilaible()
        {
            stBorrowing.CopyID = clsBookCopies.IsBookAvailble((int)numBookID.Value);
            stBorrowing._CopyID = stBorrowing.CopyID;
            return (stBorrowing._CopyID != -1);
        }
        private bool _MemberIsFound()
        {
            stBorrowing._Member = clsMembers.Find((int)numMemberID.Value);
            if (stBorrowing._Member == null)
            {
                stBorrowing.MemberFound = false;
                btnShowInfoMember.Enabled = false;
                dgvShowMember.DataSource = null;
                dgvShowMember.Visible = false;
                btnShowInfoMember.Text = "ShowInfo";
                btnShowInfoMember.Image = Image.FromFile(@"E:\Library\Picture\Hide.png");
                stBorrowing.ChangeIamgeOfMember = 0;
                return false;

            }

            btnShowInfoMember.Enabled = true;
            stBorrowing.MemebrID = stBorrowing._Member.MemberID;
            stBorrowing._MemberID = stBorrowing.MemebrID;
            stBorrowing.MemberFound = true;

            return stBorrowing.MemberFound;
        }
        private void _ChangeIamgeOfAvilaibleOfBooks()
        {
            if (_BookisAvilaible())
            {
                pictureBox1.Image = Image.FromFile(@"E:\Library\Picture\correct.png");
                btnShowInfoBook.Enabled = true;
                stBorrowing.AvilaibleOfBook = true;
                return;
            }
            else
            {
                pictureBox1.Image = Image.FromFile(@"E:\Library\Picture\wrong.png");
                btnShowInfoBook.Enabled = false;
                stBorrowing.AvilaibleOfBook = false;
                dgvShowBook.DataSource = null;
                dgvShowBook.Visible = false;
                btnShowInfoBook.Text = "ShowInfo";
                btnShowInfoBook.Image = Image.FromFile(@"E:\Library\Picture\Hide.png");
                stBorrowing.ChangeIamgeOfBook = 0;
            }

        }
        private void _ChangeImagesOfBook()
        {
            int BookID;
            if (stBorrowing.ChangeIamgeOfBook != 1)
            {
                btnShowInfoBook.Text = "HideInfo";
                btnShowInfoBook.Image = Image.FromFile(@"E:\Library\Picture\Show.png");
                stBorrowing.ChangeIamgeOfBook = 1;
                dgvShowBook.Visible = true;
                BookID = clsBookCopies.Find(stBorrowing._CopyID).BookID;
                dgvShowBook.DataSource = clsBooks.GetAllInfoBookByIDForShow(BookID);

            }
            else
            {
                btnShowInfoBook.Text = "ShowInfo";
                btnShowInfoBook.Image = Image.FromFile(@"E:\Library\Picture\Hide.png");
                stBorrowing.ChangeIamgeOfBook = 0;
                dgvShowBook.DataSource = null;
                dgvShowBook.Visible = false;

            }
        }
        private void _ChangeImagesOfMember()
        {
            if (stBorrowing.ChangeIamgeOfMember != 1)
            {
                btnShowInfoMember.Text = "HideInfo";
                btnShowInfoMember.Image = Image.FromFile(@"E:\Library\Picture\Show.png");
                stBorrowing.ChangeIamgeOfMember = 1;
                dgvShowMember.Visible = true;
                dgvShowMember.DataSource = clsMembers.GetAllInfoMembersbyID(stBorrowing._MemberID);

            }
            else
            {
                btnShowInfoMember.Text = "ShowInfo";
                btnShowInfoMember.Image = Image.FromFile(@"E:\Library\Picture\Hide.png");
                stBorrowing.ChangeIamgeOfMember = 0;
                dgvShowMember.DataSource = null;
                dgvShowMember.Visible = false;

            }
        }
        private void _LoadDateBookAndMember()
        {
            numBookID.Value = clsBookCopies.Find(stBorrowing._CopyID).BookID;
            numMemberID.Value = stBorrowing._MemberID;
        }
        private void _LoadData()
        {
            btnShowInfoBook.Enabled = false;
            btnShowInfoBook.Text = "ShowInfo";
            btnShowInfoMember.Enabled = false;
            btnShowInfoMember.Text = "ShowInfo";
            dateIssueDate.Enabled = false;
            if (stBorrowing._mode == enMode.Add)
            {
                lblMode.Text = "ADD NEW ISSUE";
                stBorrowing._borrowingRecords = new clsBorrowingRecords();
                return;
            }

            stBorrowing._borrowingRecords = clsBorrowingRecords.Find(stBorrowing._BorrowingID);
            if (stBorrowing._borrowingRecords == null)
            {
                MessageBox.Show("This form will be closed because No BorrowingRecord with ID = " + stBorrowing._BorrowingID);
                this.Close();
                return;
            }

            lblMode.Text = "EDIT ISSUE WITH ID"+ stBorrowing._borrowingRecords.BorrowingRecordID;
            _LoadDateBookAndMember();
            btnShowInfoBook.Enabled = false;
            btnShowInfoMember.Enabled = false;
            dateIssueDate.Value = stBorrowing._borrowingRecords.BorrowingDate;
            dateDueDate.Value = stBorrowing._borrowingRecords.DueDate; 

            
        }
        private bool ValdateReservation()
        {
            clsReservations reservations=new clsReservations();
            return (reservations.GetAllReservationsForBorrowing(stBorrowing._borrowingRecords, stBorrowing._CopyID))
        ;
        }
        private bool ValdsteDate(DateTime dateIssueDate, DateTime dateDueDate)
        {
            return (dateIssueDate.Equals(dateDueDate)) || (dateDueDate < dateIssueDate);   
        }
        private bool _Save()
        {

            stBorrowing._borrowingRecords.BorrowingRecordID = stBorrowing._BorrowingID;
           stBorrowing._borrowingRecords.MemberID = (int)numMemberID.Value;

            stBorrowing._borrowingRecords.CopyID = stBorrowing._CopyID;
            stBorrowing._borrowingRecords.BorrowingDate = Convert.ToDateTime(dateIssueDate.Value.ToShortDateString());
            stBorrowing._borrowingRecords.DueDate = Convert.ToDateTime(dateDueDate.Value.ToShortDateString());
            stBorrowing.PriceOFBook = clsBooks.Find((int)numBookID.Value).PriceBorrwoing;


            if (ValdsteDate(stBorrowing._borrowingRecords.BorrowingDate, stBorrowing._borrowingRecords.DueDate))
            {
                MessageBox.Show("Error: Data Is not Saved Successfully Becuose The due date is equal or smaller " +
                    "than Issue date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!ValdateReservation())
            {
                MessageBox.Show("Error: Data Is not Saved Successfully Becuose this book has resrvation", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return false;
            }


            if (stBorrowing._borrowingRecords.Save() && stBorrowing.AvilaibleOfBook && stBorrowing.MemberFound)
            {
                MessageBox.Show(" Isuue Saved Successfully With ID= " +
                    stBorrowing._borrowingRecords.BorrowingRecordID + " the price of book is " + stBorrowing.PriceOFBook +
                    " For only six days after six days you will you have fine", "Saved", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                _UpdateCopies(stBorrowing._CopyID);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
               return  false;
            }


            stBorrowing._mode = enMode.Update;
            lblMode.Text = "EDIT ISSUE WITH ID = " + stBorrowing._borrowingRecords.BorrowingRecordID;
            return true;


        }
        private void frmAddAndUpdateBorroing_Load(object sender, EventArgs e)
        {
            _LoadData();
            if (ForMember == 1)
                _LoadDataForMember();
        }
        private void btnShowInfoBook_Click(object sender, EventArgs e)
        {
            _ChangeImagesOfBook();
        }
        private void btnShowInfoMember_Click(object sender, EventArgs e)
        {
            _ChangeImagesOfMember();
        }
        private void numMemberID_ValueChanged(object sender, EventArgs e)
        {
            _MemberIsFound();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
                if(_Save())
                this.Close();
           
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void numBookID_ValueChanged(object sender, EventArgs e)
        {
            if(stBorrowing._mode ==enMode.Update)
            _UpdateCopiesForUpdate(stBorrowing._CopyID);

            _ChangeIamgeOfAvilaibleOfBooks();
        }
    }
}
