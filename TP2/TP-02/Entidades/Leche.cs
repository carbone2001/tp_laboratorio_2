using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }
        ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color) : this(marca, codigo, color, ETipo.Entera) { }

        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo) : base(codigo, marca, color)
        {
            this.tipo = tipo;
        }
        

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine((string)this);
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendFormat("TIPO : " + this.tipo);
            sb.AppendLine("\n");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
