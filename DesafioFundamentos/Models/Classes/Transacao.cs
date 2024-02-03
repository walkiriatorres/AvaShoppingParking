using DesafioFundamentos.Models.Enums;

namespace DesafioFundamentos.Models.Classes
{
    public class Transacao
    {
        private Guid Id { get; set; }
        private Veiculo Veiculo { get; set; }
        private FormaPagamento FormaPagamento { get; set; }
        private decimal ValorPagamento { get; set; }
        private DateTime HoraPagamento { get; set; }
        
        public Transacao(Guid id, Veiculo veiculo, decimal valorPagamento, FormaPagamento formaPagamento, DateTime horaPagamento)
        {
            this.Id = id;
            this.Veiculo = veiculo;
            this.ValorPagamento= valorPagamento;
            this.FormaPagamento = formaPagamento;
            this.HoraPagamento = horaPagamento;
        }
        
        public Guid GetId(){
            return Id;
        }
        public Veiculo GetVeiculo(){
            return Veiculo;
        }
        public FormaPagamento GetFormaPagamento(){
            return FormaPagamento;
        }
        public decimal GetValorPagamento(){
            return ValorPagamento;
        }
        public DateTime GetHoraPagamento(){
            return HoraPagamento;
        }

        /*

         public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Transacao other = (Transacao)obj;

            return Id.Equals(other.Id)
                && Veiculo.Equals(other.Veiculo)
                && FormaPagamento.Equals(other.FormaPagamento)
                && ValorPagamento.Equals(other.ValorPagamento)
                && HoraPagamento.Equals(other.HoraPagamento);
        }

        // Sobrescrever o método GetHashCode para evitar avisos do compilador
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Veiculo, FormaPagamento, ValorPagamento, HoraPagamento);
        }
        */
    }
}