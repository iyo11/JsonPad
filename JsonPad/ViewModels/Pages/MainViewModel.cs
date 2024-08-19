using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using JsonPad.Models.Json;
using JsonPad.Services;

namespace JsonPad.ViewModels.Pages;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<Node> _nodeTree;

    [ObservableProperty] 
    private string _jsonText = "";
    
    [ObservableProperty]
    private string _warningText = "";

    public MainViewModel()
    {

    }

    partial void OnJsonTextChanged(string value)
    {
        try
        {
            WarningText = "";
            NodeTree = new JsonService().LoadJsonData(value);
        }
        catch (Exception e)
        {
            WarningText = e.Message;
        }
    }
}
