using ASM2.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
    public static int ReadLastId<T>(List<T>? list)
    {
        if (list != null && list.Count > 0)
        {
            T lastElement = list[list.Count - 1];
            PropertyInfo idProperty = typeof(T).GetProperty("id");
            if (idProperty != null && idProperty.PropertyType == typeof(int))
            {
                int lastId = (int)idProperty.GetValue(lastElement);
                return lastId;
            }
        }
        return 0;
    }

    public static T FindObj<T>(List<T>? list, int id)
    {
        //create new T object
        T objRemove = (T)Activator.CreateInstance(typeof(T));


        if (list == null)
        {
            return default(T);
        }

        PropertyInfo idProperty = typeof(T).GetProperty("id");
        if (idProperty == null || idProperty.PropertyType != typeof(int))
        {
            return default(T);
        }

        /*        // Find the object with the specified ID
        return list.Find(obj => Convert.ToInt32(idProperty.GetValue(obj)) == id);*/

        foreach (var obj in list)
        {
            var objId = Convert.ToInt32(idProperty.GetValue(obj));
            if (objId == id)
            {
                objRemove = obj;
                break;
            }
        }

        return objRemove;
    }

}