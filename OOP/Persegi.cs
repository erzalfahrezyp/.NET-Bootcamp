public class Persegi : IHitung
{
    public int Sisi { get; set; }

    public double Luas()
    {
        return Sisi*Sisi;
    }
}