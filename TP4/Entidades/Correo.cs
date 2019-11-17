using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Campos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion
        #region Propiedades
        public List<Paquete> Paquetes { get { return this.paquetes; } set { this.paquetes = value; } }
        #endregion
        #region Metodos
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        /// <summary>
        /// Finaliza todos los hilos de paquetes que sigan en proceso.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread x in this.mockPaquetes)
                if (x.IsAlive)
                    x.Abort();
        }
        /// <summary>
        /// Muestra una lista con todos los datos de los paquetes que contiene el Correo.
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns>Devuelve un string con los datos pedidos</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder str = new StringBuilder();
            if (elementos.GetType() == typeof(Correo))
                foreach (Paquete p in ((Correo)elementos).Paquetes)
                    str.AppendLine(p.MostrarDatos(p)+"("+p.Estado.ToString()+")");
            return str.ToString();
        }
        /// <summary>
        /// Agrega un paquete al correo si no existe ya un paquete con el mismo Tracking ID.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns>Un objeto correo como resultado de esta suma</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete x in c.Paquetes)
                if (p == x)
                    throw new TrackingIdRepetidoException("El Tracking ID " + p.TrackingID + " ya se encuentra en la lista de envios.");
            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();
            return c;
        }
        #endregion

    }
}
