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
using static Library.frmCirculation;
using static Library.frmScreenAuthor;
using static Library.frmScreenMembers;

namespace Library
{
    public partial class frmCirculation : Form
    {
        clsPersons _persons;

        public frmCirculation(clsPersons persons )
        {
            _persons = persons;
            InitializeComponent();
        }
        clsFines _fines;
        clsBookCopies _BookCopies;
        clsBorrowingRecords _borrowingRecords;
        stCirculationScreenVar CirculationScreenVar;
        stFineScreenVar fineScreenVar;
        public struct stCirculationScreenVar
        {
            public int SearchBorroingID;
            public int SearccReservationID;
            public int SearchFineID;
            public int CopyID;
       

        }
        public struct stFineScreenVar
        {
            public decimal FineAmount;
            public int FineNumberOfDays;
        }
        private DataTable _dataTable = new DataTable();
        private DataView _dataView = new DataView();
        private void _LoadAllDataFromDatabaseForBorrowing()
        {
            _dataTable = clsBorrowingRecords.GetAllBorrowingRecord();
            _dataView = _dataTable.DefaultView;
            dgvListOfBorroings.DataSource = _dataView;
        }
        private void _LoadAllDataFromDatabaseForReservation()
        {
            _dataTable = clsReservations.GetAllReservations();
            _dataView = _dataTable.DefaultView;
            dgvListOfReservation.DataSource = _dataView;
        }
        private void _LoadAllDataFromDatabaseForFine()
        {
            _dataTable = clsFines.GetAllFines();
            _dataView = _dataTable.DefaultView;
            dgvListOFFines.DataSource = _dataView;
        }
        private byte _GetPermision()
        {
            if (_persons.Permissions.ToLower() == "admin")
                return 1;
            else
                return 0;
        }
        private void _IndexTabChange(Guna2TabControl tabControl)
        {
            if (tabControl.SelectedTab.Tag.ToString()=="B")
                _LoadDataFromDatabase(tabIssue.Tag.ToString());
            else
            if (tabControl.SelectedTab.Tag.ToString() == "R")
                _LoadDataFromDatabase(tabReservation.Tag.ToString());
            else
            if (tabControl.SelectedTab.Tag.ToString() == "F")
                _LoadDataFromDatabase(tabFine.Tag.ToString());


        }
        private void _LoadDataFromDatabase(string Tag)
        {
            switch(Tag)
            {
                case "B":
                    _LoadAllDataFromDatabaseForBorrowing();
                    break;
                case "R":
                    _LoadAllDataFromDatabaseForReservation();
                        break;
                case "F":
                    _LoadAllDataFromDatabaseForFine();
                    break;
                default:
                    _LoadAllDataFromDatabaseForBorrowing();
                    break;

            }
        }
        //Borrowing;

        private void _SerchBorrowing()
        {
            if (txtSSearchBorroing.Text == "")
            {
                _LoadDataFromDatabase(tabIssue.Tag.ToString());
                return;
            }

            if (int.TryParse((txtSSearchBorroing.Text), out int BorrowingID))
            {
                CirculationScreenVar.SearchBorroingID = BorrowingID;
                _dataView.RowFilter = $"BorrowingRecordID={CirculationScreenVar.SearchBorroingID}";
                dgvListOfBorroings.Refresh();
                return;
            }
            else
            {

                CirculationScreenVar.SearchBorroingID = 0;
                _dataView.RowFilter = $"BorrowingRecordID={CirculationScreenVar.SearchBorroingID}";
                dgvListOfBorroings.Refresh();
            }
        }
        private bool _SaveFines()
        {
            _fines = new clsFines();
            _fines.BorrowingRecordID = (int)dgvListOfBorroings.CurrentRow.Cells[0].Value;
            _fines.MemberID = (int)dgvListOfBorroings.CurrentRow.Cells[1].Value;
            if(fineScreenVar.FineAmount<=0)
            {
                _fines.FineAmount =0;
                _fines.PaymentStatus = true;
                _fines.NumberOfLateDays =0;

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
           _BookCopies= clsBookCopies.Find(CopyID);
            if (_BookCopies == null)
                return;

            CirculationScreenVar.CopyID = CopyID;
            _BookCopies.AvailabilityStatus = false;

            if (_BookCopies.Save())
            {
                // MessageBox.Sshow("Data Saved Successfully.", "Successfull", MessageBoxButtons.OK
                //  , MessageBoxIcon.Information);
                return ;
            }

            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK
                   , MessageBoxIcon.Error);
        }

