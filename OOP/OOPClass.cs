// OOP
// Class

//instansisasi
Pegawai p1 = new Pegawai();
Pegawai p2 = new Pegawai("K2001");

p1.KodePegawai = "K2000";
p1.Nama = "Budi";
p1.Alamat = "Jl. Jendral Sudirman";


Pegawai p3 = new Pegawai
{
    KodePegawai = "K2002",
    Nama = "Susi",
    Alamat = " Jl. Jendral Sudirman"
};

p1.Show();
p2.Show();
p3.Show();

/*Product m1 = new Product
{
    Kode = "M001",
    Nama = "Buku tulis",
    Harga = 5000
};
m1.Show();*/

Product m2 = new Product(9);
m2.Kode = "M002";
m2.Nama = "Buku tulis";
m2.Harga = 5000;
m2.Show();

var h = Helper.Jumlah(40, 30);
Console.WriteLine(h);

//MyClass c = new MyClass();
MyClass c = MyClass.Create();
c.Show();

Bentuk b = new Bentuk();
b.Show();
Kotak k = new Kotak();
k.Show();

Bentuk kk = new Kotak();
kk.Show();

IHitung a = new Segitiga
{
    Alas = 10,
    Tinggi = 8
};
a.Luas();

IHitung bb = new Persegi
{
    Sisi = 8
};
bb.Luas();

// concrete class
public class Pegawai // pascal case
{
    // Fields = variabel yang ada di dalam class
    public string nama;
    public string alamat;

    // Properties pascal case
    public string KodePegawai { get; set; }
    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }
    public string Alamat
    {
        get { return alamat; }
        set { alamat = value; }
    }

    // Constructors
    public Pegawai()
    {
        //initialisasi
        KodePegawai = "";
        nama = "";
        alamat = "";
    }
    public Pegawai(string kode)
    {
        //initialisasi
        KodePegawai = kode;
        nama = "";
        alamat = "";
    }

    // Methods
    public void Show()
    {
        Console.WriteLine("Kode Pegawai: {0}", KodePegawai);
        Console.WriteLine("Nama: {0}", nama);
        Console.WriteLine("Alamat: {0}", alamat);
    }

}