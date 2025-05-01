using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json;
using System.Threading.Tasks;
using GymStats.PointsData;

/*
    
*/


public class Stats 
{
    public int Biceps { get; set; } = 0;
    public int Triceps { get; set; } = 0;
    public int Chest { get; set; } = 0;
    public int Legs { get; set; } = 0;
    public int Back { get; set; } = 0;
    public int Shoulders { get; set; } = 0;
    public int Forearm { get; set; } = 0;
    public int Abs { get; set; } = 0;
    public long StatPoints => Biceps  + Triceps + Chest + Legs + Back + Shoulders + Abs;

    private static string _filePath = "stats.json";


    public static Stats Load() 
    {
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<Stats>(json) ?? new Stats();
        }
        return new Stats();
    }

    public void Save() 
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(_filePath, json);
    }

    public void PoitsToNivel() 
    {
        var points = DistPoints.Load();
        var niveis = new List<(int Limite, string Transformation)>
        {
            (0, "Base"),
            (100, "Kaioken x2"),
            (155, "Kaioken x3"),
            (260, "Kaioken x4"),
            (300, "Kaioken x10"),
            (360, "Kaioken x20"),
            (420, "False Super Saiyan"),
            (600, "Super Saiyan"),
            (800, "Super Saiyan 2"),
            (1200, "Super Saiyan 3"),
            (1800, "Golden Great Ape"),
            (2500, "Super Saiyan 4"),
            (3500, "Super Saiyan God"),
            (5000, "Super Saiyan Blue"),
            (7500, "Super Saiyan Blue Kaioken x10"),
            (10000, "Super Saiyan Blue Kaioken x20"),
            (15000, "Ultra Instinct -Sign-"),
            (20000, "Ultra Instinct -Sign- (Dominado)"),
            (30000, "Mastered Ultra Instinct")
        };

        string ultimaTransformacao = "Base";

        foreach (var nivel in niveis)
        {
            if (StatPoints >= nivel.Limite)
            {
                ultimaTransformacao = nivel.Transformation;
            }
            else break;
        }
        points.Transformation = ultimaTransformacao;
        points.Save();
    }

    public void ResetPoints()
    {
        var points = DistPoints.Load();
        
        Biceps = 0;
        Triceps = 0;
        Chest = 0;
        Legs = 0;
        Back = 0;
        Shoulders = 0;
        Forearm = 0;
        Abs = 0;
        points.Transformation = "Base";

        points.Save();
        Save();
    }
}
