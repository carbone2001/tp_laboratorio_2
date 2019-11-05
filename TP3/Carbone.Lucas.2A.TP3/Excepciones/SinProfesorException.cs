using System;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        #region Metodos
        public SinProfesorException() : base("No hay profesor para la clase.")
        {
        }
        #endregion
    }
}
