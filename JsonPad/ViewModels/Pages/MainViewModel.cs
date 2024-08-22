using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JsonPad.Models.Page;
using JsonPad.Views.Pages;

namespace JsonPad.ViewModels.Pages;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private PageView _currentPage = new();

    [ObservableProperty] private ObservableCollection<PageView> _pages = [];
    

    public MainViewModel()
    {
        AddJsonPage();
        if (Pages.Count > 0)
        {
            CurrentPage = Pages[0];
        }
    }

    partial void OnCurrentPageChanged(PageView value)
    {
    }
    

    [RelayCommand]
    private void ClosePage(PageView pageView)
    {
        Pages.Remove(pageView);
    }

    [RelayCommand]
    private void AddJsonPage()
    {
        Pages.Add(new PageView
        {
            Icon = "json_file",
            Page = new JsonView(),
            Title = $"New Page [{Pages.Count + 1}]"
        });
    }
    
    [RelayCommand]
    private void AddTextPage()
    {
        Pages.Add(new PageView
        {
            Icon = "text_file",
            Page = new TextView(),
            Title = $"New Page [{Pages.Count + 1}]"
        });
    }
}