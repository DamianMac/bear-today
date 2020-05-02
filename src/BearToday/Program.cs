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
            var uri = builder.BuildToday(DateTime.Now);
            var url = uri.AbsoluteUri;

            var cmd = $"-g \"{url}\"";
            
            var process = new Process();
            process.StartInfo.FileName = "open";
            process.StartInfo.Arguments = cmd;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
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
