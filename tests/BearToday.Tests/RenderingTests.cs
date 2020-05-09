using BearToday.TemplateProcessor;
using Xunit;

namespace BearToday.Tests
{
    public class RenderingTests
    {
        public class WhenRenderingASimpleTemplate : SpecificationFor<TemplateRenderer>
        {
            private TemplateRenderingResult _result;

            public override TemplateRenderer Given()
            {
                return new TemplateRenderer();
            }

            public override void When()
            {
                var template = new ContentTemplate
                {
                    Title = "Hello World",
                    Body = "This is a body"
                };
                _result = Subject.Render(template);
            }

            [Fact]
            public void IsValid()
            {
                Assert.True(_result.IsValid);
            }

            [Fact]
            public void TitleGetsRendered()
            {
                Assert.Equal("Hello World", _result.Rendered.Title);
            }
            
            [Fact]
            public void BodyGetsRendered()
            {
                Assert.Equal("This is a body", _result.Rendered.Body);
            }

            [Fact]
            public void TagsAreAnEmptyArray()
            {
                Assert.Equal(new string[]{}, _result.Rendered.Tags);
            }
        }
        
        public class WhenRenderingTagsWithNoTemplate : SpecificationFor<TemplateRenderer>
        {
            private TemplateRenderingResult _result;

            public override TemplateRenderer Given()
            {
                return new TemplateRenderer();
            }

            public override void When()
            {
                _result = Subject.Render(new ContentTemplate
                {
                    Title = "Hello World",
                    Body = "This is a body",
                    Tags = new []{"one", "two"}
                });
            }

            [Fact]
            public void TagsGetPassedThrough()
            {
                Assert.Equal(new []{"one", "two"}, _result.Rendered.Tags);
            }
        }
    }
}