using API_PostgreSql.Domain.Models.EmployeeAgregate;
using Microsoft.AspNetCore.Mvc;
using API_PostgreSql.Application.Services;
using API_PostgreSql.Infrastructure;
using API_PostgreSql.Domain.Models.AuthAgregate;
using System.Text;
using System.Security.Cryptography;

namespace API_PostgreSql.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost]
        public IActionResult Auth(string userName, string password)
            {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Converta os bytes hash em uma representação hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                var login = _authRepository.Login(userName, builder.ToString());
                if (login.UserName == null)
                {
                    return BadRequest("Usuário não encontrado");
                }
                return Ok(login);
            }
            
            
        }
    }
}
