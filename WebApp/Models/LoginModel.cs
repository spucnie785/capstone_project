using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class LoginModel
    {
        [Key] public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

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
    }
}
