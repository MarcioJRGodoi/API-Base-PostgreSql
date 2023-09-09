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

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            var user = _userRepository.Get(id);
            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);   
        }

        // POST api/<UserController>
        //[Authorize]
        [HttpPost]
        public void Post([FromForm] EmployeeViewModel user)
        {
            var newUser = new User(user.Name, user.Password, user.Profile);
            _userRepository.Add(newUser);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, EmployeeViewModel user)
        {
            var UserExists = _userRepository.Get(id);
            if (UserExists == null)
            {
                throw new ArgumentException("O usuário informado não existe");
            }
            var newUser = new User(user.Name, user.Password, user.Profile);
            _userRepository.Update(id, newUser);
            return Ok("Usuario Atualizado com sucesso");
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
