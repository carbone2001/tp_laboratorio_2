using System;
using System.IO;
namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Metodos
        /// <summary>
        /// Guarda un archivo de texto
        /// </summary>
        /// <param name="archivo">Es la ruta en donde se creara el archivo</param>
        /// <param name="datos">Es la cadena que contendra el archivo</param>
        /// <returns>True si se puedo guardar el archivo.</returns>
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
        /// <summary>
        /// Lee un archivo
        /// </summary>
        /// <param name="archivo">Es la ruta donde se encontrara el archivo</param>
        /// <param name="datos">Una salida para los datos leidos</param>
        /// <returns></returns>
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
