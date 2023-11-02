using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication7.Models;
using MySqlConnector;

namespace AppSovmest;

public partial class AddOrderEquipment : Window
{
    private DBHelper db = new DBHelper();
    private Client _client;
    private List<Workers> _workersList = new List<Workers>();
    private List<TypeEquipments> _equipmentsList = new List<TypeEquipments>();
    private List<TypeFaults> _faultsList = new List<TypeFaults>();
    public AddOrderEquipment(Client client)
    {
        InitializeComponent();
        _client = client;
        UpdateComboBox();
    }


    private void InsertOrder(object? sender, RoutedEventArgs e)
    {
        using (var conn = new MySqlConnection(db._connectionString.ConnectionString))
        {
            
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO orderequipment (Client,Worker,TypeEquip,TypeFault,SerialNumber,DescriptionProblem) " +
                                  "VALUES (@Client,@Worker,@TypeEquip,@TypeFault,@SerialNumber,@DescriptionProblem);";
                cmd.Parameters.AddWithValue("@Client", "sad");
                cmd.Parameters.AddWithValue("@Worker", "");
                cmd.Parameters.AddWithValue("@TypeEquip", "sad");
                cmd.Parameters.AddWithValue("@TypeFault", "sad");
                cmd.Parameters.AddWithValue("@SerialNumber", "sad");
                cmd.Parameters.AddWithValue("@DescriptionProblem", "sad");
                cmd.ExecuteNonQueryAsync();
            }
            conn.Close();
        }
    }

    private void UpdateComboBox()
    {
        using (var conn = new MySqlConnection(db._connectionString.ConnectionString))
        {
            
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM workers cross join typefaults cross join typeequipments";
                
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _workersList.Add(new Workers(
                        reader.GetInt16(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)));
                    _faultsList.Add(new TypeFaults(
                        reader.GetInt16(4),
                        reader.GetString(5)));
                    _equipmentsList.Add(new TypeEquipments(
                        reader.GetInt16(6),
                        reader.GetString(7)));
                }
            }
            conn.Close();
        }

        cbWorker.ItemsSource = _workersList.Select(u => u.name).Distinct().ToList();
        cbTypeEquip.ItemsSource = _equipmentsList.Select(u => u.Name).Distinct().ToList();
        cbTypeFault.ItemsSource = _faultsList.Select(u => u.Name).Distinct().ToList();
    }
}