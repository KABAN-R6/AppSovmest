using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication7.Models;
using MySqlConnector;

namespace AppSovmest;

public partial class AddOrderEquipment : Window
{
    public DBHelper db = new DBHelper();
    public AddOrderEquipment()
    {
        InitializeComponent();
        
       
    }

    
}