namespace DesafioFundamentos.Exceptions
{
    [Serializable]
    public class TransacaoInvalidaException : Exception
    {
        public TransacaoInvalidaException() { }

        public TransacaoInvalidaException(string message)
        : base(message) { }

        public TransacaoInvalidaException(string message, Exception inner)
        : base(message, inner) { }        
    }
}
