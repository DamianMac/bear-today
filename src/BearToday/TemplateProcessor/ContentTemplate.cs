using System.Collections.Generic;

namespace BearToday.TemplateProcessor
{
    public class ContentTemplate
    {
        public string Title { get; set; }
        public string[] Tags { get; set; }
        public string Body { get; set; }
        public bool Pin { get; set; }
        public bool ShowTimestamp { get; set; }
    }
}