using System.Diagnostics;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/test1", () => {
    var decoratedCalculator = DynamicProxy<ITest>.Create(new Test());
    decoratedCalculator.TesteMethodOn();
    return "teste - on";
});

app.MapGet("/test2", () => {
    var decoratedCalculator = DynamicProxy<ITest>.Create(new Test());
    decoratedCalculator.TesteMethodOff();
    return "teste - off";
});

app.Run();

// TEST CLASS
[System.AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class TestDecoratorAttribute : Attribute 
{
    public string Param { get; set; }
    public TestDecoratorAttribute(string param)
    {
        Param = param;
    }
}

public interface ITest {
    void TesteMethodOn();
    void TesteMethodOff();
}

public class Test : ITest
{
    [TestDecorator("on")]
    public void TesteMethodOn()
    {
        Debug.WriteLine("enter TesteMethod() - On");
    }

    [TestDecorator("off")]
    public void TesteMethodOff()
    {
        Debug.WriteLine("enter TesteMethod() - Off");
    }
}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
