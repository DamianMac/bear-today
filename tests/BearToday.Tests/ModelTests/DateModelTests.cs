using System;
using BearToday.TemplateProcessor.TemplateModels;
using Xunit;

namespace BearToday.Tests.ModelTests
{
    public class DateModelTests
    {
        public class WhenGeneratingADateModel : SpecificationFor<DateModel>
        {
            public override DateModel Given()
            {
                var date = new DateTime(2020, 5, 9, 15, 30, 0);
                return new DateModel(date);
            }

            public override void When()
            {
            }

            [Fact]
            public void ItSetsYear()
            {
                Assert.Equal(2020, Subject.Year);
            }

            [Fact]
            public void ItSetsMonth()
            {
                Assert.Equal(5, Subject.Month);
            }

            [Fact]
            public void ItSetsDay()
            {
                Assert.Equal(9, Subject.Day);
            }

            [Fact]
            public void ItSetsDayOfWeek()
            {
                Assert.Equal("Saturday", Subject.DayOfWeek);
            }

            [Fact]
            public void ItPadsMonth()
            {
                Assert.Equal("05", Subject.PaddedMonth);
            }

            [Fact]
            public void ItPadsDay()
            {
                Assert.Equal("09", Subject.PaddedDay);
            }

            [Fact]
            public void ItSetsMonthName()
            {
                Assert.Equal("May", Subject.MonthName);
            }
            
        }
    }
}