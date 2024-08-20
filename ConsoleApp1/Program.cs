using System;
using System.Text.Json.Nodes;

namespace ConsoleApp1;

internal class Program
{
    private static void Main(string[] args)
    {
        json();
        Console.ReadLine();
    }


    public static void json()
    {
        var json = @"{
            ""name"": ""John Doe"",
            ""age"": 30,
            ""isEmployed"": true,
            ""address"": {
                ""street"": ""123 Main St"",
                ""city"": ""Anytown"",
                ""state"": ""CA""
            },
            ""phoneNumbers"": [
                { ""type"": ""home"", ""number"": ""555-1234"" },
                { ""type"": ""work"", ""number"": ""555-5678"" }
            ]
        }";

        ParseJson(json);
    }

    private static void ParseJson(string jsonString)
    {
        var node = JsonNode.Parse(jsonString);

        if (node is JsonObject jsonObject)
        {
            PrintJsonObject(jsonObject, "");
        }
        else if (node is JsonArray jsonArray)
        {
            Console.WriteLine("Array:");
            for (var i = 0; i < jsonArray.Count; i++)
            {
                Console.WriteLine($"Item {i}:");
                ParseJson(jsonArray[i].ToJsonString());
            }
        }
        else
        {
            Console.WriteLine("Not a valid JSON object or array.");
        }
    }

    private static void PrintJsonObject(JsonObject jsonObject, string prefix)
    {
        foreach (var property in jsonObject)
        {
            //Console.WriteLine($"{prefix}{property.Key}: {property.Value.GetType().Name}");
            Console.WriteLine($"{prefix}{property.Key}:");

            if (property.Value is JsonObject subObject)
            {
                PrintJsonObject(subObject, $"{prefix}  ");
            }
            else if (property.Value is JsonArray subArray)
            {
                Console.WriteLine($"{prefix}  Array:");
                for (var i = 0; i < subArray.Count; i++)
                {
                    Console.WriteLine($"{prefix}  Item {i}:");
                    ParseJson(subArray[i].ToJsonString());
                }
            }
            else
            {
                Console.WriteLine($"{prefix}  {property.Value}");
            }
        }
    }
}