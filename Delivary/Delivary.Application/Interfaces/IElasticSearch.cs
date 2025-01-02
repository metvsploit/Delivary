using Elastic.Clients.Elasticsearch;

namespace Delivary.Application.Interfaces
{
    public interface IElasticSearch
    {
        ElasticsearchClient Client { get; init; }
    }
}
