using LibraryDataAccessLayer;
using System;
using System.Data;

namespace LibraryBusinessLayer
{
    public class clsSetting
    {
        public static int DefualtBorrrowDays { get; set; }
        public static int DefaultFinePerDay { get; set; }

        public static decimal CalculateFines(ref int NumberOfDays)
        {
            DataTable dt = clsDataSetting.GetAllSetting();

            foreach(DataRow Row in dt.Rows)
            {
                DefualtBorrrowDays =Convert.ToByte( Row["DefualtBorrrowDays"]);
                DefaultFinePerDay = Convert.ToByte(Row["DefaultFinePerDay"]);
            }
            if (NumberOfDays == DefualtBorrrowDays)
                return 0;
            else
                NumberOfDays -=DefualtBorrrowDays;

           return  DefaultFinePerDay * NumberOfDays;

        }



    }
}
