using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace WebApp.Models
{
    public class LoginModel
    {
        [Key] public int Id { get; set; }
        public string Username { get; set; }
		public string Password { get; set; }
		private string ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog = VoterAppDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False";

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

        public bool ValidateLogin(LoginModel login)
        {
	        var success = false;

	        string queryString = "select * from dbo.Logins where Username = @Username and Password = @Password";

	        using (var connection = new SqlConnection(ConnectionString))
	        {
		        SqlCommand command = new SqlCommand(queryString, connection);
		        command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = login.Username;
		        command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = login.Password;
		        try
		        {
			        connection.Open();
			        SqlDataReader r = command.ExecuteReader();

			        if (r.HasRows) success = true;
		        }
		        catch (Exception e)
		        {
                    Console.WriteLine(e.Message);
		        }
			}

           

	        return success;
        }
    }
}
