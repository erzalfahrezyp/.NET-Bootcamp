using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Models;
using System.Drawing;

namespace MVCWebApp.Controllers
{
    public class TrainingController : Controller
    {
        public IActionResult Index() // /training/index
        {
            return View();
        }
        public IActionResult Hello() // /training/hello
        {
            return View();
            // return View("Test"); // jika tidak di otak-atik akan ikut nama diatasnya. bisa diganti dengan View(Test)
        }
        [HttpGet("training/test")] // rewrite router name ==> /test
        public IActionResult MyTest()
        {
            return View(); // nama view = nama fungsi
        }
        public IActionResult Pegawai() // training/pegawai
        {
            Pegawai p = new Pegawai { Id = 10, Nama = "Peg 10", Email = "peg10@gmail.com" };

            // viewbag
            ViewBag.Judul = "Hallo apa kabar";

            return View(p);
        }
        public IActionResult Detail(int id) // training/detail/(int id)
        {
            Pegawai p = new Pegawai { Id = id, Nama = "Peg 10", Email = "peg10@gmail.com" };

            // viewbag
            ViewBag.Judul = "Hallo apa kabar";

            return View("Pegawai", p);
        }
        public IActionResult Registration() // training/registration HTTP GET
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(Pegawai peg) // training/registration HTTP POST
        {
            ViewBag.Judul = "Data yang sudah diterima";

            return View("Pegawai", peg);
        }
        public IActionResult MyRegistration() // training/myregistration HTTP GET
        {
            return View();
        }
        [HttpPost]
        public IActionResult MyRegistration(Pegawai mypeg) // training/myregistration HTTP POST
        {
            ViewBag.Judul = "Data yang sudah diterima";

            return View("Pegawai", mypeg);
        }
    }
}
