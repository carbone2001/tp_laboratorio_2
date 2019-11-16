using System;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        #region Metodos
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        {

        }
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
        #endregion
    }
}
