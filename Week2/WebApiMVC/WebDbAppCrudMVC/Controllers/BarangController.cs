using Microsoft.AspNetCore.Mvc;
using System.IO;
using WebDbAppCrudMVC.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebDbAppCrudMVC.Controllers
{
    public class BarangController : Controller
    {
        private readonly ProductContext _context;
        private readonly IWebHostEnvironment _hosting;

        public BarangController(ProductContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }
        public IActionResult Index()
        {
            return View(_context.Barangs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string FileProduct, Barang barang, List<IFormFile> file)
        {
            var path = Path.Combine(_hosting.WebRootPath, "/upload/");
            var fileTarget = Path.Combine(path, file[0].FileName);
            var produk = new Barang();
            produk.FileProduct = FileProduct;

            if (file.Count > 0)
            {
                using (var stream = new FileStream(fileTarget, FileMode.Create))
                {
                    await file[0].CopyToAsync(stream);
                }
                produk.FileProduct = "upload/" + file[0].FileName;
            }

            _context.Barangs.Add(barang);
            await _context.SaveChangesAsync();
            

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var barang = await _context.Barangs.FindAsync(id);

            if (barang == null)
            {
                return NotFound();
            }
            return View(barang);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Barang barang, IFormFile file)
        {
            var barangToUpdate = await _context.Barangs.FindAsync(id);

            if (barangToUpdate == null)
            {
                return NotFound();
            }

            barangToUpdate.Name = barang.Name;
            barangToUpdate.Price = barang.Price;
            barangToUpdate.Stock = barang.Stock;

            if (file != null && file.Length > 0)
            {
                var path = Path.Combine(_hosting.WebRootPath, "/upload/", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                barangToUpdate.FileProduct = "upload/" + file.FileName;
            }

            _context.Barangs.Update(barangToUpdate);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var barang = _context.Barangs.Where(o => o.Id == id).FirstOrDefault();

            return View(barang);
        }
        public IActionResult Delete(int id)
        {
            var barang = _context.Barangs.Where(o => o.Id == id).FirstOrDefault();

            return View(barang);
        }
        [HttpPost]
        public IActionResult Delete(int id, string? btn)
        {
            var barang = _context.Barangs.Where(o => o.Id == id).FirstOrDefault();
            if (barang!=null)
            {
                _context.Barangs.Remove(barang);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
