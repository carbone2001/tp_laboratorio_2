using System;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region Metodos
        public bool Guardar(string archivo, T datos)
        {
            throw new NotImplementedException();
        }

        public bool Leer(string archivo, out T datos)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
