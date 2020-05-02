using System;
using System.Diagnostics;
using System.IO;

namespace BearToday
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new CallbackUrlBuilder();
            var todayUri = builder.BuildToday(DateTime.Now);
            var url = todayUri.AbsoluteUri;

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
