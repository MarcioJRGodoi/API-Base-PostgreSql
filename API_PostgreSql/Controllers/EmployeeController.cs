using API_postgres.IRepository;
using API_postgres.Models;
using API_postgres.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_postgres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            return _employeeRepository.GetAll().ToList();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);
            var dataBytes = System.IO.File.ReadAllBytes(employee.Photo);

            return File(dataBytes, "image/png");

        }

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
