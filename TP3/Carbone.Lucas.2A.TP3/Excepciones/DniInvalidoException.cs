using System;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Campos
        private string mensajeBase;
        #endregion
        #region Metodos
        public DniInvalidoException() : this("Formato de DNI invalido.")
        {
        }
        public DniInvalidoException(Exception e) : this("Formato de DNI invalido.", e)
        {
        }
        public DniInvalidoException(string mensaje) : base(mensaje)
        {
            this.mensajeBase = mensaje;
        }
        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {
        }
        #endregion
    }
}
