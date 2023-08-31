using API_PostgreSql.Domain.DTOs;

namespace API_PostgreSql.Domain.Models.AuthAgregate
{
    public interface IAuthRepository
    {
        UserDTO Login(string username, string password);
    }
}
