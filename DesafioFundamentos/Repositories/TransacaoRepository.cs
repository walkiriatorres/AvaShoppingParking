using DesafioFundamentos.Exceptions;
using DesafioFundamentos.Models;

namespace DesafioFundamentos.Repositories
{
    public class TransacaoRepository
    {
        private static TransacaoRepository Instancia = new TransacaoRepository();
        
        public List<Transacao> Transacoes;

        private TransacaoRepository(){
            this.Transacoes = new List<Transacao>();
        }

        public static TransacaoRepository GetInstancia(){
            return Instancia;
        }

        public void Salvar(Transacao transacao){

            Transacoes.Add(transacao);
        }

        public List<Transacao> ListarTodas(){
            return Transacoes;
        }
    }
}