using DesafioFundamentos.Services;
using DesafioFundamentos.Models.Classes;
using DesafioFundamentos.Models.Enum;
using DesafioFundamentos.Repositories;

namespace DesafioFundamentosTestes.Services
{
    public class TransacaoServiceTestes
    {
        private Veiculo _veiculo;       

        public TransacaoServiceTestes(){
            _veiculo = new Veiculo("abc1234");           
        }

        // Listar Todas

        // Criar       

        
        
        [Fact]
        public void DeveExibirUmaListaQueContemTransacao1ETransacao2QuandoEstasTransacoesForemCriadas()
        {   
            TransacaoService _transacaoService = new TransacaoService();

            Transacao transacao1 = _transacaoService.Criar(_veiculo, 10, FormaPagamento.CartaoDeCredito);
            Transacao transacao2 = _transacaoService.Criar(_veiculo, 50, FormaPagamento.CartaoDeCredito);
            List<Transacao> minhaListaEsperada = _transacaoService.ListarTodas();
            var resultado = minhaListaEsperada.Count();


            List<Transacao> minhaLista = new List<Transacao>{transacao1, transacao2};  
            var resultadoEsperado = minhaLista.Count();          

            Assert.Equal(resultadoEsperado, resultado);
            
            _transacaoService.GetTransacaoRepository().GetTransacoes().Clear();
        }            
    }
}