namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Campos
        private int legajo;
        #endregion
        #region Metodos
        /// <summary>
        /// Compara los tipos del objeto que llama la funcion contra el que recibe como parametro
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Devuelve true si es objeto ingresado es del mismo tipo que el que llamo la funcion. Caso contrario devuelve false.</returns>
        public override bool Equals(object obj)
        {

            if (obj.GetType() == this.GetType())
                return true;
            return false;
        }
        /// <summary>
        /// Genera una cadena con los datos cargados en los atributos
        /// </summary>
        /// <returns>Retorna la cadena con los datos del objecto</returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + "\nLEGAJO NUMERO: " + this.legajo.ToString() + "\n";
        }
        /// <summary>
        /// Compara dos objetos de tipo Universitario y si estos son desiguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Devuelve true si son desiguales o false si no es asi.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        /// Compara si dos objetos de tipo Universitario son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Retorna true si los dos objetos son iguales y false en caso contrario.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2) && ((pg1.legajo == pg2.legajo) || (pg1.DNI == pg2.DNI)))
                return true;
            return false;
        }
        /// <summary>
        /// Muestra la participacion que tien en clase
        /// </summary>
        /// <returns>Retorna un string donde se comenta la participacion</returns>
        protected abstract string ParticiparEnClase();
        public Universitario() : base()
        {
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion
    }
}
