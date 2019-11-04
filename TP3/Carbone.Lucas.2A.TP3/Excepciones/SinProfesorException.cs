using System;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        public SinProfesorException() : base("No hay profesor para la clase.")
        {
        }
    }
}
