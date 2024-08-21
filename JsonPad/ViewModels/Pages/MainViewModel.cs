using System;
using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JsonPad.Models.Page;
using JsonPad.Views.Pages;

namespace JsonPad.ViewModels.Pages;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private PageView _currentPage = new();

    [ObservableProperty] private ObservableCollection<PageView> _pages = [];
    
    [ObservableProperty]
    private Thickness _marginAddButton = new Thickness(0, 0, 0, 0);

    

    public MainViewModel()
    {
        AddPage();
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
        var left = Pages.Count * 136;
        MarginAddButton = new Thickness(left, 0, 0, 0);
    }

    [RelayCommand]
    private void AddPage()
    {
        Pages.Add(new PageView
        {
            Page = new JsonView(),
            Title = $"New Page [{Pages.Count + 1}]"
        });
        var left = Pages.Count * 136;
        MarginAddButton = new Thickness(left, 0, 0, 0);
    }
}