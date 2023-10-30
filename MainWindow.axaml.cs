using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication7.Models;
using MySqlConnector;

namespace AppSovmest;

public partial class MainWindow : Window
{
    private List<Client> Clients { get; set; }
    public DBHelper db = new DBHelper();
    public MainWindow()
    {
        
        InitializeComponent();
        Clients = new List<Client>();
        UpdateData();
    }
    
    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {;
        
        var loginuser = LoginBOX.Text;
        var passuser = PasswordBOX.Text;

        foreach (var client in Clients)
        {
            if (loginuser.Equals(client.login) && passuser.Equals(client.Password))
            {
                new Profile(client).Show();
                Close();
                break;
                
            }
        }
        
    }

    public void UpdateData()
    {
        using (var connection = new MySqlConnection(db._connectionString.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT *FROM clients";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Clients.Add(new Client(reader.GetInt16("Id"), 
                        reader.GetString("name"), 
                        reader.GetString("login"),
                        reader.GetString("Password")));
                }
            }

            connection.Close();
        }
    }
    
    
}