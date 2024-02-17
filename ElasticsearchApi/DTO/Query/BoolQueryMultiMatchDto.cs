namespace ElasticsearchApi.DTO
{
    public class BoolQueryMultiMatchDto
    {
        public string Must { get; set; }
        public string MustNot { get; set; }
        public string Should { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}