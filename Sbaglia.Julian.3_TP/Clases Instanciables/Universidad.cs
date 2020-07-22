using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;
using Archivos;
using System.Linq;
using ClasesAbstractas;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        /// <summary>
        /// Permite operar la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }

            set { this.alumnos = value; }
        }

        /// <summary>
        /// Permite operar la lista de profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        /// <summary>
        /// Permite operar la lista de jornadas.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        /// <summary>
        /// Permite acceder a la lista de jornadas.
        /// </summary>
        /// <param name="i">Indice desde el cual entrar./param>
        /// <returns>Retorna i si es valido, null si no es.</returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.jornada.Count)
                {
                    return this.jornada.ElementAt(i);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    this.Jornadas[i] = value;
                }
            }
        }

        /// <summary>
        /// Guarda los datos de una universidad en un archivo .xlm.
        /// </summary>
        /// <param name="uni">Universidad a guardar.</param>
        /// <returns>True si la universidad es valida.</returns>
        public static bool Guardar(Universidad uni)
        {
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory() + @"\ArchivosGuardados";

                System.IO.Directory.CreateDirectory(path);
                Xml<Universidad> archivo = new Xml<Universidad>();

                return archivo.Guardar((path + @"\Universidad.xml"), uni);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Lee los datos de la universidad guardada en un archivo .xml
        /// y los retorna en un objeto tipo Universidad.
        /// </summary>
        /// <returns>Universidad guardada.</returns>
        public static Universidad Leer()
        {
            try
            {
                Universidad uni = new Universidad();

                Xml<Universidad> archivo = new Xml<Universidad>();
                archivo.Leer((System.IO.Directory.GetCurrentDirectory() + @"\ArchivosGuardados\Universidad.xml"), out uni);

                return uni;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Devuelve los datos de una universidad en una cadena de caracteres.
        /// </summary>
        /// <returns>String con datos de la universidad.</returns>
        private string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");
            foreach (Jornada item in this.Jornadas)
            {
                sb.AppendFormat("{0}", item.ToString());
                sb.AppendLine("<------------------------------------------------->");
            }

            return sb.ToString();
        }
        
        /// <summary>
        /// Devuelve los datos de la universidad como cadena de caracteres.
        /// </summary>
        /// <returns>String con los datos.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Compara si un alumno esta incluido en una universidad.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>Devuelve true si el alumno esta incluido, false si no.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno itemAlumno in g.Alumnos)
            {
                if (itemAlumno.Equals(a))
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Compara si un alumno no esta inluido en una universidad.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>Devuelve false si el alumno esta incluido, true si no.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Compara si un profesor esta incluido en una universidad.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="i">Profesor a comparar.</param>
        /// <returns>Devuelve true si el profesor esta incluido, false si no.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor itemProfesor in g.Instructores)
            {
                if (itemProfesor.Equals(i))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Compara si un profesor no esta incluido en una universidad.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="i">Profesor a comparar.</param>
        /// <returns>Devuelve false si el profesor esta incluido, true si no.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Encuentra al primer profesor capaz de dar la jornada.
        /// </summary>
        /// <param name="u">Universidad a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Profesor capas de dar la jornada.</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor itemProfesor in u.Instructores)
            {
                if (itemProfesor == clase)
                {
                    return itemProfesor;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Encuentra el primer profesor incapaz de dar la jornada.
        /// </summary>
        /// <param name="i">Universidad a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Profesor que no pueda dar la jornada.</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.Instructores)
            {
                if (item != clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Crea la jornada de la clase indicada y le asigna el profesor
        /// y los alumnos de ser posible, sino se retorna sin cambios.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="clase">Clase a crear la jornada.</param>
        /// <returns>Nueva jornada con profesor y alumnos.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            try
            {
                Jornada nuevaJornada = new Jornada(clase, (g == clase));
                for (int i = 0; i < g.Alumnos.Count; i++)
                {
                    if (g.Alumnos[i] == clase)
                    {
                        nuevaJornada.Alumnos.Add(g.Alumnos[i]);
                    }
                }
                g.Jornadas.Add(nuevaJornada);
                return g;
            }
            catch (SinProfesorException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Agrega un alumnos a la universidad de no ser repetido.
        /// </summary>
        /// <param name="u">Universidad a modificar.</param>
        /// <param name="a">Alumno a agregar.</param>
        /// <returns>Universidad actualizada.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        /// <summary>
        /// Agrega un profesor a la universidad de no ser repetido
        /// </summary>
        /// <param name="u">Universidad a modificar</param>
        /// <param name="i">Profesor a agregar</param>
        /// <returns>Universidad actualizada.</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }
            return u;
        }
    }
}
