using ElasticsearchApi.DTO;
using ElasticsearchApi.Models;

namespace ElasticsearchApi;

public static class ExtensionMethods
{
    public static Order ToOrder(this OrderDto orderDto)
    {
        Order order = new()
        {
            id = orderDto.id,
            order_id = orderDto.order_id,
            customer_id = orderDto.customer_id,
            product_id = orderDto.product_id,
            category = orderDto.category,
            city = orderDto.city,
            country = orderDto.country,
            product_name = orderDto.product_name,
            sales = orderDto.sales,
            ship_mode = orderDto.ship_mode,
            // order_date = orderDto.order_date,
            RawOrderDate = orderDto.order_date,
            customer_name = orderDto.customer_name
        };

        return order;

    }
}