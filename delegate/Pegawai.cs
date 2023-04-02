public class Pegawai
{
    public int Id { get; set; }
    public string Nama { get; set; }
    public string Email { get; set; }
    public string Alamat { get; set; }
    public string Kota { get; set; }
    public Pegawai(int id, string nama, string email, string alamat, string kota)
    {
        Id = id;
        Nama = nama;
        Email = email;
        Alamat = alamat;
        Kota = kota;
    }
}

public delegate List<Pegawai> Search(
    string nama = "",
    string email = "",
    string alamat= "",
    string kota= ""
);