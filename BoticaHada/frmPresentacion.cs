using BoticaHada.Utilidades;
using CapaEntity;
using CapaNegocio;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoticaHada
{
    public partial class frmPresentacion : Form
    {
        public frmPresentacion()
        {
            InitializeComponent();
            // Ajuste automático de las columnas
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ajuste automático de las filas
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void frmPresentacion_Load(object sender, EventArgs e)
        {
            cboPresentacion.Items.Add(new OpcionCombo() { Valor = "UNIDAD", Texto = "Unidad" });
            cboPresentacion.Items.Add(new OpcionCombo() { Valor = "BLISTER", Texto = "Blister" });
            cboPresentacion.Items.Add(new OpcionCombo() { Valor = "CAJA", Texto = "Caja" });
            cboPresentacion.DisplayMember = "Texto";
            cboPresentacion.ValueMember = "Valor";
            cboPresentacion.SelectedIndex = 0;


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

            List<PresentacionProducto> listaPresentacionProducto = new CNPresentacionProducto().Listar();

            foreach (PresentacionProducto item in listaPresentacionProducto)
            {

                dgvData.Rows.Add(new object[]{"",
                    item.IdPresentacionProducto,
                    item.oProducto.IdProducto,
                    item.oProducto.Codigo,
                    item.oProducto.Nombre,
                    item.TipoPresentacion,
                    item.Cantidad,
                    item.Stock,
                    item.PrecioCompra,
                    item.PrecioVenta,
                });

            }
        }

        private void Limpiar()
        {
            lblDetallePresentacion.Text = "Detalle Presentacion";
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtIdProducto.Text = "0";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            cboPresentacion.SelectedIndex = 0;
            nudCantidad.Value = 0;
            nudStock.Value = 0;
            nudPrecioCompra.Value = 0;
            nudPrecioVenta.Value = 0;
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

                    lblDetallePresentacion.Text = "Editando...";
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();
                    txtIdProducto.Text = dgvData.Rows[indice].Cells["IdProducto"].Value.ToString();
                    txtCodigo.Text = dgvData.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtNombre.Text = dgvData.Rows[indice].Cells["Nombre"].Value.ToString();
                    nudCantidad.Value = Convert.ToInt32(dgvData.Rows[indice].Cells["Cantidad"].Value);
                    nudStock.Value = Convert.ToInt32(dgvData.Rows[indice].Cells["Stock"].Value);
                    nudPrecioCompra.Value = Convert.ToDecimal(dgvData.Rows[indice].Cells["PrecioCompra"].Value);
                    nudPrecioVenta.Value = Convert.ToDecimal(dgvData.Rows[indice].Cells["PrecioVenta"].Value);


                    foreach (OpcionCombo oc in cboPresentacion.Items)
                    {

                        if (oc.Valor.ToString() == dgvData.Rows[indice].Cells["TipoPresentacion"].Value.ToString())
                        {
                            int indice_combo = cboPresentacion.Items.IndexOf(oc);
                            cboPresentacion.SelectedIndex = indice_combo;
                            break;
                        }
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            string mensaje = string.Empty;
            PresentacionProducto oPresentacionProducto = new PresentacionProducto()
            {
                IdPresentacionProducto = Convert.ToInt32(txtId.Text),
                oProducto = new Producto()
                {
                    IdProducto = Convert.ToInt32(txtIdProducto.Text),
                },
                TipoPresentacion = ((OpcionCombo)cboPresentacion.SelectedItem).Valor.ToString(),
                Cantidad = Convert.ToInt32(nudCantidad.Value),
                Stock = Convert.ToInt32(nudStock.Value),
                PrecioCompra = Convert.ToDecimal(nudPrecioCompra.Value),
                PrecioVenta = Convert.ToDecimal(nudPrecioVenta.Value),

            };

            if (oPresentacionProducto.IdPresentacionProducto == 0)
            {
                int idPproductogenerado = new CNPresentacionProducto().Registar(oPresentacionProducto, out mensaje);

                if (idPproductogenerado != 0)
                {
                    dgvData.Rows.Add(new object[]{"",idPproductogenerado,txtIdProducto.Text, txtCodigo.Text,txtNombre.Text,
                        ((OpcionCombo)cboPresentacion.SelectedItem).Valor.ToString(),
                        nudCantidad.Text,nudStock.Text,nudPrecioCompra.Text,nudPrecioVenta.Text,
                    });
                    MessageBox.Show("Nueva Presentacion agregada correctamente", "Nueva Presentacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                bool resultado = new CNPresentacionProducto().Editar(oPresentacionProducto, out mensaje);

                if (resultado == true)
                {

                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["IdProducto"].Value = txtIdProducto.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Codigo"].Value = txtCodigo.Text;
                    row.Cells["Cantidad"].Value = nudCantidad.Text;
                    row.Cells["Stock"].Value = nudStock.Text;
                    row.Cells["PrecioCompra"].Value = nudPrecioCompra.Text;
                    row.Cells["PrecioVenta"].Value = nudPrecioVenta.Text;
                    row.Cells["TipoPresentacion"].Value = ((OpcionCombo)cboPresentacion.SelectedItem).Valor.ToString();


                    MessageBox.Show("Presentacion modificada correctamente", "Editar Presentacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea elminar la Presentacion?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    PresentacionProducto oPproducto = new PresentacionProducto()
                    {
                        IdPresentacionProducto = Convert.ToInt32(txtId.Text)
                    };
                    bool respuesta = new CNPresentacionProducto().Eliminar(oPproducto, out mensaje);

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

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Llamar al método de búsqueda del producto
                string codigo = txtCodigo.Text;
                if (!string.IsNullOrEmpty(codigo))
                {
                    Producto producto = new CNPresentacionProducto().BuscarProducto(codigo);
                    if (producto != null)
                    {
                        txtIdProducto.Text = producto.IdProducto.ToString();
                        txtNombre.Text = producto.Nombre;
                        nudCantidad.Select();
                        MessageBox.Show("Producto encontrando", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ese producto no esta registrado", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void btnDescargarExcel_Click(object sender, EventArgs e)
        {
            {
                if (dgvData.Rows.Count < 1)
                {
                    MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DataTable dt = new DataTable();
                    foreach (DataGridViewColumn columna in dgvData.Columns)
                    {
                        if (columna.HeaderText != "" && columna.Visible) dt.Columns.Add(columna.HeaderText, typeof(string));
                    }

                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        if (row.Visible) dt.Rows.Add(new object[]
                        {
                        row.Cells[3].Value.ToString(),
                        row.Cells[4].Value.ToString(),
                        row.Cells[5].Value.ToString(),
                        row.Cells[6].Value.ToString(),
                        row.Cells[7].Value.ToString(),
                        row.Cells[8].Value.ToString(),
                        row.Cells[9].Value.ToString(),
                        });
                    }

                    SaveFileDialog savefile = new SaveFileDialog();
                    savefile.FileName = string.Format("ReporteProductoStock_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                    savefile.Filter = "Excel Files | *.xlsx";

                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            XLWorkbook wb = new XLWorkbook();
                            var hoja = wb.Worksheets.Add(dt, "Informe");
                            hoja.ColumnsUsed().AdjustToContents();
                            wb.SaveAs(savefile.FileName);
                            MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            throw;
                        }
                    }
                }
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
