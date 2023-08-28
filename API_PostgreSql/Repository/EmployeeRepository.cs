using API_postgres.Data;
using API_postgres.IRepository;
using API_postgres.Models;
using Microsoft.AspNetCore.Connections;

namespace API_postgres.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionDatabase _context = new ConnectionDatabase();
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
    }
}
