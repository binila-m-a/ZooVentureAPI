using System;
using System.Collections.Generic;
using System.Linq;
using ZooVentureAPI.DTO;
using ZooVentureAPI.Models;

namespace ZooVentureAPI.Services
{
    public class FoodServices : IFoodServices
    {
        private readonly Zoo zoo;
        public FoodServices(Zoo zoo)
        {
            this.zoo = zoo;
        }

        public List<FoodExpenseResultDTO> AddResultsForAnimalType(Zoo zoo, List<Animals> animals, List<FoodPrice> foodPrices)
        {
            List<FoodExpenseResultDTO> results = new List<FoodExpenseResultDTO>();
            try
            {
                if (zoo != null && animals != null && foodPrices != null)
            {
                int serialNumber = 1; 

                foreach (var lion in zoo.Lions.Lions)
                {
                    decimal amount = 0; 
                 
                    var foodExpenseResultDTO = new FoodExpenseResultDTO
                    {
                        SlNo = serialNumber++,
                        Name = lion.Name,
                        Weight = lion.Weight,
                        AnimalSpecies = "Carnivores",
                    };

                    foreach (var animal in animals.Where(a => a.Name == "Lion"))
                    {
                        var meatPrice = foodPrices.FirstOrDefault(fp => fp.Type == "Meat");

                        if (meatPrice != null)
                        {
                            amount = meatPrice.PricePerKg;
                        }

                        foodExpenseResultDTO.Animal = animal.Name;
                        foodExpenseResultDTO.TotalFoodCost = CalculateFoodCost(animal, lion.Weight, amount);
                    }

                    results.Add(foodExpenseResultDTO);
                }

                foreach (var tiger in zoo.Tigers.Tigers)
                {
                    decimal amount = 0; 
                 
                    var foodExpenseResultDTO = new FoodExpenseResultDTO
                    {
                        SlNo = serialNumber++,
                        Name = tiger.Name,
                        Weight = tiger.Weight,
                        AnimalSpecies = "Carnivores",
                    };

                    foreach (var animal in animals.Where(a => a.Name == "Tiger"))
                    {
                        var meatPrice = foodPrices.FirstOrDefault(fp => fp.Type == "Meat");

                        if (meatPrice != null)
                        {
                            amount = meatPrice.PricePerKg;
                        }

                        foodExpenseResultDTO.Animal = animal.Name;
                        foodExpenseResultDTO.TotalFoodCost = CalculateFoodCost(animal, tiger.Weight, amount);
                    }

                    results.Add(foodExpenseResultDTO);
                }
                foreach (var giraffe in zoo.Giraffes.Giraffes)
                {
                    decimal amount = 0; 
                   
                    var foodExpenseResultDTO = new FoodExpenseResultDTO
                    {
                        SlNo = serialNumber++,
                        Name = giraffe.Name,
                        Weight = giraffe.Weight,
                        AnimalSpecies = "Herbivores",
                    };

                    foreach (var animal in animals.Where(a => a.Name == "Giraffe"))
                    {
                        var meatPrice = foodPrices.FirstOrDefault(fp => fp.Type == "Fruit");

                        if (meatPrice != null)
                        {
                            amount = meatPrice.PricePerKg;
                        }

                        foodExpenseResultDTO.Animal = animal.Name;
                        foodExpenseResultDTO.TotalFoodCost = CalculateFoodCost(animal, giraffe.Weight, amount);
                    }

                    results.Add(foodExpenseResultDTO);
                }
                foreach (var zebra in zoo.Zebras.Zebras)
                {
                    decimal amount = 0; 
                 
                    var foodExpenseResultDTO = new FoodExpenseResultDTO
                    {
                        SlNo = serialNumber++,
                        Name = zebra.Name,
                        Weight = zebra.Weight,
                        AnimalSpecies = "Herbivores",
                    };

                    foreach (var animal in animals.Where(a => a.Name == "Zebra"))
                    {
                        var meatPrice = foodPrices.FirstOrDefault(fp => fp.Type == "Fruit");

                        if (meatPrice != null)
                        {
                            amount = meatPrice.PricePerKg;
                        }

                        foodExpenseResultDTO.Animal = animal.Name;
                        foodExpenseResultDTO.TotalFoodCost = CalculateFoodCost(animal, zebra.Weight, amount);
                    }

                    results.Add(foodExpenseResultDTO);
                }
                foreach (var wolf in zoo.Wolves.Wolves)
                {
                    decimal meatamount = 0;
            

                    var foodExpenseResultDTO = new FoodExpenseResultDTO
                    {
                        SlNo = serialNumber++,
                        Name = wolf.Name,
                        Weight = wolf.Weight,
                        AnimalSpecies = "Omnivores",
                    };

                    foreach (var animal in animals.Where(a => a.Name == "Wolf"))
                    {
                        var meatPrice = foodPrices.FirstOrDefault(fp => fp.Type == "Meat");

                        if (meatPrice != null)
                        {
                            meatamount = meatPrice.PricePerKg;
                        }
                       

                       

                        foodExpenseResultDTO.Animal = animal.Name;
                        foodExpenseResultDTO.TotalFoodCost = CalculateFoodCost(animal, wolf.Weight, meatamount);
                    }

                    results.Add(foodExpenseResultDTO);
                }
                foreach (var piranha in zoo.Piranhas.Piranhas)
                {
                    decimal meatamount = 0;
           
                    var foodExpenseResultDTO = new FoodExpenseResultDTO
                    {
                        SlNo = serialNumber++,
                        Name = piranha.Name,
                        Weight = piranha.Weight,
                        AnimalSpecies = "Omnivores",
                    };

                    foreach (var animal in animals.Where(a => a.Name == "Piranha"))
                    {
                        var meatPrice = foodPrices.FirstOrDefault(fp => fp.Type == "Meat");

                        if (meatPrice != null)
                        {
                            meatamount = meatPrice.PricePerKg;
                        }

                        foodExpenseResultDTO.Animal = animal.Name;
                        foodExpenseResultDTO.TotalFoodCost = CalculateFoodCost(animal, piranha.Weight, meatamount);
                    }

                    results.Add(foodExpenseResultDTO);
                }
            }

            }
            catch (Exception ex)
            {
              
                Console.WriteLine($"Exception occurred in AddResultsForAnimalType: {ex.Message}");
            }

            return results;
        }


        private decimal CalculateFoodCost(Animals animal, decimal weight, decimal price)
        {
            try
            {
                decimal foodRate = animal.FoodRate;
                string preferredFood = animal.PreferredFood;
                decimal meatPercentage = animal.MeatPercentage;

                decimal pricePerKg = price;

                decimal cost = weight * foodRate * pricePerKg;

                if (animal.PreferredFood.ToLower() == "both")
                {
                    cost = weight * foodRate * meatPercentage / 100 * pricePerKg;
                }

                return Math.Round(cost, 2);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Exception occurred in CalculateFoodCost: {ex.Message}");
                return 0; 
            }
        }

    }
}
