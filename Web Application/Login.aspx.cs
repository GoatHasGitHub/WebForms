using System;
using System.Data.SqlClient;

namespace Web_Application
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Implement logic to check if the user exists in the database with the provided credentials
            if (ValidateUser(username, password))
            {
                // Redirect to a success page or perform any other actions for successful login
                Response.Redirect("~/RadioStanice.aspx");
            }
            else
            {
                // Display an error message for unsuccessful login
                lblErrorMessage.Text = "Invalid username or password.";
            }
        }

        private bool ValidateUser(string username, string password)
        {
            // Database connection string
            string connectionString = ConnectionStringProvider.ConnectionString;

            // Query to check if the user exists with the provided credentials
            string query = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName AND Password = @Password";

            // Using statement ensures proper disposal of resources
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Use parameterized query to prevent SQL injection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@Password", password);

                    // ExecuteScalar returns the number of rows matching the query
                    int count = (int)command.ExecuteScalar();

                    // If count is greater than 0, a matching user was found
                    return count > 0;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
			Response.Redirect("~/Default.aspx");
		}
    }
}
