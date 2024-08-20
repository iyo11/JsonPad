using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using JsonPad.Models.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonPad.Services;

public class JsonService
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };


    public string FormatJson(string json)
    {
        if (string.IsNullOrEmpty(json)) return "";
        try
        {
            var jObject = JObject.Parse(json);
            return JsonConvert.SerializeObject(jObject, Formatting.Indented);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public ObservableCollection<Node> LoadJsonData(string json)
    {
        if (string.IsNullOrEmpty(json)) return [];
        var jObject = JObject.Parse(json);
        if (jObject == null) throw new ArgumentException("Invalid JSON data", nameof(json));
        return ToJsonTree(jObject, new Node().Children);
    }

    private ObservableCollection<Node> ToJsonTree(JToken jToken, ObservableCollection<Node> nodes)
    {
        Node newNode = null;
        switch (jToken.Type)
        {
            case JTokenType.Object:
                newNode = new Node
                {
                    Name = "{ } " + jToken.Path.Split('.').Last(),
                    Children = []
                };

                foreach (var child in jToken.Children<JProperty>())
                    newNode.Children = ToJsonTree(child.Value, newNode.Children);
                break;

            case JTokenType.Array:
                newNode = new Node
                {
                    Name = "[ ] " + jToken.Path.Split('.').Last(),
                    Children = []
                };

                foreach (var child in jToken.Children()) newNode.Children = ToJsonTree(child, newNode.Children);
                break;

            default:
                newNode = new Node
                {
                    Name = $"\"{jToken.Path.Split('.').Last()}\" : \"{jToken}\""
                };
                break;
        }

        nodes.Add(newNode);
        return nodes;
    }
}