using System;
using System.Collections.Generic;
using System.IO;
class Program {
    static string Creating(string command, string ingredients, List<string> result) {
        string[] ingredients_list = ingredients.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string intermediate = "";
        foreach (string ingredient in ingredients_list) {
            if (int.TryParse(ingredient, out int result_index)) {
                intermediate += result[result_index - 1];
            } else {
                intermediate += ingredient;
            }
        }


        switch (command) {
            case "MIX":
                return $"MX{intermediate}XM";
            case "WATER":
                return $"WT{intermediate}TW";
            case "DUST":
                return $"DT{intermediate}TD";
            case "FIRE":
                return $"FR{intermediate}RF";
            default:
                return "Неверное заклинание";
        }
    }



    static void Main() {
        string[] m = File.ReadAllLines(@"C:\Users\MV\OneDrive\Рабочий стол\Алгоритмизация и программирование\ргр\Зельеварение\Зельеварение\input10.txt");
        List<string> result = new List<string>(); 
        foreach (string i in m) {
            string[] parts = i.Split(new[] { ' ' }, 2);
            string command = parts[0];
            string ingredients = parts.Length > 1 ? parts[1].Trim() : "";
            string spell = Creating(command, ingredients, result);
            result.Add(spell);
        }
        Console.WriteLine(result[^1]);
    } 
}
