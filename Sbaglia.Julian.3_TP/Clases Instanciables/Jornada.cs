using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Schema;
using ClasesAbstractas;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Permite operar con la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }

            set
            {
                if (value != null)
                {
                    this.alumnos = value;
                }
            }
        }

        /// <summary>
        /// Para operar con EClase de una jornada
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }

            set
            {
                if (this.instructor == value)
                {
                    this.clase = value;
                }
                else
                {
                    throw new SinProfesorException();
                }
            }
        }

        /// <summary>
        /// Para operar con el profesor que pertenece a una jornada y
        /// verifica que sea capaz de dar la jornada.
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }

            set
            {
                if (value == this.clase)
                {
                    this.instructor = value;
                }
                else
                {
                    throw new SinProfesorException();
                }
            }
        }
        
        /// <summary>
        /// Verifica si el alumno participa de la jornada.
        /// </summary>
        /// <param name="j">La jornada que se verifica.</param>
        /// <param name="a">El alumno que se verifica.</param>
        /// <returns>True en caso de que participe. False en caso de que no.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.clase;
        }

        /// <summary>
        /// Verifica si el alumno participa de la jornada.
        /// </summary>
        /// <param name="j">La jornada que se verifica.</param>
        /// <param name="a">El alumno que se verifica.</param>
        /// <returns>False en caso de que particpe. True en caso de que no.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Verifica que el alumno sea participante de la jornada
        /// y, si no es participante, lo agrega.
        /// </summary>
        /// <param name="j">La jornada.</param>
        /// <param name="a">El alumno.</param>
        /// <returns>La jornada actualizada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                foreach (Alumno itemAlumno in j.Alumnos)
                {
                    if (itemAlumno.Equals(a))
                    {
                        return j;
                    }
                }
                j.Alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Convierte los datos de una jornada en 
        /// una cadena de caracteres.
        /// </summary>
        /// <returns>String con los datos.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASE DE {0} POR {1}", this.clase.ToString(), this.instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Guarda los datos de una jornada en un archivo de texto en /MisDocumentos/SuarezMurray2A.
        /// Si la carpeta no existe, la crea.
        /// </summary>
        /// <param name="jornada">La jornada a guardar.</param>
        /// <returns>True si la Jornada es valida.</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory()
                    + @"\ArchivosGuardados";
                System.IO.Directory.CreateDirectory(path);
                Texto archivoTexto = new Texto();
                archivoTexto.Guardar((path + @"\Jornada.txt"), jornada.ToString());
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
        /// <summary>
        /// Lee el archivo de texto donde se guarda la jornada (ver: jornada.Guardar()),
        /// y retorna los datos como string.
        /// </summary>
        /// <returns>Datos de la jornada guardada.</returns>
        public static string Leer()
        {
            try
            {
                string jornada = "";
                Texto archivoTexto = new Texto();
                archivoTexto.Leer((System.IO.Directory.GetCurrentDirectory() +
                    @"\ArchivosGuardados\Jornada.txt"), out jornada);
                return jornada;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
