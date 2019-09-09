namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza una operacion matematica
        /// </summary>
        /// <param name="num1">El primer operando</param>
        /// <param name="num2">El segundo operando</param>
        /// <param name="operador">El operador con el que se trabajara</param>
        /// <returns>Devuelve el resultado segun el operador </returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            switch (Calculadora.ValidarOperador(operador))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                default:
                    break;
            }

            return resultado;
        }
        /// <summary>
        /// Valida el operador ingresado por parametro
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Retorno el operador ingresado ya validado. Devuelta + en caso de error</returns>
        public static string ValidarOperador(string operador)
        {
            char operadorChar;
            string retorno = "+";
            if (char.TryParse(operador, out operadorChar))
            {
                if (operadorChar == '+' || operadorChar == '-' || operadorChar == '*' || operadorChar == '/')
                {
                    retorno = operadorChar.ToString();
                }
            }
            return retorno;
        }
    }
}
