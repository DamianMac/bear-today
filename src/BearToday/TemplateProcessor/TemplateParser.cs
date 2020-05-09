using System.IO;
using System.Reflection;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace BearToday.TemplateProcessor
{
    public class TemplateParser
    {
        public TemplateParsingResult Parse(string content)
        {
            var result = new TemplateParsingResult();

            using var input = new StringReader(content);

            var template = ReadFrontMatter(input);

            //Hack! The Yaml parser puts it one position ahead of the beginning of the content.
            //Wind it back
            ResetReaderPosition(input);
            template.Body = input.ReadToEnd();
            
            result.ContentTemplate = template;
            result.IsValid = true;

            return result;

        }

        private static ContentTemplate ReadFrontMatter(StringReader input)
        {
            var parser = new Parser(input);
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            parser.Consume<StreamStart>();
            parser.Consume<DocumentStart>();
            var template = deserializer.Deserialize<ContentTemplate>(parser);
            parser.Consume<DocumentEnd>();
            return template;
        }

        private static void ResetReaderPosition(StringReader reader)
        {
            var positionFieldInfo = reader.GetType()
                .GetField("_pos", BindingFlags.NonPublic | BindingFlags.Instance);
            
            // ReSharper disable once PossibleNullReferenceException
            var position = (int)positionFieldInfo.GetValue(reader);
            positionFieldInfo.SetValue(reader, position-1);
        }

    }

}