using LibraryDataAccessLayer;
using System;
using System.Data;

namespace LibraryBusinessLayer
{
    public class clsBorrowingRecords
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int BorrowingRecordID { get; set; }
        public int MemberID { get; set; }
        public int CopyID { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime DueDate { get; set; }
        public string ActualReturnDate { get; set; }

        public clsBorrowingRecords()
        {
            this.BorrowingRecordID = -1;
            this.MemberID = -1;
            this.CopyID = -1;
            this.BorrowingDate = DateTime.Now;
            this.DueDate = DateTime.Now;
            this.ActualReturnDate = "";

            Mode = enMode.AddNew;

        }

        private clsBorrowingRecords(int BorrowingRecordID, int MemberID, int CopyID, DateTime BorrowingDate,
           DateTime DueDate, string ActualReturnDate)

        {
            this.BorrowingRecordID = BorrowingRecordID;
            this.MemberID = MemberID;
            this.CopyID = CopyID;
            this.BorrowingDate = BorrowingDate;
            this.DueDate = DueDate;
            this.ActualReturnDate = ActualReturnDate;

            Mode = enMode.Update;

        }
        private bool _AddNewBorrowingRecord()
        {
            //call DataAccess Layer 

            this.BorrowingRecordID = clsDataBorroing.AddNewBorrowingRecord(this.MemberID, this.CopyID, this.BorrowingDate,
             this.DueDate, this.ActualReturnDate);

            return (this.BorrowingRecordID != -1);
        }

        private bool _UpdateBorrowingRecord()
        {
            //call DataAccess Layer 

            return clsDataBorroing.UpdateBorrowingRecord(this.BorrowingRecordID, this.MemberID, this.CopyID, this.BorrowingDate,
            this.DueDate, this.ActualReturnDate);

        }

        public static clsBorrowingRecords Find(int ID)
        {
            int MemberID = -1;
            int CopyID = -1;
            DateTime BorrowingDate = DateTime.Now;
            DateTime DueDate = DateTime.Now;
            string ActualReturnDate = "";


            if (clsDataBorroing.GetBorroingRecordInfoByID(ID, ref MemberID, ref CopyID, ref BorrowingDate,
           ref DueDate, ref ActualReturnDate))

                return new clsBorrowingRecords(ID, MemberID, CopyID, BorrowingDate,
            DueDate, ActualReturnDate);
            else
                return null;

        }


        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBorrowingRecord())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateBorrowingRecord();

            }




            return false;
        }

        public static DataTable GetAllBorrowingRecord()
        {
            return clsDataBorroing.GetAllBorrowingRecords();

        }
        public static DataTable GetAllBorrowingRecordsByMemberID(int MemberID)
        {
            return clsDataBorroing.GetAllBorrowingRecordsByMemberID(MemberID);

        }
        public static DataTable GetAllBorrowingRecordsByID(int ID)
        {
            return clsDataBorroing.GetAllBorrowingRecordsByID(ID);

        }
        public static DataTable GetAllBorrowingRecordsByID(int ID,int MemberID)
        {
            return clsDataBorroing.GetAllBorrowingRecordsByID(ID, MemberID);

        }
        public static bool DeleteBorrowingRecord(int ID)
        {
            return clsDataBorroing.DeleteBorrowingRecords(ID);
        }

        public static bool isBorrowingRecordExist(int ID)
        {
            return clsDataBorroing.IsBorrowingRecordExist(ID);
        }


     
        public static byte ReturnBook(DateTime _BorrowingDate, DateTime _ActualReturnDate)
        {
            TimeSpan DeffrentDays = _ActualReturnDate.Subtract(_BorrowingDate);
            byte NumberOfDays = Convert.ToByte(DeffrentDays.TotalDays);
            return NumberOfDays-=1;

        }

    }
}
