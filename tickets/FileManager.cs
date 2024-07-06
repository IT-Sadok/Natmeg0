using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ConsoleApp8
{
    public class FileManager<T>
{
    private string _filePath;

    public FileManager()
    {
        _filePath = $"{typeof(T).Name}.json";
    }

    public void Save(T data)
    {
        string json = JsonSerializer.Serialize(data);
        File.WriteAllText(_filePath, json);
    }

    public T? Read()
    {
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<T>(json);
        }
        return default(T);
    }
}

}
