using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        
        #region Methods
        /// <summary>
        /// Actualiza los datos de las listas Entrega, En Viaje e Ingresado.
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();
            foreach (Paquete p in correo.Paquetes)
            {
                switch (p.Estado)
                {
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(p);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(p);
                        break;
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(p);
                        break;
                }
            }
        }
        /// <summary>
        /// Al suceder este evento se agregara un paquete al correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(this.txtDireccion.Text,this.mtxtTrackingID.Text);
            p.InformarEstado += paq_InformaEstado;
            try
            {
                this.correo += p;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ActualizarEstados();
        }
        /// <summary>
        /// Mostrara los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        public FrmPpal()
        {
            InitializeComponent();
            this.FormClosing += FrmPpal_FormClosing;
            this.correo = new Correo();
        }
        /// <summary>
        /// Evento encargado de finalizar entregas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
        /// <summary>
        /// Muestra la informacion en rtbMostrar y la guarda un archivo llamado salida.txt en el escritorio.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T>elemento)
        {
            if (elemento != null)
            {
                string datosElemento = elemento.MostrarDatos(elemento);
                rtbMostrar.Text = datosElemento;
                datosElemento.Guardar("salida.txt");
            }
        }
        /// <summary>
        /// Al hacer click a un paquete en la lista Entregado mostrar la información del paquete en el cuadro de texto situado en la parte inferior izquierda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
        /// <summary>
        /// Evento que al suceder informara el estado de los paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (sender is Exception)
            {
                MessageBox.Show("Ha ocurrido un error al conectarse a la base de datos!","Error al conectarse con la base de datos",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {  this.ActualizarEstados(); } 
        }
        #endregion

        
    }
}
