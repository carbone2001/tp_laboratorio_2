using System;
using System.Threading;
namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Campos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion
        #region Propiedades
        public string DireccionEntrega { get { return this.direccionEntrega; } set { this.direccionEntrega = value; } }
        public EEstado Estado { get { return this.estado; } set { this.estado = value; } }
        public string TrackingID { get { return this.trackingID; } set { this.trackingID = value; } }
        #endregion

        #region Metodos
        public void MockCicloDeVida()
        {
            while (true)
            {
                Thread.Sleep(4000);
                if (this.Estado != EEstado.Entregado)
                {
                    this.Estado++;
                    this.InformarEstado(this, new EventArgs());
                }
                else
                {
                    this.InformarEstado(this, new EventArgs());
                    try
                    {
                        PaqueteDAO.InsertarPaquete(this);
                    }
                    catch (Exception e)
                    {
                        this.InformarEstado(e, new EventArgs());
                    }
                    break;
                }
            }
        }
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            try
            {
                return String.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.TrackingID == p2.TrackingID);
        }
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        #endregion

        #region Eventos
        public delegate void DelegadoEstado(object sender, EventArgs e);
        #endregion

        #region Tipos anidados
        public event DelegadoEstado InformarEstado;
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion
    }
}
