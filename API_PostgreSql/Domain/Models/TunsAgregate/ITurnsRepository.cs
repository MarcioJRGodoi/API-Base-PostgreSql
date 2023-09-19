using API_PostgreSql.Domain.DTOs;

namespace API_PostgreSql.Domain.Models.TurnsAgregate
{
    public interface ITurnsRepository
    {
        Task Add(Turns turns);
        Task<List<TurnsDTO>> GetAll();
        Task<List<TurnsDTO>> GetByGaiola(int idGaiola);
        Task<Turns> Get(int id);
        void Update(int id, Turns turns);
        void Delete(int id);
    }
}