using API_PostgreSql.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using API_PostgreSql.Application.Services;

namespace API_PostgreSql.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string userName, string password)
        {
            if(userName == "eu" || password == "123")
            {
                var token = TokenService.GenerateToken(new Employee());
                return Ok(token);
            }
            return BadRequest("username or password invalid");
        }
    }
}
