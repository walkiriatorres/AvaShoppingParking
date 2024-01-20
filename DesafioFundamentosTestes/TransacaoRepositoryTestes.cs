using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DesafioFundamentos.Models;
using DesafioFundamentos.Repositories;

namespace DesafioFundamentosTestes
{
    public class TransacaoRepositoryTestes
    {

        private Transacao _transacao;
        private Veiculo _veiculo;

        private TransacaoRepository _transacaoRepository; 
        public TransacaoRepositoryTestes()
        {
            _veiculo = new Veiculo("ABC1234");
            _transacao = new Transacao(Guid.NewGuid(), _veiculo, "1", 10, DateTime.Now);
            _transacaoRepository = new TransacaoRepository();
        }

        [Fact]
        public void DeveExibir1QuandoSalvarUmaTransacao()
        {
            _transacaoRepository.Salvar(_transacao);

            var resultadoEsperado = 1;
            var resultado = _transacaoRepository.Transacoes.Count();

            Assert.Equal(resultadoEsperado, resultado);
        }

        // FAZER TRATAMENTO PARA NÃO ACEITAR TRANSAÇÃO NULA?

        [Fact]
        public void DeveExibir1QuandoSalvarUmaTransacaoNula()
        {
            _transacaoRepository.Salvar(null);
            
            var resultadoEsperado = 1;
            var resultado = _transacaoRepository.Transacoes.Count();

            Assert.Equal(resultadoEsperado, resultado);
        }
        
        [Fact]
        public void DeveExibirUmaListaQueContemTransacao1Transacao2Transacao3QuandoEstasTransacoesForemCriadas()
        {
            Transacao transacao1 = new Transacao(Guid.NewGuid(), _veiculo, "1", 10, DateTime.Now);
            Transacao transacao2 = new Transacao(Guid.NewGuid(), _veiculo, "2", 50, DateTime.Now);
            Transacao transacao3 = new Transacao(Guid.NewGuid(), _veiculo, "1", 100, DateTime.Now);

            var resultadoEsperado = new List<Transacao>{transacao1, transacao2, transacao3};

            _transacaoRepository.Transacoes.Add(transacao1);
            _transacaoRepository.Transacoes.Add(transacao2);
            _transacaoRepository.Transacoes.Add(transacao3);
            
            var resultado = _transacaoRepository.ListarTodas();

            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void DeveExibirUmaListaVaziaQuandoTransacoesNãoForemCriadas()
        {
            var resultadoEsperado = new List<Transacao>{};
            
            var resultado = _transacaoRepository.ListarTodas();

            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}