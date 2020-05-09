using System;
using BearToday.Renderers;
using BearToday.TemplateProcessor;

namespace BearToday
{
    public class Program
    {
        static void Main(string[] args)
        {

            var templateName = args[0];
            
            var pipeline = new ContentPipeline();
            var result = pipeline.BuildContent(templateName);
            
            var renderer = new BearRenderer();
            renderer.Render(result);
            
            Console.WriteLine("Done");
        }
    }
}
