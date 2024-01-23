using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFundamentos.Models;
using DesafioFundamentos.Repositories;

namespace DesafioFundamentos.Services
{
    public class TransacaoService
    {
        public TransacaoRepository transacaoRepository;

        public TransacaoService(){
            this.transacaoRepository = TransacaoRepository.GetInstancia();
        } 
        public Transacao Criar(Veiculo veiculo, decimal valorPagamento, FormaPagamento formaPagamento){
            Transacao transacao = new Transacao(Guid.NewGuid(), veiculo, formaPagamento, valorPagamento, DateTime.Now);
            transacaoRepository.Salvar(transacao);
        
            return transacao;
        }

        public List<Transacao> ListarTodas(){
            return transacaoRepository.ListarTodas();
        }       
    }
}