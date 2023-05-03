using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDBApi.Models;

namespace WebDBApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BootcampContext _context;

        public ProductController(BootcampContext context)
        {
            _context = context;
        }

        [HttpGet("/product")]
        public List<Product> ListProduct()
        {
            return _context.Products.ToList();
        }

        [HttpPost("/product/create")]
        public Product Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        [HttpGet("/product/details/{id}")]
        public Product Detail(int id)
        {
            var product = _context.Products.Where(o => o.Id == id).FirstOrDefault();
            return product;
        }

        [HttpPut("/product/edit/{id}")]
        public Product Edit(int id, Product p)
        {
            var product = _context.Products.Where(o => o.Id == id).FirstOrDefault();
            if (product != null)
            {
                if (!string.IsNullOrEmpty(p.Name)) 
                {
                    product.Name = p.Name;
                }
                product.Price = p.Price;
                product.Stock = p.Stock;

                _context.Products.Update(product);
                _context.SaveChanges();
            }

            return product;
        }
        [HttpDelete("/product/delete/{id}")]
        public Product Delete(int id)
        {
            var product = _context.Products.Where(o => o.Id == id).FirstOrDefault();
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            
            return product;
        }
    }
}