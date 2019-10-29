using System;
using Excepciones;
namespace EntidadesAbstractas
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
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); }
        }
        public int DNI { get { return this.dni; } set { this.dni = ValidarDni(this.nacionalidad, value); } }
        public ENacionalidad Nacionalidad { get { return this.nacionalidad; } set { this.nacionalidad = value; } }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = ValidarNombreApellido(value); }
        }
        public string StringToDNI { set { this.dni = ValidarDni(this.nacionalidad, value); } }
        #endregion
        #region Metodos
        public Persona()
        {
        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        public override string ToString()
        {
            return String.Format("NOMBRE COMPLETO: {0}, {1}\nNACIONALIDAD: {2}\n", this.Apellido, this.Nombre, this.Nacionalidad.ToString());
        }
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato >= 1 && dato <= 89999999)
                    return dato;
                throw new NacionalidadInvalidaException();
            }
            else if (nacionalidad == ENacionalidad.Extranjero)
            {
                if (dato >= 90000000 && dato <= 99999999)
                    return dato;
                throw new NacionalidadInvalidaException();
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            foreach (char c in dato)
            {
                if (!char.IsDigit(c))
                    throw new DniInvalidoException();
            }
            return ValidarDni(nacionalidad, int.Parse(dato));
        }
        private string ValidarNombreApellido(string dato)
        {
            foreach (char c in dato)
            {
                if (char.IsDigit(c))
                    return "";
            }
            return dato;
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
