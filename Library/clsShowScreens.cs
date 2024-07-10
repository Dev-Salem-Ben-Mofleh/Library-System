using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using LibraryBusinessLayer;
namespace Library
{
    public class clsShowScreens
    {

       
        public static void ShowCirculationScreen(clsPersons persons)
        {

            frmCirculation frm = new frmCirculation(persons);
            frm.ShowDialog();
        }
        public static void ShowLogOutScreen()
        {

            LogIn frm = new LogIn();
            frm.ShowDialog();

        }
        public static void ShowAddBooksScreen(int BookId)
        {
            frmAddAndUpdateBooks frm = new frmAddAndUpdateBooks(BookId);
            frm.ShowDialog();
        }
        public static void ShowUpdateBooks(int BookID)
        {

            frmAddAndUpdateBooks frm = new frmAddAndUpdateBooks(BookID);
            frm.ShowDialog();
        }
        public static void ShowDetailsScreen(int BookID, string Title)
        {
            frmShowDetails frm = new frmShowDetails(BookID, Title);
            frm.ShowDialog();
        }
        public static void ShowDetailsAuthorsScreen(string AuthorName, int AuthorID)
        {
            frmAuthorDetails frm = new frmAuthorDetails(AuthorName, AuthorID);
            frm.ShowDialog();
        }
        public static void ShowAddAuthorScreen(int AuthorID)
        {
            frmAddAndUpdateAuthor frm = new frmAddAndUpdateAuthor(AuthorID);
            frm.ShowDialog();
        }
        public static void ShowUpdateAuthors(int AuthorID)
        {

            frmAddAndUpdateAuthor frm = new frmAddAndUpdateAuthor(AuthorID);
            frm.ShowDialog();
        }
        public static void ShowBooksGenerScreen(int GenerID,string GenerName)   
            {
             frmShowBooksGener frm = new frmShowBooksGener( GenerID, GenerName);
             frm.ShowDialog();
            }
        public static void ShowAddGenreScreen(int GenerID)
        {
            frmAddAndUpdateGener frm = new frmAddAndUpdateGener(GenerID);
            frm.ShowDialog();
        }
        public static void ShowUpdateGenres(int GenerID)
        {

            frmAddAndUpdateGener frm = new frmAddAndUpdateGener(GenerID);
            frm.ShowDialog();
        }
        public static void ShowAddMemberScreen(int MemberID, string Card)
        {
            frmAddAndUpdateMembers frm = new frmAddAndUpdateMembers(MemberID, Card);
            frm.ShowDialog();
        }
        public static void ShowUpdateMembers(int MemberID, string Card)
        {

            frmAddAndUpdateMembers frm = new frmAddAndUpdateMembers(MemberID, Card);
            frm.ShowDialog();
        }
        public static void ShowAddEmployeeScreen(int EmployeeID)
        {
            frmAddAndUpdateEmployees frm = new frmAddAndUpdateEmployees(EmployeeID);
            frm.ShowDialog();
        }
        public static void ShowUpdateEmployees(int EmployeeID)
        {

            frmAddAndUpdateEmployees frm = new frmAddAndUpdateEmployees(EmployeeID);
            frm.ShowDialog();
        }
        public static void ShowDetailsOfBorroings(int CopyID,int BorroingID,int BookID,int MemberID)
        {
            frmShowDetailsOfBorroingcs frm = new frmShowDetailsOfBorroingcs(BorroingID,BookID,MemberID, CopyID);
            frm.ShowDialog();
        }

        public static void ShowAddBorroingScreen(int BorroingID, int CopyID, int MemberID)
        {
            frmAddAndUpdateBorroing frm = new frmAddAndUpdateBorroing(BorroingID, CopyID, MemberID);
            frm.ShowDialog();
        }
        public static void ShowUpdateBorroings(int BorroingID, int CopyID, int MemberID)
        {
            frmAddAndUpdateBorroing frm = new frmAddAndUpdateBorroing(BorroingID, CopyID, MemberID);
            frm.ShowDialog();
        }

        

        public static void ShowAddReseravtone(int ReservationID,int MemberID, int CopyID)
        {
            frmAddAndUpdateReseravtone frm = new frmAddAndUpdateReseravtone(ReservationID, MemberID, CopyID);
            frm.ShowDialog();
        }
        public static void ShowDetailsOfFines(int MemberID, int BorroingID, int FineID)
        {

            frmShowDetailsFines frm = new frmShowDetailsFines(MemberID, BorroingID, FineID);
            frm.ShowDialog();
        }

        //forMember


     
        public static void ShowBookScreenForMember(clsPersons persons)
        {

            frmScreenBooksForMembers frm = new frmScreenBooksForMembers(persons);
            frm.ShowDialog();
        }
        public static void ShowReservationScreenForMember(clsPersons persons)
        {
            frmScreenResseravionForMember frm = new frmScreenResseravionForMember(persons);
            frm.ShowDialog();
        }
        public static void ShowBorrowingScreenForMember(clsPersons persons)
        {
            frmScreenBorroingforMember frm = new frmScreenBorroingforMember(persons);
            frm.ShowDialog();
        }
        public static void ShowFinesScreenForMember(clsPersons persons)
        {
            frmScreenFineForMember frm = new frmScreenFineForMember(persons);
            frm.ShowDialog();
        }
        public static void ShowProfileScreenForMember(clsPersons persons)
        {

            frmScreenProfile frm = new frmScreenProfile(persons);
            frm.ShowDialog();
        }

        public static void ShowAddBorrowingsForMember( int BookID , int MemberID)
        {
            frmAddAndUpdateBorroing frm = new frmAddAndUpdateBorroing(BookID, MemberID);
            frm.ShowDialog();
        }
        
    }


}
