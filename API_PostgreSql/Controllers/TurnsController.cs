using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.Models.EmployeeAgregate;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_PostgreSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnsController : ControllerBase
    {
        private readonly ITurnsRepository _turnsRepository;

        public TurnsController(ITurnsRepository turnsRepository)
        {
            _turnsRepository = turnsRepository;
        }
        // GET: api/<TurnsController>
        [HttpGet]
        public async Task<List<TurnsDTO>> Get()
        {
            return await _turnsRepository.GetAll();
        }

    }
}
