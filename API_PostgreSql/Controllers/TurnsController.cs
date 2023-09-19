using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.Models.EmployeeAgregate;
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
        private readonly ICageRepository _cageRepository;

        public TurnsController(ITurnsRepository turnsRepository, ICageRepository cageRepository)
        {
            _turnsRepository = turnsRepository;
            _cageRepository = cageRepository;
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
                return NotFound("Usúario não encontrado");
            }
            return Ok(turns);
        }

        // GET api/<TurnsController>/ByGaiola/5
        [HttpGet("ByGaiola/{id}")]
        public async Task<IActionResult> GetByGaiola(int idGaiola)
        {
            // Consulta as voltas com base no idGaiola
            var turns = await _turnsRepository.GetByGaiola(idGaiola);

            if (turns == null || !turns.Any())
            {
                return NotFound("Nenhuma volta encontrada para a gaiola especificada.");
            }

            // Obtém a descrição da gaiola
            var gaiola = await _cageRepository.Get(idGaiola);

            if (gaiola == null)
            {
                return NotFound("Gaiola não encontrada.");
            }

            // Crie uma lista de objetos que incluem as informações da volta e da gaiola
            var result = turns.Select(turn => new TurnsWithCageDTO
            {
                Id = turn.Id,
                // Outros campos da volta
                GaiolaDescricao = gaiola.Descricao // Inclui a descrição da gaiola
            }).ToList();

            return Ok(result);
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