using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_PostgreSql.Domain.DTOs
{
    public class CageDTO
    {
        public int Id { get; set; }
        public float Diametro { get; set; }
        public string Descricao { get; set; }
    }
}
