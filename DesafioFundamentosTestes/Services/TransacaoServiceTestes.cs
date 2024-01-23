using DesafioFundamentos.Services;
using DesafioFundamentos.Models;
using DesafioFundamentos.Repositories;

namespace DesafioFundamentosTestes.Services
{
    public class TransacaoServiceTestes
    {
        private Veiculo _veiculo;
        private TransacaoService _transacaoService;        

        public TransacaoServiceTestes(){
            _veiculo = new Veiculo("abc1234");            
            _transacaoService = new TransacaoService();
        }
        /*

        [Fact]
        public void DeveExibirUmaListaQueContemTransacao1ETransacao2QuandoEstasTransacoesForemCriadas()
        {   
            Transacao transacao1 = _transacaoService.Criar(_veiculo, 10, (FormaPagamento)1);
            Transacao transacao2 = _transacaoService.Criar(_veiculo, 50, (FormaPagamento)2);

            List<Transacao> resultadoEsperado = new List<Transacao>{transacao1, transacao2};

            List<Transacao> resultado = _transacaoService.ListarTodas();

            Assert.Equal(resultadoEsperado, resultado);
        } 
        */     
    }
}