namespace DesafioFundamentos.Exceptions
{
    [Serializable]
    public class VeiculoInvalidoException : Exception
    {
        public VeiculoInvalidoException() { }

        public VeiculoInvalidoException(string message)
        : base(message) { }

        public VeiculoInvalidoException(string message, Exception inner)
        : base(message, inner) { }        
    }
}
