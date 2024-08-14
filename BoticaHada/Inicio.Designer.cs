namespace BoticaHada
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.menuUsuario = new FontAwesome.Sharp.IconMenuItem();
            this.menuProducto = new FontAwesome.Sharp.IconMenuItem();
            this.menuVentas = new FontAwesome.Sharp.IconMenuItem();
            this.menuCompra = new FontAwesome.Sharp.IconMenuItem();
            this.menuClientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuProveedores = new FontAwesome.Sharp.IconMenuItem();
            this.menuReportes = new FontAwesome.Sharp.IconMenuItem();
            this.menuAcercade = new FontAwesome.Sharp.IconMenuItem();
            this.MenuTitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.submenuRegistarVentas = new FontAwesome.Sharp.IconMenuItem();
            this.submenuDetalleVentas = new FontAwesome.Sharp.IconMenuItem();
            this.submenuRegistrarCompras = new FontAwesome.Sharp.IconMenuItem();
            this.submenuDetalleCompras = new FontAwesome.Sharp.IconMenuItem();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuario,
            this.menuProducto,
            this.menuVentas,
            this.menuCompra,
            this.menuClientes,
            this.menuProveedores,
            this.menuReportes,
            this.menuAcercade});
            this.Menu.Location = new System.Drawing.Point(0, 69);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1184, 73);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // menuUsuario
            // 
            this.menuUsuario.AutoSize = false;
            this.menuUsuario.IconChar = FontAwesome.Sharp.IconChar.UsersGear;
            this.menuUsuario.IconColor = System.Drawing.Color.Black;
            this.menuUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuUsuario.IconSize = 50;
            this.menuUsuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuUsuario.Name = "menuUsuario";
            this.menuUsuario.Size = new System.Drawing.Size(122, 69);
            this.menuUsuario.Text = "Usuarios";
            this.menuUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuUsuario.Click += new System.EventHandler(this.menuusuario_Click);
            // 
            // menuProducto
            // 
            this.menuProducto.AutoSize = false;
            this.menuProducto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.menuProducto.IconChar = FontAwesome.Sharp.IconChar.Medrt;
            this.menuProducto.IconColor = System.Drawing.Color.Black;
            this.menuProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuProducto.IconSize = 50;
            this.menuProducto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProducto.Name = "menuProducto";
            this.menuProducto.Size = new System.Drawing.Size(122, 69);
            this.menuProducto.Text = "Producto";
            this.menuProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuProducto.Click += new System.EventHandler(this.menuProducto_Click);
            // 
            // menuVentas
            // 
            this.menuVentas.AutoSize = false;
            this.menuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuRegistarVentas,
            this.submenuDetalleVentas});
            this.menuVentas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuVentas.IconColor = System.Drawing.Color.Black;
            this.menuVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuVentas.IconSize = 50;
            this.menuVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuVentas.Name = "menuVentas";
            this.menuVentas.Size = new System.Drawing.Size(122, 69);
            this.menuVentas.Text = "Ventas";
            this.menuVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuCompra
            // 
            this.menuCompra.AutoSize = false;
            this.menuCompra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuRegistrarCompras,
            this.submenuDetalleCompras});
            this.menuCompra.IconChar = FontAwesome.Sharp.IconChar.DollyFlatbed;
            this.menuCompra.IconColor = System.Drawing.Color.Black;
            this.menuCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCompra.IconSize = 50;
            this.menuCompra.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCompra.Name = "menuCompra";
            this.menuCompra.Size = new System.Drawing.Size(122, 69);
            this.menuCompra.Text = "Compras";
            this.menuCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuClientes
            // 
            this.menuClientes.AutoSize = false;
            this.menuClientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.menuClientes.IconColor = System.Drawing.Color.Black;
            this.menuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuClientes.IconSize = 50;
            this.menuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(122, 69);
            this.menuClientes.Text = "Clientes";
            this.menuClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuClientes.Click += new System.EventHandler(this.menuClientes_Click);
            // 
            // menuProveedores
            // 
            this.menuProveedores.AutoSize = false;
            this.menuProveedores.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.menuProveedores.IconColor = System.Drawing.Color.Black;
            this.menuProveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuProveedores.IconSize = 50;
            this.menuProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProveedores.Name = "menuProveedores";
            this.menuProveedores.Size = new System.Drawing.Size(122, 69);
            this.menuProveedores.Text = "Proveedores";
            this.menuProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuProveedores.Click += new System.EventHandler(this.menuProveedores_Click);
            // 
            // menuReportes
            // 
            this.menuReportes.AutoSize = false;
            this.menuReportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.menuReportes.IconColor = System.Drawing.Color.Black;
            this.menuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuReportes.IconSize = 50;
            this.menuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(122, 69);
            this.menuReportes.Text = "Reportes";
            this.menuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuReportes.Click += new System.EventHandler(this.menuReportes_Click);
            // 
            // menuAcercade
            // 
            this.menuAcercade.AutoSize = false;
            this.menuAcercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuAcercade.IconColor = System.Drawing.Color.Black;
            this.menuAcercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuAcercade.IconSize = 50;
            this.menuAcercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuAcercade.Name = "menuAcercade";
            this.menuAcercade.Size = new System.Drawing.Size(122, 69);
            this.menuAcercade.Text = "Acerca de";
            this.menuAcercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // MenuTitulo
            // 
            this.MenuTitulo.AutoSize = false;
            this.MenuTitulo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MenuTitulo.Location = new System.Drawing.Point(0, 0);
            this.MenuTitulo.Name = "MenuTitulo";
            this.MenuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MenuTitulo.Size = new System.Drawing.Size(1184, 69);
            this.MenuTitulo.TabIndex = 1;
            this.MenuTitulo.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(44, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Botica Hada";
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 142);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1184, 519);
            this.contenedor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(1008, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUsuario.Location = new System.Drawing.Point(1077, 32);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(63, 15);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // submenuRegistarVentas
            // 
            this.submenuRegistarVentas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuRegistarVentas.IconColor = System.Drawing.Color.Black;
            this.submenuRegistarVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuRegistarVentas.Name = "submenuRegistarVentas";
            this.submenuRegistarVentas.Size = new System.Drawing.Size(180, 22);
            this.submenuRegistarVentas.Text = "Registar";
            this.submenuRegistarVentas.Click += new System.EventHandler(this.submenuRegistarVentas_Click);
            // 
            // submenuDetalleVentas
            // 
            this.submenuDetalleVentas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuDetalleVentas.IconColor = System.Drawing.Color.Black;
            this.submenuDetalleVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuDetalleVentas.Name = "submenuDetalleVentas";
            this.submenuDetalleVentas.Size = new System.Drawing.Size(180, 22);
            this.submenuDetalleVentas.Text = "Ver Detalle";
            this.submenuDetalleVentas.Click += new System.EventHandler(this.submenuDetalleVentas_Click);
            // 
            // submenuRegistrarCompras
            // 
            this.submenuRegistrarCompras.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuRegistrarCompras.IconColor = System.Drawing.Color.Black;
            this.submenuRegistrarCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuRegistrarCompras.Name = "submenuRegistrarCompras";
            this.submenuRegistrarCompras.Size = new System.Drawing.Size(180, 22);
            this.submenuRegistrarCompras.Text = "Registrar";
            this.submenuRegistrarCompras.Click += new System.EventHandler(this.submenuRegistrarCompras_Click);
            // 
            // submenuDetalleCompras
            // 
            this.submenuDetalleCompras.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuDetalleCompras.IconColor = System.Drawing.Color.Black;
            this.submenuDetalleCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuDetalleCompras.Name = "submenuDetalleCompras";
            this.submenuDetalleCompras.Size = new System.Drawing.Size(180, 22);
            this.submenuDetalleCompras.Text = "Ver Detalle";
            this.submenuDetalleCompras.Click += new System.EventHandler(this.submenuDetalleCompras_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.MenuTitulo);
            this.MainMenuStrip = this.Menu;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.MenuStrip MenuTitulo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menuUsuario;
        private FontAwesome.Sharp.IconMenuItem menuVentas;
        private FontAwesome.Sharp.IconMenuItem menuCompra;
        private FontAwesome.Sharp.IconMenuItem menuClientes;
        private FontAwesome.Sharp.IconMenuItem menuProveedores;
        private FontAwesome.Sharp.IconMenuItem menuReportes;
        private FontAwesome.Sharp.IconMenuItem menuAcercade;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuario;
        private FontAwesome.Sharp.IconMenuItem submenuRegistarVentas;
        private FontAwesome.Sharp.IconMenuItem submenuDetalleVentas;
        private FontAwesome.Sharp.IconMenuItem submenuRegistrarCompras;
        private FontAwesome.Sharp.IconMenuItem submenuDetalleCompras;
        private FontAwesome.Sharp.IconMenuItem menuProducto;
    }
}