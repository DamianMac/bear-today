using System;
using System.IO;
using BearToday.TemplateProcessor;
using NSubstitute;
using Xunit;

namespace BearToday.Tests
{
    public class TemplateLoaderTests
    {
        public class WhenLoadingATemplateByName : SpecificationFor<TemplateLoader>
        {
            private IFileSystem _fileSystem;
            private FileNotFoundException _exception;
            private DirectoryInfo _path = new FileInfo(typeof(Program).Assembly.Location).Directory;

            public override TemplateLoader Given()
            {
                _fileSystem = Substitute.For<IFileSystem>();
                return new TemplateLoader(_fileSystem);
            }

            public override void When()
            {
                try
                {
                    Subject.Load("today");
                }
                catch (FileNotFoundException exception)
                {
                    _exception = exception;
                }
            }

            [Fact]
            public void ItLooksLocally()
            {
                var searchPath = Path.Combine(_path.FullName, "today.md");
                _fileSystem.Received().Exists(searchPath);
            }

            [Fact]
            public void ItLooksInATemplatesSubdirectory()
            {
                var searchPath = Path.Combine(_path.FullName, "templates", "today.md");
                _fileSystem.Received().Exists(searchPath);
                
            }

            [Fact]
            public void ItLooksInADotPath()
            {
                var homeFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var searchPath = Path.Combine(homeFolder, ".BearToday/today.md");
                _fileSystem.Received().Exists(searchPath);
            }

            [Fact]
            public void ItThrowsIfItCantFindIt()
            {
                Assert.IsType<FileNotFoundException>(_exception);
            }
        }
        
        public class WhenATemplateIsFound : SpecificationFor<TemplateLoader>
        {
            private DirectoryInfo _path = new FileInfo(typeof(Program).Assembly.Location).Directory;
            private string _content;

            public override TemplateLoader Given()
            {
                var fileSystem = Substitute.For<IFileSystem>();
                var searchPath = Path.Combine(_path.FullName, "today.md");
                fileSystem.Exists(searchPath).Returns(true);
                fileSystem.Read(searchPath).Returns("YAY");
                
                return new TemplateLoader(fileSystem);
            }

            public override void When()
            {
                _content = Subject.Load("today");
            }

            [Fact]
            public void ItReadsTheContent()
            {
                Assert.Equal("YAY", _content);
            }
        }
    }
}