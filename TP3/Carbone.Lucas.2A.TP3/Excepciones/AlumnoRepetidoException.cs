using System;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException() : base("AlumnoRepetido") { }
    }
}
