using DesafioFundamentos.Models.Classes;
using DesafioFundamentos.Models.Enums;
using System.Text.RegularExpressions;
using DesafioFundamentos.Exceptions;
using DesafioFundamentos.Repositories;

namespace DesafioFundamentos.Services
{
    public class ValidadorService
    {
        private bool PlacaNulaOuVazia(string placa) {
            if(string.IsNullOrEmpty(placa))
            {
                return true;
            }

            return false;
        }

        private bool EstacionamentoEstaLotado(Estacionamento estacionamento) {            
            if(estacionamento == null)
            {
                return false;
            }

            return ContarVeiculosEstacionados(estacionamento) == estacionamento.GetTotalDeVagas();
        }

        public bool PlacaEhValida(string placa) {
            if(PlacaNulaOuVazia(placa))
            {
                return false;
            }

            string PadraoPlacaAnterior = @"^[A-Z]{3}\d{4}$";
            string PadraoPlacaMercosul = @"^[A-Z]{3}\d[A-Z]\d{2}$";

            Regex regexAnterior = new Regex(PadraoPlacaAnterior, RegexOptions.IgnoreCase);
            Regex regexMercosul = new Regex(PadraoPlacaMercosul, RegexOptions.IgnoreCase);

            return regexAnterior.IsMatch(placa) || regexMercosul.IsMatch(placa);
        }    

        private void ConsultarValidadeVeiculoEstacionamento(Veiculo veiculo, Estacionamento estacionamento){
            if (veiculo == null)
            {
                throw new VeiculoInvalidoException("O veiculo não pode ser nulo.");
            }
            
            if (estacionamento == null)
            {
                throw new EstacionamentoInvalidoException("O estacionamento não pode ser nulo.");
            }
            
            if(PlacaNulaOuVazia(veiculo.GetPlaca()))
            {
                throw new PlacaInvalidaException("Placa nula ou vazia não pode ser estacionada.");
            }

            if(!PlacaEhValida(veiculo.GetPlaca()))
            {
                throw new PlacaInvalidaException("Placa inválida.");
            }
        }

        public void PodeAdicionarVeiculo(Veiculo veiculo, Estacionamento estacionamento)

        {
            ConsultarValidadeVeiculoEstacionamento(veiculo, estacionamento);
            
            if(EstacionamentoEstaLotado(estacionamento))
            {                
                throw new VeiculoInvalidoException("Estacionamento está lotado.");
            }            
            
            if(VeiculoEstaEstacionado(veiculo, estacionamento))
            {
                throw new VeiculoInvalidoException("Veiculo já está estacionado.");
            }
        }    
        public int ContarVeiculosEstacionados(Estacionamento estacionamento) {
            if (estacionamento == null)
            {
                throw new EstacionamentoInvalidoException("O estacionamento não pode ser nulo.");
            }
            
            return estacionamento.GetVagasOcupadas().Count;
        }

        // ATENÇÃO NOS MÉTODOS A SEGUIR: FAZER A MESMA COISA? WIP 

        public void PodeConsultarVeiculoEstacionado(Veiculo veiculo, Estacionamento estacionamento){
            ConsultarValidadeVeiculoEstacionamento(veiculo, estacionamento);

            if(!VeiculoEstaEstacionado(veiculo, estacionamento))
            {
                throw new VeiculoInvalidoException("Veiculo não está estacionado.");
            }
        }    

        public bool VeiculoEstaEstacionado(Veiculo veiculo, Estacionamento estacionamento){

            if(veiculo == null || estacionamento == null)            
            {
                return false;
            }

            return estacionamento.GetVagasOcupadas().Any(v => v.GetPlaca().ToUpper() == veiculo.GetPlaca().ToUpper());            
        }        

        public void PodeRealizarPagamento(Veiculo veiculo, decimal valorAPagar, FormaPagamento formaPagamento, Estacionamento estacionamento){
            ConsultarValidadeVeiculoEstacionamento(veiculo, estacionamento);
            
            if(valorAPagar <= 0){
                throw new VeiculoInvalidoException("Não há valor a pagar.");

            }
            
            if (!Enum.IsDefined(typeof(FormaPagamento), formaPagamento) || formaPagamento == default(FormaPagamento))
            {
                throw new FormaPagamentoInvalidaException("Forma de pagamento inválida.");
            }
        }

        public void PodeRemoverVeiculo(Veiculo veiculo, Estacionamento estacionamento){
            PodeConsultarVeiculoEstacionado(veiculo, estacionamento);

            if(veiculo.GetLimiteSaida() < DateTime.Now)
            {
                throw new VeiculoInvalidoException("Veiculo excedeu limite de saída.");
            }
        }

        public string PodeConsultarTransacaoDaPlaca(string placa) {
            if(PlacaNulaOuVazia(placa))
            {
                throw new PlacaInvalidaException("Placa nula ou vazia.");
            }

            if(!PlacaEhValida(placa))
            {
                throw new PlacaInvalidaException("Placa inválida.");
            }

            if(!TransacaoRepository.GetInstancia().GetTransacoes().Any(t => t.GetVeiculo().GetPlaca().ToUpper() == placa.ToUpper())){
                throw new PlacaInvalidaException($"Placa: {placa} não realizou transação");
            }

            return "Autorizado";
        }

        public string PodeConsultarTransacaoDoDia(string data) {
            DateTime dataInformada;

            if (!DateTime.TryParse(data, out dataInformada))
            {
                throw new TransacaoInvalidaException ("Formato de data inválido. Certifique-se de usar o formato DD/MM/AAAA.");
            }

            if (dataInformada > DateTime.Now)
            {
                throw new TransacaoInvalidaException("A data não pode ser maior do que a data atual.");
            }

            return "Autorizado";
        }
        
        public string PodeConsultarTransacaoDoPeriodo(string dataInicio, string dataFim) {
            DateTime inicio, fim;

            if (!DateTime.TryParse(dataInicio, out inicio) || !DateTime.TryParse(dataFim, out fim))
            {
                throw new TransacaoInvalidaException ("Formato de data inválido. Certifique-se de usar o formato DD/MM/AAAA.");
            }

            if (inicio > DateTime.Now)
            {
                throw new TransacaoInvalidaException("A data de início não pode ser maior do que a data atual.");
            }
            
            if (inicio.CompareTo(fim) > 0)
            {
                throw new TransacaoInvalidaException("A data de início não pode ser maior do que a data de fim.");
            }

            return "Autorizado";
        }      
    }
}