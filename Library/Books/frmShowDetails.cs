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
    public partial class frmShowDetails : Form
    {
        int _BookID;
        string _Title;
        public frmShowDetails(int bookID,string Title)
        {
            InitializeComponent();
            _BookID = bookID;
            _Title= Title;
        }
        private  void _GetDetailsOfBook() 
        {
             
            DataTable dt = clsBookCopies.GetAllBookCopiesByBookID(_BookID);
            foreach (DataRow Rows in dt.Rows)
            {
                DataGridViewRow row = new DataGridViewRow();

                dgvListOfBooks.Rows.Add(row);
                int RowIndex = dgvListOfBooks.Rows.Count- 1;
                int startCokumnIndex = 0;
                int endCokumnIndex = 1;
                for(int i = startCokumnIndex;i <= endCokumnIndex; i++)
                {
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    if (i == 0)
                    { 
                        cell.Value = Rows["CopyID"];
                        dgvListOfBooks[i, RowIndex] = cell; 
                    }
                    else
                    {
                        if ((bool)Rows["AvailabilityStatus"] == false)
                        {
                            cell.Value = "Available";
                            dgvListOfBooks[i, RowIndex] = cell;

                        }
                        else
                        {
                            cell.Value = "UnAvailable";
                            dgvListOfBooks[i, RowIndex] = cell;

                        }


                    }


                }
                

            }
        }
        
        private void _LoadData()
        {
            lblBookID.Text = _BookID.ToString();
            lblBookName.Text = _Title;
        }
        private void frmShowDetails_Load(object sender, EventArgs e)
        {
            _LoadData();
            _GetDetailsOfBook();
        }
    }
}
