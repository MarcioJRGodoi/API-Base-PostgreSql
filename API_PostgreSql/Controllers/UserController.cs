using API_PostgreSql.Application.InputModel;
using API_PostgreSql.Application.ViewModel;
using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.Models;
using API_PostgreSql.Domain.Models.EmployeeAgregate;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_postgres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger, IMapper mapper)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/<UserController>

        [HttpGet]
        public Task<List<UserViewModel>> Get()
        {
            return _userRepository.GetAll();

        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userRepository.Get(id);
            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }
            return Ok(user);
        }

        // POST api/<UserController>
        //[Authorize]
        [HttpPost]
        public IActionResult Post([FromForm] UserInputModel user)
        {
            try
            {
                var newUser = new User(user.Name, user.Password, user.Profile);
                _userRepository.Add(newUser);

                return Ok("Usuário criado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UserInputModel updatedUser)
        {
            try
            {
                User user = new(updatedUser.Name, updatedUser.Password, updatedUser.Profile);
                var updated = await _userRepository.Update(id, user);

                if (!updated)
                {
                    return NotFound("Usuário não encontrado");
                }

                return Ok("Usuário atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try 
            {
               var delete =  await _userRepository.Delete(id);
                if (!delete)
                {
                   return NotFound("Usuário não encontrado");
                }
                return Ok("Usuário deletado com sucesso");
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }

        }
    }
}
