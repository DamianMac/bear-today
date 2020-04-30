using System;

namespace BearToday
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var builder = new CallbackUrlBuilder();
            var uri = builder.BuildToday(DateTime.Now);
            var url = uri.AbsoluteUri;

            var cmd = $"-g \"{url}\"";
            Console.WriteLine(cmd);
            System.Diagnostics.Process.Start("open", cmd);
            
            Console.WriteLine("Done");
        }
    }
}
