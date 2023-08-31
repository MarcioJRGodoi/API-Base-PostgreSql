using API_PostgreSql.Domain.Models.EmployeeAgregate;
using Microsoft.AspNetCore.Mvc;
using API_PostgreSql.Application.Services;
using API_PostgreSql.Infrastructure;
using API_PostgreSql.Domain.Models.AuthAgregate;

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
        public IActionResult Auth(string userName,string password)
            {
            var login = _authRepository.Login(userName, password);
            if (login == null)
            {
                return BadRequest("Usuário não encontrado");
            }
            return Ok(login);
            
        }
    }
}
