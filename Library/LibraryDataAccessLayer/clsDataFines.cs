using System;
using System.Data.SqlClient;
using System.Data;


namespace LibraryDataAccessLayer
{
    public class clsDataFines
    {
        public static bool GetFineInfoByID(int FineID, ref int MemberID, ref int BorrowingRecordID,
    ref int NumberOfLateDays,
  ref decimal FineAmount, ref bool PaymentStatus)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Fines WHERE FineID = @FineID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FineID", FineID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    MemberID = (int)reader["MemberID"];
                    BorrowingRecordID = (int)reader["BorrowingRecordID"];
                    NumberOfLateDays = Convert.ToByte( reader["NumberOfLateDays"]);
                    FineAmount = (decimal)reader["FineAmount"];
                    PaymentStatus = (bool)reader["PaymentStatus"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewFine( int MemberID,  int BorrowingRecordID,
             int NumberOfLateDays, decimal FineAmount,  bool PaymentStatus)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int FineID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Fines (MemberID, BorrowingRecordID, NumberOfLateDays,FineAmount, 
                            PaymentStatus)
                             VALUES (@MemberID, @BorrowingRecordID, @NumberOfLateDays,@FineAmount, @PaymentStatus);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
            command.Parameters.AddWithValue("@NumberOfLateDays", NumberOfLateDays);
            command.Parameters.AddWithValue("@FineAmount", FineAmount);
            command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    FineID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return FineID;
        }

        public static bool UpdateFine(int FineID,  int MemberID,  int BorrowingRecordID,
        int NumberOfLateDays, decimal FineAmount,  bool PaymentStatus)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Fines  
                            set MemberID = @MemberID, 
                                BorrowingRecordID = @BorrowingRecordID, 
                                NumberOfLateDays = @NumberOfLateDays, 
                                FineAmount = @FineAmount, 
                                PaymentStatus = @PaymentStatus
                                where FineID = @FineID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FineID", FineID);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
            command.Parameters.AddWithValue("@NumberOfLateDays", NumberOfLateDays);
            command.Parameters.AddWithValue("@FineAmount", FineAmount);
            command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllFines()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Fines";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable GetFineByID(int FineID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Fines where FineID=@FineID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FineID", FineID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable GetFineByMemberID(int MemberID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Fines where MemberID=@MemberID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }
        public static DataTable GetFineByID(int FineID, int MemberID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Fines where FineID=@FineID and MemberID=@MemberID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FineID", FineID);
            command.Parameters.AddWithValue("@MemberID", MemberID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }


        public static bool DeleteFine(int FineID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Fines 
                                where FineID = @FineID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FineID", FineID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsFineExist(int FineID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Fines WHERE FineID = @FineID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FineID", FineID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool IsFinePaied(ref int FineID,int BorrowingID, bool PaymentStatut = true)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT FineID FROM Fines WHERE BorrowingID = @BorrowingID " +
                "and PaymentStatut=@PaymentStatut";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BorrowingID", BorrowingID);
            command.Parameters.AddWithValue("@PaymentStatut", PaymentStatut);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    FineID = insertedID;
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                FineID = -1;
            }
            finally
            {
                connection.Close();
            }

            return (FineID != -1);
        }

    }
}
