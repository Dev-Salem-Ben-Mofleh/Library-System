using LibraryDataAccessLayer;
using System;
using System.Data;

namespace LibraryBusinessLayer
{
    public class clsBooks
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

            public int BookID { get; set; }
            public string Tital { get; set; }
            public string ISBN { get; set; }
            public DateTime PublicationDate { get; set; }
            public string AdditionalDetails { get; set; }
            public int AuthorID { get; set; }
            public int GenreID { get; set; }
            public decimal PriceBorrwoing { get; set; }


        public clsBooks()
        {
            this.BookID = -1;
            this.Tital = "";
            this.ISBN = "";
            this.PublicationDate = DateTime.Now;
            this.AdditionalDetails = "";
            this.AuthorID = -1;
            this.GenreID = -1;
            this.PriceBorrwoing = 0;
            Mode = enMode.AddNew;

        }
        private clsBooks(int BookID, string Tital, string ISBN, DateTime PublicationDate,
   string AdditionalDetails, int AuthorID, int GenreID, decimal PriceBorrwoing)

        {
            this.BookID = BookID;
            this.Tital = Tital;
            this.ISBN = ISBN;
            this.PublicationDate = PublicationDate;
            this.AdditionalDetails = AdditionalDetails;
            this.AuthorID = AuthorID;
            this.GenreID = GenreID;
            this.PriceBorrwoing = PriceBorrwoing;



            Mode = enMode.Update;

        }
        

        private bool _AddNewBook()
        {
            //call DataAccess Layer 

           this.BookID = clsDataBooks.AddNewBook(this.Tital, this.ISBN, this.PublicationDate,
            this.AdditionalDetails, this.AuthorID, this.GenreID,this.PriceBorrwoing);
            
            return (this.BookID != -1);
        }

        private bool _UpdateBook()
        {
            //call DataAccess Layer 

            return clsDataBooks.UpdateBook(this.BookID,this.Tital, this.ISBN, this.PublicationDate,
            this.AdditionalDetails, this.AuthorID, this.GenreID, this.PriceBorrwoing);

        }

        public static clsBooks Find(int ID)
        {
            string Tital = "";
            string ISBN = "";
            DateTime PublicationDate = DateTime.Now;
            string AdditionalDetails = "";
            int AuthorID = -1;
            int GenreID = -1;
            decimal PriceBorrwoing = 0;

            if (clsDataBooks.GetBookInfoByID(ID, ref Tital, ref ISBN, ref PublicationDate,
           ref AdditionalDetails, ref AuthorID, ref GenreID,ref PriceBorrwoing))

                return new clsBooks(ID,  Tital,  ISBN,  PublicationDate,
            AdditionalDetails,  AuthorID,  GenreID, PriceBorrwoing);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBook())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateBook();

            }




            return false;
        }

        public static DataTable GetAllBooks()
        {
            return clsDataBooks.GetAllBooks();

        }
        public static DataTable GetAllInfoBooks()
        {
            return clsDataBooks.GetAllInfoBooks();

        }

        public static DataTable GetAllInfoBooksForGener(int GenerID)
        {
            return clsDataBooks.GetAllInfoBooksForGener(GenerID);

        }
        public static DataTable GetAllInfoBookByID(int BookID)
        
        
        {
            return clsDataBooks.GetAllInfoBookByID(BookID);

        }

        public static DataTable GetAllInfoBookByIDForShow(int BookID)
        {
            return clsDataBooks.GetAllInfoBookByIDForShow(BookID);

        }
        

        

        public static DataTable GetAllInfoBookByAuthorName(string AuthorName)
        {
            return clsDataBooks.GetAllInfoBookByAuthorName(AuthorName);

        }



        public static bool DeleteBook(int ID)
        {
            return clsDataBooks.DeleteBook(ID);
        }

        public static bool isBookExist(int ID)
        {
            return clsDataBooks.IsBookExist(ID);
        }

        public static int CountBooks()
        {
            return clsDataBooks.CountBooks();
        }

    }
}
