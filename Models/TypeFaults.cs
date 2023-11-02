namespace AvaloniaApplication7.Models;

public class TypeFaults
{
    public int Id { get; set; }
    public string Name { get; set; }

    public TypeFaults(int id, string name)
    {
        Id = id;
        Name = name;
    }
}