using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_PostgreSql.Domain.DTOs
{
    public class TurnsDTO
    {
        public int Id { get; private set; }
        public int velocidade_media { get; set; }
        public DateTime data { get; set; }
        public int gaiola_id { get; private set; }
        public int tempo_atividade { get; set; }
        public int distancia_percorrida { get; set; }
    }
}
