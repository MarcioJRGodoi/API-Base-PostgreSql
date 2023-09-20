using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.Models.EmployeeAgregate;
using API_PostgreSql.Domain.Models.TurnsAgregate;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                return NotFound("Não foram encontrados registros");
            }
            return Ok(turns);
        }

        //GET api/GetByDate
        [HttpGet("{id}/{dateI}/{dateE}")]
        public async Task<IActionResult> GetByDate(int id, DateTime dateI, DateTime dateE)
        {
            try
            {
                dateI = DateTime.SpecifyKind(dateI, DateTimeKind.Utc);
                dateE = DateTime.SpecifyKind(dateE, DateTimeKind.Utc);

                //if (dateI.Date == dateE.Date)
                //{
                //    // Se as datas de início e fim forem iguais, ajuste a data de fim para o final do dia.
                //    dateE = dateE.Date.AddDays(1).AddTicks(-1);
                //}

                dateE = dateE.Date.AddDays(1).AddTicks(-1);

                var turns = await _turnsRepository.GetByDate(id, dateI, dateE);
                if(turns.Count == 0)
                {
                    return NotFound("Não foram encontrados registros com as datas fornecidas");
                }
                return Ok(turns); 
            }catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno {ex.Message}");
            }
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