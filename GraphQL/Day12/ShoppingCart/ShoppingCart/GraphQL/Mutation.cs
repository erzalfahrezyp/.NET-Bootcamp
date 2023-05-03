using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ShoppingCart.Models;

using BC = BCrypt.Net.BCrypt;

namespace ShoppingCart.GraphQL
{
    public class Mutation
    {
        public string Register([Service] ShoppingCartContext context, RegisterUser user)
        {
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    // tambah user
                    var u = new User
                    {
                        Username = user.UserName,
                        Fullname = user.FullName,
                        Password = BC.HashPassword(user.Password)
                    };
                    //_context.Users.Add(u);
                    //_context.SaveChanges();
                    // ambil role member
                    var role = context.Roles.Where(o => o.Name == "Admin").FirstOrDefault();
                    // assign role ke user
                    if (role != null)
                    {
                        var ur = new UserRole();
                        ur.User = u;
                        ur.Role = role;

                        context.UserRoles.Add(ur);
                        // simpan dan commit
                        context.SaveChanges();
                        trans.Commit(); // commit
                        return "Sukses";
                    }
                    //return "Sukses";
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                }
            }
            return "gagal";
        }
        public UserToken Login([Service] ShoppingCartContext context, [Service] IConfiguration configuration, UserLogin userLogin)
        {
            //linq
            var usr = context.Users
                .Where(o => o.Username == userLogin.Username).FirstOrDefault();
            if (usr != null)
            {
                if (BC.Verify(userLogin.Password, usr.Password))
                {
                    var roles = from ur in context.UserRoles
                                join r in context.Roles
                                on ur.RoleId equals r.Id
                                where ur.UserId == usr.Id
                                select r.Name;
                    var roleClaims = new Dictionary<string, object>();
                    foreach (var role in roles)
                    {
                        roleClaims.Add(ClaimTypes.Role, "" + role);
                    }

                    var secret = configuration.GetValue<string>("AppSettings:Secret");
                    var secretBytes = Encoding.ASCII.GetBytes(secret);

                    //token
                    var expired = DateTime.Now.AddDays(2); //2 hari
                    var tokenHandler = new JwtSecurityTokenHandler();
                    //data
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        //payload
                        Subject = new System.Security.Claims.ClaimsIdentity(
                            new Claim[]
                            {
                                new Claim(ClaimTypes.Name, userLogin.Username),
                            }),
                        Expires = expired,
                        SigningCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(secretBytes),
                            SecurityAlgorithms.HmacSha256Signature
                            )
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var userToken = new UserToken
                    {
                        Token = tokenHandler.WriteToken(token),
                        ExpiredAt = expired.ToString(),
                        Message = ""
                    };
                    return userToken;
                }
            }
            return new UserToken { Message = "Invalid username or password" };
        }




        // CRUD PRODUCT
        private readonly ShoppingCartContext _context;
        public Mutation(ShoppingCartContext context)
        {
            _context = context;
        }
        public Product CreateProduct(string name, double price, int stock)
        {
            Product newItem = new Product();
            newItem.Name = name;
            if (newItem.Name != null)
            {
                newItem.Price = price;
                newItem.Stock = stock;
            }
            _context.Products.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }

        public Product UpdateProduct(int id, string? name, double? price, int? stock )
        {
            var product = _context.Products.FirstOrDefault(o => o.Id == id);
            if (product != null)
            {
                product.Name = name ?? product.Name;
                product.Price = price ?? product.Price;
                product.Stock = stock ?? product.Stock;
            }
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(o => o.Id == id);
            if (product != null)
            {
                product.Deleted = true;
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            return product;
        }
    }
}
