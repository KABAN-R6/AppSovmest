using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication7.Models;
using Avalonia.Markup.Xaml;
using MySqlConnector;

namespace AppSovmest;

public partial class ListOrders : Window
{
    private List<OrderEquipment> orderEquipmentt { get; set; }

    private Client _client;
    public ListOrders(Client client)
    {
        _client = client;
        InitializeComponent();
        orderEquipmentt = new List<OrderEquipment>();
        update();
        listOrders.ItemsSource = orderEquipmentt;
    }

    private void update()
    {
        using (var connection = new MySqlConnection(new DBHelper()._connectionString.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM orderequipment " +
                                      "JOIN workers On orderequipment.Worker = workers.id " +
                                      "JOIN typefaults ON orderequipment.TypeFault = typefaults.id " +
                                      "JOIN typeequipments ON orderequipment.TypeEquip = typeequipments.id " +
                                      "WHERE Client = @id ";
                command.Parameters.AddWithValue("@id", _client.Id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orderEquipmentt.Add(new OrderEquipment()
                        {
                            Id = reader.GetInt32("Id"),
                            Client = reader.GetInt32("Client"),
                            Worker = reader.GetString("name"),
                            TypeEquip = reader.GetString(14),
                            TypeFault = reader.GetString(12),
                            SerialNumber = reader.GetInt32("SerialNumber"),
                            DescriptionProblem = reader.GetString("DescriptionProblem"),

                        });
                    }

                }
            }
            connection.Close();
        }
    }

    private void OpenAddOrder(object? sender, RoutedEventArgs e)
    {
        new AddOrderEquipment(_client).Show();
    }
}