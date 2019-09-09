using Entidades;
using System;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);
            lblResultado.Text = (Calculadora.Operar(numero1, numero2, cmbOperador.Text)).ToString();
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
    }
}
