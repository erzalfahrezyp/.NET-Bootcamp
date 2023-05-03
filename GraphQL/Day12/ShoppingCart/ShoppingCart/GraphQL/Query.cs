using ShoppingCart.Models;

namespace ShoppingCart.GraphQL
{
    public class Query
    {
        public string GetMessage() => "Hello from GraphQL";

        public IQueryable<Product> GetProduct([Service] ShoppingCartContext context)
        {
            return context.Products.Where(p => !p.Deleted);
        }
        public Product GetProductById([Service] ShoppingCartContext context, int id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }
    }
}
