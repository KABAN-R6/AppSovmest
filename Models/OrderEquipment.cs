using System;
using System.Runtime.InteropServices.JavaScript;

namespace AvaloniaApplication7.Models;

public class OrderEquipment
{
    public int Id { get; set; }
    public int Client { get; set; }
    public int Worker { get; set; }

    public int TypeEquip { get; set; }
    
    public int TypeFault { get; set; }
    public int SerialNumber {get; set; }
    public string  DescriptionProblem {get; set; }
}