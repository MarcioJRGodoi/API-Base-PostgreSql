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
        public async void Add(User user)
        {
            // metodo para criptografar a senha recebida
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(user.Password));

                // Converta os bytes hash em uma representação hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                //Parte que cria o usuario e envia para o banco de dados
                var newUser = new User(user.Name, builder.ToString(), user.Profile);
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
            }
               
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

        public async void Update(int id, User user)
        {
            //tecnicamente nao é uma boa pratica fazer isso dessa forma, porem podemos usar por enquanto
            var oldUser =  await _context.Users.FindAsync(id);
            oldUser.Name = user.Name;
            oldUser.Profile = user.Profile;
            oldUser.Password = user.Password;

            await _context.SaveChangesAsync();
  
        }

        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
