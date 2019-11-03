using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;
using Archivos;
namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Campos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion
        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }
        #endregion
        #region Metodos
        public static bool Guardar(Universidad uni)//NO SE HA TERMINADO DE DESARROLLAR
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar("Universidad.xml", uni); ;
        }
        public static Universidad Leer()//NO SE HA TERMINADO DE DESARROLLAR
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad uni;
            xml.Leer("Universidad.xml",out uni);
            return uni;
        }
        /// <summary>
        /// Genera una cadena donde se muestran los datos cargados en los atributos del objeto que llega por parametro
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>Retorna la cadena generada</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("JORNADA:");
            foreach (Jornada j in uni.Jornadas)
            {
                str.Append(j.ToString());
                str.AppendLine("<------------------------------------------------>\n");
            }
            return str.ToString();
        }




        /// <summary>
        /// Compara si dos objetos de tipo Universitario son desiguales
        /// </summary>
        /// <param name="g"></param>
        /// <param name="g"></param>
        /// <returns>Retorna true si los dos objetos son desiguales y false en caso contrario.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Compara si dos objetos de tipo Universitario son desiguales
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>Retorna true si los dos objetos son desiguales y false en caso contrario.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Compara si dos objetos de tipo Universitario son desiguales
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna true si los dos objetos son desiguales y false en caso contrario.</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor x in u.Instructores)
            {
                if (x != clase)
                    return x;
            }
            throw new SinProfesorException();
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jAux;
            jAux = new Jornada(clase, g == clase);
            int count = g.Alumnos.Count;
            Alumno aux;
            for (int i = 0; i < count; i++)
            {
                aux = g.Alumnos[i];
                if (aux == clase)
                    jAux.Alumnos.Add(aux);
            }
            g.Jornadas.Add(jAux);
            return g;
        }
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
                u.Alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();
            return u;
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);
            return u;
        }
        /// <summary>
        /// Compara si dos objetos de tipo Universitario son iguales
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Retorna true si los dos objetos son iguales y false en caso contrario.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            if (!Object.Equals(g.Alumnos, null))
                foreach (Alumno x in g.Alumnos)
                {
                    if (x == a)
                        return true;
                }
            return false;
        }
        /// <summary>
        /// Compara si dos objetos de tipo Universitario son iguales
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>Retorna true si los dos objetos son iguales y false en caso contrario.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor x in g.Instructores)
            {
                if (x == i)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Compara si dos objetos de tipo Universitario son iguales
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna true si los dos objetos son iguales y false en caso contrario.</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor x in u.Instructores)
            {
                if (x == clase)
                    return x;
            }
            throw new SinProfesorException();
        }
        public override string ToString()//NO SE HA TERMINADO DE DESARROLLAR
        {
            return Universidad.MostrarDatos(this);
        }
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }
        #endregion
        #region Tipo Anidados
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion
    }


}
