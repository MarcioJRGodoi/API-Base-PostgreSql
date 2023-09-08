using API_PostgreSql.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_PostgreSql.Domain.Models.EmployeeAgregate
{
    public interface IUserRepository
    {
        Task Add(User user);

        Task<List<UserDTO>> GetAll();
        Task<User> Get(int id);

        Task<bool> Update(int id, User user);

        IActionResult Delete(int id);
    }
}
