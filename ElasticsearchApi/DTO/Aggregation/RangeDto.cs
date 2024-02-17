namespace ElasticsearchApi.DTO.Aggregation;

public class RangeDto
{
    public float To { get; set; }
    public Range Range { get; set; }
    public float From { get; set; }
}

public class Range
{
    public float From { get; set; }
    public float To { get; set; }
}