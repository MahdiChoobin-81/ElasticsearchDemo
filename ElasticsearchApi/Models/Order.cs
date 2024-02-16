using System.ComponentModel.DataAnnotations;
using System.Globalization;
using ElasticsearchApi.DTO;
using Nest;

namespace ElasticsearchApi.Models;
[ElasticsearchType(Name = "orders")]
public class Order
{
    [PropertyName("id")]
    public int id { get; set; }
    
    [PropertyName("sales")]
    public float sales { get; set; }
    
    [PropertyName("product_id")]
    public string product_id { get; set; }
    
    [PropertyName("category")]
    public string category { get; set; }
    
    [PropertyName("order_id")]
    public string order_id { get; set; }
    
    [PropertyName("product_name")]
    public string product_name { get; set; }
    
    [PropertyName("city")]
    public string city { get; set; }
    
    [PropertyName("customer_id")]
    public string customer_id { get; set; }
    
    [PropertyName("ship_mode")]
    public string ship_mode { get; set; }
    
    [PropertyName("country")]
    public string country { get; set; }
    
    [PropertyName("customer_name")]
    public string customer_name { get; set; }
    
    // [Date(Format = "dd/MM/yyyy"), PropertyName("Order Date")] => it does not work with my data.
    
    // [PropertyName("order_date")]
    // DateTime date = DateTime.Parse("09/25/2011", new CultureInfo("en-GB")); // returns 09/25/2011
    // string d2 = date.ToString("dd/MM/yyyy");
    public DateOnly RawOrderDate
    {
        set { order_date = value.ToString("dd/MM/yyyy"); }
    }
    // [Date(Format = "dd/MM/yyyy")]
    // [Date(Format = "M/d/yyyy")]
    // [PropertyName("order_date")]
    public string order_date { get; set; } 

    




}