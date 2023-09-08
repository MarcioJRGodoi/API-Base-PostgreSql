using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_PostgreSql.Domain.DTOs
{
    public class TurnsDTO
    {
        public int Id { get; private set; }
        public int VelocidadeMedia { get; set; }
        public DateTime Data { get; set; }
        public int GaiolaId { get; set; }
        public int TempoAtividade { get; set; }
        public float DistanciaPercorrida { get; set; }
    }
}
