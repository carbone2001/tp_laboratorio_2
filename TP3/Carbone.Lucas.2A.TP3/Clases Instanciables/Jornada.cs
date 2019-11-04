using Archivos;
using System.Collections.Generic;
using System.Text;
namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Campos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion
        #region Propiedades
        /// <summary>
        /// Lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Guarda los datos de jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>True si se pudo guardar el archivo. False en caso contrario.</returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                Texto t = new Texto();
                return t.Guardar("Jornada.txt", jornada.ToString());
            }
            catch (System.Exception e)
            {
                throw new Excepciones.ArchivosException();
            }

        }
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        /// <summary>
        /// Lee un archivo de texto
        /// </summary>
        /// <returns>Devuelve un string con los datos del archivo leido</returns>
        public static string Leer()
        {
            try
            {
                Texto t = new Texto();
                string datos;
                t.Leer("Jornada.txt", out datos);
                return datos;
            }
            catch (System.Exception e)
            {
                throw new Excepciones.ArchivosException();
            }

        }
        /// <summary>
        /// Compara si dos objetos de tipo Alumno son desiguales
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Retorna true si los dos objetos son desiguales y false en caso contrario.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agrega el alumno ingresado por el parametro en caso de que no este en la lista
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Devuelve un objeto de tipo Jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.Alumnos.Add(a);
            return j;
        }
        /// <summary>
        /// Compara si dos objetos de tipo Alumno son desiguales
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Retorna true si los dos objetos son desiguales y false en caso contrario.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (a == j.Clase)
                return true;
            return false;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("CLASE DE " + this.Clase.ToString() + " POR " + this.Instructor.ToString());
            str.AppendLine("\nALUMNOS:");
            foreach (Alumno a in this.Alumnos)
                str.AppendLine(a.ToString());
            return str.ToString();
        }
        #endregion
    }
}
