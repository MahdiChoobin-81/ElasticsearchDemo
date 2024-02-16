using ElasticsearchApi.DTO;
using ElasticsearchApi.Models;
using Nest;

namespace ElasticsearchApi.Services.CRUD;

public interface IElasticsearchCrudService
{
    Task<string> CreateDocumentAsync(OrderDto document);

    Task<Order> GetDocumentByIdAsync(int id);

    Task<IEnumerable<Order>> GetAllDocuments();

    Task<string> UpdateDocumentAsync(OrderDto document);

    Task<string> DeleteDocumentAsync(int id);
}