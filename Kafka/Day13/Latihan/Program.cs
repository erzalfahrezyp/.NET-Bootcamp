using Confluent.Kafka;
using System.Net;

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


app.MapPost("/sendKafka", () =>
{
    var config = new ProducerConfig
    {
        BootstrapServers = "127.0.0.1:9092",
        ClientId = Dns.GetHostName(),
        TransactionalId = "producer01"
    };

    var topic = "testkafka";
    using (var producer = new ProducerBuilder<string, string>(config).Build())
    {
        Console.WriteLine("Kafka connected...");
        producer.InitTransactions(TimeSpan.FromSeconds(10));
        var counter = 1;
        while (true)
        {
            var key = "key" + counter.ToString();
            var product = new Product
            {
                Id = counter,
                Name = "Product " + counter.ToString(),
                Stock = counter,
                Price = counter * 1.2f,
            };
            //var value = "message " + counter.ToString();
            var value = Newtonsoft.Json.JsonConvert.SerializeObject(product);
            producer.BeginTransaction();
            producer.Produce(topic, new Message<string, string>
            {
                Key = key,
                Value = value
            }, (deliveryReport) =>
            {
                if (deliveryReport.Error.Code != ErrorCode.NoError)
                {
                    Console.WriteLine("Failed to send message...");
                }
                else
                {
                    Console.WriteLine($"Succeed. PartitionOffset: " + $"{deliveryReport.TopicPartitionOffsetError}");
                }
            });
            producer.Flush(TimeSpan.FromSeconds(5));
            producer.CommitTransaction();
            counter++;
            return product;
        }
    }
});

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



app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
