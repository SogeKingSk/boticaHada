using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntity;
using CapaNegocio;
using FontAwesome.Sharp;


namespace BoticaHada
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem menuActivo = null;
        private static Form formularioActivo = null;
        public Inicio(Usuario oUsuario =null)
        {
            if (oUsuario == null) usuarioActual = new Usuario() { Nombre = "HOLA", IdUsuario = 1 };
            else usuarioActual = oUsuario;

            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos = new CNPermiso().Listar(usuarioActual.IdUsuario);

            foreach (IconMenuItem iconmenu in Menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconmenu.Name);
                if (encontrado == false)
                {
                    iconmenu.Visible=false;
                }
            }

            lblUsuario.Text = usuarioActual.Nombre;
        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (menuActivo != null)
            {
                menuActivo.BackColor = Color.FromArgb(33, 15, 85);
                menuActivo.ForeColor = ColorTranslator.FromHtml("#7376BD");
            }

            menu.BackColor = ColorTranslator.FromHtml("#281269");
            menu.ForeColor  = menu.IconColor;
            
            menuActivo = menu;
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = ColorTranslator.FromHtml("#1C0E49");
            contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void menuusuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuarios());
        }

        private void menuProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProducto());
        }

        private void submenuRegistarVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)menuVentas, new frmVentas());
        }

        private void submenuRegistrarCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)menuCompra, new frmCompras());
        }

        

        private void menuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProveedores());
        }

        private void menuReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmReportes());
        }

        private void submenuDetalleVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)menuVentas, new frmDetalleVenta());
        }

        private void submenuDetalleCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)menuCompra, new frmDetalleCompra());
        }

        private void menuPresentacion_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)menuCompra, new frmPresentacion());
        }
    }
}
