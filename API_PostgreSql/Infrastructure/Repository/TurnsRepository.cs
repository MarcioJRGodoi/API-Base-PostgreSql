using API_PostgreSql.Application.ViewModel;
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
                    QuantidadeVoltas = turns.QuantidadeVoltas,
                }).ToListAsync();
        }

        public async void Update(int id, Turns turns)
        {
            var oldTurns = await _context.Turns.FindAsync(id);
            oldTurns.DistanciaPercorrida = turns.DistanciaPercorrida;
            oldTurns.VelocidadeMedia = turns.VelocidadeMedia;
            oldTurns.TempoAtividade = turns.TempoAtividade;
            oldTurns.GaiolaId = turns.GaiolaId;
            oldTurns.Data = turns.Data;
            oldTurns.QuantidadeVoltas = turns.QuantidadeVoltas;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var turn = await _context.Turns.FindAsync(id);
            if(turn != null)
            {
                return false;
            }
            _context.Turns.Remove(turn);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<TurnsViewModel> GetByDate(int id, DateTime dataI, DateTime dataE)
        {
            var turns = await _context.Turns
                .Where(turn => turn.Data >= dataI && turn.Data <= dataE && turn.GaiolaId == id)
                .ToListAsync();
            var metricas = new TurnsViewModel
            {
                VelocidadeTotal = turns.Sum(t => t.VelocidadeMedia / turns.Count),
                DistanciaPercorridaTotal = turns.Sum(t => t.DistanciaPercorrida),
                TempoDeAtividadeTotal = turns.Sum(t => t.TempoAtividade),
                MetrosPorSegundo = (float)turns.Sum(t => t.DistanciaPercorrida / 3.6),
                Medias = turns.Select(turns => new TurnsDTO
                {
                    GaiolaId = turns.GaiolaId,
                    Data = turns.Data,
                    VelocidadeMedia = turns.VelocidadeMedia,
                    TempoAtividade = turns.TempoAtividade,
                    DistanciaPercorrida = turns.DistanciaPercorrida,
                    QuantidadeVoltas = turns.QuantidadeVoltas,
                }).ToList(),
            };
            return metricas;
        }
    }
}