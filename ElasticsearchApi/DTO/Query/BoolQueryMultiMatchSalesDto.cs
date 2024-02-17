namespace ElasticsearchApi.DTO.Query
{
    public class BoolQueryMultiMatchSalesDto
    {
        public int Must { get; set; }
        public string MustNot { get; set; }
        public string Should { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}