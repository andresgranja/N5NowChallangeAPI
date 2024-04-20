using N5Now.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Application.Interfaces
{
    public interface IPermissionService
    {
        Task<Permission> RequestPermissionAsync(Permission permission);
    }
}
