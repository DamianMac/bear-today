using System;
using System.Diagnostics;
using BearToday.TemplateProcessor;

namespace BearToday.Renderers
{
    public class BearRenderer
    {
        public void Render(ContentPublishingResult result)
        {
            
            var builder = new BearCallbackUrlBuilder();
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
        }
    }
}