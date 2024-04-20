using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Domain.Entities
{
    public class PermissionType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        // Navigation property
        public List<Permission> Permissions { get; set; }
    }
}
