using ElasticsearchApi.Models;
using ElasticsearchApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ESController : ControllerBase
{
    private readonly IElasticsearchService<Order> _elasticsearchService;
    
    public ESController(IElasticsearchService<Order> elasticsearchService)
    {
        _elasticsearchService = elasticsearchService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDocument()
    {
        var result = await _elasticsearchService.GetAllDocuments();
        return Ok(result);
    }
    
    [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            var result = await _elasticsearchService.CreateDocumentAsync(order);
            return Ok(result);
        }
        
        [HttpGet]
        [Route("read/{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _elasticsearchService.GetDocumentAsync(id);
            if (order is null)
                return NotFound();
            return Ok(order);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order)
        {
            var result = await _elasticsearchService.UpdateDocumentAsync(order);
            return Ok(result);
        }
        
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _elasticsearchService.DeleteDocumentAsync(id);
            return Ok(result);
        }
    
}