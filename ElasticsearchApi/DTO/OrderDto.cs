using System.ComponentModel.DataAnnotations;

namespace ElasticsearchApi.DTO;

public class OrderDto
{
    public int id { get; set; }
    
    public float sales { get; set; }
    
    public string product_id { get; set; }
    
    public string category { get; set; }
    
    public string order_id { get; set; }
    
    public string product_name { get; set; }
    
    public string city { get; set; }
    
    public string customer_id { get; set; }
    
    public string ship_mode { get; set; }
    
    public string country { get; set; }
    
    public string customer_name { get; set; }
    
   public DateOnly order_date { get; set; } 
}