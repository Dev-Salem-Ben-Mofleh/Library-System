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
    public partial class frmScreenFineForMember : Form
    {
        clsPersons _persons;
        public frmScreenFineForMember(clsPersons persons)
        {
            _persons = persons;
            MemberID = clsMembers.FindByPersonID(_persons.PersonID).MemberID;
            
            InitializeComponent();
        }

        clsFines _fines;
        int MemberID;
        int SearchFineID;
        private DataTable _dataTable = new DataTable();
        private DataView _dataView = new DataView();

        private void _LoadDataFromDatabase()
        {
            _dataTable = clsFines.GetAllFines();
            _dataView = _dataTable.DefaultView;
            dgvListOFFines.DataSource = _dataView;
        }

        private bool _UbpdateFines()
        {
            _fines = clsFines.Find((int)dgvListOFFines.CurrentRow.Cells[0].Value);
            if (_fines == null)
                return false;

            if (_fines.PaymentStatus == true)
                return true;

            _fines.BorrowingRecordID = (int)dgvListOFFines.CurrentRow.Cells[2].Value;
            _fines.MemberID = (int)dgvListOFFines.CurrentRow.Cells[1].Value;
            _fines.NumberOfLateDays = Convert.ToByte(dgvListOFFines.CurrentRow.Cells[3].Value);
            _fines.FineAmount = (decimal)dgvListOFFines.CurrentRow.Cells[4].Value;
            _fines.PaymentStatus = true;

            if (_fines.Save())
            {
                // MessageBox.Show("Data Saved Successfully.", "Successfull", MessageBoxButtons.OK
                //   , MessageBoxIcon.Information);
                _LoadDataFromDatabase();
                return true;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK
                   , MessageBoxIcon.Error);
            return false;

        }
        private void _SerchFines()
        {
            if (txtSearchFine.Text == "")
            {
                _LoadDataFromDatabase();
                return;
            }

            if (int.TryParse((txtSearchFine.Text), out int FineID))
            {
               SearchFineID = FineID;
                _dataView.RowFilter = $"FineID={SearchFineID}";
                dgvListOFFines.Refresh();
                return;
            }
            else//
            {
                SearchFineID = 0;
                _dataView.RowFilter = $"FineID={SearchFineID}";
                dgvListOFFines.Refresh();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowDetailsOfFines((int)dgvListOFFines.CurrentRow.Cells[1].Value,
               (int)dgvListOFFines.CurrentRow.Cells[2].Value,
               (int)dgvListOFFines.CurrentRow.Cells[0].Value);
        }

        private void btnbooks_Click(object sender, EventArgs e)
        {
            this.Hide();
            clsShowScreens.ShowBookScreenForMember(_persons);

        }

        private void frmScreenFineForMember_Load(object sender, EventArgs e)
        {
            _LoadDataFromDatabase();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _UbpdateFines();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            _UbpdateFines();
        }

        private void txtSearchFine_TextChanged(object sender, EventArgs e)
        {
            _SerchFines();
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
    }
}
