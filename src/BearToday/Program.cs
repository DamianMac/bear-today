using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;

namespace BearToday
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new CallbackUrlBuilder();
            var uri = new Uri("http://localhost");
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
