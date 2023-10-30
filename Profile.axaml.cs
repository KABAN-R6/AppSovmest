using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AppSovmest;

public partial class Profile : Window
{
    public Profile()
    {
        InitializeComponent();
    }
   
    private void BtnOrderClick(object? sender, TappedEventArgs e)
    {
        new AddOrderEquipment().Show();

    }

    private void LogOutClick(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }

    
}