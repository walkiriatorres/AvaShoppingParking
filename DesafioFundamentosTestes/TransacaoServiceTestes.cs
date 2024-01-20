using DesafioFundamentos.Services;
using DesafioFundamentos.Models;
using DesafioFundamentos.Repositories;

namespace DesafioFundamentosTestes
{
    public class TransacaoServiceTestes
    {
        private Veiculo _veiculo;
        private TransacaoRepository _transacaoRepository;
        private TransacaoService _transacaoService;

        

        public TransacaoServiceTestes(){
            _veiculo = new Veiculo("abc1234");
            _transacaoRepository = new TransacaoRepository();            
            _transacaoService = new TransacaoService();
        }

        [Fact]
        public void DeveExibirUmaListaQueContemTransacao1ETransacao2QuandoEstasTransacoesForemCriadas()
        {
            Transacao transacao1 = new Transacao(Guid.NewGuid(), _veiculo, "1", 10, DateTime.Now);
            Transacao transacao2 = new Transacao(Guid.NewGuid(), _veiculo, "2", 50, DateTime.Now);

            List<Transacao> listaVeiculos = new List<Transacao>{transacao1, transacao2};

            _transacaoService.transacaoRepository.Salvar(transacao1);
            _transacaoService.transacaoRepository.Salvar(transacao2);

            /*
            OU FAZER ASSIM:
            _transacaoService.transacaoRepository.transacoes.Add(transacao1);
            _transacaoService.transacaoRepository.transacoes.Add(transacao2);
            */

            var resultado = _transacaoService.ListarTodas();

            Assert.Equal(listaVeiculos, resultado);
        }        
    }
}