using LibraryDataAccessLayer;
using System;
using System.Data;

namespace LibraryBusinessLayer
{
    public class clsReservations
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ReservationID { get; set; }
        public int MemberID { get; set; }
        public int CopyID { get; set; }
        public DateTime ReservationDate { get; set; }

        public clsReservations()
        {
            this.ReservationID = -1;
            this.MemberID = -1;
            this.CopyID = -1;
            this.ReservationDate = DateTime.Now;

            Mode = enMode.AddNew;

        }

        private clsReservations(int ReservationID, int MemberID, int CopyID, DateTime ReservationDate)

        {
            this.ReservationID = ReservationID;
            this.MemberID = MemberID;
            this.CopyID = CopyID;
            this.ReservationDate = ReservationDate;

            Mode = enMode.Update;

        }
        private bool _AddNewReservations()
        {
            //call DataAccess Layer 

            this.ReservationID = clsDataReservations.AddNewReservations(this.MemberID, this.CopyID, this.ReservationDate);

            return (this.ReservationID != -1);
        }

        private bool _UpdateReservation()
        {
            //call DataAccess Layer 

            return clsDataReservations.UpdateReservations(this.ReservationID, this.MemberID, this.CopyID, this.ReservationDate);

        }

        public static clsReservations Find(int ID)
        {
            int MemberID = -1;
            int CopyID = -1;
            DateTime ReservationDate = DateTime.Now;


            if (clsDataReservations.GetReservationInfoByID(ID, ref MemberID, ref CopyID, ref ReservationDate))

                return new clsReservations(ID, MemberID, CopyID, ReservationDate);
            else
                return null;

        }


        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewReservations())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateReservation();

            }




            return false;
        }

        public static DataTable GetAllReservations()
        {
            return clsDataReservations.GetAllReservations();

        }


        public static DataTable GetAllReservationsByMemberID(int MemberID)
        {
            return clsDataReservations.GetAllReservationsByMemberID(MemberID);

        }
        public static DataTable GetAllReservationsByID(int MemberID, int ReservationID)
        {
            return clsDataReservations.GetAllReservationsByID(MemberID, ReservationID);

        }

        private bool IsThereAReservationInThisDate(DateTime borrowingDate,DateTime DueDate,DateTime ReservationDate)
        {
            for(int i = 0; borrowingDate<= DueDate; i++)
            {
                if (borrowingDate.Equals(ReservationDate) || borrowingDate.Date> ReservationDate.Date)
                    return false;
                else
                    borrowingDate= borrowingDate.Date.AddDays(1);
            }
            return true;
        }
        public  bool GetAllReservationsForBorrowing( clsBorrowingRecords borrowingRecords,int CopyID)
        {
            DataTable dt= clsDataReservations.GetAllReservationsForBorrowing(CopyID);

            foreach(DataRow Row in dt.Rows)
            {
               if(! IsThereAReservationInThisDate(borrowingRecords.BorrowingDate, borrowingRecords.DueDate
                    , (DateTime)Row["ReservationDate"]))
                 return false; 
            }
            return true;

        }
        public static bool DeleteReservation(int ID)
        {
            return clsDataReservations.DeleteReservation(ID);
        }

        public static bool isReservationExist(int ID)
        {
            return clsDataReservations.IsReservationExist(ID);
        }

        public static bool IsReservationisFound(int CopyID)
        {
            return clsDataReservations.IsReservationisFound(CopyID);
        }
    }
}
