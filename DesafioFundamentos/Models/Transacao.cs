namespace DesafioFundamentos.Models
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public Veiculo Veiculo { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public decimal ValorPagamento { get; set; }
        public DateTime HoraPagamento { get; set; }
        
        public Transacao(Guid id, Veiculo veiculo, FormaPagamento formaPagamento, decimal valorPagamento, DateTime horaPagamento)
        {
            this.Id = id;
            this.Veiculo = veiculo;
            this.FormaPagamento = formaPagamento;
            this.ValorPagamento= valorPagamento;
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
        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Transacao other = (Transacao)obj;

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}