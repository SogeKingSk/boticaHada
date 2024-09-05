using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{
    public class PresentacionProducto
    {
        public int IdPresentacionProducto { get; set; }
        public Producto oProducto { get; set; }
        public string TipoPresentacion { get; set; }
        public int Cantidad { get; set; }
        public int Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }

    }
}
