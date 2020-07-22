using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        public SinProfesorException()
            : base("No hay Profesor para la clase.")
        {

        }
    }
}

