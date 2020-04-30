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
            private Uri _todayUrl;
            private DateTime _today;

            public override CallbackUrlBuilder Given()
            {
                return new CallbackUrlBuilder();
            }

            public override void When()
            {
                _today = new DateTime(2020, 5, 1, 8, 0, 0);
                _todayUrl = Subject.BuildToday(_today);
            }

            [Fact]
            public void ItShouldCallCreate()
            {
                var url = _todayUrl.ToString();
                Assert.Contains("/create", url);

            }

            [Fact]
            public void ItShouldCallBear()
            {
                Assert.Equal("bear", _todayUrl.Scheme);
            }

            [Fact]
            public void ItShouldBeAnXCallbackUrl()
            {
                Assert.Equal("x-callback-url", _todayUrl.Host);
            }

            [Fact]
            public void ItShouldFormatTitle()
            {
                var expectedTitle = "1%20May%202020%20-%20Friday";
                Assert.Contains(expectedTitle, _todayUrl.Query);
            }

            [Fact]
            public void ItShouldFormatTags()
            {
                var expectedTags = "tags=today%2F2020%2F05";
                Assert.Contains(expectedTags, _todayUrl.Query);
            }

            [Fact]
            public void SetsShowWindow()
            {
                Assert.Contains("show_window=no", _todayUrl.Query);
            }
            
            [Fact]
            public void SetsPinNote()
            {
                Assert.Contains("pin=yes", _todayUrl.Query);
            }
            
            [Fact]
            public void SetsTimestamp()
            {
                Assert.Contains("timestamp=yes", _todayUrl.Query);
            }

            [Fact]
            public void SetsText()
            {
                Assert.Contains("Today", _todayUrl.Query);
            }
            
            
        }
    }
}