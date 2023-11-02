namespace AvaloniaApplication7.Models;

public class Workers
{
    public int Id { get; set; }
    public string name { get; set; }
    public string login { get; set; }
    public string Password { get; set; }

    public Workers(int id, string Name, string login, string password)
    {
        Id = id;
        name = Name;
        this.login = login;
        Password = password;
    }
}