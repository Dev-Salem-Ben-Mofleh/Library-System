using LibraryDataAccessLayer;
using System;
using System.Data;

namespace LibraryBusinessLayer
{
    public class clsBookCopies
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int CopyID { get; set; }
        public int BookID { get; set; }
        public bool AvailabilityStatus { get; set; }
       

        public clsBookCopies()
        {
            this.CopyID = -1;
            this.BookID = -1;
            this.AvailabilityStatus = false;

            Mode = enMode.AddNew;

        }

        private clsBookCopies(int CopyID,int BookID,bool AvailabilityStatus)

        {
            this.CopyID = CopyID;
            this.BookID = BookID;
            this.AvailabilityStatus = AvailabilityStatus;
            

            Mode = enMode.Update;

        }

        private bool _AddNewBookCopies()
        {
            //call DataAccess Layer 

            this.CopyID = clsDataBookCopies.AddNewBookCopies(this.BookID, this.AvailabilityStatus);

            return (this.CopyID != -1);
        }

        private bool _UpdateBookCopies()
        {
            //call DataAccess Layer 
            return clsDataBookCopies.UpdateBookCopies(this.CopyID,  this.BookID,  this.AvailabilityStatus);

        }

        public static clsBookCopies Find(int ID)
        
        {
            int BookID = -1;
            bool AvailabilityStatus = false;
           


            if (clsDataBookCopies.GetBookCopiesInfoByID(ID, ref BookID,ref AvailabilityStatus))

                return new clsBookCopies(ID, BookID, AvailabilityStatus);
            else
                return null;

        }


        public  bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBookCopies())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateBookCopies();

            }




            return false;
        }

        public static DataTable GetAllBookCopies()
        {
            return clsDataBookCopies.GetAllBookCopies();

        }
        public static DataTable GetAllBookCopiesByBookID(int ID)
        {
            return clsDataBookCopies.GetAllBookCopiesByBookID(ID);

        }

        public static DataTable GetAllBookCopiesAvilible(int ID)
        {
            return clsDataBookCopies.GetAllBookCopiesAvilible(ID);

        }

        public static bool DeleteBookCopies(int ID)
        {
            return clsDataBookCopies.DeleteBookCopies(ID);
        }
        public static bool DeleteBookCopiesBuAvalible(int BookID)
        {
            return clsDataBookCopies.DeleteBookCopiesByAvailable( BookID);
        }

        public static bool isBookCopiesExist(int ID)
        {
            return clsDataBookCopies.IsBookCopiesExist(ID);
        }
        public static int CountCopies(int BookID)
        {
            return clsDataBookCopies.CountBookCopeis(BookID);
        }

        public static int IsBookAvailble(int BookID)
        {
            return clsDataBookCopies.IsBookAvailble(BookID);
        }
    }
}
