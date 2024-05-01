using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace WebApp.Models
{
    public class LoginModel
    {
        [Key] public int Id { get; set; }
        public string? Username { get; set; }
		public string? Password { get; set; }
		private const string ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=WebAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public LoginModel(string username, string password)
		{
			Username = username;
			Password = password;
		}

        public LoginModel()
        {
            Username = null;
            Password = null;
        }

        public bool ValidateLogin()
        {
	        var success = false;

	        string queryString =
		        "select * from dbo.Logins where Username = @Username and Password = @Password;";

	        using (var connection = new SqlConnection(ConnectionString))
	        {
		        SqlCommand command = new SqlCommand(queryString, connection);
		        command.Parameters.AddWithValue("@Username", Username);
		        command.Parameters.AddWithValue("@Password", Password);
		        try
		        {
			        connection.Open();
			        SqlDataReader r = command.ExecuteReader();
                    if (r.HasRows) success = true;
                    r.Close();
                    command = new SqlCommand("SELECT SCOPE_IDENTITY();", connection);
                    Id = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                }
		        catch (Exception e)
		        {
                    Console.WriteLine(e.Message);
		        }
			}

	        return success;
        }

        public void AddToDatabase()
        {

            if (ValidateLogin()) return;

            const string commandText = "INSERT INTO dbo.Logins (Username, Password) VALUES (@Username, @Password); SELECT SCOPE_IDENTITY();";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);

                try
                {
                    connection.Open();
                    Id = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void DeleteFromDatabase()
        {
            const string deleteCommand = "DELETE FROM dbo.Voters WHERE Username = @Username AND Password = @Password;";

            using (var connection = new SqlConnection(ConnectionString))
            {

                var delete = new SqlCommand(deleteCommand, connection);
                delete.Parameters.AddWithValue("@Username", Username);
                delete.Parameters.AddWithValue("@Password", Password);

                try
                {
                    connection.Open();

                    delete.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
