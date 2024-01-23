namespace DesafioFundamentos.Models
{
    public class Transacao
    {
        private Guid Id { get; set; }
        private Veiculo Veiculo { get; set; }
        private FormaPagamento FormaPagamento { get; set; }
        private decimal ValorPagamento { get; set; }
        private DateTime HoraPagamento { get; set; }
        
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
    }
}