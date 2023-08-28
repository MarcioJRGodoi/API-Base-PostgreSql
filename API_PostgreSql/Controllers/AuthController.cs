using API_postgres.Models;
using API_postgres.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_PostgreSql.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string userName, string password)
        {
            if(userName == "eu" || password == "1230")
            {
                var token = TokenService.GenerateToken(new Employee());
                return Ok(token);
            }
            return BadRequest("username or password invalid");
        }
    }
}
