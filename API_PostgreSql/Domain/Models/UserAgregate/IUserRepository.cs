using API_PostgreSql.Application.ViewModel;
using API_PostgreSql.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_PostgreSql.Domain.Models.EmployeeAgregate
{
    public interface IUserRepository
    {
        Task Add(User user);

        Task<List<UserViewModel>> GetAll();
        Task<UserViewModel> Get(int id);

        Task<bool> Update(int id, User user);

        Task<bool> Delete(int id);
    }
}
