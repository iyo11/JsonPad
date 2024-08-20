using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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