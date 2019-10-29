using System.Collections.Generic;
using System.Text;
using Archivos;
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
        public static bool Guardar(Jornada jornada)//NO SE HA TERMINADO DE DESARROLLAR
        {
            Texto t = new Texto();
            return t.Guardar("Jornada.txt", jornada.ToString());
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
        public static string Leer()//NO SE HA TERMINADO DE DESARROLLAR
        {
            Texto t = new Texto();
            string datos;
            t.Leer("Jornada.txt", out datos);
            return datos;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.Alumnos.Add(a);
            return j;
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (a == j.Clase)
                return true;
            return false;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("CLASE DE " + this.Clase.ToString() +" POR " + this.Instructor.ToString());
            str.AppendLine("\nALUMNOS:");
            foreach (Alumno a in this.Alumnos)
                str.AppendLine(a.ToString());
            return str.ToString();
        }
        #endregion
    }
}
