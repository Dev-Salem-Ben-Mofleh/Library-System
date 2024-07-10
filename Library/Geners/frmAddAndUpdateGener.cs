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
using System.Xml.Linq;

namespace Library
{
    public partial class frmAddAndUpdateGener : Form
    {
        public enum enMode { Add = 0, Update = 1 };
        private enMode _mode;
        int _GenreID;
        clsGeners _Genre;
        public frmAddAndUpdateGener(int GenreID)
        {
            _GenreID = GenreID;

            if (_GenreID == -1)
                _mode = enMode.Add;
            else
                _mode = enMode.Update;
            InitializeComponent();
        }
        private void _LoadData()
        {
            if (_mode == enMode.Add)
            {
                lblMode.Text = "ADD NEW GENRE";
                _Genre = new clsGeners();
                return;
            }

            _Genre = clsGeners.Find(_GenreID);
            if (_Genre == null)
            {
                MessageBox.Show("This form will be closed because No Genre with ID = " + _GenreID,
                    "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblMode.Text = "EDIT GENRE  ";
            txtGenerID.Text = _Genre.GenerID.ToString();
            txtNameGener.Text = _Genre.GenerName;
           
        }

        private bool _Save()
        {

            _Genre.GenerName = txtNameGener.Text;



            if (_Genre.Save())
            {
                MessageBox.Show("Gener Saved Successfully With ID = " + _Genre.GenerID, "Saved", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error: Gener Is not Saved Successfully.", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                return false;
            }
            _mode = enMode.Update;
            lblMode.Text = "EDIT GENRE WITH ID = " + _Genre.GenerID;
            txtGenerID.Text = _Genre.GenerID.ToString();
            return true;


        }

        private void frmAddAndUpdateGener_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsValidaited.ValditedAddAndUpdateGener(errorProvider1, txtNameGener))
            {
                if (_Save())
                    this.Close();
            }
           
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
