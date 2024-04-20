using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N5Now.Application.Interfaces;
using N5Now.Domain.Entities;

namespace N5Now.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpPost]
        public async Task<IActionResult> RequestPermission([FromBody] Permission permission)
        {
            var createdPermission = await _permissionService.RequestPermissionAsync(permission);
            return CreatedAtAction(nameof(RequestPermission), new { id = createdPermission.Id }, createdPermission);
        }
    }
}
