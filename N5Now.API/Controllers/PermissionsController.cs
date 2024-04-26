using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N5Now.Application.Interfaces;
using N5Now.Application.Services;
using N5Now.Domain.Entities;
using N5Now.Infrastructure.Data;
using N5Now.Infrastructure.Messaging;

namespace N5Now.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly KafkaProducer _kafkaProducer;
        private readonly ElasticsearchContext _elasticsearchContext;

        public PermissionsController(IPermissionService permissionService, KafkaProducer kafkaProducer, ElasticsearchContext elasticsearchContext)
        {
            _permissionService = permissionService;
            _kafkaProducer = kafkaProducer;
            _elasticsearchContext = elasticsearchContext;
        }

        private async Task PersistPermissionInElasticsearch<T>(T permission) where T : class
        {
            // Index permission in Elasticsearch
            await _elasticsearchContext.IndexPermissionAsync(permission);
        }

        [HttpPost("request")]
        public async Task<IActionResult> RequestPermission()
        {
            // Perform logic to request permission
            var permissionRequest = new { Id = Guid.NewGuid(), Operation = "request" };

            // Persist in Elasticsearch
            await PersistPermissionInElasticsearch(permissionRequest);

            // Produce message to Kafka
            await _kafkaProducer.ProduceMessageAsync("permission-topic", permissionRequest);

            return Ok("Permission requested successfully");
        }

        [HttpPost("modify")]
        public async Task<IActionResult> ModifyPermission()
        {
            // Perform logic to modify permission
            var permissionModification = new { Id = Guid.NewGuid(), Operation = "modify" };

            // Persist in Elasticsearch
            await PersistPermissionInElasticsearch(permissionModification);

            // Produce message to Kafka
            await _kafkaProducer.ProduceMessageAsync("permission-topic", permissionModification);

            return Ok("Permission modified successfully");
        }

        [HttpPost]
        public async Task<IActionResult> RequestPermission([FromBody] Permission permission)
        {
            var createdPermission = await _permissionService.RequestPermissionAsync(permission);
            return CreatedAtAction(nameof(RequestPermission), new { id = createdPermission.Id }, createdPermission);
        }
    }
}
