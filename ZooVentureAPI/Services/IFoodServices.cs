using ZooVentureAPI.DTO;
using ZooVentureAPI.Models;

namespace ZooVentureAPI.Services
{
    public interface IFoodServices
    {
        List<FoodExpenseResultDTO> AddResultsForAnimalType(Zoo zoo,List<Animals> animals, List<FoodPrice> foodPrices);
    }
}
