using CapaDate;
using CapaEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNProveedor
    {
        private CDProveedor oCDProveedor = new CDProveedor();
        public List<Proveedor> Listar()
        {
            return oCDProveedor.Listar();
        }
        public int Registar(Proveedor oProveedor, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (oProveedor.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Proveedor\n";
            }
            if (oProveedor.Ruc == "")
            {
                Mensaje += "Es necesario el Ruc del Proveedor\n";
            }
            if (oProveedor.RazonSocial == "")
            {
                Mensaje += "Es necesario la Razon Social del Proveedor\n";
            }
            if (oProveedor.Telefono == "")
            {
                Mensaje += "Es necesario el Telefono del Proveedor\n";
            }
            if (oProveedor.Correo == "")
            {
                Mensaje += "Es necesario el Correo del Proveedor\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return oCDProveedor.Registrar(oProveedor, out Mensaje);
            }
        }
        public bool Editar(Proveedor oProveedor, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (oProveedor.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Proveedor\n";
            }
            if (oProveedor.Ruc == "")
            {
                Mensaje += "Es necesario el Ruc del Proveedor\n";
            }
            if (oProveedor.RazonSocial == "")
            {
                Mensaje += "Es necesario la Razon Social del Proveedor\n";
            }
            if (oProveedor.Telefono == "")
            {
                Mensaje += "Es necesario el Telefono del Proveedor\n";
            }
            if (oProveedor.Correo == "")
            {
                Mensaje += "Es necesario el Correo del Proveedor\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return oCDProveedor.Editar(oProveedor, out Mensaje);
            }

        }
        public bool Eliminar(Proveedor oProveedor, out string Mensaje)
        {
            return oCDProveedor.Eliminar(oProveedor, out Mensaje);
        }
    }
}