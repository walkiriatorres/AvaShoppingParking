namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal PrecoInicial;
        private decimal PrecoPorHora;
        private int TotalDeVagas;
        private List<Veiculo> VagasOcupadas;

        public Estacionamento(decimal precoInicial, decimal precoPorHora, int totalDeVagas) {
            this.PrecoInicial = precoInicial;
            this.PrecoPorHora = precoPorHora;
            this.TotalDeVagas = totalDeVagas;
            this.VagasOcupadas = new List<Veiculo>();
        }

        public decimal GetPrecoInicial() {
            return this.PrecoInicial;
        }

        public decimal GetPrecoPorHora() {
            return this.PrecoPorHora;
        }

        public int GetTotalDeVagas() {
            return this.TotalDeVagas;
        }

        public List<Veiculo> GetVagasOcupadas() {
            return this.VagasOcupadas;
        }

        public override bool Equals(object obj)
        {
            // Verifica se o objeto fornecido é nulo ou não é do tipo Estacionamento
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // Converte o objeto para Estacionamento
            Estacionamento OutroEstacionamento = (Estacionamento)obj;

            // Compara os estacionamentos
            
            return PrecoInicial == OutroEstacionamento.PrecoInicial &&
                    PrecoPorHora == OutroEstacionamento.PrecoPorHora &&
                    TotalDeVagas == OutroEstacionamento.TotalDeVagas &&
                    VagasOcupadas.SequenceEqual(OutroEstacionamento.VagasOcupadas);
        }       

        public override int GetHashCode()
        {
            return HashCode.Combine(PrecoInicial, PrecoPorHora, TotalDeVagas, VagasOcupadas);
        }      
    }
}