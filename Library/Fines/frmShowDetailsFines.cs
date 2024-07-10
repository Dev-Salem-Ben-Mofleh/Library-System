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
    public partial class frmShowDetailsFines : Form
    {
        int _MemberID, _BorroingID, _FineID;
        public frmShowDetailsFines(int MemberID,int BorroingID, int FineID)
        {
            _MemberID = MemberID;
            _BorroingID= BorroingID;
            _FineID = FineID;

            InitializeComponent();
        }

        private void _ChangeIamgeOfPaid(bool Iamge)
        {
            if (Iamge)
            {
                pictureBox1.Image = Image.FromFile(@"E:\Library\Picture\correct.png");
            }
            else
            {
                pictureBox1.Image = Image.FromFile(@"E:\Library\Picture\wrong.png");
            }

        }
        private void _LoadAllDateFromFines()
        {
            DataTable dt = clsFines.GetFineByID(_FineID);
            foreach (DataRow Row in dt.Rows)
            {
                lblfineID.Text = Row["FineID"].ToString();
                lblFineAmount.Text = Row["FineAmount"].ToString();
                _ChangeIamgeOfPaid((bool)Row["PaymentStatus"]);
                
                
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
                BorrowingDate = Convert.ToDateTime(Row["BorrowingDate"]);
                lblBorroingDate.Text = BorrowingDate.ToString("dd-MM-yyyy");
                DueDate = Convert.ToDateTime(Row["DueDate"]);
                lblDueDate.Text = DueDate.ToString("dd-MM-yyyy");
                lblReturnedDate.Text = Row["ActualReturnDate"].ToString();
                if (lblReturnedDate.Text != "")
                    pictureBox1.Image = Image.FromFile(@"E:\correct.png");
                else
                    pictureBox1.Image = Image.FromFile(@"E:\wrong.png");

            }
        }

        private void frmShowDetailsFines_Load(object sender, EventArgs e)
        {
            _LoadAllDateFrmBorrowings();
            _LoadAllDateFromMembers();
            _LoadAllDateFromFines();
        }

    }
}
