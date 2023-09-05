using API_PostgreSql.Domain.DTOs;

namespace API_PostgreSql.Domain.Models.CageAgregate
{
    public interface ICageRepository
    {
        Task Add(Cage cage);

        Task<List<CageDTO>> GetAll();

        Task<Cage> Get(int id);
        void Update(int id, Cage cage);
        void Delete(int id);
    }
}
