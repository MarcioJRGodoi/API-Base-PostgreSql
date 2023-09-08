using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_PostgreSql.Domain.Models.CageAgregate
{
    [Table("gaiola")]
    public class Cage
    {
        [Key]
        [Column("id")]
        public int Id { get; private set; }
        [Column("diametro")]
        public float Diametro { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }

        public Cage(int diametro, string descricao)
        {
            Diametro = diametro;
            Descricao = descricao;
        }

        public Cage()
        {
        }
    }
}
