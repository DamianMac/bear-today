using System;
using BearToday.TemplateProcessor.TemplateModels;

namespace BearToday.TemplateProcessor
{
    public static class ModelBuilder
    {
        public static object Build()
        {
            return new {date = new DateModel(DateTime.Now)};
        }
    }
}