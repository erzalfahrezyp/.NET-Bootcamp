using Microsoft.AspNetCore.Mvc;

namespace MVCWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string bilangan1, string bilangan2, string operasi)
        {
            double bil1, bil2, hasil;
            bool isValidBil1 = double.TryParse(bilangan1, out bil1);
            bool isValidBil2 = double.TryParse(bilangan2, out bil2);

            ViewBag.Bil1 = string.Format("{0:#,##0}", bil1);
            ViewBag.Bil2 = string.Format("{0:#,##0}", bil2);
            ViewBag.Operasi = operasi;

            if (isValidBil1 && isValidBil2)
            {
                switch (ViewBag.Operasi)
                {
                    case "+":
                        hasil = bil1 + bil2;
                        ViewBag.Hasil = string.Format("{0:#,##0}", hasil);
                        break;
                    case "-":
                        hasil = bil1 - bil2;
                        ViewBag.Hasil = string.Format("{0:#,##0}", hasil);
                        break;
                    case "*":
                        hasil = bil1 * bil2;
                        ViewBag.Hasil = string.Format("{0:#,##0}", hasil); ;
                        break;
                    case "/":
                        if (bil2 != 0)
                        {
                            hasil = bil1 / bil2;
                            ViewBag.Hasil = string.Format("{0:#,##0}", hasil);
                        }
                        else
                        {
                            ViewBag.Error = "Error!";
                        }
                        break;
                    default:
                        ViewBag.Error = "Invalid operation!";
                        break;
                }
            }
            else
            {
                ViewBag.Error = "Invalid input!";
            }
            
            return View();
        }

    }
}