        private void _FineCalculate()
        {
            fineScreenVar.FineAmount= clsSetting.CalculateFines(ref fineScreenVar.FineNumberOfDays);

        }
        
        private void _ReturnBook()
        {
            int CopyID;
            CopyID = (int)dgvListOfBorroings.CurrentRow.Cells[2].Value;
            _borrowingRecords = clsBorrowingRecords.Find((int)dgvListOfBorroings.CurrentRow.Cells[0].Value);
           
           
            if (_borrowingRecords.ActualReturnDate!= "") 
            {
                MessageBox.Show("This Record is Aleardy Retruned","Confirm",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to Return this book ","Confirm ",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                fineScreenVar.FineNumberOfDays = clsBorrowingRecords.ReturnBook((DateTime)dgvListOfBorroings.CurrentRow.Cells[3].Value,
                    DateTime.Now);
                _FineCalculate();
               if( _SaveBorroingRecord() && _SaveFines())
                {
                    MessageBox.Show("Returning Record Saved successfully Retruned " +
                    "You have to Check Table Fines ,if the member has fine or not with RecordFineID = "+
                    _fines.FineID, "Confirm",
           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadDataFromDatabase(tabIssue.Tag.ToString());
                    _UpdateCopies(CopyID);
                }
            }
        }

        private void _DeleteBorroing()
        {
            int FineID = -1;
            if (MessageBox.Show("Are you sure you want to delete Borroing Record ["
                + dgvListOfBorroings.CurrentRow.Cells[0].Value + "]", "Confirm Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)

            {
                if (clsFines.IsFinePaied(ref FineID, (int)dgvListOfBorroings.CurrentRow.Cells[0].Value))
                    clsFines.DeleteFine(FineID);
                

                //Perform Delele and refresh
                if (clsBorrowingRecords.DeleteBorrowingRecord((int)dgvListOfBorroings.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Borroing Record Deleted Successfully."
                        , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadDataFromDatabase(tabIssue.Tag.ToString());
                    _UpdateCopies(CirculationScreenVar.CopyID);

                }

                else
                    MessageBox.Show("Borroing  Record is not deleted. becuose this record has a fine not paid yet"
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Reservation;
        private void _SerchReservationing()
        {
            if (txtSearchReservation.Text == "")
            {
                _LoadDataFromDatabase(tabReservation.Tag.ToString());
                return;
            }

            if (int.TryParse((txtSearchReservation.Text), out int ReaervationID))
            {
                CirculationScreenVar.SearccReservationID = ReaervationID;
                _dataView.RowFilter = $"ReservationID={CirculationScreenVar.SearccReservationID}";
                dgvListOfReservation.Refresh();
                return;
            }
            else
            {
                CirculationScreenVar.SearccReservationID = 0;
                _dataView.RowFilter = $"ReservationID={CirculationScreenVar.SearccReservationID}";
                dgvListOfReservation.Refresh();
            }
        }
        private void _DeleteResevatiom()
        {
            if (MessageBox.Show("Are you sure you want to delete Reservation Record ["
                + dgvListOfReservation.CurrentRow.Cells[0].Value + "]", "Confirm Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)

            {
            

                //Perform Delele and refresh
                if (clsReservations.DeleteReservation((int)dgvListOfReservation.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Reservation Record Deleted Successfully."
                        , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadDataFromDatabase(tabReservation.Tag.ToString());
                }

                else
                    MessageBox.Show("Ressrvation is not deleted."
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Fines;
        private bool _UbpdateFines()
        {
            _fines = clsFines.Find((int)dgvListOFFines.CurrentRow.Cells[0].Value);
            if (_fines == null)
                return false;

            if (_fines.PaymentStatus == true)
                return true;

            _fines.BorrowingRecordID = (int)dgvListOFFines.CurrentRow.Cells[2].Value;
            _fines.MemberID = (int)dgvListOFFines.CurrentRow.Cells[1].Value;
            _fines.NumberOfLateDays =Convert.ToByte( dgvListOFFines.CurrentRow.Cells[3].Value);
            _fines.FineAmount = (decimal)dgvListOFFines.CurrentRow.Cells[4].Value;
            _fines.PaymentStatus = true;

            if (_fines.Save())
            {
                // MessageBox.Show("Data Saved Successfully.", "Successfull", MessageBoxButtons.OK
                //   , MessageBoxIcon.Information);
                _LoadDataFromDatabase(tabFine.Tag.ToString());
                return true;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK
                   , MessageBoxIcon.Error);
            return false;

        }

        private void _SerchFines()
        {
            if (txtsearchFines.Text == "")
            {
                _LoadDataFromDatabase(tabFine.Tag.ToString());
                return;
            }

            if (int.TryParse((txtsearchFines.Text), out int FineID))
            {
                CirculationScreenVar.SearchFineID = FineID;
                _dataView.RowFilter = $"FineID={CirculationScreenVar.SearchFineID}";
                dgvListOFFines.Refresh();
                return;
            }
            else
            {
                CirculationScreenVar.SearchFineID = 0;
                _dataView.RowFilter = $"FineID={CirculationScreenVar.SearchFineID}";
                dgvListOFFines.Refresh();
            }
        }
        private bool _IsFinePaid()
        {
            clsFines Fine= clsFines.Find((int)dgvListOFFines.CurrentRow.Cells[0].Value);

            if (Fine != null)
            {
                if (Fine.PaymentStatus)
                    return false;
                else
                    return true;
            }
            return false;

        }
        private void _DeleteFines()
        {
            if (MessageBox.Show("Are you sure you want to delete Fine Record ["
                + dgvListOFFines.CurrentRow.Cells[0].Value + "]", "Confirm Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)

            {

                if(_IsFinePaid())
                {
                    MessageBox.Show("Fine Record can not Deleted Successfully, because not paid yet"
                        , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Perform Delele and refresh
                if (clsFines.DeleteFine((int)dgvListOFFines.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Fine Record Deleted Successfully."
                        , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadDataFromDatabase(tabFine.Tag.ToString());

                }

                else
                    MessageBox.Show("Fine is not deleted."
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowDetailsOfBorroings((int)dgvListOfBorroings.CurrentRow.Cells[2].Value,
                (int)dgvListOfBorroings.CurrentRow.Cells[0].Value,
               clsBookCopies.Find((int)dgvListOfBorroings.CurrentRow.Cells[2].Value).BookID ,
               (int)dgvListOfBorroings.CurrentRow.Cells[1].Value);
        }

        private void btnAddResravtion_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowAddReseravtone(-1, -1, -1);
        }

        private void btnEditResravtion_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowAddReseravtone((int)dgvListOfReservation.CurrentRow.Cells[0].Value,
                (int)dgvListOfReservation.CurrentRow.Cells[1].Value,
                (int)dgvListOfReservation.CurrentRow.Cells[2].Value);

        }

        private void btnAddNew_Click_1(object sender, EventArgs e)
        {
            clsShowScreens.ShowAddBorroingScreen(-1,-1,-1);
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            clsShowScreens.ShowUpdateBorroings((int)dgvListOfBorroings.CurrentRow.Cells[0].Value
                , (int)dgvListOfBorroings.CurrentRow.Cells[2].Value, 
                (int)dgvListOfBorroings.CurrentRow.Cells[1].Value);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowDetailsOfFines((int)dgvListOFFines.CurrentRow.Cells[1].Value,
               (int)dgvListOFFines.CurrentRow.Cells[2].Value,
               (int)dgvListOFFines.CurrentRow.Cells[0].Value);
        }

        private void frmCirculation_Load(object sender, EventArgs e)
        {
            _LoadDataFromDatabase(tabIssue.Tag.ToString());
        }

        private void txtSSearchBorroing_TextChanged_1(object sender, EventArgs e)
        {
            _SerchBorrowing();

        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ReturnBook();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            _ReturnBook();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _DeleteBorroing();
        }

        

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (_persons.Permissions == "Admin")
            {
                _DeleteBorroing();

            }
            else
                MessageBox.Show("You do not have Permission to delete.", "Error", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
        }

        private void gdvReseravtionList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TapCirculation_SelectedIndexChanged(object sender, EventArgs e)
        {
            _IndexTabChange((Guna2TabControl)sender);
        }

        private void btnDeleteResravtion_Click(object sender, EventArgs e)
        {
            if (_persons.Permissions == "Admin")
            {
                _DeleteResevatiom();

            }
            else
                MessageBox.Show("You do not have Permission to delete.", "Error", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
        }

        private void txtSearchReservation_TextChanged(object sender, EventArgs e)
        {
            _SerchReservationing();
        }

        private void btnDeleteFine_Click(object sender, EventArgs e)
        {
            if (_persons.Permissions == "Admin")
            {
                _DeleteFines();

            }
            else
                MessageBox.Show("You do not have Permission to delete.", "Error", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
        }

        private void txtsearchFines_TextChanged(object sender, EventArgs e)
        {
            _SerchFines();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            _UbpdateFines();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _UbpdateFines();

        }


    }
}