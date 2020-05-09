using BearToday.TemplateProcessor;
using Xunit;

namespace BearToday.Tests
{
    public class TemplateParserTests
    {
        public class WhenParsingATemplateWithATitleAndTags : SpecificationFor<TemplateParser>
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
                Assert.Equal("Today's To Do list", _result.Template.Title);
            }

            [Fact]
            public void ItParsesTags()
            {
                Assert.Equal(new []{"todo", "today"}, _result.Template.Tags);
            }

            [Fact]
            public void ItParsesTheBody()
            {
                Assert.StartsWith("Things to do", _result.Template.Body);
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
                Assert.Equal("Today's To Do list", _result.Template.Title);
            }

            [Fact]
            public void TagsAreNull()
            {
                Assert.Null(_result.Template.Tags);
            }
        }
    }
}