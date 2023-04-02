// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var hasil = Jumlah(1, 2);

// lambda
// (parameter) => expression
var mylambda = (int a, int b) => a + b;
var hasil2 = mylambda(1, 6);

var hitung = (int a, int b) =>
{
    var c = a + b;
    return c;
};
var hasil3 = hitung(1, 5);

Hello a = (string m) => Console.WriteLine(m);
a("Hello World");

var correct = (int a, int b) => (a > 10) || (b > 10);
var hasil4 = correct(15,3);
Console.WriteLine(hasil4);


int Jumlah(int a, int b)
{
    return a + b;
}


public delegate void Hello(string m);