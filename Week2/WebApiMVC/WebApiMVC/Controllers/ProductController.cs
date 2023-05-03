using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMVC.Model;

namespace WebApiMVC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public List<Product> All()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Product 1", Stock = 10 });
            products.Add(new Product { Id = 2, Name = "Product 2", Stock = 20 });
            products.Add(new Product { Id = 3, Name = "Product 3", Stock = 30 });

            return products;
        }
        [HttpPost]
        public Product Create(Product product)
        {
            product.Id = 99;
            return product;
        }
    }
}
