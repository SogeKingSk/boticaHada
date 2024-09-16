using CapaDate;
using CapaEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNPresentacionProducto
    {
        private CDPresentacionProducto oCDPresentacionProducto = new CDPresentacionProducto();
        public List<PresentacionProducto> Listar()
        {
            return oCDPresentacionProducto.Listar();
        }
        public int Registar(PresentacionProducto oPresentacionProducto, out string Mensaje)
        {
            Mensaje = string.Empty;
            
            
            return oCDPresentacionProducto.Registrar(oPresentacionProducto, out Mensaje);
            
        }
        public bool Editar(PresentacionProducto oPresentacionProducto, out string Mensaje)
        {
            Mensaje = string.Empty;

            
            return oCDPresentacionProducto.Editar(oPresentacionProducto, out Mensaje);
            

        }
        public bool Eliminar(PresentacionProducto oPresentacionProducto, out string Mensaje)
        {
            return oCDPresentacionProducto.Eliminar(oPresentacionProducto, out Mensaje);
        }

        public Producto BuscarProducto(string codigo)
        {
            return oCDPresentacionProducto.BuscarProductoPorCodigo(codigo);
        }

        public PresentacionProducto BuscarProductoQR(string codigo)
        {
            return oCDPresentacionProducto.BuscarProductoPorCodigoQR(codigo);
        }
    }
}
