using API_PostgreSql.Domain.DTOs;

namespace API_PostgreSql.Application.ViewModel
{
    public class TurnsViewModel
    {
        public int VelocidadeTotal { get; set; }
        public float DistanciaPercorridaTotal { get; set; }
        public int TempoDeAtividadeTotal { get; set; }
        public List<TurnsDTO> Medias { get; set; }

    }
}
