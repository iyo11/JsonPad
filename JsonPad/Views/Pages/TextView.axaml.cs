using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JsonPad.ViewModels.Pages;

namespace JsonPad.Views.Pages;

public partial class TextView : UserControl
{
    public TextView()
    {
        InitializeComponent();
        DataContext = new TextViewModel();
    }
}