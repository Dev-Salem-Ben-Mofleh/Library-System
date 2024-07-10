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
using static Library.frmHomeForMember;
using static Library.frmMainScreen;

namespace Library
{
    public partial class frmMainScreen : Form
    {
        public frmMainScreen()
        {
            InitializeComponent();
        }

        public struct stMainScreen
        {
            public DateTime dateTime ;
            public int TimeCounter;
            public int CountBooks;
            public int CountAuthors;
            public int CountMembers;
            public int CountEmployeess;

        }
        stMainScreen mainScreen;

        private void _TheTime()
        {

            mainScreen.TimeCounter++;
            mainScreen.dateTime = DateTime.Now;
            mainScreen.dateTime = mainScreen.dateTime.AddDays(mainScreen.TimeCounter);
            lblTime.Text = mainScreen.dateTime.ToString("hh:mm:ss");
        }
        private void _TheDate()
        {
            mainScreen.dateTime = DateTime.Now;
            lblDate.Text = mainScreen.dateTime.Date.ToString("dddd,MMMM,yyyy");
        }
        private void _LoadCountes()
        {
            mainScreen.CountBooks = clsBooks.CountBooks();
            mainScreen.CountAuthors = clsAuthors.CountAuthors();
            mainScreen.CountMembers = clsMembers.CountMembers();
            mainScreen.CountEmployeess = clsEmployees.CountEmployees();

            lblNumberOfBooks.Text = mainScreen.CountBooks.ToString();
            lblNumberOfAuthors.Text = mainScreen.CountAuthors.ToString();
            lblNumberOfMembers.Text = mainScreen.CountMembers.ToString();
            lblEmployeed.Text= mainScreen.CountEmployeess.ToString();
        }



        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            _TheDate();
            _LoadCountes();
        }
  
        private void timerTime_Tick(object sender, EventArgs e)
        
        
        {
            _TheTime();
        }



       
    }
}
