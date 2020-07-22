using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Excepciones;


namespace ClasesAbstractas
{
    abstract public class Persona
    {
        /// <summary>
        /// 
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        /// <summary>
        /// get: retorna el nombre.
        /// set: valida el nombre y lo asigna.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }

            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    nombre = value;
                }
            }
        }

        /// <summary>
        /// get: retorna el apellido.
        /// set: valida el apellido y lo asigna.
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }

            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this.apellido = value;
                }
            }
        }

        /// <summary>
        /// get: retorna el DNI.
        /// set: valida el DNI y lo asigna.
        /// </summary>
        public int DNI
        {
            get { return this.dni; }

            set
            {
                try
                {
                    dni = ValidarDni(nacionalidad, value);
                }
                catch (DniInvalidoException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// get: retorna la nacionalidad.
        /// set: asigna la nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }

            set
            {
                nacionalidad = value;
            }
        }

        /// <summary>
        /// valida el DNI y lo asigna.
        /// </summary>
        public string StringToDNI
        {
            set { this.dni = ValidarDni(nacionalidad, value); }
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">DNI de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            ValidarDni(nacionalidad, dni);
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">DNI de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Devuelve los datos como una cadena de caracteres.
        /// </summary>
        /// <returns>La cadena con los datos.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// Valida que el numero del DNI este entre los valores adecuados.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI a validar.</param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retornoAux = 1;

            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato > 0 && dato < 90000000)
                {
                    retornoAux = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }

            else if (nacionalidad == ENacionalidad.Extranjero)
            {
                if (dato >= 90000000 && dato <= 99999999)
                {
                    retornoAux = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }

            return retornoAux;
        }

        /// <summary>
        /// Valida que el DNI recibido este compuesto por valores correspondientes.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>El DNI validado.</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                return ValidarDni(nacionalidad, int.Parse(dato));
            }
            catch (FormatException)
            {
                throw new DniInvalidoException("DNI con caracteres no correspondientes.");
            }
        }

        /// <summary>
        /// Valida que el apellido recibido este compuesto por letras.
        /// </summary>
        /// <param name="dato">Apellido a validar.</param>
        /// <returns>El apellido validado.</returns>
        private static string ValidarNombreApellido(string dato)
        {
            string retorno = null;

            if (!string.IsNullOrWhiteSpace(dato))
            {
                Regex rx = new Regex(@"[^A-Za-z\s]");

                if (!rx.IsMatch(dato))
                {
                    retorno = dato;
                }
            }

            return retorno;
        }
    }
}
