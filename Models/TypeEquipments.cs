namespace AvaloniaApplication7.Models;

public class TypeEquipments
{
    public int Id { get; set; }
    public string Name { get; set; }

    public TypeEquipments(int id, string name)
    {
        Id = id;
        Name = name;
    }
}