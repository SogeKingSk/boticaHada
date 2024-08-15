using CapaDate;
using CapaEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNRol
    {
        private CDRol oCDRol = new CDRol();
        public List<Rol> Listar()
        {
            return oCDRol.Listar();
        }
    }
}
