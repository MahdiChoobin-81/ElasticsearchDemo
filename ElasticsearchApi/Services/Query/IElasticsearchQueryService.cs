using ElasticsearchApi.DTO;
using ElasticsearchApi.DTO.Query;
using ElasticsearchApi.Models;

namespace ElasticsearchApi.Services.Query;

public interface IElasticsearchQueryService<T>
{
    Task<IEnumerable<T>> MatchQuery(string query);
    Task<IEnumerable<T>> MultiMatchQuery(string query);
    Task<IEnumerable<T>> MultiMatchAndPhraseQuery(string query);
    Task<IEnumerable<T>> BoolQueryMultiMatch(BoolQueryMultiMatchDto query);
    
    Task<IEnumerable<T>> BoolQueryMultiMatchAndSales(BoolQueryMultiMatchSalesDto query);
    
    
}