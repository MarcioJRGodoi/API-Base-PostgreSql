using API_PostgreSql.Domain.DTOs;

namespace API_PostgreSql.Domain.Models.EmployeeAgregate
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        List<EmployeeDTO> GetAll(int pageNumber, int pageQuantity);
        Employee? Get(int id);
    }
}
