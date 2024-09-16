using CapaDate;
using CapaEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNCompra
    {
        private CDCompra oCDCompra = new CDCompra();
        public int ObtenerCorrelativo()
        {
            return oCDCompra.ObtenerCorrelativo();
        }
        public bool Registar(Compra oCompra,DataTable DetalleCompra, out string Mensaje)
        {
                        
            return oCDCompra.Registrar(oCompra,DetalleCompra, out Mensaje);
            
        }
    }
}
