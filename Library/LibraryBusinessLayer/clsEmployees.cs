using LibraryDataAccessLayer;
using System;
using System.Data;

namespace LibraryBusinessLayer
{
    public class clsEmployees
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int EmployeeID { get; set; }
        public decimal Salary { get; set; }
        public int PersonID { get; set; }

        public clsEmployees()
        {
            this.EmployeeID = -1;
            this.Salary = -1;
            this.PersonID = -1;

            Mode = enMode.AddNew;

        }

        private clsEmployees(int EmployeeID, decimal Salary, int PersonID)

        {
            this.EmployeeID = EmployeeID;
            this.Salary = Salary;
            this.PersonID = PersonID;

            Mode = enMode.Update;

        }
        private bool _AddNewEmployee()
        {
            //call DataAccess Layer 

            this.EmployeeID = clsDataEmployees.AddNewEmployee(this.Salary, this.PersonID);

            return (this.EmployeeID != -1);
        }

        private bool _UpdateEmployee()
        {
            //call DataAccess Layer 

            return clsDataEmployees.UpdateEmployee(this.EmployeeID, this.Salary, this.PersonID);

        }

        public static clsEmployees Find(int ID)
        {
            decimal Salary = -1;
            int PersonID = -1;


            if (clsDataEmployees.GetEmployeeInfoByID(ID, ref Salary, ref PersonID))

                return new clsEmployees(ID, Salary, PersonID);
            else
                return null;

        }


        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewEmployee())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateEmployee();

            }




            return false;
        }
        public static DataTable GetAllEmployees()
        {
            return clsDataEmployees.GetAllEmployees();

        }

        public static DataTable GetAllInfoEmployees()
        {
            return clsDataEmployees.GetAllInfoEmployees();

        }

       

        public static bool DeleteEmployee(int ID)
        {
            return clsDataEmployees.DeleteEmployee(ID);
        }

        public static bool isEmployeeExist(int ID)
        {
            return clsDataEmployees.IsEmployeeExist(ID);
        }
        public static int CountEmployees()
        {
            return clsDataEmployees.CountEmployees();
        }


    }
}
