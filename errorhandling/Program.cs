// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var a = 10;
var b = 0;
var isError = false;
try
{
    throw new MyCustomError("Ini error custom");
    //var c = a / b;
    //Console.WriteLine(c);

}
catch(MyCustomError ex)
{
    Console.WriteLine(ex.Message);
    ex.SaveToDatabase();
    isError = true;
}
catch(DivideByZeroException)
{
    Console.WriteLine("Ini error DivideByZeroException");
    isError = true;
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    isError = true;
}
finally
{
    if(isError)
        Console.WriteLine("Ada error");
    else
        Console.WriteLine("Tidak ada error");
}

Console.WriteLine("Selesai");