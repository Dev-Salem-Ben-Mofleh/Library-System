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
    public partial class frmAuthorDetails : Form
    {
        string _AuthorName;
        int _AuthorId;
        public frmAuthorDetails( string AuthorName, int authorId)
        {
            _AuthorName = AuthorName;
            InitializeComponent();
            _AuthorId = authorId;
        }
        private void _LaodInfoAuthor()
        {
            lblAuthorID.Text = _AuthorId.ToString();
            lblAuthorName.Text= _AuthorName;
        }
        private void _LoadDataFromDatabase()
        {
            dgvListOfAuthorss.DataSource = clsBooks.GetAllInfoBookByAuthorName(_AuthorName);
        }
        private void frmAuthorDetails_Load(object sender, EventArgs e)
        {
            _LoadDataFromDatabase();
            _LaodInfoAuthor();
        }
    }
}
