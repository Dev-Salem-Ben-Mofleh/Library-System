using Library.Properties;
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
using static Guna.UI2.Native.WinApi;

namespace Library
{
    public partial class frmShowDetailsOfBorroingcs : Form
    {
        int _BorroingID, _BookID, _MemberID,_CopyID;
        public frmShowDetailsOfBorroingcs(int BorroingID,int BookID,int MemberID, int CopyID)
        {
            _BorroingID= BorroingID;
            _BookID= BookID;
            _MemberID= MemberID;
            _CopyID= CopyID;
            InitializeComponent();
        }

        private void _LoadAllDateFromBooks()
        {
            DataTable dt = clsBooks.GetAllInfoBookByID(_BookID);
            foreach (DataRow Row in dt.Rows)
            {
                lblBookID.Text= Row["BookID"].ToString();
                lblCopyID.Text=_CopyID.ToString();
                lblTitalBook.Text = Row["Title"].ToString();
                lblAuthorName.Text = Row["AuthorName"].ToString();
                lblGenerName.Text = Row["GenerName"].ToString();
                lblISBN.Text = Row["ISBN"].ToString();
                lblPublication.Text = Row["PublicationDate"].ToString();
                lblQuantity.Text = Row["Quantity"].ToString();

            }
        }
        private void _LoadAllDateFromMembers()
        {
            DataTable dt = clsMembers.GetAllInfoMembersbyID(_MemberID);
            foreach (DataRow Row in dt.Rows)
            {
                lblMemberID.Text = Row["MemberID"].ToString();
                lblFullName.Text = Row["FullName"].ToString();
                lblUserName.Text = Row["UserName"].ToString();
                lblEmail.Text = Row["Email"].ToString();
                lblPassword.Text = Row["Password"].ToString();
                lblPhoneNumber.Text = Row["PhoneNumber"].ToString();
                lblLibraryCard.Text = Row["LibraryCardNumber"].ToString();

            }
        }
        private void _LoadAllDateFrmBorrowings()
        {
            DateTime BorrowingDate;
            DateTime DueDate;


            DataTable dt = clsBorrowingRecords.GetAllBorrowingRecordsByID(_BorroingID);
            foreach (DataRow Row in dt.Rows)
            {
                lblBorroingId.Text = Row["BorrowingRecordID"].ToString();
                BorrowingDate=Convert.ToDateTime( Row["BorrowingDate"]);
                lblBorroingDate.Text = BorrowingDate.ToString("dd-MM-yyyy");
                DueDate=Convert.ToDateTime( Row["DueDate"]);
                lblDueDate.Text = DueDate.ToString("dd-MM-yyyy");
                lblReturnedDate.Text= Row["ActualReturnDate"].ToString();
                if (lblReturnedDate.Text != "")
                    pictureBox1.Image = Image.FromFile(@"E:\correct.png");
                else
                    pictureBox1.Image = Image.FromFile(@"E:\wrong.png");

            }
        }
        private void frmShowDetailsOfBorroingcs_Load(object sender, EventArgs e)
        {
            _LoadAllDateFromBooks();
            _LoadAllDateFromMembers();
            _LoadAllDateFrmBorrowings();
        }
    }
}
