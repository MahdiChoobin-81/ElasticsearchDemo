using ElasticsearchApi.DTO;
using ElasticsearchApi.Models;
using ElasticsearchApi.Services;
using ElasticsearchApi.Services.CRUD;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CrudController : ControllerBase
{
    private readonly IElasticsearchCrudService _elasticsearchCrudService;
    
    public CrudController(IElasticsearchCrudService elasticsearchCrudService)
    {
        _elasticsearchCrudService = elasticsearchCrudService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDocument()
    {
        var result = await _elasticsearchCrudService.GetAllDocuments();
        return Ok(result);
    }
    
    [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto order)
        {
            var result = await _elasticsearchCrudService.CreateDocumentAsync(order);
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _elasticsearchCrudService.GetDocumentByIdAsync(id);
            if (order is null)
                return NotFound();
            return Ok(order);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderDto order)
        {
            var result = await _elasticsearchCrudService.UpdateDocumentAsync(order);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _elasticsearchCrudService.DeleteDocumentAsync(id);
            return Ok(result);
        }
    
}