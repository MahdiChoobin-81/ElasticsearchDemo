// using ElasticsearchApi.Models;
// using Nest;
//
// namespace ElasticsearchApi.Services.Query;
//
// public class OrderQueryService : IElasticsearchQueryService<Order>
// {
//     private readonly ElasticClient _elasticClient;
//
//     public OrderQueryService(ElasticClient elasticClient)
//     {
//         _elasticClient = elasticClient;
//     }
//
//     public async Task<IEnumerable<Order>> MatchQuery(string name)
//     {
//         var response = await _elasticClient.SearchAsync<Order>(s => s
//             .Query(q => q
//                 .Match(m => m
//                     .Field(o => o.Name)
//                     .Query(name))));
//         return response.Documents;
//     }
//
//     public async Task<IEnumerable<Order>> MultiMatchQuery(string query)
//     {
//         var response = await _elasticClient.SearchAsync<Order>(s => s
//             .Query(q => q
//                 .MultiMatch(m => m
//                     .Fields(f => f
//                         .Field(o => o.Name)
//                         .Field(o => o.Description))
//                     .Query(query))));
//         return response.Documents;
//     }
//
     // public async Task<IEnumerable<Order>> MultiMatchAndPhraseQuery(string query)
     // {
     //     var response = await _elasticClient.SearchAsync<Order>(s => s
     //         .Query(q => q
     //             .MultiMatch(m => m
     //                 .Fields(f => f
     //                     .Field(o => o.Name)
     //                     .Field(o => o.Description))
     //                 .Type(TextQueryType.Phrase)
     //                 .Query(query))));
     //     return response.Documents;
     // }
//
//     public async Task<IEnumerable<Order>> BoolQueryMultiMatch(
//         string must,
//         string mustNot,
//         string should,
//         DateTime filterStart,
//         DateTime filterEnd)
//     {
//         var response = await _elasticClient.SearchAsync<Order>(s => s
//             .Query(q => q
//                 .Bool(b => b
//                     .Must(m => m
//                         .MultiMatch(m => m
//                             .Fields(f => f
//                                 .Field(o => o.Name)
//                                 .Field(o => o.Description))
//                             .Query(must)))
//                     .MustNot(m => m
//                         .MultiMatch((m => m
//                             .Fields(f => f
//                                 .Field(o => o.Name)
//                                 .Field(o => o.Description))
//                             .Query(mustNot))))
//                     .Should(s => s
//                         .MultiMatch((m => m
//                             .Fields(f => f
//                                 .Field(o => o.Name)
//                                 .Field(o => o.Description))
//                             .Query(should))))
//                     .Filter(f => f
//                         .DateRange(s => s
//                             .Field(o => o.InvoiceDate)
//                             .GreaterThan(filterStart)
//                             .LessThan(filterEnd)))
//                 )
//             )
//         );
//         return response.Documents;
//     }
//
//     public async Task<IEnumerable<Order>> BoolQueryMultiMatchAndQuantity(int must, string mustNot, string should, DateTime filterStart, DateTime filterEnd)
//     {
//         var response = await _elasticClient.SearchAsync<Order>(s => s
//             .Query(q => q
//                 .Bool(b => b
//                     .Must(m => m
//                         .Range(r => r
//                             .Field(f => f
//                                 .Quantity)
//                             .GreaterThanOrEquals(must)))
//                     .MustNot(m => m
//                         .MultiMatch((m => m
//                             .Fields(f => f
//                                 .Field(o => o.Name)
//                                 .Field(o => o.Description))
//                             .Query(mustNot))))
//                     .Should(s => s
//                         .MultiMatch((m => m
//                             .Fields(f => f
//                                 .Field(o => o.Name)
//                                 .Field(o => o.Description))
//                             .Query(should))))
//                     .Filter(f => f
//                         .DateRange(s => s
//                             .Field(o => o.InvoiceDate)
//                             .GreaterThan(filterStart)
//                             .LessThan(filterEnd)))
//                 )
//             )
//         );
//         return response.Documents;
//     }
// }