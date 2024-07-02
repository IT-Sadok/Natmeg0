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
        private const string _filePath = "tickets.json";

        public FileManager() { }
        
        public void Save(List<T> tickets)
        {
            string json = JsonSerializer.Serialize(tickets);
            File.WriteAllText(_filePath, json);
        }

       public List<T> Read()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<T>>(json);
            }
            return new List<T>();
        }
       
       
    }

}
