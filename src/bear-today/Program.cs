using System;

namespace bear-today
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var cmd = "-g bear://x-callback-url/create?title=30%20April%202020%20-%20Thursday&tags=today%2F2020%2F04&show_window=no&timestamp=yes&text=Hi%20there%0A%0A%23%23%20Today%0A%0A%0A";
            System.Diagnostics.Process.Start("open", cmd);

            Console.WriteLine("Done");
        }
    }
}
