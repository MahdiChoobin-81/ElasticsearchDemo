using System.Collections;
using ElasticsearchApi.DTO;
using ElasticsearchApi.DTO.Aggregation;
using ElasticsearchApi.Models;
using Nest;

namespace ElasticsearchApi.Services.Aggregation;

public class OrderAggregationService : IElasticsearchAggregationService
{
    private readonly ElasticClient _elasticClient;

    public OrderAggregationService(ElasticClient elasticClient)
    {
        _elasticClient = elasticClient;
    }

    // Combined Aggregation (DateHistogram(Bucket) and Sum(Metric))
    public async Task<IEnumerable> AnnualSales()
    {
        
        var annualSales = await _elasticClient.SearchAsync<Order>(s => s
            .Size(0)    
            .Aggregations(a => a
                .DateHistogram("annual_docs_agg", dh => dh
                    .Field(o => o.order_date)
                    .CalendarInterval(DateInterval.Year)
                    .Aggregations(sa => sa
                        .Sum("sales_agg", su => su
                            .Field(o => o.sales))))));

        var buckets = annualSales.Aggregations.DateHistogram("annual_docs_agg")?.Buckets;

        if (buckets != null)
        {
            var result = buckets.Select(bucket => new
            {
                year = bucket.Date.Year,
                sales = bucket.Sum("sales_agg")?.Value
            });
            return result;
        }
        return Enumerable.Empty<object>();
        
    }

    // i used both Query(DateRange) and Aggregation(DateHistogram and Sum) in
    // the below method (or search☺).
    public async Task<IEnumerable> CustomMonthlySalesRange(DateRangeDto dateRanges)
    {
        
        var monthlySales = await _elasticClient.SearchAsync<Order>(s => s
            .Size(0)
            .Query(q => q
                .DateRange(r => r
                    .Field(o => o.order_date)
                    .GreaterThanOrEquals(dateRanges.StartedDate.ToString("dd/MM/yyyy"))
                    .LessThanOrEquals(dateRanges.EndedDate.ToString("dd/MM/yyyy"))
                )
            )
            .Aggregations(a => a
                .DateHistogram("monthly_sales_agg", date => date
                    .Field(o => o.order_date)
                    .CalendarInterval(DateInterval.Month)
                    .Aggregations(aa => aa
                        .Sum("sales_agg", sm => sm
                            .Field(o => o.sales))
                    )
                )
            )
        );

        var buckets = monthlySales.Aggregations.DateHistogram("monthly_sales_agg").Buckets;

        var result = buckets.Select(bucket => new
        {
            month = DateOnly.FromDateTime(bucket.Date),
            sales = bucket.Sum("sales_agg").Value
        });

        return result;

    }

    // Histogram(Bucket) and Average(Metric) Aggregation 👇
    public async Task<IEnumerable> CustomSalesSegmentation(float amount)
    {
        var response = await _elasticClient.SearchAsync<Order>(s => s
            .Aggregations(a => a
                .Histogram("sales_segmentation_agg",h => h
                    .Field(o => o.sales)
                    .Interval(amount)
                    .Aggregations(subAgg => subAgg
                        .Average("average_sales_agg", avg => avg
                            .Field(ord => ord.sales))))));

        var buckets = response.Aggregations
            .Histogram("sales_segmentation_agg").Buckets;

        var result = buckets.Select(bucket => new
        {
            amount = bucket.Key,
            docs = bucket.DocCount,
            average = bucket.Average("average_sales_agg")?.Value
        });

        return result;

    }

    // Range Aggregation 👇
    public async Task<IEnumerable> CustomSalesSegmentationRange(RangeDto ranges)
    {
        var response = await _elasticClient.SearchAsync<Order>(s => s
            .Size(0)
            .Aggregations(a => a
                .Range("range_agg", r => r
                    .Field(o => o.sales)
                    .Ranges(
                        range => range.To(ranges.To),
                        range => range.From(ranges.Range.From).To(ranges.Range.To),
                        range => range.From(ranges.From)))));

        var buckets = response.Aggregations
            .Range("range_agg").Buckets;
        
        var result = buckets.Select(bucket => new
        {
            range = bucket.Key,
            docs = bucket.DocCount
        });

        return result;
    }
    // Term Aggregation 👇
    public async Task<IEnumerable> TermAggregation(string field)
    {
        var response = await _elasticClient.SearchAsync<Order>(s => s
            .Aggregations(a => a
                .Terms("term_agg", t => t
                    .Field(field)
                    .Order(o => o.CountDescending()))));
        var buckets = response.Aggregations.Terms("term_agg").Buckets;
        var result = buckets.Select(bucket => new
        {
            field = bucket.Key,
            docs = bucket.DocCount
        });

        return result;
    }
}