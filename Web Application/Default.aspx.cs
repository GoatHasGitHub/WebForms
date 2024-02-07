using System;
using System.Data.SqlClient;

namespace Web_Application
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string fullName = txtFullName.Text;
            string password = txtPassword.Text;
            string repeatPassword = txtRepeatPassword.Text;

            // Check if passwords match
            if (password != repeatPassword)
            {
                lblErrorMessage.Text = "Passwords do not match.";
                return;
            }

            // Check if the user already exists
            if (!UserExists(username))
            {
                // Perform user registration (you may want to hash the password for security)
                if (RegisterUser(username, fullName, password))
                {
                    // Redirect to Login.aspx after successful registration
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    lblErrorMessage.Text = "Registration failed. Please try again.";
                }
            }
            else
            {
                lblErrorMessage.Text = "Username already exists. Please choose a different username.";
            }
        }

        private bool UserExists(string username)
        {
            // Check if the user already exists in the database
            using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool RegisterUser(string username, string fullName, string password)
        {
            // Insert new user into the database
            using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (UserName, Password, FullName) VALUES (@UserName, @Password, @FullName)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
			Response.Redirect("Login.aspx");
		}
    }
}
