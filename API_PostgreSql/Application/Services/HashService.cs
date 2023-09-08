using System.Security.Cryptography;

namespace API_PostgreSql.Application.Services
{
    public class HashService
    {
        public static byte[] GenerateRandomSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[16]; // Você pode ajustar o tamanho do salt conforme necessário
                rng.GetBytes(salt);
                return salt;
            }
        }

        public static string HashPassword(string password, byte[] salt)
        {
            int iterations = 10000; // Número de iterações (ajuste conforme necessário)
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                byte[] hash = pbkdf2.GetBytes(32); // Tamanho do hash (32 bytes para um hash seguro)
                byte[] saltAndHash = new byte[salt.Length + hash.Length];

                // Combine o salt e o hash em um único array
                Array.Copy(salt, 0, saltAndHash, 0, salt.Length);
                Array.Copy(hash, 0, saltAndHash, salt.Length, hash.Length);

                // Converta o salt e o hash para uma representação em base64 para armazenamento seguro
                string saltAndHashBase64 = Convert.ToBase64String(saltAndHash);

                return saltAndHashBase64;
            }
        }
    }
}
