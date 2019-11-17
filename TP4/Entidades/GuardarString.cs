using System;
using System.IO;
namespace Entidades
{
    public static class GuardarString
    {
        #region Metodos
        /// <summary>
        /// Guarda un archivo de texto en el escritorio.
        /// </summary>
        /// <param name="texto">El texto a guardar</param>
        /// <param name="archivo">Nombre del archivo</param>
        /// <returns>Devuelve true si el guardado fue exitoso. De lo contrario, se devolvera false.</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + archivo;
                using (StreamWriter sw = new StreamWriter(ruta))
                    sw.WriteLine(texto);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
