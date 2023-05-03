using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WebApiMvc.Models;

using BC = BCrypt.Net.BCrypt;
namespace WebApiMvc.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly WebApiMvcContext _context;
        private readonly IConfiguration _configuration;
        public AccountController(WebApiMvcContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        public string Register(User user)
        {
            //using(var trans = _context.Database.BeginTransaction())
            //{
            //    try
            //    {
                    // tambah user
                    var u = new User
                    {
                        Username = user.Username,
                        FullName = user.FullName,
                        Password = BC.HashPassword(user.Password)
                    };
                    _context.Users.Add(u);
                    _context.SaveChanges();
                    // ambil role member
                    //var role = _context.Roles.Where(o => o.Name == "Menmber").FirstOrDefault();
                    // assign role ke user
                    //if (role != null)
                    //{
                    //    var ur = new UserRole();
                    //    ur.User = u;
                    //    ur.Role = role;
                    //    
                    //    _context.UserRoles.Add(ur);
                    //    // simpan dan commit
                    //    _context.SaveChanges();
                    //    trans.Commit(); // commit
                    //    return "Sukses";
                    //}
                    return "Sukses";
            //    }
            //    catch (Exception ex)
            //    {
            //        trans.Rollback();
            //    }
            //}
            //return "gagal";
        }
        [HttpPost]
        public UserToken Login(UserLogin user) 
        { 
            //linq
            var usr = _context.Users
                .Where(o => o.Username == user.Username).FirstOrDefault();
            if (usr != null)
            {
                if(BC.Verify(user.Password, usr.Password))
                {
                    var secret = _configuration.GetValue<string>("AppSettings:Secret");
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
                                new Claim(ClaimTypes.Name, user.Username),
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
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
