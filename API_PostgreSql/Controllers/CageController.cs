using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.Models.CageAgregate;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_PostgreSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CageController : ControllerBase
    {
        private readonly ICageRepository _cageRepository;

        public CageController(ICageRepository cageRepository)
        {
            _cageRepository = cageRepository;
        }
        // GET: api/<CageController>
        [HttpGet]
        public async Task<List<CageDTO>> Get()
        {
            return await _cageRepository.GetAll();
        }

        // GET api/<CageController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cage = await _cageRepository.Get(id);
            if(cage == null)
            {
                return BadRequest("Usúario não encontrado");
            }
            return Ok(cage);
        }

        // POST api/<CageController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cage cage)
        {
            await _cageRepository.Add(cage);
            return Ok(cage);
        }

        // PUT api/<CageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
