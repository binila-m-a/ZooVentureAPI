using ZooVentureAPI.Models;

namespace ZooVentureAPI.Services
{
    public interface IFileServices
    {
        List<FoodPrice> ReadFoodPrices(string filePath);
        List<Animals> ReadAnimals(string filePath);
        Zoo ReadZoo(string filePath);
    }
}
