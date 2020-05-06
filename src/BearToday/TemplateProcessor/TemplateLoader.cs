using System;
using System.IO;
using System.Reflection;

namespace BearToday.TemplateProcessor
{
    public class TemplateLoader
    {
        private readonly IFileSystem _fileSystem;

        public TemplateLoader(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public string Load(string templateName)
        {
            //Assume a markdown filename
            var fileName = $"{templateName}.md";

            //Look in current directory, or a ~/.BearToday/
            var searchDirectories = new[]
            {
                // ReSharper disable once PossibleNullReferenceException
                new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName,
                Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName, "templates"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ".BearToday")
            };

            foreach (var directory in searchDirectories)
            {
                var pathToSearch = Path.Combine(directory, fileName);
                if (_fileSystem.Exists(pathToSearch))
                    return _fileSystem.Read(pathToSearch);
            }
            
            throw new FileNotFoundException($"Can't find {fileName} in any known directories");
        }
    }
}