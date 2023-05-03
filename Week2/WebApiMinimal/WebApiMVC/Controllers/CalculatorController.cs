using Microsoft.AspNetCore.Mvc;
using MyServices;

namespace WebApiMVC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculatorController : Controller
    {
        private readonly IKalculator _kalkulator;

        // DI Injector
        public CalculatorController(IKalculator kalkulator)
        {
            _kalkulator = kalkulator;
        }
        [HttpPost]
        public Bilangan Tambah([FromBody] Bilangan bilangan)
        {
            bilangan.Hasil = _kalkulator.Tambah(bilangan.Bil1, bilangan.Bil2);
            return bilangan;
        }
        [HttpPost]
        public Bilangan Kurang([FromBody] Bilangan bilangan)
        {
            bilangan.Hasil = _kalkulator.Kurang(bilangan.Bil1, bilangan.Bil2);
            return bilangan;
        }
        [HttpPost]
        public Bilangan Kali([FromBody] Bilangan bilangan)
        {
            bilangan.Hasil = _kalkulator.Kali(bilangan.Bil1, bilangan.Bil2);
            return bilangan;
        }
        [HttpPost]
        public Bilangan Bagi([FromBody] Bilangan bilangan)
        {
            bilangan.Hasil = _kalkulator.Bagi(bilangan.Bil1, bilangan.Bil2);
            return bilangan;
        }
    }
}
