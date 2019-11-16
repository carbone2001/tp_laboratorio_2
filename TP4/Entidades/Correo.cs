using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Campos
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;
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
        public void FinEntregas()
        {
            foreach (Thread x in this.mockPaquetes)
                if (x.IsAlive)
                {
                    x.Abort();
                }
                    
        }
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder str = new StringBuilder();
            if (elementos.GetType() == typeof(Correo))
                foreach (Paquete p in ((Correo)elementos).Paquetes)
                    str.AppendLine(p.MostrarDatos(p)+"("+p.Estado.ToString()+")");
            return str.ToString();
        }
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
