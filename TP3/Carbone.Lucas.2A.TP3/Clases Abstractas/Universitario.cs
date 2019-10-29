namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Campos
        private int legajo;
        #endregion
        #region Metodos
        public override bool Equals(object obj)
        {

            if (obj.GetType() == this.GetType())
                return true;
            return false;
        }
        protected virtual string MostrarDatos()
        {
            return  base.ToString() + "\nLEGAJO NUMERO: " + this.legajo.ToString() + "\n";
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2) && ((pg1.legajo == pg2.legajo) || (pg1.DNI == pg2.DNI)))
                return true;
            return false;
        }
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
