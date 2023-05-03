using WebAPIApp;
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

// api

app.MapGet("/hello", () => "Hello GET"); // ambil data
app.MapPost("/hello", () => "Hello POST"); // tambah data
app.MapPut("/hello", () => "Hello PUT"); // edit data
app.MapDelete("/hello", () => "Hello DELETE"); // hapus data

// parameter

app.MapPost("/kirim", (Customer o) =>
{
    o.Id = 99;

    return o;
});

app.MapPost("/tambah", (Calculator c) =>
{
    c.Hasil = c.Bil1 + c.Bil2;

    return c;
});

app.MapPost("/kurang", (Calculator c) =>
{
    c.Hasil = c.Bil1 - c.Bil2;

    return c;
});

app.MapPost("/kali", (Calculator c) =>
{
    c.Hasil = c.Bil1 * c.Bil2;

    return c;
});

app.MapPost("/bagi", (Calculator c) =>
{
    c.Hasil = c.Bil1 / c.Bil2;

    return c;
});


app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
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

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
