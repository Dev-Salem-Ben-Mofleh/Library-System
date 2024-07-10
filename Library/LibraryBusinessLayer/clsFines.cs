using LibraryDataAccessLayer;
using System;
using System.Data;

namespace LibraryBusinessLayer
{
    public class clsFines
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int FineID { get; set; }
        public int MemberID { get; set; }
        public int BorrowingRecordID { get; set; }
        public int NumberOfLateDays { get; set; }
        public decimal FineAmount { get; set; }
        public bool PaymentStatus { get; set; }

        public clsFines()
        {
            this.FineID = -1;
            this.MemberID = -1;
            this.BorrowingRecordID = -1;
            this.NumberOfLateDays = 0;
            this.FineAmount = -1;
            this.PaymentStatus = false;

            Mode = enMode.AddNew;

        }

        private clsFines(int FineID, int MemberID, int BorrowingRecordID, int NumberOfLateDays,
           decimal FineAmount, bool PaymentStatus)

        {
            this.FineID = FineID;
            this.MemberID = MemberID;
            this.BorrowingRecordID = BorrowingRecordID;
            this.NumberOfLateDays = NumberOfLateDays;
            this.FineAmount = FineAmount;
            this.PaymentStatus = PaymentStatus;

            Mode = enMode.Update;

        }
        private bool _AddNewFine()
        {
            //call DataAccess Layer 

            this.FineID = clsDataFines.AddNewFine(this.MemberID, this.BorrowingRecordID, this.NumberOfLateDays,
             this.FineAmount, this.PaymentStatus);

            return (this.FineID != -1);
        }

        private bool _UpdateFine()
        {
            //call DataAccess Layer 

            return clsDataFines.UpdateFine(this.FineID, this.MemberID, this.BorrowingRecordID, this.NumberOfLateDays,
            this.FineAmount, this.PaymentStatus);

        }

        public static clsFines Find(int ID)
        {
            int MemberID = -1;
            int BorrowingRecordID = -1;
            int NumberOfLateDays = 0;
            decimal FineAmount = -1;
            bool PaymentStatus = false;


            if (clsDataFines.GetFineInfoByID(ID, ref MemberID, ref BorrowingRecordID, ref NumberOfLateDays,
           ref FineAmount, ref PaymentStatus))

                return new clsFines(ID, MemberID, BorrowingRecordID, NumberOfLateDays,
            FineAmount, PaymentStatus);
            else
                return null;

        }


        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewFine())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateFine();

            }




            return false;
        }

        public static DataTable GetAllFines()
        {
            return clsDataFines.GetAllFines();

        }

        public static DataTable GetFineByID(int FineID)
        {
            return clsDataFines.GetFineByID( FineID);

        }
        public static DataTable GetFineByMemberID(int MemberId)
        {
            return clsDataFines.GetFineByMemberID(MemberId);

        }
        public static DataTable GetFineByID(int FineID, int MemberId)
        {
            return clsDataFines.GetFineByID(FineID, MemberId);

        }


        public static bool DeleteFine(int ID)
        
        
        {
            return clsDataFines.DeleteFine(ID);
        }

        public static bool isFineExist(int ID)
        {
            return clsDataFines.IsFineExist(ID);
        }

        public static bool IsFinePaied(ref int FineID,int BorrowingID)
        {
            return clsDataFines.IsFinePaied(ref FineID, BorrowingID);
        }
    }
}
