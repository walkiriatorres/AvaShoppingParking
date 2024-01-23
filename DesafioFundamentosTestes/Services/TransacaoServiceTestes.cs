using DesafioFundamentos.Services;
using DesafioFundamentos.Models;
using DesafioFundamentos.Repositories;

namespace DesafioFundamentosTestes.Services
{
    public class TransacaoServiceTestes
    {
        private Veiculo _veiculo;       

        public TransacaoServiceTestes(){
            _veiculo = new Veiculo("abc1234");           
        }

        [Fact]
        public void DeveExibirUmaListaQueContemTransacao1ETransacao2QuandoEstasTransacoesForemCriadas()
        {   
            TransacaoService _transacaoService = new TransacaoService();

            Transacao transacao1 = _transacaoService.Criar(_veiculo, 10, (FormaPagamento)1);
            Transacao transacao2 = _transacaoService.Criar(_veiculo, 50, (FormaPagamento)2);
            Transacao transacao3 = _transacaoService.Criar(_veiculo, 100, (FormaPagamento)2);

            List<Transacao> resultadoEsperado = new List<Transacao>{transacao1, transacao2, transacao3};

            _transacaoService.transacaoRepository.SetTransacoes(new List<Transacao>{transacao1, transacao2, transacao3});

            List<Transacao> resultado = _transacaoService.ListarTodas();

            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}