using ElasticsearchApi.Models;

namespace ElasticsearchApi.Services.Query;

public interface IElasticsearchQueryService<T>
{
    Task<IEnumerable<T>> MatchQuery(string query);
    Task<IEnumerable<T>> MultiMatchQuery(string query);
    Task<IEnumerable<T>> MultiMatchAndPhraseQuery(string query);
    Task<IEnumerable<T>> BoolQueryMultiMatch(
        string must,
        string mustNot,
        string should,
        DateTime filterStart,
        DateTime filterEnd);
    
    Task<IEnumerable<T>> BoolQueryMultiMatchAndQuantity(
        int must,
        string mustNot,
        string should,
        DateTime filterStart,
        DateTime filterEnd);
    
    
}