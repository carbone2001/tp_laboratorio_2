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
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + "\nESTADO DE CUENTA: " + this.estadoCuenta.ToString() + "\nTOMA CLASES DE " + this.claseQueToma.ToString();
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma != clase)
                return true;
            return false;
        }
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            return false;
        }
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma.ToString();
        }
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
