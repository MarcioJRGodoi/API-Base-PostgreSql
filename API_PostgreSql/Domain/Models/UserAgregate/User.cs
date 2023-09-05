using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API_postgres;

namespace API_PostgreSql.Domain.Models.EmployeeAgregate
{
    [Table("usuario")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get;  set; }
        [Column("usuario")]
        public string Name { get;  set; }
        [Column("senha")]
        public string Password { get;  set; }
        [Column("perfil")]
        public string Profile { get; set; }

        public User(string userName, string password, string profile)
        {
            Name = userName;
            Password = password;
            Profile = profile;
        }

        public User()
        {
        }
    }
}
