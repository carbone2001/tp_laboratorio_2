using System;
using System.Data.SqlClient;
namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Campos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion
        #region Metodos
        /// <summary>
        /// Inserta un paquete a la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            string cmd = String.Format("INSERT INTO Paquetes(direccionEntrega,trackingID,alumno) values('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Lucas Carbone");
            try
            {
                comando.CommandText = cmd;
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                comando.Connection.Close();
            }
        }
        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
        }
        #endregion
    }
}
