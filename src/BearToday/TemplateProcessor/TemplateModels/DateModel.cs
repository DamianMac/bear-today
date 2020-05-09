using System;
using DotLiquid;

namespace BearToday.TemplateProcessor.TemplateModels
{
    [LiquidType("*")]
    public class DateModel
    {
        public DateModel(DateTime now)
        {
            Now = now;

            DayOfWeek = Now.DayOfWeek.ToString();
            Day = Now.Day;
            Month = Now.Month;
            Year = Now.Year;
            PaddedDay = Pad(Now.Day);
            PaddedMonth = Pad(Now.Month);
            MonthName = Now.ToString("MMMM");
        }

        public DateTime Now { get; set; }
        public string DayOfWeek { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public string MonthName { get; set; }

        public string PaddedDay { get; set; }
        public string PaddedMonth { get; set; }


        private string Pad(int number)
        {
            return number.ToString().PadLeft(2, '0');
        }
        
        
    }
}