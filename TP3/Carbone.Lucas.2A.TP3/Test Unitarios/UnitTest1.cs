using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace Test_Unitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExcepcionDeArchivos()
        {
            try
            {
                Universidad u;
                u = Universidad.Leer();
                u = null;
                Universidad.Guardar(u);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArchivosException));
            }

        }
        [TestMethod]
        public void ExceptionSinProfesor()
        {
            try
            {
                Universidad u = new Universidad();
                u += Universidad.EClases.Laboratorio;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }

        }
        [TestMethod]
        public void ValidacionNumeroDniInvalido()
        {
            try
            {
                Alumno a = new Alumno(1, "Nombre", "Apellido", "99999gh999", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }
        [TestMethod]
        public void ValoresNulos()
        {
            Profesor p = new Profesor(2,null, null, "5", Persona.ENacionalidad.Argentino);
            string s = p.ToString();
        }


    }
}
