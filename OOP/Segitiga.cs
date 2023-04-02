public class Segitiga : IHitung
{
    public int Alas { get; set; }
    public int Tinggi { get; set; }

    public double Luas()
    {
        return 0.5 * Alas * Tinggi;
    }
}