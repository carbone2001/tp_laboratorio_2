using System;
using System.Collections.Generic;
using System.Text;
using EntidadesAbstractas;
using Excepciones;
namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Campos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion
        #region Metodos
        private void _randomClases()
        {
            Universidad.EClases aux;
            aux = (Universidad.EClases)Profesor.random.Next(1, 4);
            this.clasesDelDia.Enqueue(aux);
        }
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
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
            throw new SinProfesorException();
        }
        protected override string ParticiparEnClase()
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
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}
