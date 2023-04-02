public class ConcreteContract : IContract
{
    public void Show()
    {
        Console.WriteLine("ConcreteContract.Show()");
    }
    public void Foo()
    {
        Console.WriteLine("ConcreteContract.Foo()");
    }
}