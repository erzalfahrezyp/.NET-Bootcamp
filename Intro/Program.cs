// minimal codes
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// C# Programming
// variables
    // eksplisit
/*int a = 1;
string kota = "Bekasi";
decimal harga = 100.5m;

Console.WriteLine(a);
Console.WriteLine(kota, harga); // concate*/

    //implisit
/*var b = 2; 
var c = "hello";
Console.WriteLine("{0} {1}", b, c);*/

const int KODE = 3;
Console.WriteLine(KODE);
// KODE = 10; // error

// operators
// aritmatika: + - * / %
// perbandingan: == != >< >= <==
// logika: && || !
int num1 = 10;
int num2 = 8;
Console.WriteLine(num1 + num2);
Console.WriteLine(num1 - num2);
Console.WriteLine(num1 * num2);
Console.WriteLine(num1 / num2);
Console.WriteLine(num1 % num2);

// nilai true/false
Console.WriteLine(num1 == num2);
Console.WriteLine(num1 != num2);
Console.WriteLine(num1 > num2);
Console.WriteLine(num1 < num2);
Console.WriteLine(num1 >= num2);
Console.WriteLine(num1 <= num2);

// && = and
// || = or
// ! = not
Console.WriteLine((num1 > num2) && (num1 > 5));
Console.WriteLine((num1 > num2) || (num1 > 5));
Console.WriteLine(!(num1 > num2));

//var hasil = Math.Pow(num1,2);
var hasil = num1 + num2;
Console.WriteLine(hasil);

// input
/*Console.WriteLine("Masukkan nama anda: ");
string nama = Console.ReadLine();
Console.WriteLine("Halo {0}", nama);
// konversi string ke numerik
Console.Write("Masukkan angka: ");
string angka = Console.ReadLine(); // cara 1
int angkaInt = int.Parse(angka); // cara 2
Console.WriteLine("Angka yang anda masukkan : {0}", angkaInt);*/

// latihan
// buat program untuk rumus ABC
/*var a = 2;
var b = -8;
var c = -3;

var x1 = Convert.ToDouble(((-b)+(Math.Sqrt(Math.Pow(b, 2))-(4*a*c)))/(2*a));
var x2 = Convert.ToDouble(((-b)-(Math.Sqrt(Math.Pow(b, 2))-(4*a*c)))/(2*a));
Console.WriteLine(x1);*/

Console.Write("Masukkan angka a: ");
string inputa = Console.ReadLine();
Console.Write("Masukkan angka b: ");
string inputb = Console.ReadLine();
Console.Write("Masukkan angka c: ");
string inputc = Console.ReadLine();

double da = double.Parse(inputa);
double db = double.Parse(inputb);
double dc = double.Parse(inputc);

var dd = Math.Sqrt(Math.Pow(db, 2) - (4 * da * dc));
var hasilX1 = (-db + dd) / (2 * da);
var hasilX2 = (-db - dd) / (2 * da);
Console.WriteLine("X1 = {0}, X2 = {0}", hasilX1, hasilX2);
// conditional statments
    // if else
int m = 10;
if(m > 5) // statement --> boolean
{
    Console.WriteLine("m lebih besar dari 5");
}
else
{
    Console.WriteLine("m kurang dari 5");
}
if((m > 5) && (m < 10)) // statment --> boolean
{ // nested if
    Console.WriteLine("(m > 5) && (m < 10)");
    if(m > 7) Console.WriteLine("m lebih besar dari 7");
}
else if(m < 5)
{
    Console.WriteLine("m kurang dari 5");
}
else
{
    Console.WriteLine("m lebih dari 10");
}

    // switch
/*int n = 2;
switch(n)
{
    case 1;
        Console.WriteLine("n = 1");
    break;

}*/

    // latihan
Console.Write("Masukkan angka: ");
string inputAngka =  Console.ReadLine();
int i = int.Parse(inputAngka);

if(i < 10)
{
    Console.WriteLine("tidak baik");
}
else if(i < 60)
{
    Console.WriteLine("kurang");
}
else if(i < 80)
{
    Console.WriteLine("cukup");
}
else if(i < 100)
{
    Console.WriteLine("baik");
}
else if(i == 100)
{
    Console.WriteLine("luar biasa");
}
else
{
    Console.WriteLine("salah Input");
}
// loops
    // for
    // i++ => i = i + 1
for(int h=0; h<10; h++)
{
    Console.WriteLine(h);
}
    //while
int j = 0;
while(j<10) // cek kodisional diawal
{
    Console.WriteLine(j);
    j++;
}
    //do while
int k = 0;
do
{
    Console.WriteLine(k);
    k++;
} while(k<10); // cek kondisional diakhir
    // foreach
string[] kota2 = {"Jakarta", "Bandung", "Surabaya"};
foreach(string item in kota2)
{
    Console.WriteLine(item);
}

// functions
// camel dan pascal case
// PascalCase ==> Pergi, Simpan, SimpanData, SimpanDataKeDatabase
// camelCase ==> pergi, simpan, simpanData, simpanDataKeDatabase
void Foo()
{
    Console.WriteLine("foo");
}
Foo();
float HitungLuas(float p, float l)
{
    return p * l;
}
var hasil2 = HitungLuas(10, 5);

// arrays
    // classics
int [] angka2 = {1,2,3,4,5};
string [] kota3 = {"Jakarta", "Bandung", "Surabaya"};

    // generic array
List<int> angka3 = new List<int>();
List<string> kota4 = new List<string>();

    // tambah
angka3.Add(10);
angka3.Add(15);

    // list
Console.WriteLine(angka3);
foreach(var item in angka3)
{
    Console.WriteLine(item);
}
Console.WriteLine(angka3[0]);

    // edit
angka3[0] = 100;

    // remove
angka3.Remove(100); // hapus berdasarkan value
angka3.RemoveAt(0); // hapus berdasarkan index