// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Task
Task t1 = Task.Run(() => Console.WriteLine("Hello from task 1"));

void DoWork()
{
    Console.WriteLine("Hello from task 2");
}

Task t5 = Task.Run(DoWork);

Action a = DoWork;
Task t6 = Task.Run(a);



Task t2 = Task.Run(() =>
{
    Console.WriteLine("t2 running in background");
    for (int i = 0; i < 100000; i++) ;
    Task.Delay(100);
    Console.WriteLine(" t2 done");
});

Task t3 = Task.Run(T3());

var t4 = Task<int>.Run((Func<int>)DoSomething());
// buat task dengan fungsi
//Task.WaitAll(t1,t2,t3,t4);
t1.Wait();
t2.Wait();
t3.Wait();
t4.Wait();
Console.WriteLine("Hasil: {0}", t4.Result);

//Task.WhenAll(t1,t2,t3,t4)
Task.WhenAll(t1,t2,t3,t4).ContinueWith((t) =>
{
    Console.WriteLine("Hasil: {0}", t4.Result);
});

static Func<int> DoSomething()
{
    return () =>
    {
        Console.WriteLine("t4 running in background");
        int val = 0;
        for (int i = 0; i < 100000; i++)
        {
            Task.Delay(5);
            val += i; // val = val + i;
        }
        Console.WriteLine(" t4 done");
        return val;
    };
}

static Action T3()
{
    return () =>
    {
        Console.WriteLine("t3 running in background");
        for (int i = 0; i < 100000; i++) ;
        Task.Delay(5);
        Console.WriteLine(" t3 done");
    };
}