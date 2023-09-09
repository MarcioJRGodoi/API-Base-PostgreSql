using API_PostgreSql.Domain.DTOs;

namespace API_PostgreSql.Domain.Models.CageAgregate
{
    public interface ICageRepository
    {
        Task Add(Cage cage);
        Task<List<CageDTO>> GetAll();
        Task<Cage> Get(int id);
        Task<bool> Update(int id, Cage cage);
        Task<Cage> Delete(int id);
    }
}
