using System;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Net;


namespace LibraryDataAccessLayer
{
    public class clsDataBooks
    {
        public static bool GetBookInfoByID(int BookID,ref string Title, ref string ISBN,
            ref DateTime PublicationDate,
          ref string AdditionalDetails, ref int AuthorID, ref int GenreID,ref decimal PriceBorrwoing)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Books WHERE BookID = @BookID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", BookID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Title = (string)reader["Title"];
                    ISBN = (string)reader["ISBN"];
                    PublicationDate = (DateTime)reader["PublicationDate"];
                    AuthorID = (int)reader["AuthorID"];
                    GenreID = (int)reader["GenreID"];
                    PriceBorrwoing = (decimal)reader["PriceBorrwoing"];


                    //ImagePath: allows null in database so we should handle null
                    if (reader["AdditionalDetails"] != DBNull.Value)
                    {
                        AdditionalDetails = (string)reader["AdditionalDetails"];
                    }
                    else
                    {
                        AdditionalDetails = "";
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

        public static int AddNewBook( string Title, string ISBN, DateTime PublicationDate,
           string AdditionalDetails, int AuthorID, int GenreID, decimal PriceBorrwoing)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int BookID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Books (Title, ISBN, PublicationDate,AdditionalDetails, AuthorID,GenreID,PriceBorrwoing)
                             VALUES (@Title, @ISBN, @PublicationDate,@AdditionalDetails, @AuthorID, @GenreID,@PriceBorrwoing);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@ISBN", ISBN);
            command.Parameters.AddWithValue("@PublicationDate", PublicationDate);
            command.Parameters.AddWithValue("@AuthorID", AuthorID);
            command.Parameters.AddWithValue("@GenreID", GenreID);
            command.Parameters.AddWithValue("@PriceBorrwoing", PriceBorrwoing);


            if (AdditionalDetails != "" && AdditionalDetails != null)
                command.Parameters.AddWithValue("@AdditionalDetails", AdditionalDetails);
            else
                command.Parameters.AddWithValue("@AdditionalDetails", System.DBNull.Value);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    BookID = insertedID;
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


            return BookID;
        }

        public static bool UpdateBook(int BookID,string Title, string ISBN, DateTime PublicationDate,
           string AdditionalDetails, int AuthorID, int GenreID, decimal PriceBorrwoing)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Books  
                            set Title = @Title, 
                                ISBN = @ISBN, 
                                PublicationDate = @PublicationDate, 
                                AuthorID = @AuthorID, 
                                GenreID = @GenreID,
                                PriceBorrwoing=@PriceBorrwoing,
                                AdditionalDetails = @AdditionalDetails
                                Where BookID = @BookID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", BookID);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@ISBN", ISBN);
            command.Parameters.AddWithValue("@PublicationDate", PublicationDate);
            command.Parameters.AddWithValue("@AuthorID", AuthorID);
            command.Parameters.AddWithValue("@GenreID", GenreID);
            command.Parameters.AddWithValue("@PriceBorrwoing", PriceBorrwoing);


            if (AdditionalDetails != "" && AdditionalDetails != null)
                command.Parameters.AddWithValue("@AdditionalDetails", AdditionalDetails);
            else
                command.Parameters.AddWithValue("@AdditionalDetails", System.DBNull.Value);


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

        public static DataTable GetAllBooks()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Books";

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

        public static DataTable GetAllInfoBooks()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Books.BookID, Books.Title, Authors.AuthorName,Geners.GenerName, " +
                "Books.ISBN,Books.PublicationDate, COUNT(*) AS Quantity, " +
                "Books.AdditionalDetails " +
                "FROM Authors INNER JOIN Books ON Authors.AuthorID = Books.AuthorID " +
                "INNER JOIN Geners ON Books.GenreID = Geners.GenerID " +
                "INNER JOIN BookCopies ON Books.BookID = BookCopies.BookID " +
                "GROUP BY Books.BookID, Books.Title, Authors.AuthorName," +
                " Geners.GenerName, Books.ISBN, Books.PublicationDate, Books.AdditionalDetails";

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
        public static DataTable GetAllInfoBookByID(int BookID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Books.BookID, Books.Title, Authors.AuthorName,Geners.GenerName, " +
                "Books.ISBN,Books.PublicationDate, COUNT(*) AS Quantity, " +
                "Books.AdditionalDetails " +
                "FROM Authors INNER JOIN Books ON Authors.AuthorID = Books.AuthorID " +
                "INNER JOIN Geners ON Books.GenreID = Geners.GenerID " +
                "INNER JOIN BookCopies ON Books.BookID = BookCopies.BookID " +
                "GROUP BY Books.BookID, Books.Title, Authors.AuthorName," +
                " Geners.GenerName, Books.ISBN, Books.PublicationDate, Books.AdditionalDetails " +
                "having Books.BookID=@BookID ";

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

        public static DataTable GetAllInfoBooksForGener(int GenreID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Books.BookID, Books.Title, Books.AuthorID, " +
                " Books.GenreID, Books.ISBN, Count(*) as Quantity,Books.AdditionalDetails " +
                "FROM Books INNER JOIN BookCopies ON Books.BookID = BookCopies.BookID " +
                " group by  Books.BookID, Books.Title, Books.AuthorID, Books.GenreID, " +
                " Books.ISBN,Books.AdditionalDetails " +
                "having Books.GenreID=@GenreID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@GenreID", GenreID);

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



        public static DataTable GetAllInfoBookByIDForShow(int BookID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Books.BookID, Books.Title, Authors.AuthorName,Geners.GenerName, " +
                "Books.PublicationDate " +
                "FROM Authors INNER JOIN Books ON Authors.AuthorID = Books.AuthorID " +
                "INNER JOIN Geners ON Books.GenreID = Geners.GenerID " +
                "where Books.BookID = @BookID ";

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
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable GetAllInfoBookByAuthorName(string AuthorName)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Books.BookID, Books.Title, Authors.AuthorName,Geners.GenerName, " +
                "Books.ISBN,Books.PublicationDate, COUNT(*) AS Quantity, " +
                "Books.AdditionalDetails " +
                "FROM Authors INNER JOIN Books ON Authors.AuthorID = Books.AuthorID " +
                "INNER JOIN Geners ON Books.GenreID = Geners.GenerID " +
                "INNER JOIN BookCopies ON Books.BookID = BookCopies.BookID " +
                "GROUP BY Books.BookID, Books.Title, Authors.AuthorName," +
                " Geners.GenerName, Books.ISBN, Books.PublicationDate, Books.AdditionalDetails " +
                "having Authors.AuthorName like ''+ @AuthorName +'%' ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AuthorName", AuthorName);

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
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool DeleteBook(int BookID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Books 
                                where BookID = @BookID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", BookID);

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

        public static bool IsBookExist(int BookID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Books WHERE BookID = @BookID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", BookID);

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
        public static int CountBooks()
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int CountBook = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select Count(*) from Books";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CountBook = insertedID;
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


            return CountBook;
        }
        


    }
}
