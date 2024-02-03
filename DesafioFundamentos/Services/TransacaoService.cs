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

        public TransacaoService(){
            this.TransacaoRepository = TransacaoRepository.GetInstancia();
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

            if (DateTime.TryParse(data, out DateTime dataInformada)){
                List<Transacao> transacoesDaData = ListaDeTransacao.Where(t => t.GetHoraPagamento().Date == dataInformada.Date).ToList();
                return transacoesDaData;
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
    }
}