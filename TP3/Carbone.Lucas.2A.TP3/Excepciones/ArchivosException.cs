using System;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region Metodos
        public ArchivosException() : base("No se ha podido guardar o leer el archivo correspondiente.") { }
        #endregion
    }
}
