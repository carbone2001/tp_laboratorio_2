using System;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException() : base("No se ha podido guardar o leer el archivo correspondiente.") { }
    }
}
