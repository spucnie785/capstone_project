public class Voter
{
    public string Id { get; } = null;
    private string Password { get; } = null;
    private string Name { get; } = null;
    public string Choice { get; set; } = null;
    public bool Voted = false;

    
    public Voter(string id, string password, string name, string choice, bool voted)
    {
        this.Id = id;
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
}
