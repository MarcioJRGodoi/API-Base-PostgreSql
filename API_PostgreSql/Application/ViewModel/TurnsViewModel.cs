using API_PostgreSql.Domain.DTOs;

namespace API_PostgreSql.Application.ViewModel
{
    public class TurnsViewModel
    {
        public double VelocidadeTotal { get; set; }
        public double DistanciaPercorridaTotal { get; set; }
        public float TempoDeAtividadeTotal { get; set; }
        public List<TurnsDTO> Medias { get; set; }

        public TurnsViewModel(double velocidadeTotal, double distanciaPercorridaTotal, float tempoDeAtividadeTotal)
        {
            VelocidadeTotal = velocidadeTotal;
            DistanciaPercorridaTotal = distanciaPercorridaTotal;
            TempoDeAtividadeTotal = tempoDeAtividadeTotal;
            Medias = new List<TurnsDTO>();
        }
    }
}
