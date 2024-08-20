using System;
using Avalonia.Controls;
using Avalonia.Metadata;
using JsonPad.ViewModels.Pages;

namespace JsonPad.Views.Pages;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}