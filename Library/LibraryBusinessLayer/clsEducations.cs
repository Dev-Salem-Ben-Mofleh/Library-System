using LibraryDataAccessLayer;
using System;
using System.Data;


namespace LibraryBusinessLayer
{
    public class clsEducations
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int EducationID { get; set; }
        public string EducationName { get; set; }
        
        public clsEducations()
        {
            this.EducationID = -1;
            this.EducationName = "";

            Mode = enMode.AddNew;

        }

        private clsEducations(int EducationID, string EducationName)

        {
            this.EducationID = EducationID;
            this.EducationName = EducationName;

            Mode = enMode.Update;

        }
        private bool _AddNewEducation()
        {
            //call DataAccess Layer 

            this.EducationID = clsDataEdEducations.AddNewEducation(this.EducationName);

            return (this.EducationID != -1);
        }

        private bool _UpdateEducation()
        {
            //call DataAccess Layer 

            return clsDataEdEducations.UpdateEducation(this.EducationID, this.EducationName);

        }

        public static clsEducations Find(int ID)
        {
            string EducationName = "";



            if (clsDataEdEducations.GetEducationInfoByID(ID, ref EducationName))

                return new clsEducations(ID, EducationName);
            else
                return null;

        }

        public static clsEducations Find(string EducationName)
        {
            int ID = -1;



            if (clsDataEdEducations.GetEducationInfoByEducationName(EducationName, ref ID))

                return new clsEducations(ID, EducationName);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewEducation())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateEducation();

            }




            return false;
        }

        public static DataTable GetAllEducations()
        {
            return clsDataEdEducations.GetAllEducations();

        }

        public static bool DeleteEducation(int ID)
        {
            return clsDataEdEducations.DeleteEducations(ID);
        }

        public static bool isEducationExist(int ID)
        {
            return clsDataEdEducations.IsEducationExist(ID);
        }
    }
}
