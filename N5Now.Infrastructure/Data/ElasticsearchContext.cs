using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Infrastructure.Data
{
    public class ElasticsearchContext
    {
        private readonly ElasticClient _client;

        public ElasticsearchContext(string elasticsearchUrl)
        {
            var settings = new ConnectionSettings(new Uri(elasticsearchUrl))
                .DefaultIndex("permissions-index"); // Set the default index name

            _client = new ElasticClient(settings);
        }

        public async Task IndexPermissionAsync<T>(T permission) where T : class
        {
            var indexResponse = await _client.IndexDocumentAsync(permission);
            if (!indexResponse.IsValid)
            {
                // Handle indexing failure
                throw new Exception($"Failed to index permission: {indexResponse.DebugInformation}");
            }
        }
    }
}
