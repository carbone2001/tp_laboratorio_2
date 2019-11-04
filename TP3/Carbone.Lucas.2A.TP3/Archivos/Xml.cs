using System;
using System.IO;
using System.Xml.Serialization;
namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T : class
    {
        #region Metodos
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                TextWriter tw = new StreamWriter(archivo);
                ser.Serialize(tw, datos);
                tw.Close();
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Leer(string archivo, out T datos)
        {
            datos = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                TextReader tr = new StreamReader(archivo);
                datos = (T)ser.Deserialize(tr);
                tr.Close();
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
