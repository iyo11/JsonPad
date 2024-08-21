using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JsonPad.Binding;
using JsonPad.Models.Json;
using JsonPad.Services;

namespace JsonPad.ViewModels.Pages;

public partial class JsonViewModel : ViewModelBase
{
    private readonly JsonService _jsonService = new();

    [ObservableProperty] private string _infoText = "";

    [ObservableProperty] private string _jsonText = "";

    [ObservableProperty] private ObservableCollection<Node> _nodeTree;

    [ObservableProperty] private string _warningText = "";
        
    [ObservableProperty]
    private int _fontSize = 15;

    [ObservableProperty] 
    private Node _selectNode = new Node();

    
    [ObservableProperty]
    private Dictionary<string,string> _jsonData = [];

    public JsonViewModel()
    {
        InfoText = $"Length:{JsonText.Length}";
    }

    [RelayCommand]
    private void FormatJson()
    {
        try
        {
            JsonText = _jsonService.FormatJson(JsonText);
        }
        catch (Exception e)
        {
            WarningText = e.Message;
        }
    }

    [RelayCommand]
    private void CompressJson()
    {
        JsonText = JsonText.Trim().Replace("\r", "").Replace("\n", "");
    }

    [RelayCommand]
    private void FontSizeUp()
    {
        FontSize++;
    }
    
    [RelayCommand]
    private void FontSizeDown()
    {
        if (FontSize > 5)
        {
            FontSize--;
        }
    }
    

    partial void OnSelectNodeChanged(Node value)
    {
        JsonData = new Dictionary<string, string>
        {
            { "Name", value.Name },
            { "Path", value.Path },
        };

    }

    
    
    partial void OnJsonTextChanged(string oldValue, string newValue)
    {
        try
        {

            if (newValue.Equals(oldValue)) return;
            WarningText = "";
            InfoText = $"Length:{newValue.Length}";
            NodeTree = _jsonService.LoadJsonData(newValue);
        }
        catch (Exception e)
        {
            WarningText = e.Message;
        }
    }
}