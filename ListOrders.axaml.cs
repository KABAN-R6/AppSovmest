using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using AvaloniaApplication7.Models;
using Avalonia.Markup.Xaml;

namespace AppSovmest;

public partial class ListOrders : Window
{
    public ListOrders()
    {
        InitializeComponent();
        List<OrderEquipment> orders = new List<OrderEquipment>();
        orders.Add(new OrderEquipment()
        {
            Id = 1,
            Client = 1,
            DescriptionProblem = "Проблема"
            
        });
        listOrders.ItemsSource= orders;
    }
}