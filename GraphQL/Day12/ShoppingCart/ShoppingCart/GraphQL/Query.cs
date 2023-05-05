using HotChocolate.Authorization;
using ShoppingCart.Models;
using System.Security.Claims;

namespace ShoppingCart.GraphQL
{
    public class Query
    {
        // PRODUCT
        public IQueryable<Product> GetProduct([Service] ShoppingCartContext context)
        {
            return context.Products.Where(p => !p.Deleted);
        }
        public Product GetProductById([Service] ShoppingCartContext context, int id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }


        // CART
        public IQueryable<CartItem> GetCartItem([Service] ShoppingCartContext context) => context.CartItems;

        public UserCart? GetMyCart([Service] HttpContext httpContext, [Service] ShoppingCartContext context)
        {
            // get username
            var user = httpContext.User.FindFirstValue(ClaimTypes.Name);
            if (user != null)
            {
                //var cart1 = from a in context.UserCarts
                //            join b in context.Users on a.UserId equals b.Id
                //            where b.Username == user && a.Checkout == false
                //            select a;
                var cart = context.UserCarts.Where(o => o.User.Username == user && o.Checkout == false).FirstOrDefault();
                return cart;
            }
            return null;
        }
    }
}
