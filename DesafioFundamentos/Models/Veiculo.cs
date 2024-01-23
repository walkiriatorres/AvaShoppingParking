namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        private string Placa { get; set; }
        private DateTime Entrada { get; set; }
        private DateTime Saida { get; set; }

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

        public void SetEntrada(DateTime entrada)
        {
            this.Entrada = entrada;
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
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            Veiculo outroVeiculo = (Veiculo)obj;
            
            return this.Placa == outroVeiculo.Placa;
        }
        
        public override int GetHashCode()
        {
            return this.Placa.GetHashCode();
        }        
    }
}