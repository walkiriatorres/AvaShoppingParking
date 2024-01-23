using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DesafioFundamentos.Models;
using DesafioFundamentos.Repositories;

namespace DesafioFundamentosTestes.Repositories
{
    public class TransacaoRepositoryTestes
    {        
        private Veiculo _veiculo;
 
        public TransacaoRepositoryTestes()
        {
            _veiculo = new Veiculo("ABC1234");
        }     

        [Fact]
        public void DeveExibirUmaListaVaziaQuandoTransacoesNãoForemCriadas()
        {
            TransacaoRepository _transacaoRepository = TransacaoRepository.GetInstancia();
            _transacaoRepository.Transacoes = new List<Transacao>();
            
            var resultadoEsperado = new List<Transacao>{};

            var resultado = _transacaoRepository.ListarTodas();

            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void DeveExibirUmaTransacaoQuandoSalvarApenasUmaTransacao()
        {
            TransacaoRepository _transacaoRepository = TransacaoRepository.GetInstancia();
            _transacaoRepository.Transacoes = new List<Transacao>();

            Transacao transacao1 = new Transacao(Guid.NewGuid(), _veiculo, (FormaPagamento)1, 10, DateTime.Now);            
            
            _transacaoRepository.Salvar(transacao1);

            var resultadoEsperado = 1;
            var resultado = _transacaoRepository.ListarTodas().Count();

            Assert.Equal(resultadoEsperado, resultado);
        }        
        
        [Fact]
        public void DeveExibirUmaListaQueContemTransacao1Transacao2Transacao3QuandoEstasTransacoesForemCriadas()
        {
            TransacaoRepository _transacaoRepository = TransacaoRepository.GetInstancia();
            _transacaoRepository.Transacoes = new List<Transacao>();
            
            Transacao transacao1 = new Transacao(Guid.NewGuid(), _veiculo, (FormaPagamento)1, 10, DateTime.Now);
            Transacao transacao2 = new Transacao(Guid.NewGuid(), _veiculo, (FormaPagamento)2, 50, DateTime.Now);
            Transacao transacao3 = new Transacao(Guid.NewGuid(), _veiculo, (FormaPagamento)1, 100, DateTime.Now);

            var resultadoEsperado = new List<Transacao>{transacao1, transacao2, transacao3};

            _transacaoRepository.Salvar(transacao1);
            _transacaoRepository.Salvar(transacao2);
            _transacaoRepository.Salvar(transacao3);
            
            var resultado = _transacaoRepository.ListarTodas();

            Assert.Equal(resultadoEsperado, resultado);
        }        
    }
}