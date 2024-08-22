using Avalonia.Controls;

namespace JsonPad.Models.Page;

public class PageView
{
    public string Icon {get; set;}
    public UserControl Page { get; set; }
    public string Title { get; set; }
}