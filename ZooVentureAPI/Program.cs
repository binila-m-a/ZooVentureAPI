using ZooVentureAPI.Models;
using ZooVentureAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddScoped<IFoodServices, FoodServices>();
builder.Services.AddScoped<IFileServices, FileServices>();
builder.Services.AddScoped<Zoo>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//// Retrieve values from appsettings.json
//string pricesFilePath = configuration["AppSettings:PricesFilePath"];
//string animalsFilePath = configuration["AppSettings:AnimalsFilePath"];
//string zooFilePath = configuration["AppSettings:ZooFilePath"];

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
