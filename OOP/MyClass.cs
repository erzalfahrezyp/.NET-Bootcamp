// factory method

public class MyClass
{
    private string a;
    private MyClass()
    {
        a = "kode kunci";
    }
    // factory method
    public static MyClass Create() // jika private
    {
        return new MyClass();
    }
    public void Show()
    {
        Console.WriteLine("kunci {0}", a);
    }
}