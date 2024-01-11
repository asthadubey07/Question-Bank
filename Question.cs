namespace QB.Model
{
    public class Question
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public List<Option>? Options { get; set; }
        public string? Topic { get; set; }
        public string? SubTopic { get; set; }
    }
}
