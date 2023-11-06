using System;
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
    private OrderEquipment _orderEquipment;
    private List<Workers> _workersList = new List<Workers>();
    private List<TypeEquipments> _equipmentsList = new List<TypeEquipments>();
    private List<TypeFaults> _faultsList = new List<TypeFaults>();
    private ListOrders _window;
    public AddOrderEquipment(Client client,OrderEquipment order,ListOrders window)
    {
        InitializeComponent();
        _client = client;
        _window = window;
        _orderEquipment = order;
        tbClient.Text += " " +client.login +" "+ client.name;
        tbSerialNumber.KeyUp += (sender, e) =>
        {
            // Получаем текст из текстового поля
            string text = tbSerialNumber.Text;

            // Используем регулярное выражение, чтобы оставить только цифры и удалить все остальное
            string cleanText = System.Text.RegularExpressions.Regex.Replace(text, "[^0-9]", "");

            // Обновляем текстовое поле с очищенным текстом
            tbSerialNumber.Text = cleanText;
        };
        
        UpdateComboBox();
        if (_orderEquipment == null)
        {
            btnAcceprOrder.Click += (sender, args) =>
            {
               
            };
        }
        else
        {
            cbWorker.SelectedItem = _workersList.FirstOrDefault(u => u.Id == _orderEquipment.worker);
            cbTypeEquip.SelectedItem = _equipmentsList.FirstOrDefault(u => u.Id == _orderEquipment.typeEquip);
            cbTypeFault.SelectedItem = _faultsList.FirstOrDefault(u => u.Id == _orderEquipment.typeFault);
            tbSerialNumber.Text = _orderEquipment.SerialNumber.ToString();
            tbDescription.Text = _orderEquipment.DescriptionProblem;
            btnAcceprOrder.Click += (sender, args) =>
            {
                UpdateOrder();
                
            };
        }
        
    }
    

    private void UpdateOrder()
    {
        using (var conn = new MySqlConnection(db._connectionString.ConnectionString))
        {
            
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText =
                    "UPDATE orderequipment " +
                    "SET Client = @Client," +
                    "Worker = @Worker," +
                    "TypeEquip = @TypeEquip," +
                    "TypeFault = @TypeFault," +
                    "SerialNumber = @SerialNumber," +
                    "DescriptionProblem = @DescriptionProblem" +
                    " WHERE id = @id; ";
                cmd.Parameters.AddWithValue("@id", _orderEquipment.Id);
                cmd.Parameters.AddWithValue("@Client", _client.Id);
                cmd.Parameters.AddWithValue("@Worker", (cbWorker.SelectedItem as Workers).Id);
                cmd.Parameters.AddWithValue("@TypeEquip", (cbTypeEquip.SelectedItem as TypeEquipments).Id);
                cmd.Parameters.AddWithValue("@TypeFault", (cbTypeFault.SelectedItem as TypeFaults).Id);
                cmd.Parameters.AddWithValue("@SerialNumber", Convert.ToInt32(tbSerialNumber.Text));
                cmd.Parameters.AddWithValue("@DescriptionProblem", tbDescription.Text);
                cmd.ExecuteNonQueryAsync();
            }
            _window.update();
            conn.Close();
            Close();
        }
    }

    private void InsertOrder()
    {
        using (var conn = new MySqlConnection(db._connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText =
                    "INSERT INTO orderequipment (Client,Worker,TypeEquip,TypeFault,SerialNumber,DescriptionProblem) " +
                    "VALUES (@Client,@Worker,@TypeEquip,@TypeFault,@SerialNumber,@DescriptionProblem);";
                cmd.Parameters.AddWithValue("@Client", _client.Id);
                cmd.Parameters.AddWithValue("@Worker", (cbWorker.SelectedItem as Workers).Id);
                cmd.Parameters.AddWithValue("@TypeEquip", (cbTypeEquip.SelectedItem as TypeEquipments).Id);
                cmd.Parameters.AddWithValue("@TypeFault", (cbTypeFault.SelectedItem as TypeFaults).Id);
                cmd.Parameters.AddWithValue("@SerialNumber", Convert.ToInt32(tbSerialNumber.Text));
                cmd.Parameters.AddWithValue("@DescriptionProblem", tbDescription.Text);
                cmd.ExecuteNonQueryAsync();
            }
            _window.update();
            conn.Close();
            Close();
        }
    }

    private void UpdateComboBox()
    {
        using (var conn = new MySqlConnection(db._connectionString.ConnectionString))
        {
            
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM workers";
                
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _workersList.Add(new Workers(
                        reader.GetInt16(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)));
                    
                }
            }
            conn.Close();
        }
        using (var conn = new MySqlConnection(db._connectionString.ConnectionString))
        {
            
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM typeequipments";
                
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _equipmentsList.Add(new TypeEquipments(
                        reader.GetInt16(0),
                        reader.GetString(1)));
                }
            }
            conn.Close();
        }
        using (var conn = new MySqlConnection(db._connectionString.ConnectionString))
        {
            
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM typefaults";
                
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _faultsList.Add(new TypeFaults(
                        reader.GetInt16(0),
                        reader.GetString(1)));
                    
                }
            }
            conn.Close();
        }

        cbWorker.ItemsSource = _workersList;
        cbTypeEquip.ItemsSource = _equipmentsList;
        cbTypeFault.ItemsSource = _faultsList;
    }

    private void Clear(object? sender, RoutedEventArgs e)
    {
        tbEquip.Text = "";
        tbDescription.Text = "";
        tbSerialNumber.Text = "";
        tbDescription.Text = "";
        cbTypeFault.Clear();
        cbTypeEquip.Clear();
        cbWorker.Clear();
        
    }
}