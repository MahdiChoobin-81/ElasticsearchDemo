using ElasticsearchApi.DTO;
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
    [Route("match/{name}")]
    public async Task<IEnumerable<Order>> Match(string name)
    {
        var result = await _elasticsearchQueryService.MatchQuery(name);
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

    [HttpGet]
    [Route("bool-query-multi-match")]
    public async Task<IEnumerable<Order>> BoolQueryMultiMatch([FromQuery] BoolQueryMultiMatchDto query)
    {
        var result = await _elasticsearchQueryService.BoolQueryMultiMatch(
            query.Must,
            query.MustNot,
            query.Should,
            query.StartDate,
            query.EndDate);
        return result;
    }
    
    [HttpGet]
    [Route("bool-query-multi-match-quantity")]
    public async Task<IEnumerable<Order>> BoolQueryMultiMatchQuantity([FromQuery] BoolQueryMultiMatchQuantityDto query)
    {
        var result = await _elasticsearchQueryService.BoolQueryMultiMatchAndQuantity(
            query.Must,
            query.MustNot,
            query.Should,
            query.StartDate,
            query.EndDate);
        return result;
    }
}