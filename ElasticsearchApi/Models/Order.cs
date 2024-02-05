namespace ElasticsearchApi.Models;

public class Order
{
    public int Id { get; set; } = new Random().Next();
    public string Name { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public string Country { get; set; }
    public int UnitPrice { get; set; }
    public int CustomerId { get; set; }
    public int Quantity { get; set; }
    public DateTime InvoiceDate { get; set; }
}