using System.IO;
using System.Linq;
using System.Reflection;

namespace BearToday
{
    public class MarkdownLoader
    {
        public string LoadTemplate(string templateName)
        {
            var filename = $"{templateName}.md";
            var assembly = typeof(MarkdownLoader).Assembly;
            var resource = assembly.GetManifestResourceNames()
                .First(r => r.Contains(filename));

            using var stream = assembly.GetManifestResourceStream(resource);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}