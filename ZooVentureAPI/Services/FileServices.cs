using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using ZooVentureAPI.Models;

namespace ZooVentureAPI.Services
{
    public class FileServices : IFileServices
    {
        public List<FoodPrice> ReadFoodPrices(string filePath)
        {
            List<FoodPrice> foodPrices = new List<FoodPrice>();

            try
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    var parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        var foodType = parts[0].Trim();
                        var pricePerKg = decimal.Parse(parts[1].Trim());
                        foodPrices.Add(new FoodPrice { Type = foodType, PricePerKg = pricePerKg });
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error reading food prices: {ex.Message}");
            }

            return foodPrices;
        }

        public List<Animals> ReadAnimals(string filePath)
        {
            List<Animals> animals = new List<Animals>();

            try
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 3)
                    {
                        var name = parts[0].Trim();
                        var foodRate = decimal.Parse(parts[1].Trim());
                        var preferredFood = parts[2].Trim();

                        if (preferredFood.Equals("both", StringComparison.OrdinalIgnoreCase) && parts.Length == 4)
                        {
                            var meatPercentage = decimal.Parse(parts[3].Trim().Replace("%", ""));
                            animals.Add(new Animals { Name = name, FoodRate = foodRate, PreferredFood = preferredFood, MeatPercentage = meatPercentage });
                        }
                        else
                        {
                            animals.Add(new Animals { Name = name, FoodRate = foodRate, PreferredFood = preferredFood });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error reading animals: {ex.Message}");
            }

            return animals;
        }

        public Zoo ReadZoo(string filePath)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(Zoo));

                using (var streamReader = new StreamReader(filePath))
                {
                    var zoo = (Zoo)serializer.Deserialize(streamReader);
                    return zoo;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error reading zoo: {ex.Message}");
                throw; 
            }
        }
    }
}
