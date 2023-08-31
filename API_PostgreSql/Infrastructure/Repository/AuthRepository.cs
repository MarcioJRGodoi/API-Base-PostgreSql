using API_PostgreSql.Application.Services;
using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.Models.AuthAgregate;
using API_PostgreSql.Domain.Models.EmployeeAgregate;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API_PostgreSql.Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ConnectionDatabase _context = new ConnectionDatabase();

        public UserDTO Login(string username, string password)
        {
            var usuario = _context.Users.SingleOrDefault(u => u.Name == username && u.Password == password);

            if (usuario == null)
            {
                return new UserDTO { };
            }
            var token = TokenService.GenerateToken(new User());
            return new UserDTO
            {
                Id = usuario.Id,
                UserName = username,
                Profile = usuario.Profile,
                Token = token
            };
        }
    }
}
