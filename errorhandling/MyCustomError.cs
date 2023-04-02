public class MyCustomError : Exception
{
    public MyCustomError(string message) : base(message)
    {
        Console.WriteLine("Called MyCustomError");
    }
    public void SaveToDatabase()
    {
        Console.WriteLine(this.Message);
        Console.WriteLine("Save to database");
    }
}