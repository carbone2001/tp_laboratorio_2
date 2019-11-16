using System;
using System.IO;
namespace Entidades
{
    public static class GuardarString
    {
        #region Metodos
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
                Console.WriteLine(e.Message);
                return false;
            }
        }
        #endregion
    }
}
