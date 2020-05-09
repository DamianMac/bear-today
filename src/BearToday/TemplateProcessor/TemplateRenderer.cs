using System.Linq;
using DotLiquid;

namespace BearToday.TemplateProcessor
{
    public class TemplateRenderer
    {
        private readonly object _model;
        public TemplateRenderer()
        {
            _model = ModelBuilder.Build();
        }

        public TemplateRenderingResult Render(ContentTemplate contentTemplate)
        {
            var result = new TemplateRenderingResult();
            var rendered = new ContentTemplate();
            
            rendered.Title = Render(contentTemplate.Title);
            rendered.Body = Render(contentTemplate.Body);
            if (contentTemplate.Tags == null)
            {
                rendered.Tags = new string[] { };
            }
            else
            {
                rendered.Tags = contentTemplate.Tags.Select(Render).ToArray();
            }

            rendered.Pin = contentTemplate.Pin;
            rendered.ShowTimestamp = contentTemplate.ShowTimestamp;
            result.Rendered = rendered;
            result.IsValid = true;
            return result;
        }

        private string Render(string template)
        {
            return Template.Parse(template).Render(Hash.FromAnonymousObject(_model));
        }
    }
}