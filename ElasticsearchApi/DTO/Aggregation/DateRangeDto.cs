using System.ComponentModel.DataAnnotations;

namespace ElasticsearchApi.DTO;

public class DateRangeDto
{
    public DateOnly StartedDate { get; set; }
    public DateOnly EndedDate { get; set; }
}