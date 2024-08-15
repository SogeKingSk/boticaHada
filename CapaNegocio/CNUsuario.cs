using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDate;
using CapaEntity;

namespace CapaNegocio
{
    public class CNUsuario
    {
        private CDUsuario oCDUsuario = new CDUsuario();
        public List<Usuario> Listar() 
        {
            return oCDUsuario.Listar();
        }
        public int Registar(Usuario oUsuario, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (oUsuario.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Usuario\n";
            }
            if (oUsuario.Nombre == "")
            {
                Mensaje += "Es necesario el Nombre del Usuario\n";
            }
            if (oUsuario.ApellidoPaterno == "")
            {
                Mensaje += "Es necesario el Apellido Paterno del Usuario\n";
            }
            if (oUsuario.ApellidoMaterno == "")
            {
                Mensaje += "Es necesario el Apellido Materno del Usuario\n";
            }
            if (oUsuario.Telefono == "")
            {
                Mensaje += "Es necesario el Telefono del Usuario\n";
            }
            if (oUsuario.Correo == "")
            {
                Mensaje += "Es necesario el Correo del Usuario\n";
            }
            if (oUsuario.Clave == "")
            {
                Mensaje += "Es necesario la Contraseña del Usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return oCDUsuario.Registrar(oUsuario, out Mensaje);
            }
        }
        public bool Editar(Usuario oUsuario, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (oUsuario.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Usuario\n";
            }
            if (oUsuario.Nombre == "")
            {
                Mensaje += "Es necesario el Nombre del Usuario\n";
            }
            if (oUsuario.ApellidoPaterno == "")
            {
                Mensaje += "Es necesario el Apellido Paterno del Usuario\n";
            }
            if (oUsuario.ApellidoMaterno == "")
            {
                Mensaje += "Es necesario el Apellido Materno del Usuario\n";
            }
            if (oUsuario.Telefono == "")
            {
                Mensaje += "Es necesario el Telefono del Usuario\n";
            }
            if (oUsuario.Correo == "")
            {
                Mensaje += "Es necesario el Correo del Usuario\n";
            }
            if (oUsuario.Clave == "")
            {
                Mensaje += "Es necesario la Contraseña del Usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return oCDUsuario.Editar(oUsuario, out Mensaje);
            }
            
        }
        public bool Eliminar(Usuario oUsuario, out string Mensaje)
        {
            return oCDUsuario.Eliminar(oUsuario, out Mensaje);
        }
    }
}
