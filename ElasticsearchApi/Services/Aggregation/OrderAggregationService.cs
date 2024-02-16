// using ElasticsearchApi.DTO.Aggregation;
// using ElasticsearchApi.Models;
// using Nest;
//
// namespace ElasticsearchApi.Services.Aggregation;
//
// public class OrderAggregationService : IElasticsearchAggregationService
// {
//     private readonly ElasticClient _elasticClient;
//
//     public OrderAggregationService(ElasticClient elasticClient)
//     {
//         _elasticClient = elasticClient;
//     }
//
//     public async Task<IEnumerable<DateHistogramBucket>> SumQuantities(DateTime startDate, DateTime endDate)
//     {
//         var response = await _elasticClient.SearchAsync<Order>(s => s
//             .Aggregations(a => a
//                 .DateHistogram("monthly_revenue", dh => dh
//                     .Field(o => o.InvoiceDate)
//                     .CalendarInterval(DateInterval.Year)
//             .Aggregations(aa => aa
//                 .Sum("sumSomthing", su => su
//                     .Field(pp => pp.UnitPrice))))));
//         return response.Aggregations.DateHistogram("monthly_revenue").Buckets;
//            
//
//     }
// }