using Microsoft.AspNetCore.Mvc;
using WebDBApp.Models;

namespace WebDBApp.Controllers
{
    public class ProductController : Controller
    {
        // DI
        private readonly BootcampContext _context;
        public ProductController(BootcampContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product o)
        {
            // insert
            _context.Products.Add(o);
            _context.SaveChanges(); // commit db

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Where(o => o.Id == id).FirstOrDefault();

            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int id, Product p)
        {
            var product = _context.Products.Where(o => o.Id == id).FirstOrDefault();
            if(product!=null)
            {
                // update
                if (!string.IsNullOrEmpty(p.Name))
                    product.Name = p.Name;
                product.Price = p.Price;
                product.Stock = p.Stock;

                // save
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var product = _context.Products.Where(o => o.Id == id).FirstOrDefault();

            return View(product);
        }
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Where(o => o.Id == id).FirstOrDefault();

            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(int id, string? btn)
        {
            // delete
            // get product by id
            var product = _context.Products.Where(o => o.Id == id).FirstOrDefault();
            if(product!=null) 
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
