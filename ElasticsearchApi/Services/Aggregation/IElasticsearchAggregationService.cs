using ElasticsearchApi.Models;
using Nest;

namespace ElasticsearchApi.Services.Aggregation;

public interface IElasticsearchAggregationService
{
    Task<IEnumerable<DateHistogramBucket>> SumQuantities(DateTime startDate, DateTime endDate);
}