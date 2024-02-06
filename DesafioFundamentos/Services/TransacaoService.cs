using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFundamentos.Models.Classes;
using DesafioFundamentos.Models.Enums;
using DesafioFundamentos.Repositories;

namespace DesafioFundamentos.Services
{
    public class TransacaoService
    {
        private TransacaoRepository TransacaoRepository;
        private ValidadorService ValidadorService;

        public TransacaoService(){
            this.TransacaoRepository = TransacaoRepository.GetInstancia();
            this.ValidadorService = new ValidadorService();
        }

        public TransacaoRepository GetTransacaoRepository(){
            return TransacaoRepository;
        }
        public Transacao Criar(Veiculo veiculo, decimal valorPagamento, FormaPagamento formaPagamento){
            Transacao transacao = new Transacao(Guid.NewGuid(), veiculo, valorPagamento, formaPagamento, DateTime.Now);
            TransacaoRepository.Salvar(transacao);
        
            return transacao;
        }

        public List<Transacao> ListarTodas(){
            return new List<Transacao>(TransacaoRepository.GetTransacoes());
        }

        public List<Transacao> ListarTransacaoPorData(string data){
            
            List<Transacao> ListaDeTransacao = ListarTodas();
            string statusAutorizacao = ValidadorService.PodeConsultarTransacaoDoDia(data);

            if (statusAutorizacao == "Autorizado" && DateTime.TryParse(data, out DateTime dataInformada)){
                return ListaDeTransacao.Where(t => t.GetHoraPagamento().Date == dataInformada.Date).ToList();
            }

            return new List<Transacao>();
        }

        public List<Transacao> ListarTransacaoPorPeriodo(string dataInicio, string dataFim)
        {
            List<Transacao> ListaDeTransacao = ListarTodas();
            List<Transacao> transacoesNoPeriodo = new List<Transacao>();

            string statusAutorizacao = ValidadorService.PodeConsultarTransacaoDoPeriodo(dataInicio, dataFim);

            if (statusAutorizacao == "Autorizado" && DateTime.TryParse(dataInicio, out DateTime inicio) && DateTime.TryParse(dataFim, out DateTime fim))
            {
                foreach (Transacao transacao in ListaDeTransacao)
                {
                    DateTime dataTransacao = transacao.GetHoraPagamento().Date;
                    if (dataTransacao >= inicio && dataTransacao <= fim)
                    {
                        transacoesNoPeriodo.Add(transacao);
                    }
                }
            }

            return transacoesNoPeriodo;
        }    

        public List<Transacao> ListarTransacoesPorPlaca(string placa){
            string statusAutorizacao = ValidadorService.PodeConsultarTransacaoDaPlaca(placa);

            if(statusAutorizacao == "Autorizado") {
                List<Transacao> ListaDeTransacao = ListarTodas();
                List<Transacao> transacoesDaPlaca = ListaDeTransacao.Where(t => t.GetVeiculo().GetPlaca().ToUpper() == placa.ToUpper()).ToList();

                return transacoesDaPlaca;
            }
            
            return new List<Transacao>();
        }

        public decimal ConsultarFaturamentoAcumulado(){
            decimal FaturamentoAcumulado = 0;

            List<Transacao> ListaDeTransacao = ListarTodas();

            foreach (Transacao t in ListaDeTransacao)
            {
                FaturamentoAcumulado += t.GetValorPagamento();
            }

            return FaturamentoAcumulado;
        }

        public decimal ConsultarFaturamentoPorData(string data){

            decimal faturamentoDoDia = 0;
            List<Transacao> listaTransacoesDoDia = ListarTransacaoPorData(data);

            foreach (Transacao t in listaTransacoesDoDia)
            {
                faturamentoDoDia += t.GetValorPagamento();
            }
            
            return faturamentoDoDia;
        }

        public decimal ConsultarFaturamentoPorPeriodo(string dataInicio, string dataFim){

            decimal faturamentoDoDia = 0;
            List<Transacao> listaTransacoesDoDia = ListarTransacaoPorPeriodo(dataInicio, dataFim);

            foreach (Transacao t in listaTransacoesDoDia)
            {
                faturamentoDoDia += t.GetValorPagamento();
            }
            
            return faturamentoDoDia;
        }
    }
}