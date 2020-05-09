using System;

namespace BearToday.TemplateProcessor
{
    public class ContentPipeline
    {
        private readonly TemplateLoader _loader;
        private readonly TemplateParser _parser;
        private readonly TemplateRenderer _renderer;

        public ContentPipeline()
        {
            _loader = new TemplateLoader(new FileSystem());
            _parser = new TemplateParser();
            _renderer = new TemplateRenderer();
        }

        public ContentPublishingResult BuildContent(string templateName)
        {
            var result = new ContentPublishingResult
            {
                IsHappy = true
            };
            
            string template;
            TemplateParsingResult parsingResult;
            TemplateRenderingResult renderingResult;
            
            try
            {
                template = _loader.Load(templateName);
            }
            catch (Exception e)
            {
                result.IsHappy = false;
                result.Error = e.Message;
                return result;
            }
            try
            {
                    parsingResult  = _parser.Parse(template);
                    if (parsingResult.IsValid == false)
                    {
                        result.IsHappy = false;
                        result.Error = "Error Parsing Template";
                    }
            }
            catch (Exception e)
            {
                result.IsHappy = false;
                result.Error = e.Message;
                return result;
            }

            try
            {
                renderingResult = _renderer.Render(parsingResult.ContentTemplate);
                result.Rendered = renderingResult.Rendered;
                if (renderingResult.IsValid == false)
                {
                    result.IsHappy = false;
                    result.Error = "Error Rendering Template";
                }
                
            }
            catch (Exception e)
            {
                result.IsHappy = false;
                result.Error = e.Message;
                return result;
            }

            return result;
        }
    }
}