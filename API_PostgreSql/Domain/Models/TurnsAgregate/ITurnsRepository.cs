using API_PostgreSql.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_PostgreSql.Domain.Models.EmployeeAgregate
{
    public interface ITurnsRepository
    {
        void Add(Turns user);

        Task<List<TurnsDTO>> GetAll();
        Task<Turns> Get(int id);

        void Update(int id, Turns turns);

        IActionResult Delete(int id);
    }
}
