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
            // Tente converter o valor do ID para int
            if (!int.TryParse(id.ToString(), out int intId))
            {
                // Se a conversão falhar, retorne null ou trate o erro conforme necessário
                return null;
            }

            return await _context.Cages.FindAsync(intId);
        }


        public async Task<List<CageDTO>> GetAll()
        {
            return await _context.Cages
                .Select(cage => new CageDTO
                {
                    Id = cage.Id,
                    Descricao = cage.Descricao,
                    Diametro = cage.Diametro,
                }).ToListAsync();
        }

        public async Task<bool> Update(int id, Cage cage)
        {
            var oldCage = await _context.Cages.FindAsync(id);
            if (oldCage != null)
            {
                oldCage.Descricao = cage.Descricao;
                oldCage.Diametro = cage.Diametro;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var cage = await _context.Cages.FindAsync(id);
            if (cage != null)
            {
                _context.Cages.Remove(cage);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}

