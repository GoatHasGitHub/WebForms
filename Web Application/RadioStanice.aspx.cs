using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Web_Application
{
	public partial class RadioStanice : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// Load data into GridView during the first load of the page
				BindGrid();
			}
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			string name = txtName.Text.Trim();
			string description = txtDescription.Text.Trim();

			if (IsProductNameExists(name))
			{
				lblErrorMessage.Text = "Product with the same name already exists.";
				lblErrorMessage.Visible = true;
			}
			else
			{
				// Save the product to the database
				SaveProduct(name, description);

				// Refresh GridView after saving
				BindGrid();

				// Clear input fields after saving
				ClearInputFields();
			}
		}

		protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			// Delete product from the database
			int productId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["Id"]);
			DeleteProduct(productId);

			// Refresh GridView after deletion
			BindGrid();
		}

		private bool IsProductNameExists(string productName)
		{
			// Check if the product name already exists in the database
			using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
			{
				connection.Open();
				string query = "SELECT COUNT(*) FROM Products WHERE Name = @ProductName";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@ProductName", productName);
					int count = (int)command.ExecuteScalar();
					return count > 0;
				}
			}
		}

		private void SaveProduct(string name, string description)
		{
			// Save the product to the database
			using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
			{
				connection.Open();
				string query = "INSERT INTO Products (Name, Description) VALUES (@Name, @Description)";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@Name", name);
					command.Parameters.AddWithValue("@Description", description);
					command.ExecuteNonQuery();
				}
			}
		}

		private void DeleteProduct(int productId)
		{
			// Delete product from the database
			using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
			{
				connection.Open();
				string query = "DELETE FROM Products WHERE Id = @Id";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@Id", productId);
					command.ExecuteNonQuery();
				}
			}
		}

		private void BindGrid()
		{
			// Bind the GridView with data
			string connectionString = ConnectionStringProvider.ConnectionString;
			string query = "SELECT Id, Name, Description FROM Products";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
				{
					System.Data.DataTable dataTable = new System.Data.DataTable();
					adapter.Fill(dataTable);

					GridView1.DataSource = dataTable;
					GridView1.DataBind();
				}
			}
		}

		private void ClearInputFields()
		{
			// Clear input fields
			txtName.Text = string.Empty;
			txtDescription.Text = string.Empty;
			lblErrorMessage.Text = string.Empty;
			lblErrorMessage.Visible = false;
		}

		protected void txtName_TextChanged(object sender, EventArgs e)
		{

		}
	}
}