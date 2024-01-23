using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFundamentos.Models;

namespace DesafioFundamentos.Services
{
    public class EstacionamentoService
    {
        public Estacionamento Estacionamento;
        public EstacionamentoValidador EstacionamentoValidador;
        public TransacaoService TransacaoService;

        public EstacionamentoService(Estacionamento estacionamento) {
            this.Estacionamento = estacionamento;
            this.EstacionamentoValidador = new EstacionamentoValidador();
            this.TransacaoService = new TransacaoService();
        }

        public Estacionamento ExibirEstacionamento(){
            return Estacionamento;
        }

        public void AdicionarVeiculo(Veiculo veiculo) {
            EstacionamentoValidador.PodeAdicionarVeiculo(veiculo, Estacionamento);
            Estacionamento.GetVagasOcupadas().Add(veiculo);                                  
        }

        public decimal ConsultarValorPagamento (Veiculo veiculo) {
            EstacionamentoValidador.PodeConsultarValor(veiculo, Estacionamento);
            decimal valorAPagar = CalcularValorPagamentoMinutos(veiculo);            

            return valorAPagar;            
        }
        
        public void RemoverVeiculo(Veiculo veiculo, FormaPagamento formaPagamento, decimal valorAPagar, Estacionamento estacionamento){
            EstacionamentoValidador.PodeRemoverVeiculo(veiculo, formaPagamento, valorAPagar, estacionamento);
            veiculo.SetSaida(DateTime.Now);
            TransacaoService.Criar(veiculo, valorAPagar, formaPagamento);
            Estacionamento.GetVagasOcupadas().Remove(veiculo);            
        }

        public Veiculo ConsultarVeiculoEstacionado(Veiculo veiculo) {                
            EstacionamentoValidador.PodeConsultarVeiculoEstacionado(veiculo, Estacionamento);
            return Estacionamento.GetVagasOcupadas().First(v => v.GetPlaca().ToUpper() == veiculo.GetPlaca().ToUpper());
        }

        public List<Veiculo> ListarTodos(){
            return Estacionamento.GetVagasOcupadas();
        }
        
        public decimal CalcularValorPagamentoMinutos(Veiculo veiculo){
            TimeSpan tempoEstacionado = DateTime.Now - veiculo.GetEntrada();

            // TimeSpan tempoEstacionado = new TimeSpan(0, 4, 00, 0, 01);

            double tempoPercorridoEmMinutos = tempoEstacionado.TotalMinutes;

            if(tempoPercorridoEmMinutos <=60){                   
                return Estacionamento.GetPrecoInicial();
            } else {                
                int horaAdicional = (int)Math.Ceiling(tempoEstacionado.TotalHours - 1);
                return Estacionamento.GetPrecoInicial() + (Estacionamento.GetPrecoPorHora() * horaAdicional);
            }
        }           
    }
}