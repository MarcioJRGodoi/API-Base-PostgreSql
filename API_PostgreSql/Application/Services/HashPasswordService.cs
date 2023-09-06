using API_PostgreSql.Domain.Models.EmployeeAgregate;
using System.Security.Cryptography;
using System.Text;

namespace API_PostgreSql.Application.Services
{
    public class HashPasswordService
    {
        public static string HashPassword(string password) 
        {
            byte[] hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

            // Converta os bytes hash em uma representação hexadecimal
            StringBuilder builder = new();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                builder.Append(hashedBytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
