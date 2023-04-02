// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

void Hello()
{
    Console.WriteLine("Hello guys!");
}

async Task Hello2()
{
    Task t1 = Task.Run(() => Console.WriteLine("Hello Task 1"));
    Task t2 = Task.Run(() => Console.WriteLine("Hello Task 2"));
    Task t3 = Task.Run(() => Console.WriteLine("Hello Task 3"));

    await t1;
    t3.Wait();
    await t2;

    Console.WriteLine("Hello guys!");
}

async Task<string> Download(string url)
{
    using var client = new HttpClient();
    //client.GetStringAsync(url).Wait(); menyebabkan blocking karna .Wait()
    if(!string.IsNullOrEmpty(url))
        return await client.GetStringAsync(url);
    else
        return "";
}

Hello();
Hello2();
var tt = Download("https://www.google.com").Result;
Console.WriteLine(tt);

Task.Run(() =>
    Console.WriteLine("Hello, World! 1")
).Wait();

Task.Run(async() =>
{
    using var client = new HttpClient();
    var hasil = await client.GetStringAsync("https: www.google.com");
});