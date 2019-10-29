using System;
using System.IO;
namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Metodos
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo);
                sw.Write(datos);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                datos = e.Message;
                return false;
            }


        }

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                datos = e.Message;
                return false;
            }

        }
        #endregion
    }
}
