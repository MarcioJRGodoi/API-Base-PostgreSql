using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.Models.EmployeeAgregate;
using Microsoft.AspNetCore.Connections;

namespace API_PostgreSql.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionDatabase _context = new ConnectionDatabase();
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User? Get(int id)
        {
            return _context.Users.Find(id);
        }

        public List<UserDTO> GetAll(int pageNumber, int pageQuantity)
        {
            return _context.Users.Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select(e => 
                new UserDTO()
                {
                    Id = e.Id,
                    UserName = e.Name,
                    Profile = e.Profile,
                }
                )
                .ToList();
        }
    }
}
