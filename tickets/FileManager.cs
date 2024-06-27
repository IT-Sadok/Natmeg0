using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ConsoleApp8
{
    public class FileManager
    {
        private const string filePath = "tickets.json";

        void Save(List<Ticket> tickets)
        {
            string json = JsonSerializer.Serialize(tickets);
            File.WriteAllText(filePath, json);
        }

       public List<Ticket> Read()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Ticket>>(json);
            }
            return new List<Ticket>();
        }
       
       
    }

}
