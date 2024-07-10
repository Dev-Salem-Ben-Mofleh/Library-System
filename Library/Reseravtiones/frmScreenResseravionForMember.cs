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
    public partial class frmScreenResseravionForMember : Form
    {
        clsPersons _persons;
        public frmScreenResseravionForMember(clsPersons persons)
        {
            _persons = persons;
            MemberID = clsMembers.FindByPersonID(_persons.PersonID).MemberID;
            InitializeComponent();
        }
        int SearccReservationID;
        int MemberID;
        private DataTable _dataTable = new DataTable();
        private DataView _dataView = new DataView();

        private void _LoadDataFromDatabase()
        {
            _dataTable = clsReservations.GetAllReservations();
            _dataView = _dataTable.DefaultView;
            dgvListOfReservations.DataSource = _dataView;
        }
        private void _SerchReservationing()
        {
            if (txtSearchReservationID.Text == "")
            {
                _LoadDataFromDatabase();
                return;
            }

            if (int.TryParse((txtSearchReservationID.Text), out int ReaervationID))
            {
                SearccReservationID = ReaervationID;
                _dataView.RowFilter = $"ReservationID={SearccReservationID}";
                dgvListOfReservations.Refresh();
                return;
            }
            else
            {
                SearccReservationID = 0;
                _dataView.RowFilter = $"ReservationID={SearccReservationID}";
                dgvListOfReservations.Refresh();
            }
        }

        private void btnAddResravtion_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowAddReseravtone(-1, -1, -1);
        }

        private void frmScreenResseravionForMember_Load(object sender, EventArgs e)
        {
            _LoadDataFromDatabase();
        }

        private void txtSearchReservationID_TextChanged(object sender, EventArgs e)
        {
            _SerchReservationing();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
