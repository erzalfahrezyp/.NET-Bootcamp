// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Nodes;

Console.WriteLine("Producer app...");

var config = new ProducerConfig
{
    BootstrapServers = "127.0.0.1:9092",
    ClientId = Dns.GetHostName(),
    TransactionalId = "producer01"
};

var topic = "demo123";
using(var producer = new ProducerBuilder<string, string>(config).Build())
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
                Console.WriteLine("Faileed to send message...");
            }
            else
            {
                Console.WriteLine($"Succeed. PartitionOffset: " + $"{deliveryReport.TopicPartitionOffsetError}");
            }
        });
        producer.Flush(TimeSpan.FromSeconds(5));
        producer.CommitTransaction();
        counter++;
        await Task.Delay(TimeSpan.FromSeconds(5));
    }
}