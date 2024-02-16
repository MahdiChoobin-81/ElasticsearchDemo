using ElasticsearchApi.Models;
using ElasticsearchApi.Services.Aggregation;
using ElasticsearchApi.Services.CRUD;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AggregationController : ControllerBase
{
    private readonly IElasticsearchAggregationService _elasticsearchAggregation;
    
    public AggregationController(IElasticsearchAggregationService elasticsearchAggregation)
    {
        _elasticsearchAggregation = elasticsearchAggregation;
    }
    
    [HttpGet]
    public async Task<IActionResult> SumQuantities()
    {
        var result = await _elasticsearchAggregation.SumQuantities(DateTime.Now, DateTime.Now);
        return Ok(result);
    }
    
}