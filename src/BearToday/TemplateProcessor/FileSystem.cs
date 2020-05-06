using System.IO;

namespace BearToday.TemplateProcessor
{
    public class FileSystem : IFileSystem
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}