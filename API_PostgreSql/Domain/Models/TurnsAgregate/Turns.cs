using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API_postgres;

namespace API_PostgreSql.Domain.Models.EmployeeAgregate
{
    [Table("voltasnaroda")]
    public class Turns
    {
        [Key]

        [Column("id")]
        public int id { get; set; }

        [Column("velocidade_media")]
        public int velocidade_media { get; set; }

        [Column("data")]
        public DateTime data { get; set; }

        [Column("gaiola_id")]
        public int gaiola_id { get; set; }

        [Column("tempo_atividade")]
        public int tempo_atividade { get; set; }

        [Column("distância_percorrida")]
        public int distancia_percorrida { get; set; }

        public Turns(int  ID,int  velocidadeMedia,DateTime Data,int idGaiola, int tempoAtividade,int distanciaPercorrida)
        {
            id=ID;
            velocidade_media = velocidadeMedia;
            data = Data;
            gaiola_id = idGaiola;
            tempo_atividade = tempoAtividade;
            distancia_percorrida = distanciaPercorrida;
        }

        public Turns()
        {
        }
    }
}
