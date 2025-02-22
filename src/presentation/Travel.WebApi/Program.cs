using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Travel.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Use to force loading of appsettings.json of test project
builder.Logging.AddConsole();

//Add DbContext
builder.Services.AddDbContext<TravelDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TravelConnection"))
, ServiceLifetime.Scoped);

// Add Swagger
// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo
//     {
//          Title = "Travel.WebApi",
//          Version = "v1"
//     });
//  });


var app = builder.Build();
// app.UseSwagger();
// app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
