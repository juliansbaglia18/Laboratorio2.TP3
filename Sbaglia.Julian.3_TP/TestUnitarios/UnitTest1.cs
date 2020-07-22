using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;
using Archivos;
using ClasesAbstractas;
using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        /// <summary>
        /// Testea que se lance la excepcion DniInvalidoException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalidoTest()
        {
            Alumno alumno = new Alumno(123, "Test", "Unitario", "9999999a", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }


        /// <summary>
        /// Testea que se lance la excepcion ArchivosException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void ArchivoTextoTest()
        {
            string aux;
            Texto archivoLeer = new Texto();
            archivoLeer.Leer("C://JornadaFalso.txt", out aux);

        }

        /// <summary>
        /// Testea que el atributo Alumnos se haya instanciado.
        /// </summary>
        [TestMethod]
        public void InstanciaColeccionTest()
        {
            Universidad universidad = new Universidad();

            Assert.IsInstanceOfType(universidad.Alumnos, typeof(List<Alumno>));

        }

    }
}
