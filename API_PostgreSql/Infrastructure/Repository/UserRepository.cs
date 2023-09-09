using API_PostgreSql.Application.Services;
using API_PostgreSql.Application.ViewModel;
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

        public async Task<UserViewModel> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null)
            {
                return null;
            }
            var userView = new UserViewModel
            {
                Id = user.Id,
                Profile = user.Profile,
                Name = user.Name,
            };
            return userView;
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            return  await _context.Users
                .Select(user => new UserViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
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

        public async Task<bool> Delete(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return false;
                }
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception e)
            {
                throw new Exception($"Erro ao deletar o usuário: {e.Message}");
            }
        }
    }
}
