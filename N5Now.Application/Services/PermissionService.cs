using N5Now.Application.Interfaces;
using N5Now.Domain.Entities;
using N5Now.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<Permission> RequestPermissionAsync(Permission permission)
        {
            return await _permissionRepository.AddPermissionAsync(permission);
        }
    }
}
