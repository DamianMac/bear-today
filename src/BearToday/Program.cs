using System;
using BearToday.Renderers;
using BearToday.TemplateProcessor;

namespace BearToday
{
    public class Program
    {
        static void Main(string[] args)
        {

            if (args == null || args.Length != 1)
            {
                ShowHelp();
                return;
            }
            
            var templateName = args[0];

            var pipeline = new ContentPipeline();
            var result = pipeline.BuildContent(templateName);
            if (result.IsHappy)
            {
                var renderer = new BearRenderer();
                renderer.Render(result);
            }
            else
            {
                Console.WriteLine($"Failed: {result.Error}");
                return;
            }

            Console.WriteLine("Success");
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Usage: ./BearToday templatename");
        }
    }
}
