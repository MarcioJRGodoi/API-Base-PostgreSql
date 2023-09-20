using API_PostgreSql.Domain.DTOs;

namespace API_PostgreSql.Domain.Models.TurnsAgregate
{
    public interface ITurnsRepository
    {
        Task Add(Turns turns);
        Task<List<TurnsDTO>> GetAll();
        Task<Turns> Get(int id);
        void Update(int id, Turns turns);
        void Delete(int id);
        Task<List<TurnsDTO>> GetByDate(int id, DateTime dataI, DateTime dataE);
    }
}