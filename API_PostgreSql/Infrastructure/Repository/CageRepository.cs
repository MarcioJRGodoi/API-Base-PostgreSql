using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.Models.CageAgregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_PostgreSql.Infrastructure.Repository
{
    public class CageRepository : ICageRepository
    {
        private readonly ConnectionDatabase _context = new();
        public async Task Add(Cage cage)
        {
            await _context.AddAsync(cage);
            await _context.SaveChangesAsync();
        }


        public async Task<Cage> Get(int id)
        {
            return await _context.Cages.FindAsync(id);
  
        }

        public async Task<List<CageDTO>> GetAll()
        {
            return await _context.Cages
                .Select(cage => new CageDTO
                {
                    Descricao = cage.Descricao,
                    Diametro = cage.Diametro,
                }).ToListAsync();
        }

        public async void Update(int id, Cage cage)
        {
            var oldCage = await _context.Cages.FindAsync(id);
            oldCage.Descricao = cage.Descricao;
            oldCage.Diametro = cage.Diametro;
            await _context.SaveChangesAsync();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
