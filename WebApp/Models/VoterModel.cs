using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

namespace WebApp.Models
{
    public class VoterModel
    {
        public LoginModel? Login { get; set; }
        [Key] public int Id { get; set; }
        public string? Name { get; }
        public string? Choice { get; set; }
        public bool Voted = false;
        private const string ConnectionString =
            "Data Source=(localdb)\\ProjectModels;Initial Catalog=WebAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


        public VoterModel()
        {
            Login = null;
            Name = null;
            Choice = "None";
            Voted = false;
        }
        public VoterModel(string username, string password, string name, string choice, bool voted)
        {
            Login = new LoginModel(username, password);
            Name = name;
            Choice = choice;
            Voted = voted;

            
        }

        public VoterModel(LoginModel login, string name, string choice, bool voted)
        {
            Login = login;
            Name = name;
            Choice = choice;
            Voted = voted;
        }

        public VoterModel(int id, LoginModel login, string name, string choice, bool voted)
        {
            Id = id;
            Login = login;
            Name = name;
            Choice = choice;
            Voted = voted;
        }

        public void ChangedChoice(string choice)
        {
            Choice = choice;
        }

        public void ClearedChoice()
        {
            Choice = null;
            Voted = false;
        }

        public string? GetChoice()
        {
            return Choice;
        }

        /**
         * returns 0 if it adds the new user to the database perfectly fine
         * returns 2 if there was an error
        **/
        public int AddToDatabase()
        {
            Login.AddToDatabase();
            const string commandText =
                "INSERT INTO dbo.Voters (Name, Choice, Voted, LoginId) VALUES (@Name, @Choice, @Voted, @LoginId); SELECT SCOPE_IDENTITY();";


            using (var connection = new SqlConnection(ConnectionString))
            {

                var command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Choice", Choice);
                command.Parameters.AddWithValue("@Voted", (Voted) ? 1 : 0);
                command.Parameters.AddWithValue("@LoginId", Login.Id);
                
                try
                {
                    connection.Open();

                    //Testing to see if user is already in the database
                    var testString = "SELECT * FROM dbo.Voters WHERE Name = @Name AND LoginId = @LoginId;";
                    var testcommand = new SqlCommand(testString, connection);
	                testcommand.Parameters.AddWithValue("@Name",Name);
                    testcommand.Parameters.AddWithValue("@LoginId", Login.Id);

                    SqlDataReader r = testcommand.ExecuteReader();
                    if (r.HasRows)
                    {
                        r.Close();
	                    command = new SqlCommand(testString, connection);
	                    Id = Convert.ToInt32(command.ExecuteScalar());
	                    return 2;
                    }
                    r.Close();

                    Id = Convert.ToInt32(command.ExecuteScalar());

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return 2;
                }
            }

            return 0;
        }

        public void DeleteFromDatabase()
        {
            const string commandText = "DELETE FROM dbo.Voters WHERE LoginId = @LoginId";

            
            using (var connection = new SqlConnection(ConnectionString))
            {

                var command = new SqlCommand(commandText, connection);
                Login.DeleteFromDatabase();
                command.Parameters.AddWithValue("@LoginId", Login.Id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public VoterModel GetFromDatabaseWithLogin(LoginModel login)
        {
            VoterModel model = null;

            var queryString = "SELECT FROM dbo.Voters WHERE LoginId = @LoginId;";

            using (var connection = new SqlConnection(ConnectionString))
            {

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@LoginId", login.Id);

                try
                {
                    connection.Open();
                    SqlDataReader r = command.ExecuteReader();
                    model = new VoterModel(r.GetInt32(0), login, r.GetString(1), r.GetString(2), r.GetBoolean(3));
                    model.Login.Id = r.GetInt32(4);
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }

            }

            return model;
        }
    }
}