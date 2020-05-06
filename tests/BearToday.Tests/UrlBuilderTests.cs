using System;
using System.Text.Encodings.Web;
using System.Web;
using Xunit;

namespace BearToday.Tests
{
    public class UrlBuilderTests
    {
        public class WhenBuildingTodayUrl : SpecificationFor<CallbackUrlBuilder>
        {
            private Uri _url;

            public override CallbackUrlBuilder Given()
            {
                return new CallbackUrlBuilder();
            }

            public override void When()
            {
                var body = @"## Journal


## Today

";
                _url = Subject.BuildUrl(BearAction.Create, new []{"foo", "bar"}, true, true, "Test One", body);
            }

            [Fact]
            public void ItShouldCallCreate()
            {
                var url = _url.ToString();
                Assert.Contains("/create", url);

            }

            [Fact]
            public void ItShouldCallBear()
            {
                Assert.Equal("bear", _url.Scheme);
            }

            [Fact]
            public void ItShouldBeAnXCallbackUrl()
            {
                Assert.Equal("x-callback-url", _url.Host);
            }

            [Fact]
            public void ItShouldFormatTitle()
            {
                var expectedTitle = "Test%20One";
                Assert.Contains(expectedTitle, _url.Query);
            }

            [Fact]
            public void ItShouldFormatTags()
            {
                var expectedTags = "foo%2Cbar";
                Assert.Contains(expectedTags, _url.Query);
            }

            [Fact]
            public void SetsShowWindow()
            {
                Assert.Contains("show_window=no", _url.Query);
            }
            
            [Fact]
            public void SetsPinNote()
            {
                Assert.Contains("pin=yes", _url.Query);
            }
            
            [Fact]
            public void SetsTimestamp()
            {
                Assert.Contains("timestamp=yes", _url.Query);
            }

            [Fact]
            public void SetsText()
            {
                Assert.Contains("Today", _url.Query);
            }
            
            
        }
    }
}