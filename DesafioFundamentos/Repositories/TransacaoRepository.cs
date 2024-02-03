using DesafioFundamentos.Exceptions;
using DesafioFundamentos.Models.Classes;
using DesafioFundamentos.Models.Enums;

namespace DesafioFundamentos.Repositories
{
    public class TransacaoRepository
    {
        private static TransacaoRepository Instancia = new TransacaoRepository();
        
        private List<Transacao> Transacoes;

        private TransacaoRepository(){
            this.Transacoes = new List<Transacao>();
        }

        public static TransacaoRepository GetInstancia(){
            return Instancia;
        }
        
        public List<Transacao> GetTransacoes(){
            return Transacoes;
        }       

        public void Salvar(Transacao transacao){
            Transacoes.Add(transacao);
        }
    }
}