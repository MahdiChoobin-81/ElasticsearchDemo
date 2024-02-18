using ElasticsearchApi.DTO;
using ElasticsearchApi.DTO.Query;
using ElasticsearchApi.Models;
using Nest;

namespace ElasticsearchApi.Services.Query;

public class OrderQueryService : IElasticsearchQueryService<Order>
{
     private readonly ElasticClient _elasticClient;

     public OrderQueryService(ElasticClient elasticClient)
     {
         _elasticClient = elasticClient;
     }

     public async Task<IEnumerable<Order>> MatchQuery(string name)
     {
         var response = await _elasticClient.SearchAsync<Order>(s => s
             .Query(q => q
                 .Match(m => m
                     .Field(o => o.product_name)
                     .Query(name))));
         return response.Documents;
     }

     public async Task<IEnumerable<Order>> MultiMatchQuery(string query)
     {
         var response = await _elasticClient.SearchAsync<Order>(s => s
             .Query(q => q
                 .MultiMatch(m => m
                     .Fields(f => f
                         .Field(o => o.product_name)
                         .Field(o => o.customer_name))
                     .Query(query))));
         return response.Documents;
     }

      public async Task<IEnumerable<Order>> MultiMatchAndPhraseQuery(string query)
      {
          var response = await _elasticClient.SearchAsync<Order>(s => s
              .Query(q => q
                  .MultiMatch(m => m
                      .Fields(f => f
                          .Field(o => o.product_name)
                          .Field(o => o.customer_name))
                      .Type(TextQueryType.Phrase)
                      .Query(query))));
          return response.Documents;
      }

     public async Task<IEnumerable<Order>> BoolQueryMultiMatch(BoolQueryMultiMatchDto query)
     {
         var response = await _elasticClient.SearchAsync<Order>(s => s
             .Query(q => q
                 .Bool(b => b
                     .Must(m => m
                         .MultiMatch(m => m
                             .Fields(f => f
                                 .Field(o => o.product_name)
                                 .Field(o => o.customer_name))
                             .Query(query.Must)))
                     .MustNot(m => m
                         .MultiMatch((m => m
                             .Fields(f => f
                                 .Field(o => o.product_name)
                                 .Field(o => o.customer_name))
                             .Query(query.MustNot))))
                     .Should(s => s
                         .MultiMatch((m => m
                             .Fields(f => f
                                 .Field(o => o.product_name)
                                 .Field(o => o.customer_name))
                             .Query(query.Should))))
                     .Filter(f => f
                         .DateRange(s => s
                             .Field(o => o.order_date)
                             .GreaterThan(query.StartDate.ToString("dd/MM/yyyy"))
                             .LessThan(query.EndDate.ToString("dd/MM/yyyy"))))
                 )
             )
         );
         return response.Documents;
     }

     public async Task<IEnumerable<Order>> BoolQueryMultiMatchRange(BoolQueryMultiMatchSalesDto query)
     {
         var response = await _elasticClient.SearchAsync<Order>(s => s
             .Query(q => q
                 .Bool(b => b
                     .Must(m => m
                         .Range(r => r
                             .Field(f => f
                                 .sales)
                             .GreaterThanOrEquals(query.Must)))
                     .MustNot(m => m
                         .MultiMatch((m => m
                             .Fields(f => f
                                 .Field(o => o.product_name)
                                 .Field(o => o.customer_name))
                             .Query(query.MustNot))))
                     .Should(s => s
                         .MultiMatch((m => m
                             .Fields(f => f
                                 .Field(o => o.product_name)
                                 .Field(o => o.customer_name))
                             .Query(query.Should))))
                     .Filter(f => f
                         .DateRange(s => s
                             .Field(o => o.order_date)
                             .GreaterThan(query.StartDate.ToString("dd/MM/yyyy"))
                             .LessThan(query.EndDate.ToString("dd/MM/yyyy"))))
                 )
             )
         );
         return response.Documents;
     }
}