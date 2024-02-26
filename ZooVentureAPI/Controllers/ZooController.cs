// ZooController.cs
using Microsoft.AspNetCore.Mvc;
using ZooVentureAPI.DTO;
using ZooVentureAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class ZooController : ControllerBase
{
    private readonly ILogger<ZooController> _logger;
    private readonly IFoodServices _foodService;
    private readonly IFileServices _fileService;
    protected readonly IConfiguration Configuration;
    public ZooController(IFoodServices foodService, IFileServices fileService, IConfiguration configuration, ILogger<ZooController> logger)
    {
        _foodService = foodService;
        _fileService = fileService;
        Configuration = configuration;
        _logger = logger;
    }

    [HttpGet("calculateFoodExpenses")]
    public ActionResult CalculateFoodExpenses()
    {
        try
        {
            var zooPath = Configuration["AppSettings:ZooFilePath"];
            var animalsPath = Configuration["AppSettings:AnimalsFilePath"];
            var pricesPath = Configuration["AppSettings:PricesFilePath"];


            var zoo = _fileService.ReadZoo(zooPath);
            var foodPrices = _fileService.ReadFoodPrices(pricesPath);
            var animals = _fileService.ReadAnimals(animalsPath);
            var totalExpenses = _foodService.AddResultsForAnimalType(zoo,animals, foodPrices);

            return Ok(totalExpenses);
        }
        catch (Exception ex)
        {
          
            _logger.LogError(ex, "An error occurred while calculating food expenses.");
            return StatusCode(500, "Internal Server Error");
        }
    }

}
