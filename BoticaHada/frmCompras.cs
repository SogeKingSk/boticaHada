using BoticaHada.Utilidades;
using CapaEntity;
using CapaNegocio;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoticaHada
{
    public partial class frmCompras : Form
    {
        private Usuario _Usuario;
        public frmCompras(Usuario oUsuario=null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
            // Ajuste automático de las columnas
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ajuste automático de las filas
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            dtpFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtIdProducto.Text = "0";
            txtIdProveedor.Text = "0";
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            
                // Llamar al método de búsqueda del producto
                string ruc = txtRuc.Text;
                if (!string.IsNullOrEmpty(ruc))
                {
                    Proveedor proveedor = new CNProveedor().BuscarProveedor(ruc);
                    if (proveedor != null)
                    {
                        txtRuc.BackColor = System.Drawing.Color.Honeydew;
                        txtIdProveedor.Text = proveedor.IdProveedor.ToString();
                        txtRazonSocial.Text = proveedor.RazonSocial;
                        txtCodigoProducto.Select();
                    }
                    else
                    {

                        txtRuc.BackColor = System.Drawing.Color.MistyRose;
                        txtIdProveedor.Text = "0";
                        txtRuc.Text = "";
                        txtRazonSocial.Text = "";
                        txtRuc.Select();

                }
                }
            
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            // Llamar al método de búsqueda del producto
            string codigo = txtCodigoProducto.Text;
            if (!string.IsNullOrEmpty(codigo))
            {
                PresentacionProducto presentacionproducto = new CNPresentacionProducto().BuscarProductoQR(codigo);
                if (presentacionproducto != null)
                {
                    txtCodigoProducto.BackColor = System.Drawing.Color.Honeydew;
                    txtIdProducto.Text = presentacionproducto.oProducto.IdProducto.ToString();
                    txtProducto.Text = presentacionproducto.oProducto.Nombre;
                    nudCantidad.Select();

                }
                else
                {
                    txtCodigoProducto.BackColor = System.Drawing.Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtProducto.Text = "";
                    txtCodigoProducto.Text = "";
                    txtCodigoProducto.Select();

                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal preciocompra = 0;
            decimal precioventa = 0;
            bool producto_existe = false;
            if (int.Parse(txtIdProducto.Text)==0)
            {
                MessageBox.Show("Debe ingresar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataGridViewRow fila in dgvData.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString()==txtIdProducto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }
            if (!producto_existe)
            {
                dgvData.Rows.Add(new object[]
                {
                    txtIdProducto.Text,
                    txtProducto.Text,
                    nudPrecioCompra.Value.ToString("0.00"),
                    nudPrecioVenta.Value.ToString("0.00"),
                    nudCantidad.Value.ToString(),
                    (nudCantidad.Value*nudPrecioCompra.Value).ToString("0.00")
                });
                calcularTotal();
                limpiarProducto();
                txtCodigoProducto.Select();
            }


        }

        private void limpiarProducto()
        {
            txtIdProducto.Text = "0";
            txtCodigoProducto.Text = "";
            txtCodigoProducto.BackColor = System.Drawing.Color.White;
            txtProducto.Text = "";
            nudPrecioCompra.Value= 0;
            nudPrecioVenta.Value= 0;
            nudCantidad.Value= 1;
        }

        private void calcularTotal()
        {
            decimal total = 0;
            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
                }
            }
            txtTotal.Text = total.ToString("0.00");
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscarProducto.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.icons8_delete_30.Width;
                var h = Properties.Resources.icons8_delete_30.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.icons8_delete_30, new Rectangle(x, y, w, h));
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
                    dgvData.Rows.RemoveAt(indice);
                    calcularTotal();
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtIdProveedor.Text)==0)
            {
                MessageBox.Show("Debe seleccionar un proveedor","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvData.Rows.Count<1)
            {
                MessageBox.Show("Debe ingresar productos en la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalle_compra = new DataTable();
            detalle_compra.Columns.Add("IdProducto", typeof(int));
            detalle_compra.Columns.Add("PrecioCompra", typeof(decimal));
            detalle_compra.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_compra.Columns.Add("Cantidad", typeof(int));
            detalle_compra.Columns.Add("MontoTotal", typeof(decimal));

            foreach (DataGridViewRow row in dgvData.Rows) 
            { 
                detalle_compra.Rows.Add(
                    new object[]
                    {
                        Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                        row.Cells["PrecioCompra"].Value.ToString(),
                        row.Cells["PrecioVenta"].Value.ToString(),
                        row.Cells["Cantidad"].Value.ToString(),
                        row.Cells["SubTotal"].Value.ToString(),

                    }
                    );
            }

            Compra oCompra = new Compra()
            {
                oUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(txtIdProveedor.Text) },
                MontoTotal =Convert.ToDecimal(txtTotal.Text),

                
            };

            string mensaje = string.Empty;
            bool respuesta = new CNCompra().Registar(oCompra, detalle_compra, out mensaje);

            if (respuesta) {
                var result = MessageBox.Show("Numero de compra generada:","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);

                txtIdProveedor.Text = "0";
                txtRuc.Text = "";
                txtRazonSocial.Text = "";
                dgvData.Rows.Clear();
                calcularTotal();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void txtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscarProveedor.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
