public class Voter
{
    public string Id { get; } = null;
    private string Username { get; } = null;
    private string Password { get; } = null;
    private string Name { get; } = null;
    private protected string Choice { get; set; } = null;
    public bool Voted = false;

    
    public Voter(string id, string username, string password, string name, string choice, bool voted)
    {
        this.Id = id;
        Username = username;
        Password = password;
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

    public string GetChoice()
    {
        return Choice;
    }
}
