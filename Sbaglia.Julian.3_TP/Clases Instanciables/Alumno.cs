using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Clases_Instanciables;
using ClasesAbstractas;

namespace Clases_Instanciables
{
    sealed public class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// COnstructor por defecto.
        /// </summary>
        public Alumno()
            : base()
        {

        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <param name="id">ID de la persona.</param>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">DNI de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="claseQueToma">La clase que toma la persona.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <param name="id">ID de la persona.</param>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">DNI de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="claseQueToma">La clase que toma la persona.</param>
        /// <param name="estadoCuenta">El estado de la cuenta de la persona.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Muestra los datos del alumno.
        /// </summary>
        /// <returns>Los datos del alumno en forma de cadena de caracteres.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.Append("ESTADO DE CUENTA: ");

            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    sb.Append("Cuota al dia");

                    break;
                case EEstadoCuenta.Deudor:
                    sb.Append("Deudor");
                    break;
                case EEstadoCuenta.Becado:

                    sb.Append("Becado");
                    break;
            }
            return sb.ToString() + "\n" + this.ParticiparEnClase();
        }

        /// <summary>
        /// Muestra la clase en la que participa el alumno.
        /// </summary>
        /// <returns>La clase que toma en forma de cadena de caracteres.</returns>
        protected override string ParticiparEnClase()
        {
            return ("TOMA CLASES DE " + claseQueToma);
        }
        
        /// <summary>
        /// Muestra a traves de un metodo los datos de un alumno.
        /// </summary>
        /// <returns>Los datos del alumno en forma de cadena de caracteres.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Compara si un alumno participa en la clase.
        /// </summary>
        /// <param name="a">Alumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>True si el alumno participa de la clase. False si no.</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if (a.estadoCuenta != EEstadoCuenta.Deudor && a.claseQueToma == clase)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Compara si un alumno participa en la clase.
        /// </summary>
        /// <param name="a">Alumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>False si el alumno participa de la clase. True si no.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if (a.claseQueToma != clase)
            {
                retorno = true;
            }
            return retorno;
        }
    }
}
