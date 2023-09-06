using API_PostgreSql.Application.Services;
using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.Models.EmployeeAgregate;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API_PostgreSql.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionDatabase _context = new();
        public async Task Add(User user)
        {

            var newUser = new User(user.Name, HashPasswordService.HashPassword(user.Password), user.Profile);
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<UserDTO>> GetAll()
        {
            return  await _context.Users
                .Select(user => new UserDTO
                {
                    Id = user.Id,
                    UserName = user.Name,
                    Profile = user.Profile,
                }).ToListAsync();
        }

        public async Task<bool> Update(int id, User user)
        {
            var existingUser = await _context.Set<User>().FindAsync(id);

            if (existingUser == null)
            {
                return false; 
            }

            existingUser.Name = user.Name;
            existingUser.Profile = user.Profile;
            existingUser.Password = HashPasswordService.HashPassword(user.Password);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Erro ao atualizar o usuário: {ex.Message}");
            }
        }

        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
