using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using AvaloniaApplication7.Models;
using Avalonia.Markup.Xaml;
using MySqlConnector;

namespace AppSovmest;

public partial class ListOrders : Window
{
    private List<OrderEquipment> orderEquipmentt { get; set; }
    private MySqlConnectionStringBuilder _connectionSb;

    public ListOrders()
    {

        InitializeComponent();
        orderEquipmentt = new List<OrderEquipment>();
        _connectionSb = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Database = "pro2",
            UserID = "root",
            Password = "123456"
        };
        update();
        List<OrderEquipment> orders = new List<OrderEquipment>();
        orders.Add(new OrderEquipment()
        {
            Id = 1,
            Client = 1,
            DescriptionProblem = "Проблема"

        });
        orders.Add(new OrderEquipment()
        {
            Id = 32323,
            Client = 6,
            DescriptionProblem = "SD:LKAp[dsk-sakd"

        });
        listOrders.ItemsSource = orders;
    }

    private void update()
    {
        using (var connection = new MySqlConnection(_connectionSb.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM orderequipment " +
                                      "JOIN workers On orderequipment.Worker = workers.id " +
                                      "JOIN typefaults ON orderequipment.TypeFault = typefaults.id " +
                                      "JOIN typeequipments ON orderequipment.TypeEquip = typeequipments.id";
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
}