using BoticaHada.Utilidades;
using CapaEntity;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace BoticaHada
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
            // Ajuste automático de las columnas
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ajuste automático de las filas
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;


            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cboBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;

            //Mostrar todos los usuarios
            List<Producto> listaProducto = new CNProducto().Listar();

            foreach (Producto item in listaProducto)
            {

                dgvData.Rows.Add(new object[]{"",
                    item.IdProducto,
                    item.Codigo,
                    item.Nombre,
                    item.Lote,
                    item.RegistroSanitario,
                    item.FechaVencimiento.ToString("dd/MM/yyyy"),
                    item.Descripcion,
                    item.Stock,
                    item.Ubicacion,
                    item.PrecioVenta,
                    item.PrecioCompra,
                    item.Estado == true ? "Activo":"No Activo",
                    item.Estado == true ? 1: 0,
                });

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int stock = 0;
            decimal precioVenta = 0.0m;
            if (!int.TryParse(txtStock.Text, out stock))
            {
                stock = 0; // Valor predeterminado si no se puede convertir
            }
            if (!decimal.TryParse(txtPrecioVenta.Text, out precioVenta))
            {
                precioVenta = 0.0m; // Valor predeterminado si no se puede convertir
            }
            string mensaje = string.Empty;
            Producto oProducto = new Producto()
            {
                IdProducto = Convert.ToInt32(txtId.Text),
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Lote = txtLote.Text,
                RegistroSanitario = txtRegistroSanitario.Text,
                FechaVencimiento = dtpFechaVencimiento.Value.Date,
                Descripcion = txtDescripcion.Text,
                Stock = stock,
                Ubicacion = txtUbicacion.Text,
                PrecioVenta = precioVenta,
                Estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false,

            };

            if (oProducto.IdProducto == 0)
            {

                int idusuariogenerado = new CNProducto().Registar(oProducto, out mensaje);

                if (idusuariogenerado != 0)
                {
                    dgvData.Rows.Add(new object[]{"",idusuariogenerado,
                        txtCodigo.Text,
                        txtNombre.Text,
                        txtLote.Text,
                        txtRegistroSanitario.Text,
                        dtpFechaVencimiento.Value.Date.ToString("dd/MM/yyyy"),
                        txtDescripcion.Text,
                        stock.ToString(),
                        txtUbicacion.Text,
                        precioVenta.ToString("F2"),
                        "0.00",
                        ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString(),
                        ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString(),
                        });
                    MessageBox.Show("Nuevo Producto agregado correctamente", "Nuevo Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                bool resultado = new CNProducto().Editar(oProducto, out mensaje);

                if (resultado == true)
                {

                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Codigo"].Value = txtCodigo.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Lote"].Value = txtLote.Text;
                    row.Cells["RegistroSanitario"].Value = txtRegistroSanitario.Text;
                    row.Cells["FechaVencimiento"].Value = dtpFechaVencimiento.Value.ToString("dd/MM/yyyy");
                    row.Cells["Descripcion"].Value = txtDescripcion.Text;
                    row.Cells["Stock"].Value = stock.ToString();
                    row.Cells["Ubicacion"].Value = txtUbicacion.Text;
                    row.Cells["PrecioVenta"].Value = precioVenta.ToString("F2");
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString();


                    MessageBox.Show("Producto modificado correctamente", "Editar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void Limpiar()
        {
            lblDetalleProducto.Text = "Detalle producto";
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtLote.Text = "";
            txtRegistroSanitario.Text = "";
            dtpFechaVencimiento.Value = DateTime.Today;
            txtDescripcion.Text = "";
            txtStock.Text = "0";
            txtUbicacion.Text = "";
            txtPrecioVenta.Text = "0.00";
            cboEstado.SelectedIndex = 0;
            txtCodigo.Select();

        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.pngwing_com.Width;
                var h = Properties.Resources.pngwing_com.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.pngwing_com, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {

                    lblDetalleProducto.Text = "Editando...";
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();
                    txtCodigo.Text = dgvData.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtNombre.Text = dgvData.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtLote.Text = dgvData.Rows[indice].Cells["Lote"].Value.ToString();
                    txtRegistroSanitario.Text = dgvData.Rows[indice].Cells["RegistroSanitario"].Value.ToString();
                    dtpFechaVencimiento.Text = dgvData.Rows[indice].Cells["FechaVencimiento"].Value.ToString();
                    txtDescripcion.Text = dgvData.Rows[indice].Cells["Descripcion"].Value.ToString();
                    txtStock.Text = dgvData.Rows[indice].Cells["Stock"].Value.ToString();
                    txtUbicacion.Text = dgvData.Rows[indice].Cells["Ubicacion"].Value.ToString();
                    txtPrecioVenta.Text = dgvData.Rows[indice].Cells["PrecioVenta"].Value.ToString();

                    

                    foreach (OpcionCombo oc in cboEstado.Items)
                    {

                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboEstado.Items.IndexOf(oc);
                            cboEstado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea elminar el Producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    Producto oProducto = new Producto()
                    {
                        IdProducto = Convert.ToInt32(txtId.Text)
                    };
                    bool respuesta = new CNProducto().Eliminar(oProducto, out mensaje);

                    if (respuesta)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))

                        row.Visible = true;

                    else row.Visible = false;

                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, punto decimal, y teclas de control
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick(); // Simula un clic en el botón btnBuscar
                e.SuppressKeyPress = true; // Evita el sonido de "ding" en la interfaz
            }
        }
    }
}
