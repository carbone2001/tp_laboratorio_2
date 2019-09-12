using Entidades;
using System;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            lblResultado.ResetText();
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.ResetText();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnToBinary_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero(lblResultado.Text);
            lblResultado.Text = numero.DecimalBinario(lblResultado.Text);
        }

        private void BtnToDecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero(lblResultado.Text);
            lblResultado.Text = numero.BinarioDecimal(lblResultado.Text);
        }

        private static double Operar(string numero1,string numero2,string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            return Calculadora.Operar(n1, n2, operador);
        }
    }
}
