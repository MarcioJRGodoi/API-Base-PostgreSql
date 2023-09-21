using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_PostgreSql.Domain.Models.TurnsAgregate
{
    [Table("voltasnaroda")]
    public class Turns
    {
        [Key]
        [Column("id")]
        public int Id { get; private set; }
        [Column("velocidade_media")]
        public int VelocidadeMedia { get; set; }
        [Column("data")]
        public DateTime Data { get; set; }
        [Column("gaiola_id")]
        public int GaiolaId { get; set; }
        [Column("tempo_atividade")]
        public int TempoAtividade { get; set; }
        [Column("distancia_percorrida")]
        public float DistanciaPercorrida { get; set; }
        [Column("quantidade_voltas")]
        public int QuantidadeVoltas { get; set; }

        public Turns(int velocidadeMedia, int tempoAtividade, float distanciaPercorrida, DateTime data, int gaiolaId, int quantidadeVoltas)
        {
            Data = data;
            GaiolaId = gaiolaId;
            VelocidadeMedia = velocidadeMedia;
            TempoAtividade = tempoAtividade;
            DistanciaPercorrida = distanciaPercorrida;
            QuantidadeVoltas = quantidadeVoltas;
        }

        public Turns()
        {
        }
    }
}