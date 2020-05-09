namespace BearToday.TemplateProcessor
{
    public class ContentPublishingResult
    {
        public bool IsHappy { get; set; }
        public ContentTemplate Rendered { get; set; }
        public string Error { get; set; }
    }
}