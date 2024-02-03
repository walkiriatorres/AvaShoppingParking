using DesafioFundamentos.Models.Classes;
using DesafioFundamentos.Models.Enum;
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
            var resultadoEsperado = new List<Transacao>{};

            var resultado = _transacaoRepository.GetTransacoes();

            Assert.Equal(resultadoEsperado, resultado);
            _transacaoRepository.GetTransacoes().Clear(); 
        }
        
        [Fact]
        public void DeveExibirUmaTransacaoQuandoSalvarApenasUmaTransacao()
        {
            TransacaoRepository _transacaoRepository = TransacaoRepository.GetInstancia();

            Transacao transacao1 = new Transacao(Guid.NewGuid(), _veiculo, 10, FormaPagamento.CartaoDeCredito, DateTime.Now);
            _transacaoRepository.Salvar(transacao1);
            var resultadoEsperado = 1;

            var resultado = _transacaoRepository.GetTransacoes().Count();

            Assert.Equal(resultadoEsperado, resultado);
            _transacaoRepository.GetTransacoes().Clear();  
        }                     
    }
}