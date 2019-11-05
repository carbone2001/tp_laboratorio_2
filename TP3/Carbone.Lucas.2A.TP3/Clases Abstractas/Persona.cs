using Excepciones;
using System;
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
        /// <summary>
        /// Crea un string con todos los datos de los atributos del objeto persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("NOMBRE COMPLETO: {0}, {1}\nNACIONALIDAD: {2}\n", this.Apellido, this.Nombre, this.Nacionalidad.ToString());
        }
        /// <summary>
        /// Valida si el dato corresponde con la nacionalidad ingresada
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Devuelve dato en caso de que haya pasado la valdiacion</returns>
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
        /// <summary>
        /// Valida si la cadena dato contiene un caracter no numero y si este corresponde con la nacionalidad ingresada 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Devuelve el dato en caso de que haya pasado la valdiacion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (!Object.Equals(nacionalidad, null) && !Object.Equals(dato, null))
            {
                foreach (char c in dato)
                {
                    if (!char.IsDigit(c))
                        throw new DniInvalidoException();
                }
                return ValidarDni(nacionalidad, int.Parse(dato));
            }
            else
            {
                throw new DniInvalidoException();
            }



        }
        /// <summary>
        /// Verifica si la cadena contiene o no un dato numerico
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Devuelve la cadena ingresada si paso por la verificacion. Caso contrario devolvera una cadena vacia.</returns>
        private string ValidarNombreApellido(string dato)
        {
            try
            {
                foreach (char c in dato)
                {
                    if (char.IsDigit(c))
                        return "";
                }
                return dato;
            }
            catch (Exception)
            {
                return "";
            }

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
