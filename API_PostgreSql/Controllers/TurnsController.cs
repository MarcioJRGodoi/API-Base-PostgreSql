using API_PostgreSql.Application.InputModel;
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
       //[Route("/dashboard")]
        [HttpGet("DashBoard/{idGaiola}")]
        public async Task<IActionResult> GetByDate(int idGaiola, DateTime dataI, DateTime dataE)
        {
            try
            {
                dataI = DateTime.SpecifyKind(dataI, DateTimeKind.Utc);
                dataE = DateTime.SpecifyKind(dataE, DateTimeKind.Utc);

                //if (dateI.Date == dateE.Date)
                //{
                //    // Se as datas de início e fim forem iguais, ajuste a data de fim para o final do dia.
                //    dateE = dateE.Date.AddDays(1).AddTicks(-1);
                //}

                dataE = dataE.Date.AddDays(1).AddTicks(-1);

                var turns = await _turnsRepository.GetByDate(idGaiola, dataI, dataE);
                if(turns.Medias.Count == 0)
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
        public IActionResult Delete(int id)
        {
            try 
            {
              var delete =  _turnsRepository.Delete(id);
                if(delete ==  null)
                {
                    return NotFound("Nenhum registro encontrado para gaiola informada");
                }
                return Ok("Registros deletados");
                

            } catch(Exception ex) 
            {
                return StatusCode(500, "Erro no servidor");
            }
            
        }
    }
}