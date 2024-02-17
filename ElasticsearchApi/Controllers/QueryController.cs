using ElasticsearchApi.DTO;
using ElasticsearchApi.DTO.Query;
using ElasticsearchApi.Models;
using ElasticsearchApi.Services;
using ElasticsearchApi.Services.CRUD;
using ElasticsearchApi.Services.Query;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace ElasticsearchApi.Controllers;

[Route("api/")]
[ApiController]

public class QueryController : ControllerBase
{
    private readonly IElasticsearchQueryService<Order> _elasticsearchQueryService;
    
    public QueryController(IElasticsearchQueryService<Order> elasticsearchQueryService)
    {
        _elasticsearchQueryService = elasticsearchQueryService;
    }

    [HttpGet]
    [Route("match/product-name/{query}")]
    public async Task<IEnumerable<Order>> Match(string query)
    {
        var result = await _elasticsearchQueryService.MatchQuery(query);
        return result;
    }

    [HttpGet]
    [Route("multi-match/{query}")]
    public async Task<IEnumerable<Order>> MultiMatch(string query)
    {
        var result = await _elasticsearchQueryService.MultiMatchQuery(query);
        return result;
    }
    [HttpGet]
    [Route("multi-phrase-match/{query}")]
    public async Task<IEnumerable<Order>> MultiAndPhraseMatch(string query)
    {
        var result = await _elasticsearchQueryService.MultiMatchAndPhraseQuery(query);
        return result;
    }
    
    [HttpPost]
    [Route("bool-query-multi-match")]
    public async Task<IEnumerable<Order>> BoolQueryMultiMatch([FromBody] BoolQueryMultiMatchDto query)
    {
        var result = await _elasticsearchQueryService.BoolQueryMultiMatch(query);
        return result;
    }
    
    [HttpPost]
    [Route("bool-query-multi-match-sales")]
    public async Task<IEnumerable<Order>> BoolQueryMultiMatchQuantity([FromBody] BoolQueryMultiMatchSalesDto query)
    {
        var result = await _elasticsearchQueryService.BoolQueryMultiMatchAndSales(query);
        return result;
    }
}