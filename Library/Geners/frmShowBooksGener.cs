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
    public partial class frmShowBooksGener : Form
    {
        int _GenerID;
        string _GenerName;
        public frmShowBooksGener(int GenerID,string GenerName)
        {
            _GenerID = GenerID;
            _GenerName = GenerName;
            InitializeComponent();
        }

        private void _LoadInfo()
        {
            lblGenreID.Text = _GenerID.ToString();
            lblGenerName.Text = _GenerName;
        }

        private void _LoadDatafromDatabase()
        {
            dgvListOfGeners.DataSource = clsBooks.GetAllInfoBooksForGener(_GenerID);
        }
        private void frmShowBooksGener_Load(object sender, EventArgs e)
        {
            _LoadInfo();
            _LoadDatafromDatabase();
        }
    }
}
