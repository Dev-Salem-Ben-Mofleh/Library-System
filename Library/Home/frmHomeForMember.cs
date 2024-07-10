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
using static Library.frmHomeForMember;
using static Library.frmMainScreen;

namespace Library
{
    public partial class frmHomeForMember : Form
    {
        clsPersons _persons;
        LogIn _Login;
        public frmHomeForMember(clsPersons persons, LogIn logIn)
        {
            _persons = persons;
            _Login = logIn;
            InitializeComponent();
        }
        public struct stHomeScreen
        {
            public DateTime dateTime;
            public int TimeCounter;

        }
        stHomeScreen homeScreen;
      
        
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


        private void btnbooks_Click(object sender, EventArgs e)
        {
            LoadForm(new frmScreenBooksForMembers(_persons));
        }

        private void btnBorroing_Click(object sender, EventArgs e)
        {
            LoadForm(new frmScreenBorroingforMember(_persons));
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            LoadForm(new frmScreenResseravionForMember(_persons));
        }

        private void btnFine_Click(object sender, EventArgs e)
        {
            LoadForm(new frmScreenFineForMember(_persons));
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            LoadForm(new frmScreenProfile(_persons));

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            _Login.Show();
            this.Close();

        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            _Login.Hide();
            _LoadInfoForUser();
            LoadForm(new frmScreenBooksForMembers(_persons));


        }


    }
}
