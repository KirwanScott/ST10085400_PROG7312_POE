using System;
using System.Data.SqlClient;

namespace ST10085400_PROG7312_POE.MVVM.Model
{
    public class DBManager
    {
        private static string connString = "Data Source=KIRWAN_SCOTT\\SQLEXPRESS;Initial Catalog=PROGPOE;Integrated Security=SSPI;";
        private SqlConnection connection;

        public DBManager()
        {
            connection = new SqlConnection(connString);
        }

        public bool ValidateUser(string username, string password)
        {
            try
            {
                connection.Open();
                string selectQuery = "SELECT COUNT(*) FROM [User] WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                int userCount = (int)command.ExecuteScalar();

                return userCount > 0; // Return true if a user with the provided credentials exists
            }
            catch (Exception ex)
            {
                // Handle the exception, e.g., log or show an error message.
                Console.WriteLine("Error validating user: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool RegisterUser(string username, string password)
        {
            try
            {
                connection.Open();
                string insertQuery = "INSERT INTO [User] (Username, Password) VALUES (@Username, @Password)";
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0; // Return true if registration was successful
            }
            catch (Exception ex)
            {
                // Handle the exception, e.g., log or show an error message.
                Console.WriteLine("Error registering user: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool UsernameExists(string username)
        {
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM User WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                // Handle exception, e.g., log or show an error message.
                Console.WriteLine("Error checking username existence: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public void AddUser(string username, string password)
        {
            try
            {
                connection.Open();
                string insertQuery = "INSERT INTO User (Username, Password) VALUES (@Username, @Password)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@Username", username);
                insertCommand.Parameters.AddWithValue("@Password", password);
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle exception, e.g., log or show an error message.
                Console.WriteLine("Error adding user: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
