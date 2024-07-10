using LibraryDataAccessLayer;
using System;
using System.Data;
using System.Security;

namespace LibraryBusinessLayer
{
    public class clsPersons
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Permissions { get; set; }


        public clsPersons()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.PhoneNumber = "";
            this.UserName = "";
            this.Password = "";
            this.Permissions = "";

            Mode = enMode.AddNew;

        }

        private clsPersons(int PersonID, string FirstName, string LastName, string Email,
           string PhoneNumber, string UserName, string Password, string Permissions)

        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.UserName = UserName;
            this.Password = Password;
            this.Permissions = Permissions;

            Mode = enMode.Update;

        }
        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.PersonID = clsDataPersons.AddNewPerson(this.FirstName, this.LastName, this.Email,
             this.PhoneNumber, this.UserName, this.Password,this.Permissions);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsDataPersons.UpdatePerson(this.PersonID, this.FirstName, this.LastName, this.Email,
            this.PhoneNumber, this.UserName, this.Password,this.Permissions);

        }

        public static clsPersons Find(int ID)
        {
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string PhoneNumber = "";
            string UserName = "";
            string Password = "";
            string Permissions = "";



            if (clsDataPersons.GetPersonInfoByID(ID, ref FirstName, ref LastName, ref Email,
           ref PhoneNumber, ref UserName, ref Password,ref Permissions))

                return new clsPersons(ID, FirstName, LastName, Email,
            PhoneNumber, UserName, Password, Permissions);
            else
                return null;

        }
        public static clsPersons Find(string UserName, string Password)
        {
            int ID = -1;
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string PhoneNumber = "";
            string Permissions = "";



            if (clsDataPersons.GetPersonInfoByUserNameAndPassword(  UserName, Password, ref ID, ref FirstName, ref LastName, ref Email,
           ref PhoneNumber,  ref Permissions))

                return new clsPersons(ID, FirstName, LastName, Email,
            PhoneNumber, UserName, Password, Permissions);
            else
                return null;

        }



        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }




            return false;
        }

        public static DataTable GetAllPersons()
        {
            return clsDataPersons.GetAllPersons();

        }

        public static bool DeletePerson(int ID)
        {
            return clsDataPersons.DeletePerson(ID);
        }

        public static bool isPersonExist(int ID)
        {
            return clsDataPersons.IsPersonExist(ID);
        }
        public static bool isPersonExist(string UserName,string Password)
        {
            return clsDataPersons.IsPersonExist(UserName, Password);
        }


    }
}
