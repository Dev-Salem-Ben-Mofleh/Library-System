using LibraryDataAccessLayer;
using System;
using System.Data;

namespace LibraryBusinessLayer
{
    public class clsGeners
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int GenerID { get; set; }
        public string GenerName { get; set; }

        public clsGeners()
        {
            this.GenerID = -1;
            this.GenerName = "";

            Mode = enMode.AddNew;

        }

        private clsGeners(int GenerID, string GenerName)

        {
            this.GenerID = GenerID;
            this.GenerName = GenerName;

            Mode = enMode.Update;

        }
        private bool _AddNewGener()
        {
            //call DataAccess Layer 

            this.GenerID = clsDataGeners.AddNewGener(this.GenerName);

            return (this.GenerID != -1);
        }

        private bool _UpdateGener()
        {
            //call DataAccess Layer 

            return clsDataGeners.UpdateGener(this.GenerID, this.GenerName);

        }

        public static clsGeners Find(int ID)
        {
            string GenerName = "";



            if (clsDataGeners.GetGenerInfoByID(ID, ref GenerName))

                return new clsGeners(ID, GenerName);
            else
                return null;

        }
        public static clsGeners Find(string GenerName)
        {
            int ID = -1;



            if (clsDataGeners.GetGenerInfoByGenerName(GenerName, ref ID))

                return new clsGeners(ID, GenerName);
            else
                return null;

        }


        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewGener())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateGener();

            }




            return false;
        }

        public static DataTable GetAllGeners()
        {
            return clsDataGeners.GetAllGeners();

        }
       
        public static bool DeleteGener(int ID)
        {
            return clsDataGeners.DeleteGeners(ID);
        }

        public static bool isGenerExist(int ID)
        {
            return clsDataGeners.IsGenerExist(ID);
        }

    }
}
