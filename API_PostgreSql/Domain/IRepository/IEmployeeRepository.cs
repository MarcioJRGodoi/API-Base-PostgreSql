using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.Models;

namespace API_PostgreSql.Domain.IRepository
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        List<EmployeeDTO> GetAll(int pageNumber, int pageQuantity);
        Employee? Get(int id);
    }
}
