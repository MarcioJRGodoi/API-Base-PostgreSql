using System.ComponentModel.DataAnnotations.Schema;

namespace API_PostgreSql.Domain.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public Object? Token { get; set; }
        public string Profile { get; set; }
    }
}
