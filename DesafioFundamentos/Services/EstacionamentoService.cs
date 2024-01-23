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

            TimeSpan tempoEstacionado = veiculo.GetSaida() - veiculo.GetEntrada();
            decimal valorAPagar = CalcularValorPagamentoMinutos(tempoEstacionado);            

            return valorAPagar;            
        }

        // -- INICIO WIP -- //
        public void RemoverVeiculo(Veiculo veiculo, FormaPagamento formaPagamento, decimal valorAPagar, Estacionamento estacionamento){
            EstacionamentoValidador.PodeRemoverVeiculo(veiculo, formaPagamento, valorAPagar, estacionamento);
            // Setar o datetime.now para veiculo.SetSaida(DateTime.Now);
            TransacaoService.Criar(veiculo, valorAPagar, formaPagamento);
            Estacionamento.GetVagasOcupadas().Remove(veiculo);            
        }
        // -- FIM WIP -- //

        public Veiculo ConsultarVeiculoEstacionado(Veiculo veiculo) {                
            EstacionamentoValidador.PodeConsultarVeiculoEstacionado(veiculo, Estacionamento);
            return Estacionamento.GetVagasOcupadas().First(v => v.GetPlaca().ToUpper() == veiculo.GetPlaca().ToUpper());
        }

        public List<Veiculo> ListarTodos(){
            return Estacionamento.GetVagasOcupadas();
        }
        
        public decimal CalcularValorPagamentoMinutos(TimeSpan tempoEstacionado){
            double tempoPercorridoEmMinutos = tempoEstacionado.TotalMinutes;

            if(tempoPercorridoEmMinutos <=60){                   
                return Estacionamento.GetPrecoInicial();
            } else {                
                int horaAdicional = (int)Math.Ceiling(tempoEstacionado.TotalHours - 1);

                Console.WriteLine($"O tempoEstacionado é: {tempoEstacionado}");
                Console.WriteLine($"O tempoPercorridoEmMinutos é: {tempoPercorridoEmMinutos}");
                Console.WriteLine($"O tempoEstacionado.TotalHours é: {tempoEstacionado.TotalHours}");
                Console.WriteLine($"A hora adicional é: {horaAdicional}");

                return Estacionamento.GetPrecoInicial() + (Estacionamento.GetPrecoPorHora() * horaAdicional);
            }
        }
                  
        public void ExibirHorasDoTimeStamp(TimeSpan intervaloDeTempo){
            int horas = intervaloDeTempo.Days * 24 + intervaloDeTempo.Hours;
            int minutos = intervaloDeTempo.Minutes;
            int segundos = intervaloDeTempo.Seconds;
            
            Console.WriteLine($"Horas: {horas}");
            Console.WriteLine($"Minutos: {minutos}");
            Console.WriteLine($"Segundos: {segundos}");
        }             
    }
}