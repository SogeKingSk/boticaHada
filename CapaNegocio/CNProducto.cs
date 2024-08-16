using CapaDate;
using CapaEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNProducto
    {
        private CDProducto oCDProducto = new CDProducto();
        public List<Producto> Listar()
        {
            return oCDProducto.Listar();
        }
        public int Registar(Producto oProducto, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (oProducto.Codigo == "")
            {
                Mensaje += "Es necesario el Codigo del Producto\n";
            }
            if (oProducto.Nombre == "")
            {
                Mensaje += "Es necesario el Nombre del Producto\n";
            }
            if (oProducto.Lote == "")
            {
                Mensaje += "Es necesario el Lote del Producto\n";
            }
            if (oProducto.RegistroSanitario == "")
            {
                Mensaje += "Es necesario el Registro Sanitario del Producto\n";
            }
            if (oProducto.Descripcion == "")
            {
                Mensaje += "Es necesario la Descripcion del Producto\n";
            }
            if (oProducto.Ubicacion == "")
            {
                Mensaje += "Es necesario la Ubicacion del Producto\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return oCDProducto.Registrar(oProducto, out Mensaje);
            }
        }
        public bool Editar(Producto oProducto, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (oProducto.Codigo == "")
            {
                Mensaje += "Es necesario el Codigo del Producto\n";
            }
            if (oProducto.Nombre == "")
            {
                Mensaje += "Es necesario el Nombre del Producto\n";
            }
            if (oProducto.Lote == "")
            {
                Mensaje += "Es necesario el Lote del Producto\n";
            }
            if (oProducto.RegistroSanitario == "")
            {
                Mensaje += "Es necesario el Registro Sanitario del Producto\n";
            }
            if (oProducto.Descripcion == "")
            {
                Mensaje += "Es necesario la Descripcion del Producto\n";
            }
            if (oProducto.Ubicacion == "")
            {
                Mensaje += "Es necesario la Ubicacion del Producto\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return oCDProducto.Editar(oProducto, out Mensaje);
            }

        }
        public bool Eliminar(Producto oProducto, out string Mensaje)
        {
            return oCDProducto.Eliminar(oProducto, out Mensaje);
        }
    }
}

