public class Product
{
    public int Id { get; }
    public string Kode { get; set; }
    public string Nama { get; set; }
    public double Harga { get; set; }
    // fungsi get set untuk edit dari luar

    public Product(int id)
    {
        Id = id;
        Kode = "";
        Nama = "";
        Harga = 0;
    }
    public void Show()
    {
        Console.WriteLine("Id: {0}", Id);
        Console.WriteLine("Kode: {0}", Kode);
        Console.WriteLine("Nama: {0}", Nama);
        Console.WriteLine("Harga: {0}", Harga);
    }
}