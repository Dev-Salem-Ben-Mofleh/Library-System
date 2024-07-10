using LibraryBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class frmAddAndUpdateAuthor : Form
    {
        public enum enMode { Add = 0, Update = 1 };
        private enMode _mode;
        int _AuthorID;
        clsAuthors _Authors;
        public frmAddAndUpdateAuthor(int AuthorID)
        {
            _AuthorID = AuthorID;

            if (_AuthorID == -1)
                _mode = enMode.Add;
            else
                _mode = enMode.Update;
            InitializeComponent();
        }
        private void _FillCbEducation()
        {
            DataTable dt = clsEducations.GetAllEducations();
            foreach (DataRow Row in dt.Rows)
            {
                cbEducation.Items.Add(Row["EducationName"]);
            }
        }

        private void _LoadData()
        {
            _FillCbEducation();
            cbEducation.SelectedIndex = 0;
            if (_mode == enMode.Add)
            {
                lblMode.Text = "ADD NEW AUTHOR";
                _Authors = new clsAuthors();
                return;
            }

            _Authors = clsAuthors.Find(_AuthorID);
            if (_Authors == null)
            {
                MessageBox.Show("This form will be closed because No Author with ID = " + _Authors,
                    "Confirm",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblMode.Text = "EDIT Author  ";
            txtAuthorID.Text = _Authors.AuthorID.ToString();
            txtName.Text = _Authors.AuthorName;
            if (_Authors.Bio != "")
            {
                txtBio.Text = _Authors.Bio;
            }
            cbEducation.SelectedIndex = cbEducation.FindString(clsEducations.Find(_Authors.EducationID).EducationName);

        }

        private bool _Save()
        {

            _Authors.EducationID = clsEducations.Find(cbEducation.Text).EducationID;
            _Authors.AuthorName = txtName.Text;

            if (txtBio.Text != "")
                _Authors.Bio = txtBio.Text;
            else
                _Authors .Bio= "";

            if (_Authors.Save())
            {
                MessageBox.Show("Author Saved Successfully With  ID= " + _Authors.AuthorID + " .", "Saved", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Author Is not Saved Successfully.", "Error",
                    MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return false;

            }

            _mode = enMode.Update;
            lblMode.Text = "EDIT AUTHOR WITH ID = " + _Authors.AuthorID;
            txtAuthorID.Text = _Authors.AuthorID.ToString();
            return true;


        }

        private void frmAddAndUpdateAuthor_Load(object sender, EventArgs e)
        {
            _LoadData();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsValidaited.ValditedAddAndUpdateAuthor(errorProvider1, txtName)) 
            {
               if( _Save())
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }

}
