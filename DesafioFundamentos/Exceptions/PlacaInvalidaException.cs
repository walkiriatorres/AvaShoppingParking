namespace DesafioFundamentos.Exceptions
{
    [Serializable]
    public class PlacaInvalidaException : Exception
    {
        public PlacaInvalidaException() { }

        public PlacaInvalidaException(string message)
        : base(message) { }

        public PlacaInvalidaException(string message, Exception inner)
        : base(message, inner) { }        
    }
}
