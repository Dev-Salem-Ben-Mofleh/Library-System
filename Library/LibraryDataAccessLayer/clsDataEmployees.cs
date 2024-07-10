using System;
using System.Data.SqlClient;
using System.Data;


namespace LibraryDataAccessLayer
{
    public class clsDataEmployees
    {
        public static bool GetEmployeeInfoByID(int EmployeeID, ref decimal Salary, ref int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Salary = (decimal)reader["Salary"];
                    PersonID = (int)reader["PersonID"];
                    
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

        public static int AddNewEmployee(decimal Salary, int PersonID)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int EmployeeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Employees (Salary, PersonID)
                             VALUES (@Salary, @PersonID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Salary", Salary);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    EmployeeID = insertedID;
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


            return EmployeeID;
        }

        public static bool UpdateEmployee(int EmployeeID, decimal Salary, int PersonID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Employees  
                            set Salary = @Salary, 
                                PersonID = @PersonID
                                where EmployeeID = @EmployeeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            command.Parameters.AddWithValue("@Salary", Salary);
            command.Parameters.AddWithValue("@PersonID", PersonID);



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

        public static DataTable GetAllEmployees()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Employees";

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

        public static DataTable GetAllInfoEmployees()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Employees.EmployeeID, Persons.FirstName+' '+Persons.LastName as FullName, " +
                "Persons.UserName, Persons.Email, Persons.Password, Persons.Permissions, Employees.Salary FROM " +
                "Persons INNER JOIN Employees ON Persons.PersonID = Employees.PersonID";


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
       
        public static bool DeleteEmployee(int EmployeeID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Employees 
                                where EmployeeID = @EmployeeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

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

        public static bool IsEmployeeExist(int EmployeeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Employees WHERE EmployeeID = @EmployeeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

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
        public static int CountEmployees()
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int CountEmployees = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select Count(*) from Employees";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CountEmployees = insertedID;
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


            return CountEmployees;
        }

    }
}
