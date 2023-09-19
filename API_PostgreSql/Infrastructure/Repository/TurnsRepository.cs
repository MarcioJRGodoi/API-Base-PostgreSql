using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.Models.EmployeeAgregate;
using API_PostgreSql.Domain.Models.TurnsAgregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_PostgreSql.Infrastructure.Repository
{
    public class TurnsRepository : ITurnsRepository
    {
        private readonly ConnectionDatabase _context = new();
        public async Task Add(Turns turns)
        {
            await _context.AddAsync(turns);
            await _context.SaveChangesAsync();
        }


        public async Task<Turns> Get(int id)
        {
            return await _context.Turns.FindAsync(id);
        }

        public async Task<List<TurnsDTO>> GetAll()
        {
            return await _context.Turns
                .Select(turns => new TurnsDTO
                {
                    GaiolaId = turns.GaiolaId,
                    Data = turns.Data,
                    VelocidadeMedia = turns.VelocidadeMedia,
                    TempoAtividade = turns.TempoAtividade,
                    DistanciaPercorrida = turns.DistanciaPercorrida,
                }).ToListAsync();
        }

        public async Task<List<Turns>> GetByGaiola(int idGaiola)
        {
            // Consulta as voltas com base no idGaiola usando o Entity Framework Core
            var turns = await _context.Turns
                .Where(turn => turn.IdGaiola == idGaiola)
                .ToListAsync();

            return turns;
        }

        public async void Update(int id, Turns turns)
        {
            var oldTurns = await _context.Turns.FindAsync(id);
            oldTurns.DistanciaPercorrida = turns.DistanciaPercorrida;
            oldTurns.VelocidadeMedia = turns.VelocidadeMedia;
            oldTurns.TempoAtividade = turns.TempoAtividade;
            oldTurns.GaiolaId = turns.GaiolaId;
            oldTurns.Data = turns.Data;
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}