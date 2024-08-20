using System.Collections.ObjectModel;

namespace JsonPad.Models.Json;

public class Node
{
    public string Name { get; set; }
    public ObservableCollection<Node> Children { get; set; } = [];
}