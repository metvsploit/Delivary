using Delivary.Application.Interfaces;
using Delivary.Domain.Consts;
using Delivary.Domain.Documents;
using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.Configuration;

namespace Delivary.Application.Services
{
    public class ElasticSearch : IElasticSearch
    {
        public ElasticsearchClient Client { get; init; }

        public ElasticSearch(IConfiguration configuration)
        {
            var settings = new ElasticsearchClientSettings(new Uri(configuration.GetConnectionString("Elastic")));
            settings.DefaultMappingFor<PizzaDocument>(x =>
            {
                x.IndexName("pizza_index");
            });

            Client = new ElasticsearchClient(settings);
        }
    }
}
