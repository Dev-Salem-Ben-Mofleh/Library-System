using LibraryBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static Library.frmMainScreen;

namespace Library
{
    public partial class frmMainHome : Form
    {
        clsPersons _persons;
        LogIn _Login;
        byte _Permission;
        public frmMainHome(clsPersons persons, LogIn logIn, byte Permission)
        {
            _persons = persons;
            _Permission = Permission;
            _Login = logIn;
            InitializeComponent();
        }
        public void LoadForm(Object from)
        {
            if (this.paMain1.Controls.Count > 0)
                this.paMain1.Controls.RemoveAt(0);
            Form f = from as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.paMain1.Controls.Add(f);
            this.paMain1.Tag = f;
            f.Show();
        }
        private void _LoadInfoForUser()
        {
            lblName.Text = _persons.FirstName + " " + _persons.LastName;
            lblPermissson.Text = _persons.Permissions;
            lblEmail.Text = _persons.Email;
        }

        private void frmMainHome_Load(object sender, EventArgs e)
        {
            _Login.Hide();
            LoadForm(new frmMainScreen());

            _LoadInfoForUser();
        }


        private void btnbooks_Click_1(object sender, EventArgs e)
        {
            LoadForm(new frmScreenBooks(_persons));
        }

        private void btnArthur_Click_1(object sender, EventArgs e)
        {
            LoadForm(new frmScreenAuthor(_persons));

        }

        private void btnMembers_Click_1(object sender, EventArgs e)
        {
            LoadForm(new frmScreenMembers(_persons));

        }

        private void btnEmployees_Click_1(object sender, EventArgs e)
        {
            if (_Permission == 1)
            {
                LoadForm(new frmScreenEmployeess(_persons));
            }
            else
                MessageBox.Show("You do not have Permission to Enter here.", "Error", MessageBoxButtons.OK
                                        , MessageBoxIcon.Error);

        }

        private void btnCirculations_Click_1(object sender, EventArgs e)
        {
            LoadForm(new frmCirculation(_persons));

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            _Login.Show();
            this.Close();
        }

        private void btnGeners_Click(object sender, EventArgs e)
        {
            LoadForm(new frmScreenGeners(_persons));

        }

    }
}
