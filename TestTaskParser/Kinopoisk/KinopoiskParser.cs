using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;
using TestTaskParser.Interfaces;

namespace TestTaskParser.Kinopoisk
{
    public class KinopoiskParser : IParser<List<string>>
    {
        public List<string> Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("premier_item"));

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }

            return list;
        }
    }
}
