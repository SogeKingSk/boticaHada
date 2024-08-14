using CapaDate;
using CapaEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNPermiso
    {
        private CDPermiso oCDPermiso = new CDPermiso();
        public List<Permiso> Listar(int IdUsuario)
        {
            return oCDPermiso.Listar(IdUsuario);
        }
    }
}
