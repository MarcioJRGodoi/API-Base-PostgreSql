using API_PostgreSql.Domain.DTOs;

namespace API_PostgreSql.Domain.Models.EmployeeAgregate
{
    public interface IUserRepository
    {
        void Add(User user);

        List<UserDTO> GetAll(int pageNumber, int pageQuantity);
        User? Get(int id);
    }
}
