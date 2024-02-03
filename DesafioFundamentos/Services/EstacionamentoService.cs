using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFundamentos.Models.Classes;
using DesafioFundamentos.Models.Enums;

namespace DesafioFundamentos.Services
{
    public class EstacionamentoService
    {
        private Estacionamento Estacionamento;
        private ValidadorService ValidadorService;
        private TransacaoService TransacaoService;

        public EstacionamentoService(Estacionamento estacionamento) {
            this.Estacionamento = estacionamento;
            this.ValidadorService = new ValidadorService();
            this.TransacaoService = new TransacaoService();
        }

        public Estacionamento GetEstacionamento(){
            return Estacionamento;
        }

        private decimal CalcularValorPagamentoMinutos(Veiculo veiculo){
            TimeSpan tempoEstacionado = DateTime.Now - veiculo.GetEntrada();

            // TimeSpan tempoEstacionado = new TimeSpan(0, 0, 20, 0, );

            double tempoPercorridoEmMinutos = tempoEstacionado.TotalMinutes;

            if(tempoPercorridoEmMinutos <= 20 || veiculo.GetLimiteSaida() > DateTime.Now){
                return 0;
            } else if(tempoPercorridoEmMinutos <=60){                   
                return Estacionamento.GetPrecoInicial() - veiculo.GetTotalPago();
            } else {                
                int horaAdicional = (int)Math.Ceiling(tempoEstacionado.TotalHours - 1);
                decimal PrecoTotal = Estacionamento.GetPrecoInicial() + (Estacionamento.GetPrecoPorHora() * horaAdicional);
                return PrecoTotal - veiculo.GetTotalPago();
            }
        }

        private void AtualizarLimiteSaida(Veiculo veiculo, Transacao transacao)
        {
            TimeSpan tempoPercorrido = transacao.GetHoraPagamento() - veiculo.GetEntrada();
            int horasPagas = (int)Math.Ceiling(tempoPercorrido.TotalHours);
            DateTime Limite = veiculo.GetEntrada().AddHours(horasPagas);
            double tempoRestante1EmMinutos = (Limite - transacao.GetHoraPagamento()).TotalMinutes;
            
            if(tempoRestante1EmMinutos < 15){
                DateTime LimiteComTolerancia = transacao.GetHoraPagamento().AddMinutes(15);
                veiculo.SetLimiteSaida(LimiteComTolerancia);
            } else {
                veiculo.SetLimiteSaida(Limite);
            }
        }

        

        public void AdicionarVeiculo(Veiculo veiculo){
            ValidadorService.PodeAdicionarVeiculo(veiculo, Estacionamento);
            Estacionamento.GetVagasOcupadas().Add(veiculo);
        }

        public decimal ConsultarValorPagamento (Veiculo veiculo) {
            ValidadorService.PodeConsultarVeiculoEstacionado(veiculo, Estacionamento);
            decimal valorAPagar = CalcularValorPagamentoMinutos(veiculo);            

            return valorAPagar;        
        }        

        public void RealizarPagamento(Veiculo veiculo, decimal valorAPagar, FormaPagamento formaPagamento){
            ValidadorService.PodeRealizarPagamento(veiculo, valorAPagar, formaPagamento, Estacionamento);
            Transacao t = TransacaoService.Criar(veiculo, valorAPagar, formaPagamento);
            veiculo.SetTotalPago(veiculo.GetTotalPago() + valorAPagar);
            AtualizarLimiteSaida(veiculo, t);
        }        
        
        public void RemoverVeiculo(Veiculo veiculo){
            ValidadorService.PodeRemoverVeiculo(veiculo, Estacionamento);
            veiculo.SetSaida(DateTime.Now);
            Estacionamento.GetVagasOcupadas().Remove(veiculo);            
        }

        public Veiculo ConsultarVeiculoEstacionado(Veiculo veiculo) {                
            ValidadorService.PodeConsultarVeiculoEstacionado(veiculo, Estacionamento);
            return Estacionamento.GetVagasOcupadas().First(v => v.GetPlaca().ToUpper() == veiculo.GetPlaca().ToUpper());
        }

        public List<Veiculo> ListarTodos(){
            return Estacionamento.GetVagasOcupadas();
        }  
    }
}