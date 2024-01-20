using DesafioFundamentos.Models;
using System.Text.RegularExpressions;
using DesafioFundamentos.Exceptions;

namespace DesafioFundamentos.Services
{
    public class EstacionamentoValidador
    {
        public void PodeAdicionarVeiculo(Veiculo veiculo, Estacionamento estacionamento)

        {            
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
                throw new VeiculoInvalidoException("Placa nula ou vazia não pode ser estacionada.");
            }
            
            if(EstacionamentoEstaLotado(estacionamento))
            {                
                throw new VeiculoInvalidoException("Estacionamento está lotado.");
            }

            if(!PlacaEhValida(veiculo.GetPlaca()))
            {
                throw new VeiculoInvalidoException("Placa inválida.");
            }
            
            if(VeiculoEstaEstacionado(veiculo, estacionamento))
            {
                throw new VeiculoInvalidoException("Veiculo já está estacionado.");
            }
        }

        public bool PlacaNulaOuVazia(string placa) {
            if(string.IsNullOrEmpty(placa))
            {
                return true;
            }

            return false;
        }

        public bool EstacionamentoEstaLotado(Estacionamento estacionamento)
        {            
            if(estacionamento == null)
            {
                return false;
            }

            return ContarVeiculosEstacionados(estacionamento) == estacionamento.GetTotalDeVagas();
        }

        public bool EstacionamentoEstaVazio(Estacionamento estacionamento)
        {            
            if(estacionamento == null)
            {
                return false;                
            }

            return estacionamento.GetVagasOcupadas().Count == 0;
        }

        public int ContarVeiculosEstacionados(Estacionamento estacionamento)
        {
            if (estacionamento == null)
            {
                throw new EstacionamentoInvalidoException("O estacionamento não pode ser nulo.");
            }
            
            return estacionamento.GetVagasOcupadas().Count;
        }

        public bool PlacaEhValida(string placa)
        {
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

        public bool VeiculoEstaEstacionado(Veiculo veiculo, Estacionamento estacionamento){
            if(veiculo == null)            
            {
                return false;
            }

            if(estacionamento == null)
            {
                return false;
            }
            return estacionamento.GetVagasOcupadas().Any(x => x.GetPlaca().ToUpper() == veiculo.GetPlaca().ToUpper());            
        }

        // criar exceções corretas:
        public void PodeConsultarValor(Veiculo veiculo, Estacionamento estacionamento){
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

            if(!VeiculoEstaEstacionado(veiculo, estacionamento))
            {
                throw new VeiculoInvalidoException("Veiculo não está estacionado.");
            }
        }

        public void PodeConsultarVeiculoEstacionado(Veiculo veiculo, Estacionamento estacionamento){
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

            if(!VeiculoEstaEstacionado(veiculo, estacionamento))
            {
                throw new VeiculoInvalidoException("Veiculo não está estacionado.");
            }

        }

        /*
        // --- WIP --- //
        // FormaPagamento trocar pra Enum? //

        public void PodeRemoverVeiculo(Veiculo veiculo, Estacionamento estacionamento, string formaPagamento, decimal valorPago){
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

            if(!VeiculoEstaEstacionado(veiculo, estacionamento))
            {
                throw new VeiculoInvalidoException("Veiculo não está estacionado.");
            }

            if(string.IsNullOrEmpty(formaPagamento)){
                throw new VeiculoInvalidoException("Forma de pagamento inválida");
            }

            // se valorPago não for decimal, faça tratamento
        }

        */
    }
}