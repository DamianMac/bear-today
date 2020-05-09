using BearToday.TemplateProcessor;
using Xunit;

namespace BearToday.Tests
{
    public class TemplateParserTests
    {
        public class WhenParsingATemplate : SpecificationFor<TemplateParser>
        {
            private TemplateParsingResult _result;
            public override TemplateParser Given()
            {
                return new TemplateParser();
            }

            public override void When()
            {
                var content = @"---
title: Today's To Do list
tags: [todo, today]
pin: true
showtimestamp: True
---
Things to do
";
                _result = Subject.Parse(content);
            }

            [Fact]
            public void IsValid()
            {
                Assert.True(_result.IsValid);
            }
            
            [Fact]
            public void ItParsesTheTitle()
            {
                Assert.Equal("Today's To Do list", _result.ContentTemplate.Title);
            }

            [Fact]
            public void ItParsesTags()
            {
                Assert.Equal(new []{"todo", "today"}, _result.ContentTemplate.Tags);
            }

            [Fact]
            public void ItParsesTheBody()
            {
                Assert.StartsWith("Things to do", _result.ContentTemplate.Body);
            }

            [Fact]
            public void ItParsesPin()
            {
                Assert.True(_result.ContentTemplate.Pin);
            }

            [Fact]
            public void ItParsesShowTimestamp()
            {
                Assert.True(_result.ContentTemplate.ShowTimestamp);
            }
        }
        
        public class WhenParsingTemplateWithNoTags : SpecificationFor<TemplateParser>
        {
            private TemplateParsingResult _result;
            public override TemplateParser Given()
            {
                return new TemplateParser();
            }

            public override void When()
            {
                var content = @"---
title: Today's To Do list
---
Things to do
";
                _result = Subject.Parse(content);
            }

            [Fact]
            public void IsValid()
            {
                Assert.True(_result.IsValid);
            }
            
            [Fact]
            public void ItParsesTheTitle()
            {
                Assert.Equal("Today's To Do list", _result.ContentTemplate.Title);
            }

            [Fact]
            public void TagsAreNull()
            {
                Assert.Null(_result.ContentTemplate.Tags);
            }
            
            
            [Fact]
            public void ItDefaultsPin()
            {
                Assert.False(_result.ContentTemplate.Pin);
            }

            [Fact]
            public void ItDefaultsShowTimestamp()
            {
                Assert.False(_result.ContentTemplate.ShowTimestamp);
            }
        }
    }
}