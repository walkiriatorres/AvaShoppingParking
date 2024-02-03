namespace DesafioFundamentos.Models.Classes
{
    public class Veiculo
    {
        private Guid Id { get; set; }
        private string Placa { get; set; }
        private DateTime Entrada { get; set; }
        private DateTime Saida { get; set; }
        private decimal TotalPago { get; set; }
        private DateTime LimiteSaida { get; set; }

        public Veiculo(string placa)
        {
            this.Id = Guid.NewGuid();
            this.Placa = placa;
            // this.Entrada = DateTime.Now;
            // this.LimiteSaida = DateTime.Now.AddMinutes(20);
            this.Entrada = new DateTime(2024, 1, 31, 18, 24, 0);
            this.LimiteSaida = new DateTime(2024, 1, 31, 18, 24, 0).AddMinutes(20);
        }        

        public Guid GetId(){
            return this.Id;
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

        public decimal GetTotalPago(){
            return this.TotalPago;
        }

        public void SetTotalPago(decimal TotalPago){
            this.TotalPago = TotalPago;
        }
        public DateTime GetLimiteSaida(){
            return this.LimiteSaida;
        }

        public void SetLimiteSaida(DateTime LimiteSaida){
            this.LimiteSaida = LimiteSaida;
        }        
        /*
        public void SetEntrada(DateTime entrada)
        {
            this.Entrada = entrada;
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
        */        
    }
}