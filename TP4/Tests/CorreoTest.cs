using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace Tests
{
    [TestClass]
    public class CorreoTest
    {

        /// <summary>
        /// Verificar que la lista de Paquetes del Correo este instanciada
        /// </summary>
        [TestMethod]
        public void ListaPaquetesInstanciada()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }

        /// <summary>
        /// Verificar no se puedan cargar 2 Paquetes con el mismo Tracking ID
        /// </summary>
        [TestMethod]
        public void CargarPaqueteMismoTrackingID()
        {
            Paquete p1 = new Paquete("direccion1", "123456");
            Paquete p2 = new Paquete("direccion2", "123456");
            Correo c = new Correo();
            c += p1;
            try
            {
                c += p2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
                return;
            }
            Assert.Fail("Error de excepcion tracking repetido: {0}.", p2.TrackingID);
        }

    }
}

