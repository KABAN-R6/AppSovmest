using System;
using System.Runtime.InteropServices.JavaScript;

namespace AvaloniaApplication7.Models;

public class OrderEquipment
{
    public int Id { get; set; }
    public int Client { get; set; }
    public string Worker { get; set; }
    public int worker { get; set; }
    public string TypeEquip { get; set; }
    public int typeEquip { get; set; }
    public string TypeFault { get; set; }
    public int typeFault { get; set; }
    public int SerialNumber {get; set; }
    public string  DescriptionProblem {get; set; }
}