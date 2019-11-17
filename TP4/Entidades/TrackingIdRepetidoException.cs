using System;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        #region Metodos
        /// <summary>
        /// Se lanza esta excepcion en caso de que el tracking se haya repetido
        /// </summary>
        /// <param name="mensaje">El mensaje que contendra la excepcion</param>
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        {
        }
        /// <summary>
        /// Se lanza esta excepcion en caso de que el tracking se haya repetido
        /// </summary>
        /// <param name="mensaje">El mensaje que contendra la excepcion</param>
        /// <param name="inner">La excepcion que contendra la excepcion</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
        #endregion
    }
}
