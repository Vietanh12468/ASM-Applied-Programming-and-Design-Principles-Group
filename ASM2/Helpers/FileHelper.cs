using ASM2.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

public static class FileHelper
{
    public static List<T>? ReadFileList<T>(string filePath)
    {
        string readText = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<T>>(readText);
    }
    public static void AddToList<T>(List<T>? list, string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(list, options);
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.Write(jsonString);
        }
    }
}