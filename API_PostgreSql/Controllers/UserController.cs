using API_PostgreSql.Application.ViewModel;
using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.Models;
using API_PostgreSql.Domain.Models.EmployeeAgregate;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public List<UserDTO> Get(int pageNumber, int pageQuantity)
        {
            return _userRepository.GetAll(pageNumber, pageQuantity).ToList();
            
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _userRepository.Get(id);
            var employeeDTO = _mapper.Map<UserDTO>(employee);
            return Ok(employeeDTO);
        }

        // POST api/<UserController>
        [Authorize]
        [HttpPost]
        public void Post([FromForm] UserViewModel user)
        {
            var newUser = new User(user.Name, user.Password, user.Profile);
            _userRepository.Add(newUser);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
