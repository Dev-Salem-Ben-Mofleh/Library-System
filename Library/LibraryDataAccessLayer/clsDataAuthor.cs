using System;
using System.Data.SqlClient;
using System.Data;
using System.Security.AccessControl;

namespace LibraryDataAccessLayer
{
    public class clsDataAuthor
    {
        public static bool GetAuthorInfoByID(int AuthorID, ref string AuthorName, ref string Bio,
            ref int EducationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Authors WHERE AuthorID = @AuthorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AuthorID", AuthorID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    AuthorName = (string)reader["AuthorName"];
                    EducationID = (int)reader["EducationID"];
                    

                    //ImagePath: allows null in database so we should handle null
                    if (reader["Bio"] != DBNull.Value)
                    {
                        Bio = (string)reader["Bio"];
                    }
                    else
                    {
                        Bio = "";
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


        public static bool GetAuthorInfoByAuthorName(string AuthorName, ref int AuthorID, ref string Bio,
            ref int EducationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Authors WHERE AuthorName = @AuthorName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AuthorName", AuthorName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    AuthorID = (int)reader["AuthorID"];
                    EducationID = (int)reader["EducationID"];


                    //ImagePath: allows null in database so we should handle null
                    if (reader["Bio"] != DBNull.Value)
                    {
                        Bio = (string)reader["Bio"];
                    }
                    else
                    {
                        Bio = "";
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

        public static int AddNewAuthor( string AuthorName,  string Bio,
            int EducationID)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int AuthorID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Authors (AuthorName, Bio, EducationID)
                             VALUES (@AuthorName, @Bio, @EducationID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AuthorName", AuthorName);
            command.Parameters.AddWithValue("@EducationID", EducationID);

            if (Bio != "" && Bio != null)
                command.Parameters.AddWithValue("@Bio", Bio);
            else
                command.Parameters.AddWithValue("@Bio", System.DBNull.Value);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    AuthorID = insertedID;
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


            return AuthorID;
        }

        public static bool UpdateAuthor(int AuthorID,  string AuthorName,  string Bio,
             int EducationID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Authors  
                            set AuthorName = @AuthorName, 
                                Bio = @Bio,
                                EducationID = @EducationID  
                                where AuthorID = @AuthorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AuthorID", AuthorID);
            command.Parameters.AddWithValue("@AuthorName", AuthorName);
            command.Parameters.AddWithValue("@EducationID", EducationID);
            

            if (Bio != "" && Bio != null)
                command.Parameters.AddWithValue("@Bio", Bio);
            else
                command.Parameters.AddWithValue("@Bio", System.DBNull.Value);


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

        public static DataTable GetAllAuthors()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Authors";

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

        public static DataTable GetAllInfoAuthors()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Authors.AuthorID, Authors.AuthorName, Educations.EducationName, " +
                "Authors.Bio FROM Authors INNER JOIN Educations ON Authors.EducationID = Educations.EducationID";

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



        public static bool DeleteAuthor(int AuthorID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Authors 
                                where AuthorID = @AuthorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AuthorID", AuthorID);

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

        public static bool IsAuthorExist(int AuthorID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Authors WHERE AuthorID = @AuthorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AuthorID", AuthorID);

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

        public static int CountAuthors()
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int CountAuthors = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select Count(*) from Authors";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CountAuthors = insertedID;
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


            return CountAuthors;
        }

    }
}
