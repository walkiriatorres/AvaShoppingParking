namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }

        public Veiculo(string placa)
        {
            this.Placa = placa;
            this.Entrada = DateTime.Now;
        }

        public string GetPlaca(){
            return this.Placa;
        }

        public DateTime GetEntrada(){
            return this.Entrada;
        }

        public DateTime GetSaida(){
            return this.Saida;
        }
        
        public void SetSaida(DateTime saida)
        {
            this.Saida = saida;
        }

        public override bool Equals(object obj)
        {
            // Verifica se o objeto fornecido é nulo ou não é do tipo Veiculo
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // Converte o objeto para Veiculo
            Veiculo outroVeiculo = (Veiculo)obj;

            // Compara as placas dos veículos
            return this.Placa == outroVeiculo.Placa;
        }        

        // Se você sobrescrever Equals, é uma boa prática sobrescrever GetHashCode também
        public override int GetHashCode()
        {
            return this.Placa.GetHashCode();
        }        
    }
}