using N5Now.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Domain.Interfaces
{
    public interface IPermissionRepository
    {
        Task<Permission> AddPermissionAsync(Permission permission);
    }
}
