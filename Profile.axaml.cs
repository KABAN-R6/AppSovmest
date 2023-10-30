using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication7.Models;
using MySqlConnector;

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
        new ListOrders(currentClient).Show();
        
    }

    private void LogOutClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    
}