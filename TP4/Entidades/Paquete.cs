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
        /// <summary>
        /// Cada 4 segudos cambiara de estado al paquete, se informara el cambio de estado. Al llegar al ultimo estado se cargara el paquete a una base de datos.
        /// </summary>
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
        /// <summary>
        /// Mostrar los datos del paquete
        /// </summary>
        /// <param name="elemento">Un objeto de tipo paquete</param>
        /// <returns>Un string con los datos obtenidos.</returns>
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
        /// <summary>
        /// Compara si los elementos ingresados son distintos
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// Compara si los elementos ingresados son iguales
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.TrackingID == p2.TrackingID);
        }
        /// <summary>
        /// Delvuelve un string con los datos del paquete.
        /// </summary>
        /// <returns></returns>
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
