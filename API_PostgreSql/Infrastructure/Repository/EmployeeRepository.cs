using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.IRepository;
using API_PostgreSql.Domain.Models;
using Microsoft.AspNetCore.Connections;

namespace API_PostgreSql.Infrastructure.Repository
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

        public List<EmployeeDTO> GetAll(int pageNumber, int pageQuantity)
        {
            return _context.Employees.Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select(e => 
                new EmployeeDTO()
                {
                    Id = e.Id,
                    NameEmployee = e.Name,
                    Photo = e.Photo
                }
                )
                .ToList();
        }
    }
}
