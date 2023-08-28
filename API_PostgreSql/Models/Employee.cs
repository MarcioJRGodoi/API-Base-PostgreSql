using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_postgres.Models
{
    [Table("empregados")]
    public class Employee
    {
        [Key]
        [Column("id")]
        public int Id { get; private set; }
        [Column("name")]
        public string Name { get; private set; }
        [Column("age")]
        public int Age { get; private set; }
        [Column("photo")]
        public string? Photo { get; private set; }

        public Employee(string name, int age, string photo)
        {
            Name = name;
            Age = age;
            Photo = photo;
        }
    }
}
