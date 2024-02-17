using ElasticsearchApi.DTO;
using ElasticsearchApi.DTO.Aggregation;
using ElasticsearchApi.Models;
using ElasticsearchApi.Services.Aggregation;
using ElasticsearchApi.Services.CRUD;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]

public class AggregationController : ControllerBase
{
    private readonly IElasticsearchAggregationService _elasticsearchAggregation;
    
    public AggregationController(IElasticsearchAggregationService elasticsearchAggregation)
    {
        _elasticsearchAggregation = elasticsearchAggregation;
    }
    
    [HttpGet]
    public async Task<IActionResult> AnnualSales()
    {
        var result = await _elasticsearchAggregation.AnnualSales();
        return Ok(result);
    }

    // im using post method because i want to get dates(end and start) from body to specify
    // the parameters format; if i use get method(get parameters from uri [FromQuery] ) its
    // hard to understand DateOnly format (yyyy-MM-dd) for clients.
    [HttpPost]
    public async Task<IActionResult> CustomMonthlySalesRange([FromBody] DateRangeDto dateRanges)
    {
        var result = await _elasticsearchAggregation
            .CustomMonthlySalesRange(dateRanges);
        return Ok(result);
    }
    
    [HttpGet("{amount}")]
    public async Task<IActionResult> CustomSalesSegmentation(float amount)
    {
        var result = await _elasticsearchAggregation.CustomSalesSegmentation(amount);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> CustomSalesSegmentationRange([FromQuery] RangeDto ranges)
    {
        var result = await _elasticsearchAggregation
            .CustomSalesSegmentationRange(ranges);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> TermAggregation([FromQuery] string field)
    {
        var result = await _elasticsearchAggregation
            .TermAggregation(field);
        return Ok(result);
    }
    
    
    
    
}