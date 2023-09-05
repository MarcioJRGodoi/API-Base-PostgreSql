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
        public Task<List<UserDTO>> Get()
        {
            return _userRepository.GetAll();
            
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userRepository.Get(id);
            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        // POST api/<UserController>
        //[Authorize]
        [HttpPost]
        public void Post([FromForm] UserViewModel user)
        {

            var newUser = new User(user.Name, user.Password, user.Profile);
            _userRepository.Add(newUser);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, UserViewModel user)
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
        public void Delete(int id)
        {
        }
    }
}
