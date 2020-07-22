using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException(string message)
            : base(message)
        {

        }

        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        {

        }

        public DniInvalidoException()
            : this("Caracteres invalidos o fuera de rango.")
        {

        }

        public DniInvalidoException(Exception e)
            : this("Caracteres invalidos o fuera de rango.", e)
        {

        }
    }
}
