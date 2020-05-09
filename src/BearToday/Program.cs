using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using BearToday.TemplateProcessor;

namespace BearToday
{
    public class Program
    {
        static void Main(string[] args)
        {

            var templateName = args[0];
            var loader = new TemplateLoader(new FileSystem());
            var template = loader.Load(templateName);
            var parser = new TemplateParser();
            var parsed = parser.Parse(template);
            var renderer = new TemplateRenderer();
            var result = renderer.Render(parsed.ContentTemplate);
            
            
            var builder = new CallbackUrlBuilder();
            var uri = builder.BuildUrl(BearAction.Create, result.Rendered.Tags, true, true, result.Rendered.Title,
                result.Rendered.Body);
            
            var url = uri.AbsoluteUri;

            var bearArgs = $"-g \"{url}\"";

            var process = new Process
            {
                StartInfo =
                {
                    FileName = "open", 
                    Arguments = bearArgs, 
                    UseShellExecute = false, 
                    RedirectStandardOutput = true
                }
            };
            process.OutputDataReceived += (sender, eventArgs) =>
            {
                Console.WriteLine(eventArgs.Data);
            };
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
            
            Console.WriteLine("Done");
        }
    }
}
