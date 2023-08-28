using API_postgres.Models;

namespace API_postgres.IRepository
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        List<Employee> GetAll();
        Employee? Get(int id);
    }
}
