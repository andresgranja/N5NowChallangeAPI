using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Domain.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public int NombreEmpleadoId { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int TipoPermisoId { get; set; }
        public DateTime FechaPermiso { get; set; }
        // Navigation property
        public PermissionType PermissionType { get; set; }
    }
}
