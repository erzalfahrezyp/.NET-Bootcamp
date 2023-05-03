namespace MVCWebApp.Models
{
    public class DataForm
    {
        public string Nama { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Passwordd { get; set; }
        public string Alamat { get; set; }
        public string JenisKelamin { get; set; }
        public string Pekerjaan { get; set; }
        public DateOnly TanggalMulai { get; set; }
        //[DisplayFormat(DataFormatString) = "0:MM/dd/yyyy")]
        public bool Penempatan { get; set; }
    }
}
