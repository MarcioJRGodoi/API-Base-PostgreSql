using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.Models.TurnsAgregate;
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

        // GET api/<TurnsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var turns = await _turnsRepository.Get(id);
            if (turns == null)
            {
                return BadRequest("Usúario não encontrado");
            }
            return Ok(turns);
        }

        // POST api/<TurnsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Turns turns)
        {
            await _turnsRepository.Add(turns);
            return Ok(turns);
        }

        // PUT api/<TurnsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TurnsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
