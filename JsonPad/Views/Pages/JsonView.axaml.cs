using Avalonia.Controls;
using JsonPad.ViewModels.Pages;

namespace JsonPad.Views.Pages;

public partial class JsonView : UserControl
{
    public JsonView()
    {
        InitializeComponent();
        DataContext = new JsonViewModel();
    }
}