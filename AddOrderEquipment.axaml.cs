using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication7.Models;
using MySqlConnector;

namespace AppSovmest;

public partial class AddOrderEquipment : Window
{
    private List<OrderEquipment> orderEquipmentt { get; set; }
    private MySqlConnectionStringBuilder _connectionSb;

    public AddOrderEquipment()
    {
        InitializeComponent();
        orderEquipmentt = new List<OrderEquipment>();
        _connectionSb = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Database = "test",
            UserID = "root",
            Password = "Givig-6812"
        };
        UpdateDataGrid();
    }

    private void UpdateDataGrid()
    {
        using (var connection = new MySqlConnection(_connectionSb.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT *FROM orderequipment";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orderEquipmentt.Add(new OrderEquipment()
                        {
                            Id = reader.GetInt32("Id"),
                            Client = reader.GetInt32("Client"),
                            Worker = reader.GetInt32("Worker"),
                            TypeEquip = reader.GetInt32("TypeEquip"),
                            TypeFault = reader.GetInt32("TypeFault"),
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