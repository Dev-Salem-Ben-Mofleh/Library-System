using System;
using System.Data.SqlClient;
using System.Data;


namespace LibraryDataAccessLayer
{
    public class clsDataBorroing
    {
        public static bool GetBorroingRecordInfoByID(int BorrowingRecordID, ref int MemberID, ref int CopyID,
    ref DateTime BorrowingDate,ref DateTime DueDate, ref string ActualReturnDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM BorrowingRecords WHERE BorrowingRecordID = @BorrowingRecordID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    MemberID = (int)reader["MemberID"];
                    CopyID = (int)reader["CopyID"];
                    BorrowingDate = (DateTime)reader["BorrowingDate"];
                    DueDate = (DateTime)reader["DueDate"];

                    //ImagePath: allows null in database so we should handle null
                    if (reader["ActualReturnDate"] != DBNull.Value)
                    {
                        ActualReturnDate = (string)reader["ActualReturnDate"];
                    }
                    else
                    {
                        ActualReturnDate = "";
                    }

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

        public static int AddNewBorrowingRecord(  int MemberID,  int CopyID,
     DateTime BorrowingDate,  DateTime DueDate,  string ActualReturnDate)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int BorrowingRecordID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO BorrowingRecords (MemberID, CopyID, BorrowingDate,DueDate,
                             ActualReturnDate)
                             VALUES (@MemberID, @CopyID, @BorrowingDate,@DueDate, @ActualReturnDate);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@CopyID", CopyID);
            command.Parameters.AddWithValue("@BorrowingDate", BorrowingDate);
            command.Parameters.AddWithValue("@DueDate", DueDate);


            if (ActualReturnDate != "" && ActualReturnDate != null)
                command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
            else
                command.Parameters.AddWithValue("@ActualReturnDate", System.DBNull.Value);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    BorrowingRecordID = insertedID;
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


            return BorrowingRecordID;
        }

        public static bool UpdateBorrowingRecord(int BorrowingRecordID, int MemberID, int CopyID,
            DateTime BorrowingDate, DateTime DueDate, string ActualReturnDate)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  BorrowingRecords  
                            set MemberID = @MemberID, 
                                CopyID = @CopyID, 
                                BorrowingDate = @BorrowingDate, 
                                DueDate = @DueDate, 
                                ActualReturnDate = @ActualReturnDate
                                where BorrowingRecordID = @BorrowingRecordID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@CopyID", CopyID);
            command.Parameters.AddWithValue("@BorrowingDate", BorrowingDate);
            command.Parameters.AddWithValue("@DueDate", DueDate);

            if (ActualReturnDate != "" && ActualReturnDate != null)
                command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
            else
                command.Parameters.AddWithValue("@ActualReturnDate", System.DBNull.Value);


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

        public static DataTable GetAllBorrowingRecords()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM BorrowingRecords";

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
        public static DataTable GetAllBorrowingRecordsByID(int BorrowingRecordID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM BorrowingRecords where  BorrowingRecordID=@BorrowingRecordID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);

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

        public static DataTable GetAllBorrowingRecordsByMemberID(int MemberID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM BorrowingRecords where  MemberID=@MemberID";

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
        public static DataTable GetAllBorrowingRecordsByID(int BorrowingRecordID, int MemberID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM BorrowingRecords where  BorrowingRecordID=@BorrowingRecordID and MemberID=@MemberID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
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


        public static bool DeleteBorrowingRecords(int BorrowingRecordID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete BorrowingRecords 
                                where BorrowingRecordID = @BorrowingRecordID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);

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

        public static bool IsBorrowingRecordExist(int BorrowingRecordID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM BorrowingRecords WHERE BorrowingRecordID = @BorrowingRecordID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);

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



    }
}
