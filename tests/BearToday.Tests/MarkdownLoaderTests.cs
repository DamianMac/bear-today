using System.Runtime.InteropServices;
using Xunit;

namespace BearToday.Tests
{
    public class MarkdownLoaderTests
    {
        public class WhenLoadingATemplate : SpecificationFor<MarkdownLoader>
        {
            private string _content;

            public override MarkdownLoader Given()
            {
                return new MarkdownLoader();
            }

            public override void When()
            {
                _content = Subject.LoadTemplate("today");
            }

            [Fact]
            public void ItReturnsTheContent()
            {
                Assert.Contains("## Today", _content);

            }
        }
    }
}