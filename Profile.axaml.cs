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

    private void InputElement_OnTapped(object? sender, TappedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void LogOutClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    private void BtnOrderClick(object? sender, TappedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}