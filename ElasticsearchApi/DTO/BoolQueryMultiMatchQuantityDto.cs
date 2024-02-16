namespace ElasticsearchApi.DTO;

public class BoolQueryMultiMatchQuantityDto
{
    public int Must { get; set; }
    public string MustNot { get; set; }
    public string Should { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}