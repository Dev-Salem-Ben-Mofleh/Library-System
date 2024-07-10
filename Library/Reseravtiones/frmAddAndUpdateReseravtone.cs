using Guna.UI2.WinForms;
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
    public partial class frmAddAndUpdateReseravtone : Form
    {
        public enum enMode { Add = 0, Update = 1 };
       private struct stReservationVar
        {
            public enMode _mode;
            public int _ReservationID, _CopyID, _MemberID;
            public clsReservations _reservations;
            public clsMembers _Member;
            public byte ChangeIamgeOfBook ;
            public byte ChangeIamgeOfMember ;
            public bool AvilaibleOfBook;
            public bool MemberFound;
            public int OldCopyID;
        }
        stReservationVar reservationVar;

        public frmAddAndUpdateReseravtone(int ReservationID, int MemberID, int CopyID)
        {
            reservationVar._ReservationID = ReservationID;
            reservationVar._MemberID = MemberID;
            reservationVar._CopyID = CopyID;
            reservationVar.OldCopyID = reservationVar._CopyID;

            if (reservationVar._ReservationID == -1)
                reservationVar._mode = enMode.Add;
            else
                reservationVar._mode = enMode.Update;
            InitializeComponent();
        }

        private bool _BookisFound()
        {
            int CopyID = clsBookCopies.IsBookAvailble((int)numBookID.Value);

            if (reservationVar._mode == enMode.Add)
                reservationVar._CopyID = CopyID;

            return (CopyID != -1);
            
        }
        private bool _MemberIsFound()
        {
            reservationVar._Member = clsMembers.Find((int)numMemberID.Value);
            if (reservationVar._Member == null)
            {
                reservationVar.MemberFound = false;
                btnShowInfoMember.Enabled = false;
                dgvShowMember.DataSource = null;
                dgvShowMember.Visible = false;
                btnShowInfoMember.Image = Image.FromFile(@"E:\Library\Picture\Hide.png");
                btnShowInfoMember.Text = "ShowInfo";
                reservationVar.ChangeIamgeOfMember = 0;
                return false;
            }

            reservationVar._MemberID = reservationVar._Member.MemberID;
            reservationVar.MemberFound = true;
            btnShowInfoMember.Enabled = true;


            return reservationVar.MemberFound;
        }
        private void _FillBookCopies()
        {
            cbCopies.Items.Clear();
                DataTable dt = clsBookCopies.GetAllBookCopiesAvilible((int)numBookID.Value);
                foreach (DataRow Row in dt.Rows)
                {
                    cbCopies.Items.Add(Row["CopyID"]);
                }

                if(cbCopies.Items.Count==0)
                MessageBox.Show("I am sorry no book are valailble", "information", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);

            if (reservationVar._mode == enMode.Add)
                cbCopies.SelectedIndex=0;
        }
        private void _ChangeIamgeOfAvilaibleOfBookCopies()
        {
            if (reservationVar.OldCopyID ==Convert.ToInt32( cbCopies.Text))
            {
                reservationVar.AvilaibleOfBook = true;
                pictureBox2.Image = Image.FromFile(@"E:\Library\Picture\correct.png");
                return;
            }

            if (_IsReservationisFound(Convert.ToInt32( cbCopies.Text)))
            {
                //MessageBox.Show("Error: this book has reservation change the Copy", "Error", MessageBoxButtons.OK
                //    , MessageBoxIcon.Error);
                reservationVar.AvilaibleOfBook = false;
                pictureBox2.Image = Image.FromFile(@"E:\Library\Picture\wrong.png");

                return;
            }
            else
            {
                pictureBox2.Image = Image.FromFile(@"E:\Library\Picture\correct.png");
                reservationVar.AvilaibleOfBook = true;
            }

        }
        private void _ChangeIamgeOfAvilaibleOfBooks()
        {
            if (_BookisFound())
            {
                pictureBox1.Image = Image.FromFile(@"E:\Library\Picture\correct.png");
                btnShowInfoBook.Enabled = true;
                _FillBookCopies();
                return;
            }
            else
            {
                btnShowInfoBook.Enabled = false;
                dgvShowBook.DataSource = null;
                dgvShowBook.Visible = false;
                btnShowInfoBook.Image = Image.FromFile(@"E:\Library\Picture\Hide.png");
                btnShowInfoBook.Text = "ShowInfo";
                pictureBox1.Image = Image.FromFile(@"E:\Library\Picture\wrong.png");
                reservationVar.ChangeIamgeOfBook = 0;
                reservationVar.AvilaibleOfBook = false;
                pictureBox2.Image = Image.FromFile(@"E:\Library\Picture\wrong.png");
                cbCopies.Items.Clear();

            }

        }
        private void _ChangeImagesOfBook()
        {
            int BookID;
            if (reservationVar.ChangeIamgeOfBook != 1)
            {
                btnShowInfoBook.Image = Image.FromFile(@"E:\Library\Picture\Show.png");
                reservationVar.ChangeIamgeOfBook = 1;
                dgvShowBook.Visible = true;
                btnShowInfoBook.Text = "HideInfo";
                BookID = clsBookCopies.Find(reservationVar._CopyID).BookID;
                dgvShowBook.DataSource = clsBooks.GetAllInfoBookByIDForShow(BookID);

            }
            else
            {
                btnShowInfoBook.Image = Image.FromFile(@"E:\Library\Picture\Hide.png");
                btnShowInfoBook.Text = "ShowInfo";
                reservationVar.ChangeIamgeOfBook = 0;
                dgvShowBook.DataSource = null;
                dgvShowBook.Visible = false;

            }
        }
        private void _ChangeImagesOfMember()
        {
            if (reservationVar.ChangeIamgeOfMember != 1)
            {
                btnShowInfoMember.Image = Image.FromFile(@"E:\Library\Picture\Show.png");
                reservationVar.ChangeIamgeOfMember = 1;
                dgvShowMember.Visible = true;
                btnShowInfoMember.Text = "HideInfo";
                dgvShowMember.DataSource = clsMembers.GetAllInfoMembersbyID(reservationVar._MemberID);

            }
            else
            {
                btnShowInfoMember.Image = Image.FromFile(@"E:\Library\Picture\Hide.png");
                reservationVar.ChangeIamgeOfMember = 0;
                dgvShowMember.DataSource = null;
                dgvShowMember.Visible = false;
                btnShowInfoMember.Text = "ShowInfo";
            }
        }
        private void _LoadDateBookAndMember()
        {
            numBookID.Value = clsBookCopies.Find(reservationVar._CopyID).BookID;
            numMemberID.Value = reservationVar._MemberID;
        }
        private void _LoadCopyIDForUpdate()
        {

            for(int i=0;i<cbCopies.Items.Count;i++)
            {
                if (cbCopies.Items[i].ToString() == reservationVar.OldCopyID.ToString())
                {
                    cbCopies.SelectedIndex = i;
                    return;
                }
            }
        }
        private void _LoadData()
        {
            btnShowInfoMember.Enabled = false;
            btnShowInfoBook.Enabled = false;
            if (reservationVar._mode == enMode.Add)
            {
                lblMode.Text = "ADD NEW RESERVATION";
                reservationVar._reservations = new clsReservations();
                return;
            }

            reservationVar._reservations = clsReservations.Find(reservationVar._ReservationID);
            if (reservationVar._reservations == null)
            {
                MessageBox.Show("This form will be closed because No Reservation with ID = " + reservationVar._ReservationID);
                this.Close();
                return;
            }

            lblMode.Text = "EDIT Reservation WITH ID= " + reservationVar._reservations.ReservationID;
            _LoadDateBookAndMember();
            dateReservationDate.Value = reservationVar._reservations.ReservationDate;
            btnShowInfoMember.Enabled = true;
            btnShowInfoBook.Enabled = true;
            pictureBox1.Image = Image.FromFile(@"E:\Library\Picture\correct.png");
            pictureBox2.Image = Image.FromFile(@"E:\Library\Picture\correct.png");
            _LoadCopyIDForUpdate();

        }

        private bool _IsReservationisFound(int CopyID)
        {
            return clsReservations.IsReservationisFound(CopyID);
        }
        private bool ValdsteDate(DateTime dateReservationDate)
        {
            return (dateReservationDate.Equals(DateTime.Now)) || (dateReservationDate < DateTime.Now);
        }
        private bool _Save()
        {


            reservationVar._reservations.ReservationID = reservationVar._ReservationID;
            reservationVar._reservations.MemberID = (int)numMemberID.Value;
            reservationVar._reservations.CopyID =Convert.ToInt32( cbCopies.Text);
            reservationVar._reservations.ReservationDate = Convert.ToDateTime(dateReservationDate.Value.ToShortDateString());

            if (ValdsteDate(reservationVar._reservations.ReservationDate))
            {
                MessageBox.Show("Error: Data Is not Saved Successfully Becuose The due date is equal or smaller " +
                    "than date Now", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (reservationVar._reservations.Save() && reservationVar.AvilaibleOfBook && reservationVar.MemberFound)
            {
                MessageBox.Show(" Reservation Saved Successfully With ID= " +
                    reservationVar._reservations.ReservationID, "Saved", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Reservation Is not Saved Successfully.", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return false;


            }

            reservationVar._mode = enMode.Update;
            lblMode.Text = "EDIT Reservation WITH ID = " + reservationVar._reservations.ReservationID;
            return true;


        }

        private void btnShowInfoBook_Click(object sender, EventArgs e)
        {
            _ChangeImagesOfBook();
        }

        private void btnShowInfoMember_Click(object sender, EventArgs e)
        {
            _ChangeImagesOfMember();
        }

        private void frmAddAndUpdateReseravtone_Load(object sender, EventArgs e)
        {
            _LoadData();
           
        }

        private void numMemberID_ValueChanged(object sender, EventArgs e)
        {
            _MemberIsFound();
        }

        private void numBookID_ValueChanged(object sender, EventArgs e)
        {

            _ChangeIamgeOfAvilaibleOfBooks();
        }

        private void cbCopies_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ChangeIamgeOfAvilaibleOfBookCopies();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_Save())
            this.Close();
        }

    }
}
