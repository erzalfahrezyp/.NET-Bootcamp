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
    }
}
