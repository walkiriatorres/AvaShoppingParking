using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Exceptions
{
    [Serializable]
    public class FormaPagamentoInvalidaException : Exception
    {
        public FormaPagamentoInvalidaException() { }

        public FormaPagamentoInvalidaException(string message)
        : base(message) { }

        public FormaPagamentoInvalidaException(string message, Exception inner)
        : base(message, inner) { }        
    }
}