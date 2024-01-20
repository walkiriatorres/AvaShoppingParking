namespace DesafioFundamentos.Exceptions
{
    [Serializable]
    public class EstacionamentoInvalidoException : Exception
    {
        public EstacionamentoInvalidoException() { }

        public EstacionamentoInvalidoException(string message)
        : base(message) { }

        public EstacionamentoInvalidoException(string message, Exception inner)
        : base(message, inner) { }        
    }
}
