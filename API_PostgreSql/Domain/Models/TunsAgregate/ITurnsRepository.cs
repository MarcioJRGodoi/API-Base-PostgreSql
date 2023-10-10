using API_PostgreSql.Application.ViewModel;
using API_PostgreSql.Domain.DTOs;

namespace API_PostgreSql.Domain.Models.TurnsAgregate
{
    public interface ITurnsRepository
    {
        Task Add(Turns turns);
        Task<List<TurnsDTO>> GetAll();
        Task<Turns> Get(int id);
        void Update(int id, Turns turns);
        Task<bool> DeleteAll(int id);
        Task<TurnsViewModel> GetByDate(int id, DateTime dataI, DateTime dataE);
    }
}