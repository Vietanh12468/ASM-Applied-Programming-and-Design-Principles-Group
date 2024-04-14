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
    public static void AddToJson<T>(List<T>? list, string filePath)
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
        T objFind = (T)Activator.CreateInstance(typeof(T));
        PropertyInfo idProperty = typeof(T).GetProperty("id");
        foreach (var obj in list)
        {
            var objId = Convert.ToInt32(idProperty.GetValue(obj));
            if (objId == id)
            {
                objFind = obj;
                break;
            }
        }
        return objFind;
    }
    public static T FindObj<T>(List<T>? list, string name)
    {
        //create new T object
        T objFind = (T)Activator.CreateInstance(typeof(T));
        PropertyInfo nameProperty = typeof(T).GetProperty("name");
        foreach (var obj in list)
        {
            var objName = nameProperty.GetValue(obj);
            if (string.Equals(objName, name))
            {
                objFind = obj;
                break;
            }
        }
        return objFind;
    }

    public static T FindObjByEmail<T>(List<T>? list, string email)
    {
        T objFind = default(T);
        PropertyInfo emailProperty = typeof(T).GetProperty("email");
        bool found = false;
        foreach (var obj in list)
        {
            var objEmail = emailProperty.GetValue(obj);
            if (string.Equals(objEmail, email))
            {
                objFind = obj;
                found = true;
                break;
            }
        }

        if (!found)
        {
            objFind = default(T);
        }

        return objFind;
    }
}