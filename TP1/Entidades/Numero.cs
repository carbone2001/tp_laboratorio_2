using System;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Retorna un numero decimal </returns>
        public string BinarioDecimal(string binario)
        {
            double resultado = 0;
            int aux;
            string strResultado = "Valor invalido";
            if(int.TryParse(binario,out aux))
            {
                if (int.Parse(binario) > 0)
                {

                    for (int i = 1; i <= binario.Length; i++)
                    {
                        resultado += int.Parse(binario[i - 1].ToString()) * (int)(Math.Pow(2, (binario.Length - i)));
                    }
                    strResultado = resultado.ToString();
                }
                else if (int.Parse(binario) == 0)
                {
                    strResultado = "0";
                }
            }
            return strResultado;
        }
        /// <summary>
        /// Convierte un numero decimal en binario
        /// </summary>
        /// <param name="numero">Recibe como parametro un numero de tipo double</param>
        /// <returns>Retorna un numero binario de tipo string</returns>
        public string DecimalBinario(double numero)
        {
            int entero = Math.Abs((int)numero);
            string resultado = "Valor invalido";
            if (entero > 0)
            {
                resultado = "";
                while (entero != 0)
                {
                    resultado = (entero % 2).ToString() + resultado;
                    entero = entero / 2;
                }
            }
            else if (entero == 0)
            {
                resultado = "0";
            }
            return resultado;
        }
        /// <summary>
        /// Convierte un numero decimal en binario
        /// </summary>
        /// <param name="strNumero">Un numero de tipo string</param>
        /// <returns>Retorna un numero binario de tipo string</returns>
        public string DecimalBinario(string strNumero)
        {
            double aux;

            if (double.TryParse(strNumero, out aux))
            {
                return this.DecimalBinario(double.Parse(strNumero));
            }
            return "Valor invalido";
        }

        /// <summary>
        /// Es contructor de objetos Numero.
        /// </summary>
        /// <param name="numero">Recibe como parametro un numero de tipo double</param>
        public Numero(double numero) : this(numero.ToString())
        {
        }
        /// <summary>
        /// Es un constructor de objetos Numero
        /// </summary>
        public Numero() : this(0)
        {
        }
        /// <summary>
        /// Es un constructor de objetos Numero
        /// </summary>
        /// <param name="strNumero">Recibe como parametro un numero de tipo string</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// Realiza una resta entre objetos Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna un numero de tipo double</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double resultado;
            resultado = n1.numero - n2.numero;
            return resultado;
        }
        /// <summary>
        /// Realiza una multiplicacion entre objetos Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna un numero de tipo double</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double resultado;
            resultado = n1.numero * n2.numero;
            return resultado;
        } 
        /// <summary>
        /// Realiza una division entre objetos Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna un numero de tipo double</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;
            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            else
            {
                resultado = double.MinValue;
            }

            return resultado;
        }
        /// <summary>
        /// Realiza una suma entre objetos Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna un numero de tipo double</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double resultado;
            resultado = n1.numero + n2.numero;
            return resultado;
        }
        /// <summary>
        /// Realiza un proceso de validacion al numero recibido como parametro
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Retorno el numero ingresado o 0 en caso de algun error</returns>
        private double ValidarNumero(string strNumero)
        {
            double numero;
            if (!double.TryParse(strNumero, out numero))
            {
                numero = 0;
            }
            return numero;
        }
        /// <summary>
        /// Setea el atributo numero del objeto Numero
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        

    }
}
