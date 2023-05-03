
using MyServices;
using WebApiMinimal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// service
// Interface, concrete
builder.Services.AddTransient<IKalculator, Kalkulator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

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

app.MapPost("/tambah", (IKalculator calc, Bilangan o) =>
{
    o.Hasil = calc.Tambah(o.Bil1, o.Bil2);

    return o;
});
app.MapPost("/kurang", (IKalculator calc, Bilangan o) =>
{
    o.Hasil = calc.Kurang(o.Bil1, o.Bil2);

    return o;
});
app.MapPost("/kali", (IKalculator calc, Bilangan o) =>
{
    o.Hasil = calc.Kali(o.Bil1, o.Bil2);

    return o;
});
app.MapPost("/bagi", (IKalculator calc, Bilangan o) =>
{
    o.Hasil = (int)calc.Bagi(o.Bil1, o.Bil2);

    return o;
});


app.MapPost("/profile", async (IWebHostEnvironment hosting,
                            string name, IFormFileCollection file) =>
{
    var path = hosting.WebRootPath + "/upload/";
    var profile = new Profile();
    profile.Name = name;

    if (file.Count > 0)
    {
        var fileTarget = path + file[0].FileName;
        using (var stream = new FileStream(fileTarget, FileMode.Create))
        {
            await file[0].CopyToAsync(stream);
        }
        profile.Url = "upload/" + file[0].FileName;
    }
    return profile;
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
