using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TestTaskParser.Interfaces;

namespace TestTaskParser.Kinopoisk
{
    public class KinopoiskParser : IParser<List<Film>>
    {
        private static readonly Regex rgx = new Regex(@"\d+(\.\d{1,2})?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public List<Film> Parse(IHtmlDocument document)
        {
            var list = new List<Film>();
            var domParser = new HtmlParser();

            var items = document.QuerySelectorAll("div.premier_item");
            foreach (var item in items)
            {
                var fragment = domParser.ParseDocument(item.OuterHtml);

                var fr = fragment.QuerySelectorAll("meta");
                var date = fr[0]?.GetAttribute("Content");
                var image = fr[1]?.GetAttribute("Content");

                var nameSource = fragment.QuerySelectorAll("span.name_big >a");
                if (nameSource.Length <= 0)
                {
                    break;
                }
                var name = nameSource[0]?.TextContent;

                var descriptionSource = fragment.QuerySelectorAll("span.sinopsys");
                if (descriptionSource.Length <= 0)
                {
                    break;
                }
                var description = descriptionSource[0]?.TextContent;

                var ratingSource = fragment.QuerySelectorAll("span.ajax_rating");
                var rating = rgx.Match(ratingSource[0]?.TextContent).ToString();

                var directorSource = fragment.QuerySelectorAll("div.textBlock >span >i >a.lined");
                var director = directorSource[0]?.TextContent;

                var actorSource = fragment.QuerySelectorAll("div.textBlock >span >a.lined");
                var actor = new List<string>();
                foreach (var i in actorSource)
                {
                    actor.Add(i.TextContent);
                }

                list.Add(new Film()
                {
                    Actor = actor,
                    Description = description,
                    Director = director,
                    Image = image,
                    Name = name,
                    Rating = rating,
                    StartDate = date
                });
            }
            return list;
        }
    }
}
