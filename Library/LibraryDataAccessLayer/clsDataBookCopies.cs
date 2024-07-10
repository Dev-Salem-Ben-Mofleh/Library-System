using System;
using System.Data.SqlClient;
using System.Data;


namespace LibraryDataAccessLayer
{
    public class clsDataBookCopies
    {
        public static bool GetBookCopiesInfoByID(int CopyID, ref int BookID, ref bool AvailabilityStatus)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM BookCopies WHERE CopyID = @CopyID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CopyID", CopyID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    BookID = (int)reader["BookID"];
                    AvailabilityStatus = (bool)reader["AvailabilityStatus"];
                  

                    //ImagePath: allows null in database so we should handle null
                   

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

        public static int AddNewBookCopies( int BookID,  bool AvailabilityStatus)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int CopyID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO BookCopies (BookID, AvailabilityStatus)
                             VALUES (@BookID,@AvailabilityStatus);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", BookID);
            command.Parameters.AddWithValue("@AvailabilityStatus", AvailabilityStatus);
           
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CopyID = insertedID;
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


            return CopyID;
        }

        public static bool UpdateBookCopies(int CopyID,  int BookID,  bool AvailabilityStatus)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  BookCopies  
                            set  BookID = @BookID, 
                                AvailabilityStatus = @AvailabilityStatus
                                 where CopyID = @CopyID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CopyID", CopyID);
            command.Parameters.AddWithValue("@BookID", BookID);
            command.Parameters.AddWithValue("@AvailabilityStatus", AvailabilityStatus);
            

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

        public static DataTable GetAllBookCopies()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM BookCopies";

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
        public static DataTable GetAllBookCopiesByBookID(int BookID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT CopyID,AvailabilityStatus FROM BookCopies " +
                "where BookID=@BookID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BookID", BookID);

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

        public static DataTable GetAllBookCopiesAvilible(int BookID, bool AvailabilityStatus=false)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM BookCopies where BookID=@BookID and AvailabilityStatus=@AvailabilityStatus";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BookID", BookID);
            command.Parameters.AddWithValue("@AvailabilityStatus", AvailabilityStatus);

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


        public static bool DeleteBookCopies(int CopyID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete BookCopies 
                                where CopyID = @CopyID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CopyID", CopyID);

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
        public static bool DeleteBookCopiesByAvailable(int BookID, bool AvailabilityStatus=false)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete BookCopies 
                                where BookID=@BookID and AvailabilityStatus=@AvailabilityStatus";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", BookID);
            command.Parameters.AddWithValue("@AvailabilityStatus", AvailabilityStatus);



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


        public static bool IsBookCopiesExist(int CopyID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM BookCopies WHERE CopyID = @CopyID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", CopyID);

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

        public static int CountBookCopeis(int BookID)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int CountCopy = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select Count(*) from BookCopies " +
                "Where BookID=@BookID";
           
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BookID", BookID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CountCopy = insertedID;
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


            return CountCopy;
        }

        public static int IsBookAvailble( int BookID, bool AvailabilityStatus=false)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int CopyID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT CopyID FROM BookCopies WHERE BookID = @BookID " +
                "and AvailabilityStatus=@AvailabilityStatus";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", BookID);
            command.Parameters.AddWithValue("@AvailabilityStatus", AvailabilityStatus);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CopyID = insertedID;
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


            return CopyID;
        }

    }
}
