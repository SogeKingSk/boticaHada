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
    }
}
