using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntity;

namespace BoticaHada
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new CNUsuario().Listar();

            Usuario ousuario = new CNUsuario().Listar().Where(u=>u.Documento == txtDocumento.Text && u.Clave == txtPassword.Text).FirstOrDefault();

            if (ousuario != null)
            {

                Inicio form = new Inicio();
                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("Ese usuario no existe","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtDocumento.Text = "";
            txtPassword.Text = "";
            this.Show();
        }
    }
}
