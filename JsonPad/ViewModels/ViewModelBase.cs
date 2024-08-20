using CommunityToolkit.Mvvm.ComponentModel;

namespace JsonPad.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty] private string _modelName;

    protected ViewModelBase()
    {
        ModelName = GetType().Name;
    }
}