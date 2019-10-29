using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;

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
            return false;
        }
        public static Universidad Leer()//NO SE HA TERMINADO DE DESARROLLAR
        {
            return null;
        }
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
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
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
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor x in g.Instructores)
            {
                if (x == i)
                    return true;
            }
            return false;
        }
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
