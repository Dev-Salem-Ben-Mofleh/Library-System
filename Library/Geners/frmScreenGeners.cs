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
using static Library.frmScreenAuthor;

namespace Library
{
    public partial class frmScreenGeners : Form
    {
        clsPersons _persons;
        public frmScreenGeners(clsPersons persons)
        {
            _persons = persons;
            InitializeComponent();
        }

        stGenerScreenVar GenerScreenVar;

        

        public struct stGenerScreenVar
        {
            public int SearchGenerID;
            public string SearchGenerName;
        }
        private DataTable _dataTable = new DataTable();
        private DataView _dataView = new DataView();
        private void _LoadAllDataFromDatabase()
        {
            _dataTable = clsGeners.GetAllGeners();
            _dataView = _dataTable.DefaultView;
            dgvListOfGeners.DataSource = _dataView;
        }
        private void _SerchGener()
        {
            if (txtSearchGeners.Text == "")
            {
                _LoadAllDataFromDatabase();
                return;
            }

            switch (cbSearchGener.Text.ToLower())
            {
                case "generid":
                    if (int.TryParse((txtSearchGeners.Text), out int Generid))
                    {
                        GenerScreenVar.SearchGenerID = Generid;
                        _dataView.RowFilter = $"GenerID={GenerScreenVar.SearchGenerID}";
                        dgvListOfGeners.Refresh();
                    }
                    else
                    {
                        GenerScreenVar.SearchGenerID = 0;
                        _dataView.RowFilter = $"GenerID={GenerScreenVar.SearchGenerID}";
                        dgvListOfGeners.Refresh();
                    }
                    break;


                case "genername":
                    GenerScreenVar.SearchGenerName = txtSearchGeners.Text;
                    _dataView.RowFilter = $" GenerName like '{GenerScreenVar.SearchGenerName}%' ";
                    dgvListOfGeners.Refresh();
                    break;

                default:
                    _LoadAllDataFromDatabase();
                    break;
            }
        }
        private void _DeleteGener()
        {
            if (MessageBox.Show("Are you sure you want to delete Gener ["
                + dgvListOfGeners.CurrentRow.Cells[0].Value + "]", "Confirm Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsGeners.DeleteGener((int)dgvListOfGeners.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Gener Deleted Successfully.", "Deleted",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadAllDataFromDatabase();
                }

                else
                    MessageBox.Show("Gener is not deleted,Because he has Books", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void frmScreenGeners_Load(object sender, EventArgs e)
        {
            cbSearchGener.SelectedIndex = 0;
            _LoadAllDataFromDatabase();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowAddGenreScreen(-1);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowUpdateGenres((int)dgvListOfGeners.CurrentRow.Cells[0].Value);
        }

        private void btnShwoDetails_Click(object sender, EventArgs e)
        {
            clsShowScreens.ShowBooksGenerScreen((int)dgvListOfGeners.CurrentRow.Cells[0].Value,
                dgvListOfGeners.CurrentRow.Cells[1].Value.ToString());
                
        }


        private void cbSearchGener_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadAllDataFromDatabase();
        }

        private void txtSearchGeners_TextChanged(object sender, EventArgs e)
        {
            _SerchGener();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_persons.Permissions == "Admin")
            {
                _DeleteGener();

            }
            else
                MessageBox.Show("You do not have Permission to delete.", "Error", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
        }
    }
}
