using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication7.Models;

namespace AppSovmest;

public partial class Profile : Window
{
    public DBHelper db = new DBHelper();
    private Client currentClient;
    public Profile(Client client)
    {
        InitializeComponent();
        currentClient = client;
        DataContext = client;
    }
   
    private void BtnOrderClick(object? sender, TappedEventArgs e)
    {
        new AddOrderEquipment().Show();
        
    }

    private void LogOutClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    
}