using System;
using System.Collections.Generic;
using System.Text;

namespace ClasesAbstractas
{
    abstract public class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universitario()
            : base()
        {

        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <param name="legajo">Legajo de la persona.</param>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">DNI de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Muestra los datos de la persona.
        /// </summary>
        /// <returns>Los datos de la persona como cadena de caracteres.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendFormat("LEGAJO NúMERO: {0}\n", this.legajo);

            return sb.ToString();
        }

        

        /// <summary>
        /// Verifica que el objeto a comparar sea un Universitario y que sea igual al objeto
        /// que llama la funcion.
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns>True si son iguales. False si no es.</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Universitario)
            {
                if (((Universitario)obj).legajo == this.legajo || ((Universitario)obj).DNI == this.DNI)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Metodo abstracto que muestra la clase que toma un alumno.
        /// </summary>
        /// <returns></returns>
        abstract protected string ParticiparEnClase();
        
        /// <summary>
        /// Determina si dos universitarios son iguales segun su legajo y DNI.
        /// </summary>
        /// <param name="pg1">Universitario a comparar.</param>
        /// <param name="pg2">Universitario a comparar.</param>
        /// <returns>True si son iuales. False si no.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Determina si dos universitarios son iguales segun su legajo y DNI.
        /// </summary>
        /// <param name="pg1">Universitario a comparar.</param>
        /// <param name="pg2">Universitario a comparar.</param>
        /// <returns>False si son iuales. True si no.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }


        
    }
}
