
public class Mutation
{
    public string SayGreeting(string message)
    {
        return "Hello World";
    }
    public string SayHello(string message)
    {
        return "Hello, " + message;
    }
    public string SayHello2(string? message)
    {
        return "Hello, " + (message ?? message);
    }
    //public Product AddProduct(Product product)
    //{
    //    return product;
    //}
    public float Tambah(Calculator calculator)
    {
        calculator.hasil = calculator.bil1 + calculator.bil2;
        return calculator.hasil;
    }
    public float Kurang(Calculator calculator)
    {
        calculator.hasil = calculator.bil1 - calculator.bil2;
        return calculator.hasil;
    }
    public float Kali(Calculator calculator)
    {
        calculator.hasil = calculator.bil1 * calculator.bil2;
        return calculator.hasil;
    }
    public float Bagi(Calculator calculator)
    {
        calculator.hasil = calculator.bil1 / calculator.bil2;
        return calculator.hasil;
    }
    //public float Tambah(float bil1, float bil2, float hasil) => hasil = bil1 + bil2;

}