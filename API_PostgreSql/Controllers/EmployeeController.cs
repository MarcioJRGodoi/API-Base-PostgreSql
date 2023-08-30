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
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/<EmployeeController>
        
        [HttpGet]
        public List<EmployeeDTO> Get(int pageNumber, int pageQuantity)
        {
            return _employeeRepository.GetAll(pageNumber, pageQuantity).ToList();
            
        }

        // GET api/<EmployeeController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _employeeRepository.Get(id);
            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            return Ok(employeeDTO);
        }

        // POST api/<EmployeeController>
        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);
            var dataBytes = System.IO.File.ReadAllBytes(employee.Photo);

            return File(dataBytes, "image/png");

        }
        [Authorize]
        [HttpPost]
        public void Post([FromForm] EmployeeViewModel employee)
        {
            var filePath = Path.Combine("Storage", employee.Photo.FileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employee.Photo.CopyTo(fileStream);

            var newEmployee = new Employee(employee.Name, employee.Age, filePath);
            _employeeRepository.Add(newEmployee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
