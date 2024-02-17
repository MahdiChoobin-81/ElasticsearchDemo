using System.Collections;
using ElasticsearchApi.DTO;
using ElasticsearchApi.DTO.Aggregation;
using ElasticsearchApi.Models;
using Nest;

namespace ElasticsearchApi.Services.Aggregation;

public interface IElasticsearchAggregationService
{
    Task<IEnumerable> AnnualSales();
    Task<IEnumerable> CustomMonthlySalesRange(DateRangeDto dateRanges);

    Task<IEnumerable> CustomSalesSegmentation(float amount);

    Task<IEnumerable> CustomSalesSegmentationRange(RangeDto range);

    Task<IEnumerable> TermAggregation(string field);

}