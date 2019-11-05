using EntidadesAbstractas;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Text;
namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Campos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion
        #region Metodos
        /// <summary>
        /// Genera y agrega una clase del dia aleatoriamente.
        /// </summary>
        private void _randomClases()
        {
            Universidad.EClases aux;
            aux = (Universidad.EClases)Profesor.random.Next(1, 4);
            this.clasesDelDia.Enqueue(aux);
        }
        /// <summary>
        /// Genera una cadena con los datos cargados en los atributos
        /// </summary>
        /// <returns>Retorna la cadena con los datos del objecto</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }
        /// <summary>
        /// Compara si dos objetos de tipo Universitario son desiguales
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna true si los dos objetos son desiguales y false en caso contrario.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        /// <summary>
        /// Compara si dos objetos de tipo Universitario son iguales
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna true si los dos objetos son iguales y false en caso contrario.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {

            Universidad.EClases aux;
            if (!Object.Equals(i, null) && !Object.Equals(i.clasesDelDia, null))
            {
                int count = i.clasesDelDia.Count;
                for (int j = 0; j < count; j++)
                {
                    aux = i.clasesDelDia.Dequeue();
                    i.clasesDelDia.Enqueue(aux);
                    if (aux == clase)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return Object.Equals(i, clase);
            }
            throw new SinProfesorException();

        }
        /// <summary>
        /// Muestra la participacion que tien en clase
        /// </summary>
        /// <returns>Retorna un string donde se comenta la participacion</returns>
        protected override string ParticiparEnClase()
        {
            try
            {
                StringBuilder str = new StringBuilder();
                int count = this.clasesDelDia.Count;
                Universidad.EClases aux;
                str.AppendFormat("CLASES DEL DÍA:");
                for (int i = 0; i < count; i++)
                {
                    aux = this.clasesDelDia.Dequeue();
                    str.AppendFormat("\n{0}", aux.ToString());
                    this.clasesDelDia.Enqueue(aux);
                }
                return str.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        static Profesor()
        {
            random = new Random();
        }
        private Profesor()
        {
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            for (int i = 0; i < 2; i++)
                this._randomClases();
        }
        /// <summary>
        /// Genera un string con todos los datos de los atributos
        /// </summary>
        /// <returns>Retorna la cadena genrada</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}
