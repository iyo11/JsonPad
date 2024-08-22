using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace JsonPad.ViewModels.Pages;

public partial class TextViewModel : ViewModelBase
{
    [ObservableProperty] private string _text = "";
    
    [ObservableProperty] private string _infoText = "";
    
    [ObservableProperty]
    private int _fontSize = 15;
    
    public TextViewModel()
    {
        InfoText = $"Length:{Text.Length}";
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
    
    partial void OnTextChanged(string value)
    {
        InfoText = $"Length:{value.Length}";
    }

}