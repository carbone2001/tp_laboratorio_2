using EntidadesAbstractas;
namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region Campos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion
        #region Metodos
        public Alumno() : base()
        {
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// Genera una cadena con los datos cargados en los atributos
        /// </summary>
        /// <returns>Retorna la cadena con los datos del objecto</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + "\nESTADO DE CUENTA: " + this.estadoCuenta.ToString() + "\nTOMA CLASES DE " + this.claseQueToma.ToString();
        }
        /// <summary>
        /// Compara si dos objetos de tipo Alumno son desiguales
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna true si los dos objetos son iguales y false en caso contrario.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma != clase)
                return true;
            return false;
        }
        /// <summary>
        /// Compara si dos objetos de tipo Alumno son iguales
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna true si los dos objetos son iguales y false en caso contrario.</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            return false;
        }
        /// <summary>
        /// Muestra la participacion que tiene en clase
        /// </summary>
        /// <returns>Retorna un string donde se comenta la participacion</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma.ToString();
        }
        /// <summary>
        /// Genera un string con todos los datos de los atributos
        /// </summary>
        /// <returns>Retorna la cadena genrada.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
        #region Tipos anidados
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion
    }
}
