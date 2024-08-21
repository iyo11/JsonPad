using System.Collections.ObjectModel;

namespace JsonPad.Models.Json;

public class Node
{
    public string Name { get; set; }
    public string Path { get; set; }
    public ObservableCollection<Node> Children { get; set; } = [];
}