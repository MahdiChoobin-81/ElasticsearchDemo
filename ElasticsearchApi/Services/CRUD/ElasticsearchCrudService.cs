using System.Globalization;
using ElasticsearchApi.DTO;
using ElasticsearchApi.Models;
using Nest;
using Object = System.Object;

namespace ElasticsearchApi.Services.CRUD;

public class ElasticsearchCrudService : IElasticsearchCrudService
{
    private readonly ElasticClient _elasticClient;

    public ElasticsearchCrudService(ElasticClient elasticClient)
    {
        _elasticClient = elasticClient;
    }
    public async Task<string> CreateDocumentAsync(OrderDto document)
    {
        
        var response = await _elasticClient.IndexDocumentAsync(document.ToOrder());
        
        return response.IsValid ? document.ToOrder().order_date.ToString() : "failed to create document";
        
    }

    public async Task<Order> GetDocumentByIdAsync(int id)
    {
        var response = await _elasticClient.GetAsync<Order>(id);
        
         return response.Source;
    }

    public async Task<IEnumerable<Order>> GetAllDocuments()
    {
        var searchResponse = await _elasticClient.SearchAsync<Order>(s => s
            .MatchAll());
        

        return searchResponse.Documents;
    }

    public async Task<string> UpdateDocumentAsync(OrderDto document)
    {
        var response = await _elasticClient.UpdateAsync<Order>(document.id,
            u => u.Doc(document.ToOrder()));
        
        return response.IsValid ? "updated" : response.DebugInformation;
    }

    public async Task<string> DeleteDocumentAsync(int id)
    {
        var response = await _elasticClient.DeleteAsync<Order>(id);
        return response.IsValid ? "deleted" : "failed to delete";
    }
}