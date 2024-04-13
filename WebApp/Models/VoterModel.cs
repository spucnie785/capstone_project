using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class VoterModel
    {
        [Key] public string Id { get; }

        private LoginModel Login { get; set; }

    private string Name { get; }
        private protected string? Choice { get; set; }
        public bool Voted = false;


        public VoterModel(string id, string username, string password, string name, string choice, bool voted)
        {
            Id = id;
            Login = new LoginModel(username, password);
            Name = name;
            Choice = choice;
            Voted = voted;
        }

        public VoterModel(string id, LoginModel login, string name, string choice, bool voted)
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
    }
}