using API_PostgreSql.Application.ViewModel;
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
            if (cage == null)
            {
                return NotFound(new { message = "Gaiola não encontrada" });
            }
            return Ok(cage);
        }

        // POST api/<CageController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CageViewModel cage)
        {
            try
            {
                Cage newCage = new(cage.Diametro, cage.Descricao);
                await _cageRepository.Add(newCage);
                return Ok("Teste");
            }
            catch (Exception ex)
            {
                // Registre a exceção para depuração
                Console.WriteLine(ex);
                return StatusCode(500, "Erro interno ao salvar a gaiola no banco de dados.");
            }
        }

        // PUT api/<CageController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] CageViewModel cageModel)
        {

        
      
            try
            {
                Cage cage = new(cageModel.Diametro, cageModel.Descricao);
                var UpdateMethod = _cageRepository.Update(id, cage);
                //_cageRepository.Update(id, cage); // Update the cage in the repository
                return Ok("Gaiola atualizada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Erro interno ao atualizar a gaiola no banco de dados.");
            }
        }

        // DELETE api/<CageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
