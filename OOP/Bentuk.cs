public class Bentuk
{
    private int a;
    protected int b;
    public Bentuk()
    {
         Console.WriteLine("Bentuk()");
    }
    public void Show()
    {
        Console.WriteLine("Bentuk.Show()");
        Console.WriteLine("a: {0}", a);
        Console.WriteLine("b: {0}", b);
    }   
}