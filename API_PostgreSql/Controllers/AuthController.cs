using API_PostgreSql.Domain.Models.EmployeeAgregate;
using Microsoft.AspNetCore.Mvc;
using API_PostgreSql.Application.Services;
using API_PostgreSql.Infrastructure;
using API_PostgreSql.Domain.Models.AuthAgregate;
using System.Text;
using System.Security.Cryptography;
using API_PostgreSql.Application.InputModel;

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
        public IActionResult Auth([FromBody] UserLoginInputModel login)
        {

            var loginUser = _authRepository.Login(login.Username, HashPasswordService.HashPassword(login.Password));
            if (loginUser.UserName == null)
            {
                return BadRequest("Usuário não encontrado");
            }
            return Ok(login);


        }
    }
}
