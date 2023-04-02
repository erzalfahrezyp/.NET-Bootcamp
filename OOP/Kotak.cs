public class Kotak : Bentuk
{
    public Kotak()
    {
        this.b = 10;
        Console.WriteLine("Kotak()");
    }
    // override
    public void Show()
    {
        Console.WriteLine("Kotak.Show()");
        Console.WriteLine("b: {0}", b);
    }
    public void Foo()
    {
        Console.WriteLine("Kotak.Foo()");
    }
}