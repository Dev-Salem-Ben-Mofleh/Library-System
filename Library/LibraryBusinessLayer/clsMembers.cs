using LibraryDataAccessLayer;
using System;
using System.Data;
using System.Security;

namespace LibraryBusinessLayer
{
    public class clsMembers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int MemberID { get; set; }
        public string LibraryCardNumber { get; set; }
        public int PerosnID { get; set; }

        public clsMembers()
        {
            this.MemberID = -1;
            this.LibraryCardNumber = "";
            this.PerosnID = -1;

            Mode = enMode.AddNew;

        }

        private clsMembers(int MemberID, string LibraryCardNumber, int PerosnID)

        {
            this.MemberID = MemberID;
            this.LibraryCardNumber = LibraryCardNumber;
            this.PerosnID = PerosnID;

            Mode = enMode.Update;

        }
        private bool _AddNewMember()
        {
            //call DataAccess Layer 

            this.MemberID = clsDataMembers.AddNewMember(this.LibraryCardNumber, this.PerosnID);

            return (this.MemberID != -1);
        }

        private bool _UpdateMember()
        {
            //call DataAccess Layer 

            return clsDataMembers.UpdateMember(this.MemberID, this.LibraryCardNumber, this.PerosnID);

        }

        public static clsMembers Find(int ID)
        {
            string LibraryCardNumber = "";
            int PerosnID = -1;


            if (clsDataMembers.GetMemberInfoByID(ID, ref LibraryCardNumber, ref PerosnID))

                return new clsMembers(ID, LibraryCardNumber, PerosnID);
            else
                return null;

        }

        public static clsMembers FindByPersonID(int PersonID)
        {
            string LibraryCardNumber = "";
            int MemebreID = -1;


            if (clsDataMembers.GetMemberInfoByPersonID(PersonID, ref LibraryCardNumber, ref MemebreID))

                return new clsMembers(MemebreID, LibraryCardNumber, PersonID);
            else
                return null;

        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMember())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateMember();

            }




            return false;
        }

        private static string _GetNewCard(string LastCard )
        {
            string NewCard="";
            for (int i=6; i<LastCard.Length;i++)
            {
                NewCard += LastCard[i];
            }
            if (NewCard != null && int.TryParse(NewCard.ToString(), out int Card))
            {
                int NumCard = Card;
                NumCard += 1;
                NewCard = NumCard.ToString();
            }
            return "LCN000"+ NewCard;
        }
        public static string GetNewCard()
        {

             string LastCard=clsDataMembers.GetLastCard();
            return _GetNewCard(LastCard);

        }
        public static DataTable GetAllMembers()
        {
            return clsDataMembers.GetAllMembers();

        }

        public static DataTable GetAllInfoMembers()
        {
            return clsDataMembers.GetAllInfoMembers();

        }

        public static DataTable GetAllInfoMembersbyID(int ID)
        {
            return clsDataMembers.GetAllInfoMembersbyID(ID);
        }




        public static bool DeleteMember(int ID)
        {
            return clsDataMembers.DeleteMember(ID);
        }

        public static bool isMemberExist(int ID)
        {
            return clsDataMembers.IsMemberExist(ID);
        }
        public static int CountMembers()
        {
            return clsDataMembers.CountMembers();
        }

    }
}
