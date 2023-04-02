// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

MyDelegate myDelegate = ShowMessage;
myDelegate("Hello World!");

MyDelegate dell = MyClass.ShowMessage;
dell("Hello World! from class");

// Anonymous method
MyDelegate myDelegate2 = delegate (string s)
{
    Console.WriteLine();
};


List<Product> list = new List<Product>();
list.Add(new Product("Apple", 1.99m));
list.Add(new Product("Orange", 2.3m));
list.Add(new Product("Kiwi", 1.3m));


//CheckHarga checkharga = CheckPrice;
var ada = list.Exists(p => p.Price > 2.0m && p.Name.StartsWith("0"));

void ShowMessage(string s)
{
    Console.WriteLine(s);
}
bool CheckPrice(Product c)
{
    return c.Price > 2.0m;
}
public class MyClass
{
    public static void ShowMessage(string s)
    {
        Console.WriteLine(s);
    }
}
public delegate void MyDelegate(string s);
public delegate bool CheckHarga(Product c);
