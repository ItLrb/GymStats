using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GymStats.PointsData
{
    public class DistPoints
    {
        public string Race { get; set; } = "Saiyan"; 
        public string Transformation { get; set; } = "Base";
        private static string _filePath = "points.json";

        public static DistPoints Load() 
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<DistPoints>(json) ?? new DistPoints();
            }
            return new DistPoints();
        }

        public void Save() 
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(_filePath, json);
        } 
    

    }
}