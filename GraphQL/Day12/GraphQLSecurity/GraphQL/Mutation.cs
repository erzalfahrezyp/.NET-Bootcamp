using GraphQLSecurity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace GraphQLSecurity.GraphQL
{
    public class Mutation
    {
        public string Register([Service]WebApiMvcContext context, RegisterUser user)
        {
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    // tambah user
                    var u = new User
                    {
                        Username = user.UserName,
                        FullName = user.FullName,
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
        public UserToken Login([Service] WebApiMvcContext context,[Service] IConfiguration configuration, UserLogin userLogin)
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
    }
}
