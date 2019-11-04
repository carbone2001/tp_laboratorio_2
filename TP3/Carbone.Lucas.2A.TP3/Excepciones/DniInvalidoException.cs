using System;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException() : base("Formato de DNI invalido.") { }
    }
}
