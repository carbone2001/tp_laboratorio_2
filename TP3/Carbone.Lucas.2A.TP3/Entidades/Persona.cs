namespace Entidades
{
    public abstract class Persona
    {
        #region Campos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion
        #region Propiedades
        public string Apellido
        {
            get { return ""; }
            set { }
        }
        public int DNI { get; set; }
        public ENacionalidad Nacionalidad { get; set; }
        public string StringToDNI { set { } }
        #endregion
        #region Metodos
        public Persona()
        {

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {

        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {

        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, int.Parse(dni), nacionalidad)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return 0;
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return 0;
        }
        private string ValidarNombreApellido(string dato)
        {
            return "";
        }
        #endregion
        #region Tipos anidados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }


}
