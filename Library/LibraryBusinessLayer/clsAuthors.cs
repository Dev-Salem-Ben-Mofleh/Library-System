using LibraryDataAccessLayer;
using System;
using System.Data;

namespace LibraryBusinessLayer
{
    public class clsAuthors
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string Bio { get; set; }
        public int EducationID { get; set; }

        public clsAuthors()
        {
            this.AuthorID = -1;
            this.AuthorName = "";
            this.Bio = "";
            this.EducationID = -1;

            Mode = enMode.AddNew;

        }

        private clsAuthors(int AuthorID,string AuthorName, string Bio, int EducationID)

        {
            this.AuthorID = AuthorID;
            this.EducationID = EducationID;
            this.Bio = Bio;
            this.AuthorName = AuthorName;
            
            Mode = enMode.Update;

        }
        private bool _AddNewAuthor()
        {
            //call DataAccess Layer 

            this.AuthorID = clsDataAuthor.AddNewAuthor(this.AuthorName, this.Bio, this.EducationID);

            return (this.AuthorID != -1);
        }

        private bool _UpdateAuthor()
        {
            //call DataAccess Layer 

          return clsDataAuthor.UpdateAuthor(this.AuthorID, this.AuthorName, this.Bio, this.EducationID);

        }

        public static clsAuthors Find(int ID)
        {
            string AuthorName = "";
            string Bio = "";
            int EducationID = -1;


            if (clsDataAuthor.GetAuthorInfoByID(ID, ref AuthorName, ref Bio, ref EducationID))

                return new clsAuthors(ID, AuthorName, Bio, EducationID);
            else
                return null;

        }

        public static clsAuthors Find(string  AuthorName)
        {
            int ID = -1;
            string Bio = "";
            int EducationID = -1;


            if (clsDataAuthor.GetAuthorInfoByAuthorName(AuthorName, ref ID, ref Bio, ref EducationID))

                return new clsAuthors(ID, AuthorName, Bio, EducationID);
            else
                return null;

        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAuthor())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateAuthor();

            }




            return false;
        }

        public static DataTable GetAllAuthor()
        {
            return clsDataAuthor.GetAllAuthors();

        }
        public static DataTable GetAllInfoAuthors()
        {
            return clsDataAuthor.GetAllInfoAuthors();
        }

        

        public static bool DeleteAuthor(int ID)
        {
            return clsDataAuthor.DeleteAuthor(ID);
        }

        public static bool isAuthorExist(int ID)
        {
            return clsDataAuthor.IsAuthorExist(ID);
        }

        public static int CountAuthors()
        {
            return clsDataAuthor.CountAuthors();
        }

    }
}
